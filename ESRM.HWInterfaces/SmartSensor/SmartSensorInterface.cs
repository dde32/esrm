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
    public enum SmartSensorCommandEnum
    {
        ReadSerialNumber = 1,
        WriteSerialNumber = 2, // Write Serialnumber
        ReadFwVersion= 3, // Read FW version
        NA = 4,  //NA                    
        ReadMode = 5, // Read Mode
        SetPitStatus = 6,// Set Pit status
        ReadPitSatus= 7,// Read Pit status
        SetLedStatus= 8,// Set LED Status
        SetBlinkStatus = 9,// Set Blink status
        SetNumberPickBeforeAuth = 10,// Set number of times car must be picked up befor identification
        ReadPickupCount = 11,// Read Pickup count
        SetPickupDirection = 12,// Set Pit direction
        ReadPitDirection = 13,// Read Pit direction
        SetMode = 14,// Set Mode
        SetStartLight = 15,// Set startLight
        ReadStartLight = 16,// Read startLight
        ReadSensors = 17,// Read Sensors
    }



    public class SmartSensorInterface_ForPitLane : IDisposable
    {
        protected DelegateErrorLog CallBackLogging;

        public string Port { get { return _ssparams.ComPort; } }

        IDigitalParamsBase _digitalParams;
        PitSensorsParams _ssparams;
        bool[] _pitStatus = new bool[6] { false, false, false, false, false, false };
        bool[]  _ledStatus = new bool[8] { false, false, false, false, false, false, false, false };

        public event TeamIdEventHandler CarEnterInPitLane;
        public event TeamIdEventHandler CarExitPitLane;

        const int LEDINDEX_FIRSTRED = 0;
        const int LEDINDEX_GREEN = 5;
        const int LEDINDEX_YELLOW = 6;
        bool _isConnected = false;

        bool _useStartLight = false;


        public bool IsConnected { get { return _isConnected; } }

        public SmartSensorInterface_ForPitLane(IDigitalParamsBase digitalParams)
          : base()
        {
            _digitalParams = digitalParams;
            _ssparams = _digitalParams.PitSmartSensorsParams;
        }

        ~SmartSensorInterface_ForPitLane()
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
        SerialPort _serialPort;


        public void ConnectToCommand()
        {

            _isConnected = false;

            try
            {
                //if (_serialPort != null && _serialPort.IsOpen)
                //{
                //    Log(string.Format("PIT SENSORS  DeConnexion au port {0}", _ssparams.ComPort));
                //    _serialPort.DataReceived -= SerialPort_DataReceived;
                //    _serialPort.Close();
                //    _serialPort.Dispose();
                //}

                // // Création des paramètres pour la communication
                // DetailedPortSettings portSettings = new HandshakeNone();
                // if(_ssparams.SensorType == SensorProtocolEnum.PP)
                //      portSettings.BasicSettings.BaudRate = BaudRates.CBR_38400;
                // else if (_ssparams.SensorType == SensorProtocolEnum.SS)
                //     portSettings.BasicSettings.BaudRate = BaudRates.CBR_57600;

                // portSettings.BasicSettings.ByteSize = 8;
                // portSettings.BasicSettings.Parity = ESRM.SerialPortLib.Parity.none;
                // portSettings.BasicSettings.StopBits = ESRM.SerialPortLib.StopBits.one;

                // portSettings.AbortOnError = false;
                //_serialPort = new Port(_ssparams.ComPort, portSettings);

                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.Close();
                    _serialPort.Dispose();
                }

                // Création des paramètres pour la communication
                 if(_ssparams.SensorType == SensorProtocolEnum.PP)
                    _serialPort = new SerialPort(Port, 38400, System.IO.Ports.Parity.None, 8);
                    else if (_ssparams.SensorType == SensorProtocolEnum.SS)
                    _serialPort = new SerialPort(Port, 57600, System.IO.Ports.Parity.None, 8);

                Log(string.Format("PIT SENSORS  Connexion au port {0}", _ssparams.ComPort));

                _serialPort.Open();
                _serialPort.DataReceived += _serialPort_DataReceived;
                //_serialPort.DataReceived += SerialPort_DataReceived;
                //_serialPort.OnError += _serialPort_OnError;

                if (!_serialPort.IsOpen)
                {
                    Log(string.Format("PIT SENSORS  Erreur de connexion au port {0}", _ssparams.ComPort));
                    throw new Exception("ERREUR DE CONNEXION SmartSensor");
                }
                _isConnected = true;
            }
            catch (Exception ex)
            {
                Log(string.Format(" PIT SENSORS Erreur de connexion au port {0} {1}", _ssparams.ComPort,ex.Message));
                CloseConnexion();
            }
        }



        public  void CloseConnexion()
        {
            //if (_serialPort != null && _serialPort.IsOpen)
            //{
            //    Log(string.Format("PIT SENSORS  DeConnexion au port {0}", _ssparams.ComPort));
            //    _serialPort.DataReceived -= SerialPort_DataReceived;
            //    _serialPort.Close();
            //    _serialPort.Dispose();
            //    _serialPort = null;
            //}
            //_isConnected = false;

            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.Dispose();
                _serialPort = null;
            }
            _isConnected = false;
        }

        #endregion CONNEXION PORT SERIE

        public void SetCallBackLogging(DelegateErrorLog callbackMethod)
        {
            CallBackLogging = callbackMethod;
        }

        protected void Log(string message)
        {
            if (CallBackLogging != null)
            {
                CallBackLogging(message);
            }
        }
        void SerialPort_DataReceived()
        {
            //try
            //{
            //    //byte[] buffer = new byte[2];
            //    Log(string.Format("PIT SENSORS  SerialPort_DataReceived  port {0}", _ssparams.ComPort));
            //    byte[] buffer = _serialPort.Input;

            //    ProcessIncomingPacket(buffer);
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytes = _serialPort.BytesToRead;
                byte[] buffer = new byte[bytes];
                _serialPort.Read(buffer, 0, bytes);
                ProcessIncomingPacket(buffer);
            }
            catch (Exception ex)
            {
            }
        }

        void ProcessIncomingPacket(byte[] buffer)
        {
            byte receivedB0 = buffer[0];
            Log(string.Format("PIT SENSORS ProcessIncomingPacket", _ssparams.ComPort));

           // if (_ssparams.SensorProtocol == SensorProtocolEnum.PP)
            {
                if (buffer.Length == 1)
                {
                    // il faut commencer par être capable d'identifier le sensor et le carid.
                    int carId;
                    ReadSensorAndCarId(receivedB0, out carId);

                    Log(string.Format("PIT SENSORS CAR ID {0}", carId));

                    OnCarEnterInPitLane(carId);
                }
            }
            //else if (_ssparams.SensorProtocol == SensorProtocolEnum.SS)
            //{
            //    int cmd = Convert.ToInt32(receivedB0);
            //    byte receivedB1 = 0;
            //    if (buffer.Length > 1)
            //        receivedB1 = buffer[1];

            //    // Detection d'une Auto sur un des capteurs
            //    if (cmd == 0)
            //    {
            //        // il faut commencer par être capable d'identifier le sensor et le carid.
            //        int sensorId, carId;
            //        ReadSensorAndCarId(receivedB1, out sensorId, out carId);

            //        // si une voiture passe sur le capteur 1 et si le sens n'est pas inversé OU si capteur 2 et sens inversé, 
            //        // on déclenche l'event qui pévient de l'entrée d'une auto dans la pitlane
            //        // on demande les PitStatus et on ajoute l'id qui vient de passer 
            //        if ((sensorId == 1 && !_ssparams.Reverse) || (sensorId == 2 && _ssparams.Reverse))
            //        {
            //            OnCarEnterInPitLane(carId);
            //            _pitStatus[carId - 1] = true;
            //            SetPitStatus();
            //        }
            //        // sinon, si une voiture passe sur le capteur 1 et sens reverse OU  si capteur 2 et non reverse
            //        // on déclenche l'event qui pévient de la sortie d'une auto de la pitlane
            //        // on demande les PitStatus et on supprime l'id qui vient de passer 
            //        else if ((sensorId == 1 && _ssparams.Reverse) || (sensorId == 2 && !_ssparams.Reverse))
            //        {
            //            OnCarExitPitLane(carId);

            //            _pitStatus[carId - 1] = false;
            //            SetPitStatus();
            //        }

            //    }
            //    else // commandes
            //    {
            //        switch (cmd)
            //        {
            //            case (int)SmartSensorCommandEnum.ReadMode:
            //                //_ssparams.se = received;
            //                break;
            //            case (int)SmartSensorCommandEnum.ReadPickupCount:
            //                break;
            //            case (int)SmartSensorCommandEnum.ReadPitDirection:
            //                break;
            //            case (int)SmartSensorCommandEnum.ReadPitSatus:
            //                ReadPitStatus(receivedB1);
            //                break;
            //            case (int)SmartSensorCommandEnum.ReadSensors:
            //                _ssparams.SensorsCount = receivedB1;
            //                break;
            //            case (int)SmartSensorCommandEnum.ReadStartLight:
            //                break;
            //        }
            //    }
            //}

        }


        private void OnCarEnterInPitLane(int carId)
        {

            if (CarEnterInPitLane != null)
                CarEnterInPitLane(this, new TeamIdEventArgs(carId));
        }

        private void OnCarExitPitLane(int carId)
        {
            if (CarExitPitLane != null)
                CarExitPitLane(this, new TeamIdEventArgs(carId));
        }

        public void YellowFlag()
        {
            if (!IsConnected || !_useStartLight)
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
            if (!IsConnected || !_useStartLight)
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
            if (!IsConnected || !_useStartLight)
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
            if (!IsConnected || !_useStartLight)
                return;

            if (_ssparams.UseStartLights)
            {
                for(int i = 0; i <= value; i++)
                    _ledStatus[LEDINDEX_FIRSTRED+i] = true;

                _ledStatus[LEDINDEX_GREEN] = false;
                _ledStatus[LEDINDEX_YELLOW] = false;
                SetLedStatus();
            }
        }

        public void Start()
        {
            if (!IsConnected || !_useStartLight)
                return;

            GreenFlag();
        }

        private void ReadSensorAndCarId(byte data, out int carId) //assumes 8 bits NOT 10
        {
            BitArray bData = new BitArray(new byte[] { data });
            // l'id de la voiture est codé sur les 3 premiers bits
            bool[] pBools = new bool[3];
            for (int i = 0; i < 3; i++)
                pBools[i] = bData[i];
            BitArray carIdData = new BitArray(pBools);
            carId = getIntFromBitArray(carIdData);
        }

        private void ReadSensorAndCarId(byte data, out int sensorId, out int carId) //assumes 8 bits NOT 10
        {
            BitArray bData = new BitArray(new byte[] { data });
            // l'id de la voiture est codé sur les 3 premiers bits
            bool[] pBools = new bool[3];
            for (int i = 0; i < 3; i++)
                pBools[i] = bData[i];
            BitArray carIdData = new BitArray(pBools);
            carId = getIntFromBitArray(carIdData);

            //le sensor ID est codé sur le bit 4
            sensorId = Convert.ToInt32(bData[3]) + 1;
        }


        public void SetMode(int mode)
        {
            ////if (_ssparams.SensorProtocol == SensorProtocolEnum.SS)
            //{
            //    if (!IsConnected)
            //        return;

            //    byte[] output = new byte[2];
            //    output[0] = Convert.ToByte((int)SmartSensorCommandEnum.SetMode);
            //    output[1] = Convert.ToByte(mode);

            //    _serialPort.Output = output;
            //}
        }

        public void SetPickup(int count)
        {
            ////if (_ssparams.SensorProtocol == SensorProtocolEnum.SS)
            //{
            //    if (!IsConnected)
            //        return;

            //    byte[] output = new byte[2];
            //    output[0] = Convert.ToByte((int)SmartSensorCommandEnum.SetNumberPickBeforeAuth);
            //    output[1] = Convert.ToByte(count);

            //    _serialPort.Output = output;
            //}
        }

        private void SetPitStatus()
        {
            //if (!IsConnected)
            //    return;

            //BitArray bData = new BitArray(_pitStatus);
            //byte[] output = new byte[2];
            //output[0] = Convert.ToByte((int)SmartSensorCommandEnum.SetPitStatus);
            //output[1] = Convert.ToByte(getIntFromBitArray(bData));
            //_serialPort.Output = output;
        }

        public void ForcePitIn(int laneId)
        {
            if (!IsConnected)
                return;

            _pitStatus.SetValue(true, laneId);
            SetPitStatus();
        }

        public void ForcePi0Out(int laneId)
        {
            if (!IsConnected)
                return;

            _pitStatus.SetValue(false, laneId);
            SetPitStatus();
        }

        private void SetLedStatus()
        {
            //if (!IsConnected || !_useStartLight)
            //    return;

            //BitArray bData = new BitArray(_ledStatus);
            //byte[] output = new byte[2];
            //output[0] = Convert.ToByte((int)SmartSensorCommandEnum.SetStartLight);
            //output[1] = Convert.ToByte(getIntFromBitArray(bData));
            //_serialPort.Output = output;
        }

        private void GetPitStatus()
        {
            //if (!IsConnected)
            //    return;

            //byte[] output = new byte[2];
            //output[0] = Convert.ToByte((int)SmartSensorCommandEnum.ReadPitSatus);
            //output[1] = Convert.ToByte(0);

            //_serialPort.Output = output;
        }


        private void ReadPitStatus(byte pitStatusValue)
        {
            BitArray bData = new BitArray(new byte[] { pitStatusValue });
            // l'id de la voiture est codé sur les 3 premiers bits
            for (int i = 0; i < 6; i++)
                _pitStatus[i] = bData[i];

        }

        public void GetSensors()
        {
            //if (!IsConnected)
            //    return;

            //byte[] output = new byte[2];
            //output[0] = Convert.ToByte((int)SmartSensorCommandEnum.ReadSensors);
            //output[1] = Convert.ToByte(0);

            //_serialPort.Output = output;
        }

        public void GetMode()
        {
            //if (!IsConnected)
            //    return;

            //byte[] output = new byte[2];
            //output[0] = Convert.ToByte((int)SmartSensorCommandEnum.ReadSensors);
            //output[1] = Convert.ToByte(0);

            //_serialPort.Output = output;
        }


        private int getIntFromBitArray(BitArray bitArray)
        {
            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }


    }
}
