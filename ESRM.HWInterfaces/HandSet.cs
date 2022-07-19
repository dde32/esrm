using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRM.Entities;

namespace ESRM.HWInterfaces
{
    public class HandSet : IDisposable, IHandSet
    {
        #region TIMER POUR TC, PIT ...
        TimerForHandSet_Braking _brakingTimer;
        TimerForHandSet_LaneChanging _lcTimer;
        TimerForPitStop _pitTimer;
        public TimerForHandSet BrakingTimer { get { return _brakingTimer; } }
        public TimerForHandSet LCTimer { get { return _lcTimer; } }
        public TimerForHandSet PitTimer { get { return _pitTimer; } }

        TimeSpan _brakingDuration;
        TimeSpan _laneChangingDuration;
        TimeSpan _pitStopBeginTime;
        #endregion TIMERS

        #region fields
        IDigitalParamsBase _digitalParams;
        bool _brakingButtonPressed = false;// utilisé  pour les TC et PITSTOPS, par pour la gestion du frein dynamique
        bool _laneChangingButtonPressed = false;
        bool _tcButtonReleased;
        HandsetThrottleCurve _throttleCurve;

        public event EventHandler TrackCall;
        public event EventHandler EndOfTrackCall;
        public event EventHandler PitStopBegin;
        //public event EventHandler PitStopEnd;
        public event EventHandler DoPitStop;
        public event EventHandler PitStopValidatetAction;
        public event EventHandler PitStopNextAction;
        public event EventHandler PitStopCancelAction;
        // non disponible sur un handSet classique
        public event EventHandler PitStopPrevAction;
        public event EventHandler StartEvent;
        public event EventHandler LBPressed;
        public event EventHandler RBPressed;


        #endregion #region fields

        #region PROPERTIES

        public IDigitalParamsBase DigitalParams
        {
            get { return _digitalParams; }
        }

        public int LaneId { get; set; }
        public bool IsLaneIdUsed { get; set; }
        public bool IsPlugged { get; set; }
        public bool CanDoPitStop { get; set; }
        public int Throttle { get; set; }


        public bool TrackCallRunning { get; set; }
        public bool PitStopRunning { get; set; }

        //public TimeSpan BrakingDuration
        //{
        //    get { return _brakingDuration; }
        //}

        public bool Braking
        {
            get { return _brakingButtonPressed; }
            set
            {
                if (_brakingButtonPressed != value)
                {
                    _brakingButtonPressed = value;

                    if (_brakingButtonPressed && IsLaneIdUsed)
                        InitBrakingDuration();

                    if (BrakingTimer.Enabled && !_brakingButtonPressed)
                        BrakingTimer.Stop();
                    else if (_brakingButtonPressed)
                        BrakingTimer.StartIfNeeded();


                    VerifyTrackCallAndPitInState();
                }
            }
        }

        public double BrakingForceCoef
        {
            get { return _brakingButtonPressed ? 1 : 0; }
        }


        public bool LaneChangingPressed
        {
            get { return _laneChangingButtonPressed; }
            set
            {
                if (_laneChangingButtonPressed != value)
                {
                    _laneChangingButtonPressed = value;

                    if (_laneChangingButtonPressed && IsLaneIdUsed)
                        InitLaneChangingDuration();

                    if (LCTimer.Enabled && !_laneChangingButtonPressed)
                        LCTimer.Stop();
                    else if (LaneChangingPressed)
                        LCTimer.StartIfNeeded();


                    VerifyTrackCallAndPitInState();
                }
            }
        }

        #endregion PROPERTIES

