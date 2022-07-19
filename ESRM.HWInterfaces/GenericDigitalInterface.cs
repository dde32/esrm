using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using ESRM.Entities;
using System.Windows.Threading;
using System.Diagnostics;
using System.IO.Ports;
using ESRM.SerialPortLib;
using ESRM.GamePads;
using ESRM.GamePads.Common;

namespace ESRM.HWInterfaces
{

    public abstract class GenericDigitalInterface : IHardwareInterface, IDisposable
    {
        public string Port { get { return DigitalParams.ComPort; } }

        // valeur min et max de throttle pour la PB
        protected int _minThrotlleValue = 0;
        protected int _maxThrotlleValue = 100;
        protected int maxHandSetCount = 6;

        // données concernant les poignées (limitation du frein etc.)
        HandsetList _handSets;
        protected bool _blockProcessHandSetPacket = false;
        protected bool[] _carLights;
        protected bool _wantToSetCarLights;

        public IHandsetList Handsets { get { return _handSets; } }
        // paramètres digitaux (méthode de TrackCall, méthode PitStop etc.)
        IDigitalParamsBase _digitalParams;
        public IDigitalParamsBase DigitalParams { get { return _digitalParams; } }

        // Race Timer 
        protected Stopwatch _raceTimer;
        // Méthode CallBack pour récupération de la valeur de throttle conditionnée par la course
        protected DelegateGetCarThrottleValueFromRace CallBackGetCarThrottleValueFromRace;
        protected DelegateErrorLog CallBackLogging;
        public bool _logging;


        // flag pour Rset de la PB
        protected bool _wantToResetConnexion;
        // Flag pour affectation d'un ID
        protected bool _wantToSetId;
        protected int _idToSet;

        // etat du timer de la PB
        protected bool _isStarted;
        protected bool _isPaused;
        protected bool _isTCRunning;
        public abstract bool IsConnected();
        public abstract bool IsInitConnected();

        public bool IsStarted { get { return _isStarted; } }
        public bool IsPaused { get { return _isPaused; } }
        public bool IsTrackCallRunning { get { return _isTCRunning; } }
        public bool IsRunning
        {
            get { return IsStarted && !IsPaused; }
        }

        public TimeSpan RaceElapsedTime { get { return _raceTimer.Elapsed; } }

        // Events
        public event PBDataReceivedEventHandler DataReceived;
        public event EventHandler TimerStarted;
        public event EventHandler TimerStoped;
        public event EventHandler TimerPaused;
        public event EventHandler TimerUnPaused;
        public event EventHandler TimerReset;
        public event EventHandler HandSetStartClick;
        public event TeamIdEventHandler HandSetLBPressed;
        public event TeamIdEventHandler HandSetRBPressed;
        public event TeamIdEventHandler TrackCallEvent;
        public event TeamIdEventHandler NonInitHandSetUsedEvent;
        public event TeamIdEventHandler EndTrackCallEvent;
        public event LapEndedEventHandler LapEnded;
        public event LapEndedEventHandler PitStopBegin;
        //public event LapEndedEventHandler PitStopEnd;
        public event TeamIdEventHandler PitStopDo;
        public event TeamIdEventHandler PitStopNextAction;
        public event TeamIdEventHandler PitStopPrevAction;
        public event TeamIdEventHandler PitStopCancelAction;
        public event TeamIdEventHandler PitStopValidateAction;

        public GenericDigitalInterface()
        {
            _raceTimer = new Stopwatch();
            _isStarted = false;
        }


