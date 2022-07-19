using System;
using System.Collections.Generic;
//using RJCP.IO.Ports;
using System.Threading;
using ESRM.Entities;
using System.IO.Ports;
using ESRM.SerialPortLib;
using ESRM.HWInterfaces.Scalextric;
using System.ComponentModel;
using System.Collections;

namespace ESRM.HWInterfaces
{
    public class PitPro : IDisposable
    {
        public string Port { get { return _ssparams.ComPort; } }

        PitSensorsParams _ssparams;

        public event TeamIdEventHandler CarEnterInPitLane;
        //public event TeamIdEventHandler CarExitPitLane;

        public PitPro(PitSensorsParams ssparams)
          : base()
        {
            _ssparams = ssparams;
            _ssparams.SensorsCount = 1;
        }

        ~PitPro()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        protected void Dispose(bool disposing)
        {
            if (_serialPort != null)
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();
                _serialPort.Dispose();
                _serialPort = null;
            }
            disposed = true;
        }

        #region CONNEXION PORT SERIE

        // serial port pour la réception des infos de la PB C7042
        Port _serialPort;

        public List<string> GetComPorts()
        {
            List<string> result = new List<string>();

            for (int i = 1; i < 10; i++)
            {
                try
                {
                    string port = "COM" + i;

                    using (SerialPort serialPort = new SerialPort(port, 38400, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One))
                    {
                        serialPort.DataBits = 8;
                        serialPort.Handshake = System.IO.Ports.Handshake.None;
                        serialPort.Open();
                        if (serialPort.IsOpen)
                        {
                            serialPort.Close();
                            result.Add(port);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            if (result.Count == 1)
                _ssparams.ComPort = result[0]; 
            return result;
        }

        public  bool Detect()
        {
            if (!string.IsNullOrEmpty(Port) && GetComPorts().Contains(Port))
            {
                return true;
            }
            else
                return false;
        }

        public void ConnectToCommand()
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.DataReceived -= SerialPort_DataReceived;
                    _serialPort.Close();
                    _serialPort.Dispose();
                }

                // Création des paramètres pour la communication
                DetailedPortSettings portSettings = new HandshakeNone();
                portSettings.BasicSettings.BaudRate = BaudRates.CBR_38400;
                portSettings.BasicSettings.ByteSize = 8;
                portSettings.BasicSettings.Parity = ESRM.SerialPortLib.Parity.none;
                portSettings.BasicSettings.StopBits = ESRM.SerialPortLib.StopBits.one;
                portSettings.AbortOnError = true;

                _serialPort = new Port(_ssparams.ComPort, portSettings);
                _serialPort.Open();
                _serialPort.DataReceived += SerialPort_DataReceived;
                _serialPort.OnError += _serialPort_OnError;

                if (!_serialPort.IsOpen)
                    throw new Exception("ERREUR DE CONNEXION SmartSensor");
            }
            catch(Exception ex)
            {
                Detect();
                CloseConnexion();
            }
        }

        private void _serialPort_OnError(string Description)
        {
            throw new NotImplementedException();
        }

        public  void CloseConnexion()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.DataReceived -= SerialPort_DataReceived;
                _serialPort.Close();
                _serialPort.Dispose();
                _serialPort = null;
            }
        }

        #endregion CONNEXION PORT SERIE


        void SerialPort_DataReceived()
        {
            try
            {
                byte[] buffer = _serialPort.Input;

                ProcessIncomingPacket(buffer);
            }
            catch (Exception ex)
            {
            }
        }

        void ProcessIncomingPacket(byte[] buffer)
        {
            byte received = buffer[0];

            // Detection d'une Auto sur un des capteurs
            int carId;
            ReadCarId(received, out carId);

            OnCarEnterInPitLane(carId);
            //_pitStatus[carId - 1] = true;
            //SetPitStatus();
        }

        public  bool IsConnected()
        {
            return _serialPort != null && _serialPort.IsOpen;
        }

        private void OnCarEnterInPitLane(int carId)
        {
            if (CarEnterInPitLane != null)
                CarEnterInPitLane(this, new TeamIdEventArgs(carId));
        }


        
        private void ReadCarId(byte data, out int carId) //assumes 8 bits NOT 10
        {
            BitArray bData = new BitArray(new byte[] { data });
            // l'id de la voiture est codé sur les 3 premiers bits
            bool[] pBools = new bool[3];
            for (int i = 0; i < 3; i++)
                pBools[i] = bData[i];
            BitArray carIdData = new BitArray(pBools);
            carId = getIntFromBitArray(carIdData);
        }





        private void SetPitStatus()
        {
            //if (!IsConnected())
            //    return;

            //BitArray bData = new BitArray(_pitStatus);
            //byte[] output = new byte[2];
            //output[0] = Convert.ToByte((int)SmartSensorCommandEnum.SetPitStatus);
            //output[1] = Convert.ToByte(getIntFromBitArray(bData));
            //_serialPort.Output = output;
        }
        
        /*
        public void YellowFlag()
        {
            if (!IsConnected())
                return;

            if (_ssparams.UseStartLights)
            {
                for (int i = 0; i <= 4; i++)
                    _ledStatus[LEDINDEX_FIRSTRED + i] = false;

                _ledStatus[LEDINDEX_GREEN] = false;
                _ledStatus[LEDINDEX_YELLOW] = true;
                SetLedStatus();
            }
        }

        public void GreenFlag()
        {
            if (!IsConnected())
                return;

            if (_ssparams.UseStartLights)
            {
                for (int i = 0; i <= 4; i++)
                    _ledStatus[LEDINDEX_FIRSTRED + i] = false;

                _ledStatus[LEDINDEX_GREEN] = true;
                _ledStatus[LEDINDEX_YELLOW] = false;
                SetLedStatus();
            }
        }

        public void ResetLed()
        {
            if (!IsConnected())
                return;

            if (_ssparams.UseStartLights)
            {
                for (int i = 0; i <= 5; i++)
                    _ledStatus[LEDINDEX_FIRSTRED + i] = false;

                _ledStatus[LEDINDEX_GREEN] = false;
                _ledStatus[LEDINDEX_YELLOW] = false;
                SetLedStatus();
            }
        }

        public void StartCountDown(int value)
        {
            if (!IsConnected())
                return;

            if (_ssparams.UseStartLights)
            {
                for (int i = 0; i <= value; i++)
                    _ledStatus[LEDINDEX_FIRSTRED + i] = true;

                _ledStatus[LEDINDEX_GREEN] = false;
                _ledStatus[LEDINDEX_YELLOW] = false;
                SetLedStatus();
            }
        }

        public void Start()
        {
            if (!IsConnected())
                return;

            GreenFlag();
        }

        public void ForcePitIn(int laneId)
        {
            if (!IsConnected())
                return;

            _pitStatus.SetValue(true, laneId);
            SetPitStatus();
        }

        public void ForcePi0Out(int laneId)
        {
            if (!IsConnected())
                return;

            _pitStatus.SetValue(false, laneId);
            SetPitStatus();
        }

        private void SetLedStatus()
        {
            if (!IsConnected())
                return;

            BitArray bData = new BitArray(_ledStatus);
            byte[] output = new byte[2];
            output[0] = Convert.ToByte((int)SmartSensorCommandEnum.SetStartLight);
            output[1] = Convert.ToByte(getIntFromBitArray(bData));
            _serialPort.Output = output;
        }

        private void GetPitStatus()
        {
            if (!IsConnected())
                return;

            byte[] output = new byte[2];
            output[0] = Convert.ToByte((int)SmartSensorCommandEnum.ReadPitSatus);
            output[1] = Convert.ToByte(0);

            _serialPort.Output = output;
        }


        private void ReadPitStatus(byte pitStatusValue)
        {
            BitArray bData = new BitArray(new byte[] { pitStatusValue });
            // l'id de la voiture est codé sur les 3 premiers bits
            for (int i = 0; i < 6; i++)
                _pitStatus[i] = bData[i];

        }
        */

        private int getIntFromBitArray(BitArray bitArray)
        {
            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }


    }
}