        #region DISPOSE
        ~HandSet()
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
                if (_brakingTimer != null)
                {
                    _brakingTimer.Dispose();
                    _brakingTimer = null;
                }
                if (_lcTimer != null)
                {
                    _lcTimer.Dispose();
                    _lcTimer = null;
                }
                if (_pitTimer != null)
                {
                    _pitTimer.Dispose();
                    _pitTimer = null;
                }
            }
        }
        #endregion

        public HandSet( IDigitalParamsBase digitalParams ,int laneId)
        {
            _digitalParams = digitalParams;
            LaneId = laneId;
            IsLaneIdUsed = false;
            _tcButtonReleased = false;
            CanDoPitStop = true;

            _brakingTimer = new TimerForHandSet_Braking(this);
            _lcTimer = new TimerForHandSet_LaneChanging(this);
            _pitTimer = new TimerForPitStop(this);
        }

        public void SetThrotthleCurve(HandsetThrottleCurve throttleCurve)
        {
            _throttleCurve = throttleCurve;
        }

        public int TranslateThrottleFromCurve(int triggerValue)
        {
            int result = 0;

            if (_throttleCurve != null)
            {
                if (triggerValue >= _throttleCurve.MaxTriggerValue)
                    result = _throttleCurve.Values.Max(t => t.ResultValue);
                else if (triggerValue <= _throttleCurve.MinTriggerValue)
                    result = _throttleCurve.Values.Min(t => t.ResultValue);
                else
                    result = _throttleCurve.Values.First(t => t.Value >= triggerValue).ResultValue;
            }
            else
                result = triggerValue;

            return result;
        }

        #region GESTION DES DUREE DE FREINAGE ET LANE CHANGING POUR PIT STOP ET TRACKCALLS

        public void ProcessDoPitStop()
        {
            OnDoPitStop();
        }

        private void InitBrakingDuration()
        {
            _brakingDuration = new TimeSpan();
        }

        private void InitLaneChangingDuration()
        {
            _laneChangingDuration = new TimeSpan();
        }

        public void AddLCDuration(TimeSpan interval)
        {
            // todo : Voir si on ne devrait pas ajouter du temps que si les gaz sont à 0 
            _laneChangingDuration += interval;
            VerifyTrackCallAndPitInState();
        }

        public void AddBrakingDuration(TimeSpan interval)
        {
            // todo : Voir si on ne devrait pas ajouter du temps que si les gaz sont à 0 
            _brakingDuration  += interval;
            VerifyTrackCallAndPitInState();
        }

        void VerifyTrackCallAndPitInState()
        {
            if (!IsLaneIdUsed)
                return;

            // PITSTOP
            // si on freine, pas de gaz, que le délai avant pitstop est dépassé et qu'on est pas en YellowFlag, on démarre le pit stop.
            CheckForPitStopStart();
            CheckForPitStopSelectOrCancel();
            CheckTrackCall();
        }

        private void CheckForPitStopStart()
        {
            if (PitStopRunning || TrackCallRunning || !CanDoPitStop)
                return;

            // si on rentre en mode pitStop avec le bouton brake
            if (_digitalParams.PitInMethod == PitInMethodEnum.Brake)
            {
                if (Braking && Throttle <= 1 && _digitalParams.PitInPressDelay <= _brakingDuration.TotalMilliseconds && !LaneChangingPressed)
                {
                    if (!PitStopRunning)
                        OnPitStopBegin();
                }
            }
            else if (_digitalParams.PitInMethod == PitInMethodEnum.LC)
            {
                if (LaneChangingPressed && Throttle <= _digitalParams.SeuilZeroGaz && _digitalParams.PitInPressDelay <= _laneChangingDuration.TotalMilliseconds && !Braking)
                {
                    if (!PitStopRunning)
                        OnPitStopBegin();
                }
            }
            else if (_digitalParams.PitInMethod == PitInMethodEnum.LCAndBrake)
            {
                if (Braking && LaneChangingPressed && Throttle <= _digitalParams.SeuilZeroGaz && _digitalParams.PitInPressDelay <= _brakingDuration.TotalMilliseconds )
                {
                    if (!PitStopRunning)
                        OnPitStopBegin();
                }
            }
        }


        private void CheckForPitStopSelectOrCancel()
        {
            if (!PitStopRunning || TrackCallRunning) 
                return;

            if (DateTime.Now.TimeOfDay.TotalMilliseconds > _pitStopBeginTime.TotalMilliseconds + 250)
            {
                // si on rentre en mode pitStop avec le bouton brake
                if (LaneChangingPressed)
                    OnPitStopCancelAction();
                else if (Braking)
                    OnPitStopSelectAction();
            }
        }
        public void CheckForActions()
        {
            if (!PitStopRunning || TrackCallRunning) 
                return;

            if (DateTime.Now.TimeOfDay.TotalMilliseconds > _pitStopBeginTime.TotalMilliseconds + 250)
            {
                if (Throttle > 35 )
                    OnPitStopValidateAction();
            }
        }


        private void CheckTrackCall()
        {
            if (PitStopRunning)
                return;

            if (!TrackCallRunning) // pas encore de TC 
            {
                // TrackCall si frein et pas de gaz 
                if (_digitalParams.TrackCallMethod == TrackCallMethodEnum.BrakeAndZGaz && Throttle <= _digitalParams.SeuilZeroGaz && Braking && _digitalParams.TrackCallPressDelay <= _brakingDuration.TotalMilliseconds && !LaneChangingPressed)
                    OnTrackCall();
                // TrackCall si frein et Lane Changing 
                else if (_digitalParams.TrackCallMethod == TrackCallMethodEnum.LCAndBrake && Braking && LaneChangingPressed && _digitalParams.TrackCallPressDelay <= _brakingDuration.TotalMilliseconds )
                    OnTrackCall();
                // TrackCall si frein et Lane Changing et 0 gaz (sans délai)
                else if (_digitalParams.TrackCallMethod == TrackCallMethodEnum.LCAndBrakeAndZGaz && Braking && LaneChangingPressed && Throttle <= _digitalParams.SeuilZeroGaz && _digitalParams.TrackCallPressDelay <= _laneChangingDuration.TotalMilliseconds)
                    OnTrackCall();
            }
            else if (_digitalParams.AutoGreenFlag && TrackCallRunning ) // remise du drapeau vert automatiquement
            {
                if (!_tcButtonReleased)
                {
                    if (_digitalParams.TrackCallMethod == TrackCallMethodEnum.BrakeAndZGaz)
                        _tcButtonReleased = !Braking;
                    else 
                        _tcButtonReleased = !Braking && !LaneChangingPressed;
                }

                if (_tcButtonReleased)
                {
                    // TrackCall si frein et pas de gaz 
                    if (_digitalParams.TrackCallMethod == TrackCallMethodEnum.BrakeAndZGaz && Braking)
                        OnEndOfTrackCall();
                    // TrackCall si frein et Lane Changing 
                    else if (_digitalParams.TrackCallMethod == TrackCallMethodEnum.LCAndBrake && Braking && LaneChangingPressed)
                        OnEndOfTrackCall();
                    // TrackCall si frein et Lane Changing et 0 gaz (sans délai)
                    else if (_digitalParams.TrackCallMethod == TrackCallMethodEnum.LCAndBrakeAndZGaz && Braking && LaneChangingPressed)
                        OnEndOfTrackCall();
                }
            }
        }

        public void OnDoPitStop()
        {
             if (DoPitStop != null)
                DoPitStop(this, EventArgs.Empty);
        }

        private void OnTrackCall()
        {
            TrackCallRunning = true;
            _tcButtonReleased = false;

            if (TrackCall != null)
                TrackCall(this, EventArgs.Empty);
        }

        private void OnEndOfTrackCall()
        {
            _pitStopBeginTime = new TimeSpan() ;
            TrackCallRunning = false;
            _tcButtonReleased = false;

            if (EndOfTrackCall != null)
                EndOfTrackCall(this, EventArgs.Empty);
        }

        private void OnPitStopBegin()
        {
            PitStopRunning = true;
            PitTimer.Start();
            _pitStopBeginTime = DateTime.Now.TimeOfDay;

            _laneChangingDuration = new TimeSpan();
            _brakingDuration = new TimeSpan();

            if (PitStopBegin != null)
                PitStopBegin(this, EventArgs.Empty);
        }

        public void StopPitStop()
        {
            _laneChangingDuration = new TimeSpan();
            _brakingDuration = new TimeSpan();
            PitTimer.Stop();
            PitStopRunning = false;

        }

        //private void OnPitStopEnd()
        //{
        //    StopPitStop();
        //    if (PitStopEnd != null)
        //        PitStopEnd(this, EventArgs.Empty);
        //}

        private void OnPitStopSelectAction()
        {
            _laneChangingDuration = new TimeSpan();
            _brakingDuration = new TimeSpan();

            if (PitStopNextAction != null)
                PitStopNextAction(this, EventArgs.Empty);
        }

        private void OnPitStopValidateAction()
        {
            _laneChangingDuration = new TimeSpan();
            _brakingDuration = new TimeSpan();

            if (PitStopValidatetAction != null)
                PitStopValidatetAction(this, EventArgs.Empty);
        }

        private void OnPitStopCancelAction()
        {
            _laneChangingDuration = new TimeSpan();
            _brakingDuration = new TimeSpan();

            if (PitStopCancelAction != null)
                PitStopCancelAction(this, EventArgs.Empty);
        }

        #endregion

        public void StopAllTimers()
        {
            _brakingTimer.Stop();
            _lcTimer.Stop();
            _pitTimer.Stop();
        }

    }
}
