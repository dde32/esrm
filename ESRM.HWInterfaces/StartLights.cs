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
    public class StartLights : IDisposable
    {
        public string Port { get { return _digitalParams.StartLightComPort; } }

        IDigitalParamsBase _digitalParams;
        bool[]  _ledStatus = new bool[8] { false, false, false, false, false, false, false, false };

        const int LEDINDEX_GREEN = 0;
        const int LEDINDEX_FIRSTRED = 1;
        const int LEDINDEX_YELLOW = 6;
        const int LEDINDEX_YELLOW2 = 7;
        bool _isConnected = false;

        bool _useStartLight = false;


        public bool IsConnected { get { return _isConnected; } }

        public StartLights(IDigitalParamsBase digitalParams)
          : base()
        {
            _digitalParams = digitalParams;
            _useStartLight = !string.IsNullOrEmpty(Port);
        }

        ~StartLights()
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
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _isConnected = true;
                return;
            }

            _isConnected = false;

            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.Close();
                    _serialPort.Dispose();
                }

                // Création des paramètres pour la communication
               _serialPort = new SerialPort(Port, 9600,System.IO.Ports.Parity.None,8);

                _serialPort.Open();
                _isConnected = _serialPort.IsOpen;
                GreenFlag();
                Thread.Sleep(50);
                YellowFlag();
                Thread.Sleep(50);
                GreenFlag();
                Thread.Sleep(50);
                ResetLed();

            }
            catch (Exception ex)
            {
                CloseConnexion();
            }
        }

        public  void CloseConnexion()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.Dispose();
                _serialPort = null;
            }
            _isConnected = false;
        }

        #endregion CONNEXION PORT SERIE

        public void GreenFlag()
        {
            if (!IsConnected || !_useStartLight)
                return;

            for (int i = 0; i <= 4; i++)
                _ledStatus[LEDINDEX_FIRSTRED + i] = false;

            _ledStatus[LEDINDEX_GREEN] = true;
            _ledStatus[LEDINDEX_YELLOW] = false;
            _ledStatus[LEDINDEX_YELLOW2] = false;
            WriteLedStatus();
        }

        public void YellowFlag()
        {
            if (!IsConnected || !_useStartLight)
                return;

            for (int i = 0; i <= 4; i++)
                _ledStatus[LEDINDEX_FIRSTRED + i] = false;

            _ledStatus[LEDINDEX_GREEN] = false;
            _ledStatus[LEDINDEX_YELLOW] = true;
            _ledStatus[LEDINDEX_YELLOW2] = true;
            WriteLedStatus();
        }



        public void ResetLed()
        {
            if (!IsConnected || !_useStartLight)
                return;

            for (int i = 0; i <= 5; i++)
                _ledStatus[LEDINDEX_FIRSTRED + i] = false;

            _ledStatus[LEDINDEX_GREEN] = false;
            _ledStatus[LEDINDEX_YELLOW] = false;
            _ledStatus[LEDINDEX_YELLOW2] = false;
            WriteLedStatus();
    }

        public void RedLight(int value)
        {
            if (!IsConnected || !_useStartLight)
                return;

            for (int i = 0; i <= 5; i++)
                _ledStatus[LEDINDEX_FIRSTRED + i] = false;

            for (int i = 0; i <= value; i++)
                _ledStatus[LEDINDEX_FIRSTRED+i] = true;

            _ledStatus[LEDINDEX_GREEN] = false;
            _ledStatus[LEDINDEX_YELLOW] = false;
            _ledStatus[LEDINDEX_YELLOW2] = false;
            WriteLedStatus();
    }


        private void WriteLedStatus()
        {
            if (!IsConnected || !_useStartLight)
                return;

            BitArray bData = new BitArray(_ledStatus);
            byte[] output = new byte[1];
            //output[0] = Convert.ToByte((int)SmartSensorCommandEnum.SetStartLight);
            output[0] = Convert.ToByte(getIntFromBitArray(bData));
            _serialPort.Write(output,0,1);
        }

        private int getIntFromBitArray(BitArray bitArray)
        {
            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }
    }
}