        #region DISPOSE
        ~GenericDigitalInterface()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                CallBackGetCarThrottleValueFromRace = null;
                CallBackLogging = null;
                disposed = true;
                if(_handSets != null)
                {
                    _handSets.Dispose();
                    _handSets = null;
                }
            }
}

       #endregion

        #region CONNEXION A LA PB

        public virtual void SetDigitalParams(IDigitalParamsBase digitalParams)
        {
            _digitalParams = digitalParams;
            _digitalParams.PowerBaseMaxThrottleValue = _maxThrotlleValue;
            ResetHandSetList();
        }

        // détection du port de communication ou du matériel digital
        public abstract bool DetectCommand();

        // connexion au matériel.
        public virtual void ConnectToCommand(bool sendResetPacket)
        {
            if (_digitalParams == null || _handSets == null)
                throw new Exception("Les paramètrage digital n'est pas fourni à l'interface, connexion impossible. Information de débuggage : utiliser la méthode SetDigitalParams");
        }

        // fermeture de la connexion au matériel, et suppression des  timers liés aux HandSet.
        public virtual void CloseConnexionCommand()
        {
            _isStarted = false;
            StopHandSetTimers();
        }

        #endregion

        #region COMMANDES TIMER ET POWER


        // démarrage  du  timer 
        public virtual void StartCommand()
        {
          //  if (!IsStarted && IsConnected())
            if (!IsStarted )
            {
                ResetCommand();
                _isStarted = true;
                _isPaused = false;
            }
            StartMainTimer();
        }

        public virtual void StartCountDownCommand()
        {
            StartCountDownCommand();
        }
            

        // démarrage  du  timer 
        public virtual void PauseAfterReconnexionCommand()
        {
            PauseMainTimer();
            _wantToResetConnexion = true;
            _isStarted = false;
            StopHandSetTimers();
            _isStarted = true;
            _isPaused = true;
        }

        

        // reset de tous les éléments liés à une course (timers, chrono global etc.)
        public virtual void ResetCommand()
        {
            _wantToResetConnexion = true;
            _isStarted = false;
            StopHandSetTimers();
            // reset du timer de course interne 
            ResetMainTimer();
        }

        // fin de gestion des handsets par l'application, la PB reprend la main
        public virtual void StopCommand()
        {
            if (IsStarted || !IsConnected())
            {
                StopMainTimer();
                _isStarted = false;
                StopHandSetTimers();
                //SetCallBackGetCarThrottleValueFromRace(null);
            }
        }

        public virtual void PauseCommand()
        {
            if (IsStarted || !IsConnected())
            {
                if (!IsPaused)
                {
                    _isPaused = true;
                    PauseMainTimer();
                }
                else
                    UnPauseCommand();
            }
        }

        public virtual void UnPauseCommand()
        {
            if (IsPaused)
            {
                UnPauseMainTimer();
                _isPaused = false;
            }
        }

        public virtual void SetCurrentCarIdCommand(int Id)
        {
            _idToSet = Id;
            _wantToSetId = true;
        }

        public virtual void ForceGreenFlag()
        {
            OnEndTrackCall(-1);
        }

        public virtual void ForceTrackCall()
        {
            OnTrackCall(-1);
        }

        public void SendCarLights(bool[] carLights)
        {
            _carLights = carLights;
            _wantToSetCarLights = true;
        }

        #endregion


        public virtual void SetCallBackGetCarThrottleValueFromRace(DelegateGetCarThrottleValueFromRace callbackMethod)
        {
            CallBackGetCarThrottleValueFromRace = callbackMethod;
        }

        protected virtual void GetCarDatas(int carId, int throtlleValue, float handsetBrakingForce,bool checkAutoTC, bool gamePadUsed, out int resultThrottle, out CantBrakeEnum canBrake, out bool highAcceleration, out bool strongBrakng, out float brakeAdhesionLoss, out float accelerationAdhesionLoss)
       {
            if (CallBackGetCarThrottleValueFromRace != null)
            {
                if (throtlleValue < _minThrotlleValue)
                    throtlleValue = 0;

                CallBackGetCarThrottleValueFromRace(carId, throtlleValue, handsetBrakingForce, checkAutoTC,gamePadUsed, out resultThrottle, out canBrake, out highAcceleration, out strongBrakng, out brakeAdhesionLoss,out accelerationAdhesionLoss);

                if (resultThrottle > _maxThrotlleValue)
                    resultThrottle = _maxThrotlleValue;
            }
            else
            {
                brakeAdhesionLoss = 0;
                accelerationAdhesionLoss = 0;
                strongBrakng = false;
                highAcceleration = false;
                resultThrottle = throtlleValue;
                canBrake = resultThrottle == 0 ? CantBrakeEnum.CanBrake : CantBrakeEnum.NoBrakeWanted; // dynamic braking systématique si pas de paramètre
            }
        }

        #region EVENTS

        private void StartMainTimer()
        {
            _raceTimer.Start();

            if (TimerStarted != null)
                TimerStarted(this, EventArgs.Empty);
        }

        private void StopMainTimer()
        {
            _raceTimer.Stop();

            if (TimerStoped != null)
                TimerStoped(this, EventArgs.Empty);
        }

        protected virtual void PauseMainTimer()
        {
            _raceTimer.Stop();
            if (TimerPaused != null)
                TimerPaused(this, EventArgs.Empty);
        }
        protected virtual void UnPauseMainTimer()
        {
            _raceTimer.Start();
            if (TimerUnPaused != null)
                TimerUnPaused(this, EventArgs.Empty);
        }

        protected virtual void ResetMainTimer()
        {
            _raceTimer.Reset();

            if (TimerReset != null)
                TimerReset(this, EventArgs.Empty);
        }

        public void OnLapEnded(int laneId, TimeSpan passTime)
        {
            if (LapEnded != null)
                LapEnded(this, new LapEndedEventArgs(laneId, passTime));
        }

        public void OnLapEndedTestTimer(int laneId)
        {
            if (LapEnded != null)
                LapEnded(this, new LapEndedEventArgs(laneId, RaceElapsedTime));
        }

        public virtual void OnTrackCall(int laneId)
        {
            _isTCRunning = true;

            if (TrackCallEvent != null)
                TrackCallEvent(this, new TeamIdEventArgs(laneId));
        }

        public virtual void OnEndTrackCall(int laneId)
        {
            _isTCRunning = false;

            if (EndTrackCallEvent != null)
                EndTrackCallEvent(this, new TeamIdEventArgs(laneId));
        }
        public virtual void OnNonInitHandSetUsedEvent(int laneId)
        {
            _isTCRunning = false;

            if (EndTrackCallEvent != null)
                NonInitHandSetUsedEvent(this, new TeamIdEventArgs(laneId));
        }



        protected void OnHandSetStartClick()
        {
            if (HandSetStartClick != null)
                HandSetStartClick(this, new EventArgs());
        }
        protected void OnHandSetLBPressed(int laneId)
        {
            if (HandSetLBPressed != null)
                HandSetLBPressed(this, new TeamIdEventArgs(laneId));
        }
        protected void OnHandSetRBPressed(int laneId)
        {
            if (HandSetRBPressed != null)
                HandSetRBPressed(this, new TeamIdEventArgs(laneId));
        }

        protected void OnPitStopDo(int laneId)
        {
            if (PitStopDo != null)
                PitStopDo(this, new TeamIdEventArgs(laneId));
        }

        protected void OnPitStopBegin(int laneId)
        {
            if (PitStopBegin != null)
                PitStopBegin(this, new LapEndedEventArgs(laneId, RaceElapsedTime));
        }

        protected void OnPitStopValidatetActio(int laneId)
        {
            if (PitStopValidateAction != null)
                PitStopValidateAction(this, new TeamIdEventArgs(laneId));
        }
        protected void OnPitStopNextAction(int laneId)
        {
            if (PitStopNextAction != null)
                PitStopNextAction(this, new TeamIdEventArgs(laneId));
        }

        protected void OnPitStopPrevAction(int laneId)
        {
            if (PitStopPrevAction != null)
                PitStopPrevAction(this, new TeamIdEventArgs(laneId));
        }
        protected void OnPitStopCancelAction(int laneId)
        {
            if (PitStopCancelAction != null)
                PitStopCancelAction(this, new TeamIdEventArgs(laneId));
        }

        protected virtual void OnDataReceveid(string HexDatas, object dataPacket)
        {
            if (DataReceived != null)
                DataReceived(this, new PBReceiveDataEventArgs(HexDatas, dataPacket));
        }

        protected void OnErrorCatched(string error)
        {
        }




        #endregion EVENTS


        #region GESTION DES HANDSET  (pour TrackCall / PitStop et Throttle)

        private void ResetHandSetList()
        {
            if (_handSets != null)
            {
                int i = _handSets.HandSetList.Count - 1;
                while (i >= 0)
                {
                    _handSets.HandSetList[i].StopAllTimers();
                    _handSets.HandSetList[i].PitStopBegin -= hs_PitStopBegin;
                    _handSets.HandSetList[i].DoPitStop -= hs_DoPitStop;
                    _handSets.HandSetList[i].TrackCall -= hs_TrackCall;
                    _handSets.HandSetList[i].EndOfTrackCall -= hs_EndOfTrackCall;
                    _handSets.HandSetList[i].PitStopNextAction -= Hs_PitStopNextAction;
                    _handSets.HandSetList[i].PitStopValidatetAction -= Hs_PitStopValidatetAction;
                    _handSets.HandSetList[i].PitStopPrevAction -= Hs_PitStopPrevAction;
                    _handSets.HandSetList[i].PitStopCancelAction -= Hs_PitStopCancelAction;
                    _handSets.HandSetList[i].StartEvent -= Hs_StartEvent;
                    _handSets.HandSetList[i].LBPressed -= Hs_LBPressed;
                    _handSets.HandSetList[i].RBPressed -= Hs_RBPressed;



                    _handSets.HandSetList[i].Dispose();
                    _handSets.HandSetList[i] = null;
                    _handSets.HandSetList.RemoveAt(i);
                    i--;
                }
            }
            _handSets = new HandsetList(DigitalParams, maxHandSetCount);
        }


        public void ActivateHandSet(TeamInRaceCollection teams, bool initialCanDoPitStop)
        {
            _blockProcessHandSetPacket = true;
            // on réinitialise l'ensemble des handse
            ResetHandSetList();

            for (int i = 1; i <= 6; i++)
            {
                IHandSet hs = Handsets.Get(i);
                hs.StopAllTimers();


                if (teams.ContainsKey(hs.LaneId))
                {
                    if (teams[hs.LaneId].UseGamePadPlayerIndex.HasValue)
                    {
                        AffectGamePadToLaneId(hs.LaneId, teams[hs.LaneId].UseGamePadPlayerIndex.Value, teams[hs.LaneId].CurrentPilot.GamePadThrottleCurve, teams[hs.LaneId].InCarPro ? teams[hs.LaneId].CurrentPilot.GamePadInCarProBrakeCurve : teams[hs.LaneId].CurrentPilot.GamePadBrakeCurve, teams[hs.LaneId].InCarPro, teams[hs.LaneId].CurrentPilot.VibrationLevel, teams[hs.LaneId].CurrentPilot.VibrationTriggerLevel);
                        hs = Handsets.Get(i);
                    }
                    else if (hs is HandSet)
                        (hs as HandSet).SetThrotthleCurve(teams[hs.LaneId].CurrentPilot.HandsetThrottleCurve);

                }
                // si le handset n'a pas été modifié en GamePad, on peut lui fournir sa courbe de puissance

                hs.IsLaneIdUsed = teams.ContainsKey(hs.LaneId);
                hs.PitStopBegin += hs_PitStopBegin;
                //hs.PitStopEnd += hs_PitStopEnd;
                hs.DoPitStop += hs_DoPitStop;
                hs.TrackCall += hs_TrackCall;
                hs.EndOfTrackCall += hs_EndOfTrackCall;
                hs.PitStopNextAction += Hs_PitStopNextAction;
                hs.PitStopValidatetAction += Hs_PitStopValidatetAction;
                hs.PitStopPrevAction += Hs_PitStopPrevAction;
                hs.PitStopCancelAction += Hs_PitStopCancelAction;
                hs.StartEvent += Hs_StartEvent;
                hs.LBPressed += Hs_LBPressed;
                hs.RBPressed += Hs_RBPressed;

            }
            _blockProcessHandSetPacket = false;
        }



        public void AffectGamePadToLaneId(int laneId, EsrmPlayerIndex gamePadIndex, GamePadThrottleCurve throttleCurve, GamePadThrottleCurve brakeCurve,bool incarPro,double vibrationsLevel, double triggerVibrationsLevel)
        {
            if (!(_handSets.HandSetList[laneId - 1] is GlobalGamePadHandSet))
            {
                Log(string.Format("Création du GamePad {0}", gamePadIndex));
                _handSets.HandSetList[laneId - 1] = GamePadFactory.GetGamePad((EsrmPlayerIndex)gamePadIndex);
                (_handSets.HandSetList[laneId - 1] as GlobalGamePadHandSet).LaneId = laneId;
                (_handSets.HandSetList[laneId - 1] as GlobalGamePadHandSet).IsLaneIdUsed = true;
                (_handSets.HandSetList[laneId - 1] as GlobalGamePadHandSet).SetParams(DigitalParams);
                (_handSets.HandSetList[laneId - 1] as GlobalGamePadHandSet).SetDriverSettings(throttleCurve, brakeCurve, incarPro, vibrationsLevel,triggerVibrationsLevel);
                Log(string.Format("Création du GamePad {0} OK", gamePadIndex));

                Log(string.Format("***** GamePad {0} begin Check State", gamePadIndex));
                (_handSets.HandSetList[laneId - 1] as GlobalGamePadHandSet).CheckStates();
                Log(string.Format("***** GamePad {0} Check State OK", gamePadIndex));
//#if DEBUG
//                if (!IsConnected())
//                {
//                    Log(string.Format("***** GamePad {0} Check State BEGIN LOOP", gamePadIndex));
//                    (_handSets.HandSetList[laneId - 1] as IGamePadHandSet).BeginStateCheck();
//                    Log(string.Format("***** GamePad {0} Check State LOOP Running", gamePadIndex));
//                }
//#endif
            }
            else
            {
                (_handSets.HandSetList[laneId - 1] as GlobalGamePadHandSet).IsLaneIdUsed = true;
                (_handSets.HandSetList[laneId - 1] as GlobalGamePadHandSet).SetParams(DigitalParams);
                (_handSets.HandSetList[laneId - 1] as GlobalGamePadHandSet).SetDriverSettings(throttleCurve, brakeCurve,incarPro, vibrationsLevel, triggerVibrationsLevel);
            }
        }

        private void StopHandSetTimers()
        {
            if (_handSets != null )
            {
                foreach (IHandSet hs in Handsets.HandSetList)
                {
                    hs.StopAllTimers();
                }
            }
        }
        
        protected virtual void CheckForTrackCallOrPitStop(int carId, IHandSet hs, bool laneChangingButtonPressed, bool brakingButtonPressed)
        {
            // si la voie en cours est utilisée et Handset est branché on lance la détection d'un éventuel trackCall ou pitstop
            if (hs.IsLaneIdUsed && hs.IsPlugged )
            {
                hs.LaneChangingPressed = laneChangingButtonPressed;
                hs.Braking = brakingButtonPressed;
            }
        }

        public void StopPitStop(int laneId)
        {
            if (_handSets != null)
            {
                IHandSet hs = _handSets.HandSetList.Find(h => h.LaneId == laneId);
                hs.StopPitStop();
            }
        }


        protected virtual bool NeedToProcessHandsetPacket(IHandSet hs,int throttleValue)
        {
            if (hs == null)
                return false;

            if (hs.IsPlugged && !hs.IsLaneIdUsed && throttleValue > 5)
                OnNonInitHandSetUsedEvent(hs.LaneId);

            // si le Handset est branché ou si la voie est utilisée, on s'occupe du HandSet
            if (hs.IsPlugged || hs.IsLaneIdUsed)
                return true;

            return false;
        }

        protected virtual bool NeedToProcessGamePadHandsetPacket(GlobalGamePadHandSet hs)
        {
            if (hs == null)
                return false;

            // si le Handset est branché ou si la voie est utilisée, on s'occupe du HandSet
            if (hs.IsPlugged || hs.IsLaneIdUsed)
                return true;

            return false;
        }


        #region EVENTS ISSUES DES HandSets

        void hs_PitStopBegin(object sender, EventArgs e)
        {
            IHandSet hs = sender as IHandSet;
            OnPitStopBegin(hs.LaneId);
        }

        public void RefusePitStop(int laneId)
        {
            Handsets.Get(laneId).PitStopRunning = false;
        }

        //void hs_PitStopEnd(object sender, EventArgs e)
        //{
        //    HandSet hs = sender as HandSet;
        //    OnPitStopEnd(hs.LaneId);
        //}

        void Hs_StartEvent(object sender, EventArgs e)
        {
            OnHandSetStartClick();
        }

        private void Hs_LBPressed(object sender, EventArgs e)
        {
            IHandSet hs = sender as IHandSet;
            OnHandSetLBPressed(hs.LaneId);
        }
        private void Hs_RBPressed(object sender, EventArgs e)
        {
            IHandSet hs = sender as IHandSet;
            OnHandSetRBPressed(hs.LaneId);
        }

        void hs_DoPitStop(object sender, EventArgs e)
        {
            IHandSet hs = sender as IHandSet;
            OnPitStopDo(hs.LaneId);
        }



        void hs_EndOfTrackCall(object sender, EventArgs e)
        {
            OnEndTrackCall((sender as IHandSet).LaneId);
        }

        void hs_TrackCall(object sender, EventArgs e)
        {
            OnTrackCall((sender as IHandSet).LaneId);
        }

        private void Hs_PitStopCancelAction(object sender, EventArgs e)
        {
            IHandSet hs = sender as IHandSet;
            OnPitStopCancelAction(hs.LaneId);
        }

        private void Hs_PitStopPrevAction(object sender, EventArgs e)
        {
            IHandSet hs = sender as IHandSet;
            OnPitStopPrevAction(hs.LaneId);
        }

        private void Hs_PitStopValidatetAction(object sender, EventArgs e)
        {
            IHandSet hs = sender as IHandSet;
            OnPitStopValidatetActio(hs.LaneId);
        }

        private void Hs_PitStopNextAction(object sender, EventArgs e)
        {
            IHandSet hs = sender as IHandSet;
            OnPitStopNextAction(hs.LaneId);
        }

        #endregion GESTION DES PIT STOPS


        public virtual void TeamIsInPitLane(int laneId, bool isInPitLane)
        {
            _handSets.Get(laneId).CanDoPitStop = isInPitLane;
            if (_handSets.Get(laneId) is GlobalGamePadHandSet)
            {
                if(isInPitLane)
                    (_handSets.Get(laneId) as GlobalGamePadHandSet).InformationVibrations(RumblesEventsEnums.PitLaneIn);
                else
                    (_handSets.Get(laneId) as GlobalGamePadHandSet).InformationVibrations(RumblesEventsEnums.PitLaneOut);
            }
        }


        #endregion GESTION DES HANDSET  (pour TrackCall / PitStop et Throttle)

        #region LOGGING

        public virtual void SetCallBackLogging(DelegateErrorLog callbackMethod)
        {
            CallBackLogging = callbackMethod;
        }

        protected void Log(string message)
        {
            if(_logging)
            {
                CallBackLogging(message);
            }
        }

        #endregion LOGGING
    }
}
