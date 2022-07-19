/// -------------------------------------------------------------------------------------------------------
/// This file is part of Carrera .NET API Project. It is subject to the license terms in the LICENSE file 
/// found in the top-level directory of this distribution and at http://carreradotnet.codeplex.com/license. 
/// 
/// No part of Carrera .NET API Project, including this file, may be copied, modified, propagated, 
/// or distributed except according to the terms contained in the LICENSE file.
/// -------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace CarreraDotNet
{
    /// <summary>
    /// Class for communicating with the Pc Unit.
    /// </summary>
    public class PcUnit : IPcUnit
    {
        private SerialPort serialPort;
        private Thread readThread;
        private Thread pollThread;
        private bool isRunning = false;        
        private ControlUnitType controlUnitType;
        private AbstractControlUnit controlUnit;

        /// <summary>Occurs when a race is started.</summary>
        public event AbstractControlUnit.RaceStartedHandler RaceStarted;

        /// <summary>Occurs when a car passes the finish line.</summary>
        public event AbstractControlUnit.FinishLinePassedHandler FinishLinePassed;

        /// <summary>Occurs when a car passes a sector.</summary>
        public event AbstractControlUnit.SectorPassedHandler SectorPassed;

        /// <summary>Gets the version number of the connected Control Unit.</summary>
        /// <value>The combined Hardware and Software version number.</value>
        /// <remarks>The version number gets read at the Connect() call. It is empty if the Pc Unit is not connected.</remarks>
        public string VersionNumber
        {
            get { return controlUnit != null ? controlUnit.VersionNumber : string.Empty; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PcUnit" /> class using the specified Com-Port name.
        /// </summary>
        /// <param name="comPort">Name of the Com-Port where the Pc Unit is connected.</param>
        /// <param name="controlUnitType">Defines the type of the control unit (older BlackBox or newer ControlUnit).</param>
        /// <remarks>
        /// Other parameter of the Com-Port are set to the recommended defaults.
        /// </remarks>
        public PcUnit(string comPort, ControlUnitType controlUnitType)
        {
            serialPort = new SerialPort();
            
            serialPort.PortName = comPort;
            serialPort.BaudRate = 19200;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Handshake = Handshake.None;

            // Set the read/write timeouts
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;

            this.controlUnitType = controlUnitType;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="PcUnit" /> class using the specified <see cref="SerialPort" /> object.
        /// </summary>
        /// <param name="serialPort">Com-Port object for communicating with the PC Unit.</param>
        /// <param name="controlUnitType">Defines the type of the control unit (older BlackBox or newer ControlUnit).</param>
        public PcUnit(SerialPort serialPort, ControlUnitType controlUnitType)
        {
            this.serialPort = serialPort;
            this.controlUnitType = controlUnitType;
        }

        /// <summary>
        /// Opens the Com-Port to the Pc Unit ans starts listening.
        /// </summary>
        public void Connect()
        {
            switch (controlUnitType)
            {
                case ControlUnitType.BlackBox: controlUnit = new BlackBox();
                    break;
                case ControlUnitType.ControlUnit: controlUnit = new ControlUnit();
                    break;
            }

            RegisterEvents();

            readThread = new Thread(Read);
            pollThread = new Thread(Poll);
            serialPort.Open();

            isRunning = true;

            readThread.Start();            

            // Receive version number
            serialPort.WriteLine("\"0");
            Thread.Sleep(100);            

            pollThread.Start();
        }

        private void RegisterEvents()
        {
            if (controlUnit != null)
            {
                controlUnit.RaceStarted += controlUnit_RaceStarted;
                controlUnit.FinishLinePassed += controlUnit_FinishLinePassed;
            }
        }

        private void UnregisterEvents()
        {
            if (controlUnit != null)
            {
                controlUnit.RaceStarted -= controlUnit_RaceStarted;
                controlUnit.FinishLinePassed -= controlUnit_FinishLinePassed;
            }
        }

        void controlUnit_FinishLinePassed(object sender, FinishLinePassedEventArgs e)
        {
            FinishLinePassed(sender, e);
        }

        private void controlUnit_RaceStarted()
        {
            RaceStarted();
        }

        /// <summary>
        /// Closes the Com-Port to the Pc Unit and stops listening.
        /// </summary>
        public void Disconnect()
        {
            isRunning = false;
            controlUnit = null;

            readThread.Join();
            pollThread.Join();

            UnregisterEvents();

            serialPort.Close();
        }

        /// <summary>Polling loop for triggering Pc Unit.</summary>
        private void Poll()
        {
            int counter = 0;
            while (isRunning)
            {
                //Thread.Sleep(100);

                serialPort.WriteLine("\"?");

                if (counter == 10)
                {
                    serialPort.WriteLine("\"H");
                    counter = 0;
                }

                counter++;
            }
        }

        /// <summary>Reading loog for receiving Pc Unit data.</summary>
        private void Read()
        {            
            StringBuilder input = new StringBuilder();
            while (isRunning)
            {
                try
                {
                    input.Append(serialPort.ReadExisting());
                    if (input.Length == 0)
                        continue;

                    controlUnit.ParseInput(input);                    
                }
                catch (TimeoutException) 
                {
                    // ToDo: Introduce meaningfull exceptions
                    throw;
                }
            }
        }
    }
}
