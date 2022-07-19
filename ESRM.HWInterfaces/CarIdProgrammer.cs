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
    public class CarIdProgrammer : IDisposable
    {
        public string Port { get { return _digitalParams.CarIdProgrammerComPort; } }

        IDigitalParamsBase _digitalParams;
        bool _isConnected = false;

        bool _useIt = false;


        public bool IsConnected { get { return _isConnected; } }

        public CarIdProgrammer(IDigitalParamsBase digitalParams)
          : base()
        {
            _digitalParams = digitalParams;
            _useIt = !string.IsNullOrEmpty(Port);
        }

        ~CarIdProgrammer()
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

         SerialPort _serialPort;
        //Port _serialPort;


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
                _serialPort = new SerialPort(Port, 19200, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                _serialPort.Handshake = System.IO.Ports.Handshake.None;
                _serialPort.ReadTimeout = 500;
                _serialPort.WriteTimeout = 500;
                _serialPort.Open();


                _serialPort.DataReceived += _serialPort_DataReceived;
                _serialPort.ErrorReceived += _serialPort_ErrorReceived;

                _isConnected = _serialPort.IsOpen;
                if (!_serialPort.IsOpen)
                {
                    _isConnected = false;
                    _serialPort.Close();
                    _serialPort.Dispose();
                }



                    //if (_serialPort != null && _serialPort.IsOpen)
                    //{
                    //    _serialPort.DataReceived -= _serialPort_DataReceived1;
                    //    //_serialPort.OnError -= SerialPort_OnError;
                    //    _serialPort.Close();
                    //    _serialPort.Dispose();
                    //}

                    //// Création des paramètres pour la communication
                    //DetailedPortSettings portSettings = new HandshakeNone();

                    //portSettings.BasicSettings.BaudRate = BaudRates.CBR_19200;
                    //portSettings.BasicSettings.ByteSize = 8;
                    //portSettings.BasicSettings.Parity = ESRM.SerialPortLib.Parity.none;
                    //portSettings.BasicSettings.StopBits = ESRM.SerialPortLib.StopBits.one;
                    //portSettings.RTSControl = RTSControlFlows.disable;
                    //portSettings.DTRControl = DTRControlFlows.disable;


                    //portSettings.AbortOnError = false;

                    //// Ouverture du sérial port sur le com issue de la détection
                    //_serialPort = new Port(Port, portSettings);
                    //// nombre de Byte à lire
                    ////_serialPort.RThreshold = 1;
                    //////// Nombre de Byte à écrire
                    ////_serialPort.SThreshold = 1;


                    //// abonnement à la reception des données et aux erreurs
                    //_serialPort.DataReceived += _serialPort_DataReceived1;
                    //_serialPort.OnError += _serialPort_OnError;
                    //_serialPort.Open();
                    //_isConnected = true;

                    //if (!_serialPort.IsOpen)
                    //{
                    //    _isConnected = false;
                    //    _serialPort.Close();
                    //    _serialPort.Dispose();
                    //    _serialPort = null;

                    //    throw new Exception("ERREUR DE CONNEXION A LA PB");
                    //}

            }
            catch (Exception ex)
            {
                CloseConnexion();
            }
        }

        //private void _serialPort_OnError(string Description)
        //{
        //}

        //private void _serialPort_DataReceived1()
        //{
        //    Thread.Sleep(0);
        //    byte[] buffer = new byte[1];
        //    buffer = _serialPort.Input;

        //}

        private void _serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
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

        public void ProgramCar(int carId)
        {
            char id = Convert.ToChar(carId.ToString());

            if (!IsConnected || !_useIt)
                return;

            //BitArray bData = new BitArray(carId);
            byte[] output = new byte[1];
            output[0] = Convert.ToByte(id);

            //_serialPort.Output = output;
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
