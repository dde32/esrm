using System;
using System.Collections.Generic;
//using RJCP.IO.Ports;
using System.Threading;
using ESRM.Entities;
using System.IO.Ports;
using ESRM.SerialPortLib;
using ESRM.HWInterfaces.Scalextric;
using System.ComponentModel;
using ESRM.GamePads;
using ESRM.GamePads.Common;

namespace ESRM.HWInterfaces
{

    public class SSDInterface : GenericDigitalInterface
    {
        public event HandSetThrottleInfosRecordedEventHandler HandSetThrottleInfosRecorded;
        int _pressButtonDelay  = 0;
        bool _initialConnectionOk;
        int _sentBeforeLastAux;
        DateTime? _lastTimeReceivedPacket;

        #region CONNEXION PORT SERIE

        // serial port pour la réception des infos de la PB C7042
        Port _serialPort;

        public SSDInterface()
            : base()
        {
            _minThrotlleValue = 0;
            _maxThrotlleValue = 63;

            _isStarted = true;
            _lastTimeReceivedPacket = null;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_serialPort != null)
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();
                _serialPort.Dispose();
                _serialPort = null;
            }
        }

        public override bool IsConnected()
        {
            if (!_lastTimeReceivedPacket.HasValue)
                return false;

            if ( DateTime.Now > _lastTimeReceivedPacket.Value.AddSeconds(2))
            {
                _initialConnectionOk = false;
                _lastTimeReceivedPacket = null;
                return false;
            }
            else
                return true;
        }

        public override bool IsInitConnected()
        {
            return _initialConnectionOk;
        }


        // Détection du port com pour communication avec PB
        public override bool DetectCommand()
        {
            if (!string.IsNullOrEmpty(DigitalParams.ComPort) && DigitalParams.OpenedComPort.Contains(DigitalParams.ComPort))
            {
                    return true;
            }
            else
                return false;
        }

        // Connexion a la PB
        public override void ConnectToCommand(bool sendResetPacket)
        {
            base.ConnectToCommand(sendResetPacket);

            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.DataReceived -= SerialPort_DataReceived;
                    //_serialPort.OnError -= SerialPort_OnError;
                    _serialPort.Close();
                    _serialPort.Dispose();
                }

                // Création des paramètres pour la communication
                DetailedPortSettings portSettings = new HandshakeNone();

                portSettings.BasicSettings.BaudRate = BaudRates.CBR_19200;
                portSettings.BasicSettings.ByteSize = 8;
                portSettings.BasicSettings.Parity = ESRM.SerialPortLib.Parity.none;
                portSettings.BasicSettings.StopBits = ESRM.SerialPortLib.StopBits.one;
                portSettings.AbortOnError = false;

                // Ouverture du sérial port sur le com issue de la détection
                _serialPort = new Port(DigitalParams.ComPort, portSettings);
                // nombre de Byte à lire
                _serialPort.RThreshold = 14;
                // Nombre de Byte à écrire
                _serialPort.SThreshold = 9;


                // abonnement à la reception des données et aux erreurs
                _serialPort.DataReceived += SerialPort_DataReceived;
                //_serialPort.OnError += SerialPort_OnError;
                _lastTimeReceivedPacket = null;
                _serialPort.Open();

                if (!_serialPort.IsOpen)
                {
                    _serialPort.Close();
                    _serialPort.Dispose();
                    _serialPort = null;

                    throw new Exception("ERREUR DE CONNEXION A LA PB");
                }

                _initialConnectionOk = true;
                if (sendResetPacket)
                    this.SendResetPacket();
                else
                    SendFirstPacket(null);
            }
            catch(Exception ex)
            {
                Log(ex.Message);
                DetectCommand();
                CloseConnexionCommand();
            }
        }

        public override void CloseConnexionCommand()
        {
            base.CloseConnexionCommand();

            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.DataReceived -= SerialPort_DataReceived;
                //_serialPort.OnError -= SerialPort_OnError;
                _serialPort.Close();
                _serialPort.Dispose();
                _serialPort = null;
            }
            Log("CloseConnexionCommand ended" );
        }

        #endregion CONNEXION PORT SERIE


        void SerialPort_OnError(string Description)
        {
            Log(Description);
        }

        void SerialPort_DataReceived()
        {           
            Thread.Sleep(0);

            _lastTimeReceivedPacket = DateTime.Now;

            Log("SerialPort_DataReceived");


            // récupération des 16 Bytes envoyés par la C7042
            byte[] buffer = new byte[16];
            // read the character
            buffer = _serialPort.Input;

            // Création d'un packet PB6 
            try
            {
                PB6RecievedPacket rPacket = new PB6RecievedPacket(buffer);
                // controle du checksum pour savoir si le paquet est recu correctement.
                if (rPacket.Checksum != null && rPacket.Checksum.Valid)
                {
                    OnDataReceveid(string.Empty, rPacket);

                    // si on a fait une demande de reset on va informer la PB et donc on ne traite pas le paquet recu.
                    if (_wantToResetConnexion)
                        SendResetPacket();
                    // si on a fait une demande de programmation d'auto on envoi l'id a programmer
                    else if (_wantToSetId)
                        SendProgrammationCarIdPacket();
                    // sinon on est dans un cas normal, on traite le paquet et on fera une réponse standard
                    else
                        ProcessIncomingPacket(ref rPacket);

                }
                // paquet mal recu on demande un resend
                else
                    RequestReSend2();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                RequestReSend2();
            }
        }

        /// <summary>
        /// Traitement d'un packet en entrée.
        /// On va controler le status des HandSets
        /// controler le status du bouton start
        /// puis traiter les packet handset
        /// et au final traiter un éventuel en of lap
        /// </summary>
        /// <param name="rPacket"></param>
        private void ProcessIncomingPacket(ref PB6RecievedPacket rPacket)
        {
            try
            {
                if (_pressButtonDelay > 0)
                    _pressButtonDelay--;

                // permet de récupérer de l'information sur l'état de la piste et des différentes mannettes (branchées ou pas)
                ReadTrackAndHandSetStatus(rPacket);
                // traitement de fin de tour - Depuis la version 3 on fait le traitement de fin de tour avant le traitement des packets des pilotes pour plus de précision
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += Worker_DoWork;
                worker.RunWorkerAsync(rPacket);


                // est ce que le bouton start est pressé
                if (rPacket.ButtonStatus.StartPressed && _pressButtonDelay == 0)
                {
                    _pressButtonDelay = 20;
                    if (IsTrackCallRunning) // un TC était en cours et on appui sur start, on relance le Drapeau vert
                        ForceGreenFlag();
                    else if (!IsStarted) // la course n'est pas commencée, on la commence
                        StartCountDownCommand();
                    else if (IsPaused)  // on était en pause, on relance
                        UnPauseCommand();
                    else if (IsStarted && IsRunning)  // a l'inverse, la course est en cours, on la mest en pause
                        PauseCommand();
                }

                PB6NormalSendPacket reponsePacket = new PB6NormalSendPacket(rPacket);
                // récupération des infos pour le HS 1 à 6
                ProcessHandSetPackets(ref reponsePacket);
               // if (_sentBeforeLastAux >= 30 && _wantToSetCarLights)
               if (_wantToSetCarLights)
               {
                    _wantToSetCarLights = false;
                    _sentBeforeLastAux = 0;
                    SendAuxPacket();
                }
                else
                    SendNormalResponsePacket(reponsePacket);

                _sentBeforeLastAux++;
            }
            catch (Exception ex)
            {
                Log(ex.Message);

                byte[] buffer = new byte[16];
                buffer = _serialPort.Input;
                RequestReSend2();
            }
        }

        private void ProcessHandSetPackets(ref PB6NormalSendPacket reponsePacket)
        {
            reponsePacket.OperationMode.IsDrivePacket = true;
            if (_blockProcessHandSetPacket)
                return;

            if (Handsets.Get(1) is GlobalGamePadHandSet)
                ProcessDriverPacketForGamePad(reponsePacket.DrivePacket1, Handsets.Get(1) as GlobalGamePadHandSet);
            else
                ProcessDriverPacketForNormalHandSet(reponsePacket.DrivePacket1, Handsets.Get(1));

            if (Handsets.Get(2) is GlobalGamePadHandSet)
                ProcessDriverPacketForGamePad(reponsePacket.DrivePacket2, Handsets.Get(2) as GlobalGamePadHandSet);
            else
                ProcessDriverPacketForNormalHandSet(reponsePacket.DrivePacket2, Handsets.Get(2));

            if (Handsets.Get(3) is GlobalGamePadHandSet)
                ProcessDriverPacketForGamePad(reponsePacket.DrivePacket3, Handsets.Get(3) as GlobalGamePadHandSet);
            else
                ProcessDriverPacketForNormalHandSet(reponsePacket.DrivePacket3, Handsets.Get(3));

            if (Handsets.Get(4) is GlobalGamePadHandSet)
                ProcessDriverPacketForGamePad(reponsePacket.DrivePacket4, Handsets.Get(4) as GlobalGamePadHandSet);
            else
                ProcessDriverPacketForNormalHandSet(reponsePacket.DrivePacket4, Handsets.Get(4));

            if (Handsets.Get(4) is GlobalGamePadHandSet)
                ProcessDriverPacketForGamePad(reponsePacket.DrivePacket5, Handsets.Get(5) as GlobalGamePadHandSet);
            else
                ProcessDriverPacketForNormalHandSet(reponsePacket.DrivePacket5, Handsets.Get(5));

            if (Handsets.Get(4) is GlobalGamePadHandSet)
                ProcessDriverPacketForGamePad(reponsePacket.DrivePacket6, Handsets.Get(6) as GlobalGamePadHandSet);
            else
                ProcessDriverPacketForNormalHandSet(reponsePacket.DrivePacket6, Handsets.Get(6));
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            PB6RecievedPacket rPacket = (e.Argument as PB6RecievedPacket);
            DoEndOfLapIfNeeded(rPacket.CarIDTrackUpdate, rPacket.GameTime);
        }


        /// <summary>
        /// Est ce les HandSet sont branché ou pas
        /// </summary>
        /// <param name="rPacket"></param>
        private void ReadTrackAndHandSetStatus(PB6RecievedPacket rPacket)
        {
            if (_blockProcessHandSetPacket || Handsets.HandSetList.Count == 0)
                return;

            Handsets.Get(1).IsPlugged = rPacket.HandsetTrackStatus.Handset1;
            Handsets.Get(2).IsPlugged = rPacket.HandsetTrackStatus.Handset2;
            Handsets.Get(3).IsPlugged = rPacket.HandsetTrackStatus.Handset3;
            Handsets.Get(4).IsPlugged = rPacket.HandsetTrackStatus.Handset4;
            Handsets.Get(5).IsPlugged = rPacket.HandsetTrackStatus.Handset5;
            Handsets.Get(6).IsPlugged = rPacket.HandsetTrackStatus.Handset6;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="carId"></param>
        /// <param name="hs"></param>
        private void ProcessDriverPacketForNormalHandSet(DriverPacket packet, IHandSet hs)
        {
            
            if (NeedToProcessHandsetPacket(hs, packet.Power))
            {
                int resultThrottle = 0; // throttle à appliquer après corrections par la course


                bool brakingButtonPressed = packet.Brake; // on conserve la notion de frein pour la suite (timers, trackcall etc.)
                CantBrakeEnum canDoBrake = brakingButtonPressed ? CantBrakeEnum.CanBrake : CantBrakeEnum.NoBrakeWanted; // flag pour la gestion de la limitation du frein


                // on converti le throttle en fonction de la courbe de puissance du handset
                hs.Throttle = (hs as HandSet).TranslateThrottleFromCurve( hs.IsPlugged ? packet.Power : 0);
                hs.CheckForActions();

                // on demande à la course de nous donner la réelle valeur du Throttle à appliquer (variable à cause de l'essence, de la santé de l'auto, du paramètre max power du pilote etc.)
                // si aucune course en cours la méthode renvoi la valeur initiale non modifiée.
                // récupération des informations de vitesse et de frein dynamique à appliquer (calculer en fonction de l'état de la voiture, des parametres pilotes, de l'usure des pneus etc.) 
                float brakeAdhesionLoss, accelerationAdhesionLoss;
                bool highAcceleration, strongBrakng;
                GetCarDatas(hs.LaneId, hs.Throttle, brakingButtonPressed ? 1 : 0, !hs.Braking && !hs.LaneChangingPressed, false, out resultThrottle,out canDoBrake, out highAcceleration, out strongBrakng, out brakeAdhesionLoss, out accelerationAdhesionLoss);
                hs.Throttle = resultThrottle;

                if (!IsStarted || IsPaused)
                {
                    canDoBrake = CantBrakeEnum.CanBrake;
                    resultThrottle = 0;
                    hs.Throttle = resultThrottle;
                }
                CheckForTrackCallOrPitStop(hs.LaneId, hs, packet.ChangeLane, brakingButtonPressed);


                packet.Power = resultThrottle;
                packet.Brake = canDoBrake == CantBrakeEnum.CanBrake;
            }
        }

        private void ProcessDriverPacketForGamePad(DriverPacket packet, GlobalGamePadHandSet hs)
        {
            if (NeedToProcessGamePadHandsetPacket(hs))
            {
                int resultThrottle = 0; // throttle à appliquer après corrections par la course
                CantBrakeEnum canDoBrake = CantBrakeEnum.NoBrakeWanted; // flag pour la gestion de la limitation du frein
                // vérification de l'état des différents éléments du gamepad
                hs.CheckStates();

                  // on demande à la course de nous donner la réelle valeur du Throttle à appliquer (variable à cause de l'essence, de la santé de l'auto, du paramètre max power du pilote etc.)
                // si aucune course en cours la méthode renvoi la valeur initiale non modifiée.
                // récupération des informations de vitesse et de frein dynamique à appliquer (calculer en fonction de l'état de la voiture, des parametres pilotes, de l'usure des pneus etc.) 
                float brakeAdhesionLoss, accelerationAdhesionLoss;
                bool highAcceleration, strongBrakng;
                // get the information for the car, converted throttle value, braking, adhesion loss etc.
                GetCarDatas(hs.LaneId, hs.Throttle, (float)hs.BrakingForceCoef, !hs.Braking && !hs.LaneChangingPressed, true, out resultThrottle, out canDoBrake,out highAcceleration, out strongBrakng, out brakeAdhesionLoss, out accelerationAdhesionLoss);
                // ICI il faut faire le check de ce qu'il peut arriver sur un HANDSET.
                // Action de pitstop
                // Auto detection de sortie de piste
                hs.CheckForActions();

                // si le frein est autorisé (il se peut que sur une course à pluie on est un délai de freinage par exemple)
                if (canDoBrake != CantBrakeEnum.Delay && canDoBrake != CantBrakeEnum.NoBrakeWanted)
                    canDoBrake = hs.DoNeedBrake(brakeAdhesionLoss) ? CantBrakeEnum.CanBrake : CantBrakeEnum.SoftBraking;

                if (brakeAdhesionLoss > 0 || accelerationAdhesionLoss > 0)
                    hs.AdhesionLossVibrations(brakeAdhesionLoss, accelerationAdhesionLoss);
                else if (highAcceleration && DigitalParams.RumblesOnHighAcceleration)
                    hs.HighSpeedVibrations();
                else if (strongBrakng && DigitalParams.RumblesOnStrongBraking)
                    hs.StrongBrakingVibrations();

                if (!IsStarted || IsPaused)
                {
                    canDoBrake = CantBrakeEnum.CanBrake;
                    resultThrottle = 0;
                }

                // esst ce qu'on applique le frein ou pas ?
                if (canDoBrake == CantBrakeEnum.CanBrake)
                {
                    packet.Brake = true;
                    packet.Power = hs.InCarPro ? hs.InCarProBrakingForceValue : 0;
                }
                else
                {
                    packet.Brake = false;
                    packet.Power = resultThrottle;
                }

                packet.ChangeLane = hs.LaneChangingPressed;
            }
        }


        // Gestion des passage sur la ligne de chronométrage
        private void DoEndOfLapIfNeeded(CarIDTrackUpdate carPacket, GameTime gameTimePacket)
        {
            // gestion du temps de fonctionnement de la PB C 7042.
            // pour une raison indéterminée, au bout de 100 secondes il se passe un truc sur la PB et la gestion de l'alimentation change
            // ce qui provoque un décalage total pour les pacers variables.
            // du coup on contourne le souci en effectuant un reset de la PB.
            // cela oblige donc à gérer le temps avec un timer à part.
            // DDE POUR LE MOMENT EN STAND BY CAR PEUT ETRE PROBLEME MAIS A REMETTRE EVENTUELLEMENT
            //if (gameTimePacket.GameTimeSpan.TotalSeconds > 100)
            //    _wantToResetConnexion = true;

            if (carPacket.CarID <= 6 && carPacket.CarID > 0 )
            {
                // gestion des pacer variables
                if (HandSetThrottleInfosRecorded != null)
                    OnHandSetThrottleInfosRecorded(carPacket.CarID, RaceElapsedTime);
                // Event de fin de tour (id de l'auto, passtime et totalThrottle pour le fuel)
                else
                    OnLapEnded(carPacket.CarID, RaceElapsedTime); //RaceElapsedTime); 
            }
        }

        private void OnHandSetThrottleInfosRecorded(int laneId, TimeSpan lapTime)
        {
            if (HandSetThrottleInfosRecorded != null)
            {
                HandSetThrottleInfosRecorded(this, new ThrottleInfosRecordedEventArgs(laneId, lapTime));
            }
        }

        private void GetGameLedStatus(out bool redLed, out bool greenLed)
        {
            redLed = true;
            greenLed = false;

            if (IsRunning)
            {
                redLed = false;
                greenLed = true;
            }
            //else if (IsPaused || !IsStarted)
            //{
            //    redLed = true;
            //    greenLed = false;
            //}
            //else if (!IsStarted)
            //{
            //    redLed = true;
            //    greenLed = true;
            //}
        }

        //private void SendNormalResponsePacketForTEST()
        //{
        //    PB6SendPacket packet = new PB6SendPacket();
        //    _serialPort.Output = packet.ExportData();
        //}

        // paquet de réponse normal.
        private void SendNormalResponsePacket(PB6NormalSendPacket packet)
        {
            bool greenled, redled;
            GetGameLedStatus(out redled, out greenled);

            packet.LEDStatus.GreenLED = greenled;
            packet.LEDStatus.RedLED = redled;
            packet.LEDStatus.LED1 = false;
            packet.LEDStatus.LED2 = false;
            packet.LEDStatus.LED3 = false;
            packet.LEDStatus.LED4 = false;
            packet.LEDStatus.LED5 = false;
            packet.LEDStatus.LED6 = false;

            _serialPort.Output = packet.ExportData();
       }

        private void SendAuxPacket()
        {
            if (_carLights == null)
                _carLights = new bool[6];

            bool greenled, redled;
            GetGameLedStatus(out redled, out greenled);
            PB6AuxPacket packet = new PB6AuxPacket();

            packet.DrivePacket1.Lights = _carLights.Length > 0 ?  _carLights[0] : false;
            packet.DrivePacket2.Lights = _carLights.Length > 1 ? _carLights[1] : false;
            packet.DrivePacket3.Lights = _carLights.Length > 2 ? _carLights[2] : false;
            packet.DrivePacket4.Lights = _carLights.Length > 3 ? _carLights[3] : false;
            packet.DrivePacket5.Lights = _carLights.Length > 4 ? _carLights[4] : false;
            packet.DrivePacket6.Lights = _carLights.Length > 5 ? _carLights[5] : false;

            _serialPort.Output = packet.ExportData();
        }

        #region ENVOI DE PAQUETS SPECIAUX (PROGRAMMATION, RESET, CLOSE etc.)

        private void SendProgrammationCarIdPacket()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                byte[] response = new byte[9];
                response[0] = 0xff;
                response[1] = 0xff;
                response[2] = 0xff;
                response[3] = 0xff;
                response[4] = 0xff;
                response[5] = 0xff;
                response[6] = 0xff;
                LEDStatus ledStatus = new LEDStatus(false, false, false, false, false, false, true, false);
                ledStatus.SetId(_idToSet);
                response[7] = ledStatus.ToByte();
                response[8] = Checksum.CalculateChecksum(response, 8);

                _serialPort.Output = response;
                _wantToSetId = false;
            }
        }

        // paquet d'initialisation de la PB
        private void SendFirstPacket(byte[] buffer)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                byte[] response = new byte[9];
                response[0] = 0xff;
                response[1] = 0xff;
                response[2] = 0xff;
                response[3] = 0xff;
                response[4] = 0xff;
                response[5] = 0xff;
                response[6] = 0xff;
                response[7] = new LEDStatus(false, false, false, false, false, false, true, true).ToByte();
                response[8] = Checksum.CalculateChecksum(response, 8);

                _serialPort.Output = response;
            }
        }

        // Packtet de reset timer
        private void SendResetPacket()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {

                byte[] response = new byte[9];
                response[0] = 0xff;
                response[1] = 0xff;
                response[2] = 0xff;
                response[3] = 0xff;
                response[4] = 0xff;
                response[5] = 0xff;
                response[6] = 0xff;
                response[7] = new LEDStatus(false, false, false, false, false, false, true, true).ToByte();
                response[8] = Checksum.CalculateChecksum(response, 8);

                //_serialPort.Break = false;
                _serialPort.Output = response;
                _wantToResetConnexion = false;
            }
        }

        // dernier paquet non recu demande de renvoi
        private void RequestReSend(byte[] buffer)
        {

            byte[] response = new byte[9];
            response[0] = 0xff;
            response[1] = 0xff;
            response[2] = 0xff;
            response[3] = 0xff;
            response[4] = 0xff;
            response[5] = 0xff;
            response[6] = 0xff;
            response[7] = buffer[7];
            response[8] = Checksum.CalculateChecksum(response, 8);
            //_serialPort.Break = false;
            _serialPort.Output = response;
        }


        private void RequestReSend2()
        {
            byte[] response = new byte[9];
            response[0] = 0xff;
            response[1] = 0xff;
            response[2] = 0xff;
            response[3] = 0xff;
            response[4] = 0xff;
            response[5] = 0xff;
            response[6] = 0xff;
            response[7] = new LEDStatus(false, false, false, false, false, false, false, true).ToByte();
            response[8] = Checksum.CalculateChecksum(response, 8);
            _serialPort.Output = response;
        }

        #endregion


        protected override void ResetMainTimer()
        {
            base.ResetMainTimer();
        }

        protected override void UnPauseMainTimer()
        {
            base.UnPauseMainTimer();
        }

        protected override void PauseMainTimer()
        {
            base.PauseMainTimer();
        }
    }
}
