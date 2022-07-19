using ESRM.Entities;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ESRM.HWInterfaces.X360
{
    public class GamePadHandSet : ESRMGamePad, IHandSet
    {

        #region TIMER POUR TC, PIT ...
        System.Timers.Timer _inPitTimer;

        TimeSpan _pitStopBeginTime;

        double _tcBeginPressTime;

        #endregion TIMERS


        #region fields
        IDigitalParamsBase _digitalParams;
        GamePadThrottleCurve _brakeCurve;
        GamePadThrottleCurve _throttleCurve;
        List<BrakeTriggerValue> _brakeForceValues;


        int _throttle;
        bool _tcButtonWasReleased;

        int _maxBrakeIntervals = GlobalDatas.BTV_1.BrakeCycle;
        int _brakeCycleElapsed = 0;
        int _lostBrakeCount;
        BrakeTriggerValue _currentBrakeTriggerValue;
        //int _brakeIntervalElapsed;
        //int _brakeInterval = 0;
        bool _braking;
        Random randomBrakeLost;
        #endregion #region fields

        #region events

        public event EventHandler TrackCall;
        public event EventHandler EndOfTrackCall;
        public event EventHandler PitStopBegin;
        public event EventHandler DoPitStop;
        public event EventHandler PitStopValidatetAction;
        public event EventHandler PitStopNextAction;
        public event EventHandler PitStopPrevAction;
        public event EventHandler PitStopCancelAction;
        public event EventHandler StartEvent;


        #endregion


        #region PROPERTIES

        public int LaneId
        {
            get;
            set;
        }
        public bool IsLaneIdUsed
        {
            get;
            set;
        }

        public bool IsPlugged
        {
            get
            {
                return true;
            }
            set { }
        }

        public bool TrackCallRunning
        {
            get;
            set;
        }
        public bool PitStopRunning
        {
            get;
            set;
        }

        public bool CanDoPitStop { get; set; }

        public int Throttle
        {
            get { return _throttle; }
            set { }
        }

        public bool LaneChangingPressed
        {
            get { return _isButtonA_Pressed || _isDpad_Pressed; }
            set { }
        }

        public bool StartPressed
        {
            get { return _isButtonStart_Pressed; }
            set { }
        }

        public bool Braking
        {
            get { return _braking; }
            set { }
        }

        public float BrakingForce
        {
            get { return _currentBrakeTriggerValue.BrakeValue; }
        }


        #endregion PROPERTIES

        public GamePadHandSet(int playerIndex) : base(playerIndex)
        {
            _inPitTimer = new System.Timers.Timer();
            _inPitTimer.Interval = 500;
            _inPitTimer.Elapsed += PitTimer_Elapsed;

            randomBrakeLost = new Random();
            CanDoPitStop = true;
            _brakeForceValues = new List<BrakeTriggerValue>();
            _brakeForceValues.Add(GlobalDatas.BTV_0);
            _brakeForceValues.Add(GlobalDatas.BTV_1);
            _brakeForceValues.Add(GlobalDatas.BTV_2);
            _brakeForceValues.Add(GlobalDatas.BTV_3);
            _brakeForceValues.Add(GlobalDatas.BTV_4);
            _brakeForceValues.Add(GlobalDatas.BTV_5);
            _brakeForceValues.Add(GlobalDatas.BTV_6);
            _brakeForceValues.Add(GlobalDatas.BTV_7);
            _brakeForceValues.Add(GlobalDatas.BTV_8);
            _brakeForceValues.Add(GlobalDatas.BTV_9);
            _brakeForceValues.Add(GlobalDatas.BTV_10);
            _currentBrakeTriggerValue = _brakeForceValues[0];

        }


        public void SetParams(IDigitalParamsBase digitalParams)
        {
            _digitalParams = digitalParams;
            CanDoPitStop = true;
        }

        public void SetTriggersCurves(GamePadThrottleCurve thCurve, GamePadThrottleCurve brakeCurve)
        {
            if (thCurve != null && thCurve.Values.Count == 0)
                _throttleCurve = null;
            else
                _throttleCurve = thCurve;
            if (brakeCurve != null && brakeCurve.Values.Count == 0)
                _brakeCurve = null;
            else
                _brakeCurve = brakeCurve;

            if (_brakeCurve != null)
            {
                _maxBrakeIntervals = _brakeCurve.Values.Max(t => t.ResultValue);
                //_continuousBrakeCount = _brakeCurve.ContinuousBrakeCount > 0 ? _brakeCurve.ContinuousBrakeCount : 1 ;
            }
            else
                _maxBrakeIntervals = GlobalDatas.MaxBrakeInterval;
        }


        private void PitTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            OnDoPitStop();
        }

        #region TC EVENTS

        private void BeginTrackCallIfPossible()
        {
            if (PitStopRunning)
                return;

            if (!TrackCallRunning) // pas encore de TC 
                OnTrackCall();
        }

        private void EndTrackCallIfNeeded()
        {
            if (PitStopRunning)
                return;

            if (!TrackCallRunning) // pas encore de TC 
            {
                OnTrackCall();
            }
            else if (_digitalParams.AutoGreenFlag && TrackCallRunning) // remise du drapeau vert automatiquement
            {
                if (_tcButtonWasReleased)
                {
                    OnEndOfTrackCall();
                }
            }
        }

        private void OnTrackCall()
        {
            TrackCallRunning = true;
            _tcButtonWasReleased = false;

            if (TrackCall != null)
                TrackCall(this, EventArgs.Empty);
        }

        private void OnEndOfTrackCall()
        {
            _pitStopBeginTime = new TimeSpan();
            TrackCallRunning = false;
            _tcButtonWasReleased = false;

            if (EndOfTrackCall != null)
                EndOfTrackCall(this, EventArgs.Empty);
        }

        #endregion



        #region ACCELERATION

        protected override void CheckInput_RightTrigger(GamePadState currentState)
        {
            _rightTriggerValue = currentState.Triggers.Right;

            CalculThrottleFromCurve();

            OnRightTriggerValueChanged();
        }

        private void CalculThrottleFromCurve()
        {
            if (_throttleCurve != null)
            {
                if (_rightTriggerValue >= _throttleCurve.MaxTriggerValue)
                    _throttle = _throttleCurve.Values.Max(t => t.ResultValue);
                else if (_rightTriggerValue <= _throttleCurve.MinTriggerValue)
                    _throttle = _throttleCurve.Values.Min(t => t.ResultValue);
                else
                    _throttle = _throttleCurve.Values.First(t => t.Value >= _rightTriggerValue).ResultValue;
            }
            else
                _throttle = (int)(_rightTriggerValue * 63.0);

            //if (_throttle > 50)
            //    OnPitStopValidateAction();
        }

        #endregion 


        #region GESTION DU FREIN PROGRESSIF 



        protected override void CheckInput_LeftTrigger(GamePadState currentState)
        {
            _leftTriggerValue = currentState.Triggers.Left;
            int bf = 0;
            if (_brakeCurve != null)
                bf = _brakeCurve.Values.First(b => b.Value >= _leftTriggerValue).ResultValue;
            else
                bf = (int)(_leftTriggerValue * _maxBrakeIntervals);

            _currentBrakeTriggerValue = _brakeForceValues[bf];

            //    UpdateBrakingIntervall();

            OnLeftTriggerValueChanged();
        }

        //private void UpdateBrakingIntervall()
        //{
        //    //if (_brakeCurve != null)
        //    //    _brakeInterval = _brakeCurve.Values.First(b => b.Value >= BrakingForce).ResultValue;
        //    //else
        //    //    _brakeInterval = _maxBrakeIntervals - (int)((BrakingForce * 100.0) / _maxBrakeIntervals);
        //}

        public bool DoNeedBrake(float brakeAdhesionLoss)
        {
            // si aucune force de freinage demandée, alors on remet à 0 les compteurs
            if (_currentBrakeTriggerValue.BrakeForce == 0)
            {
                ResetBrakingIntervalls();
                return false;
            }
            else // sinon, c'est qu'il y a demande de freinage
            {
                _braking = _lostBrakeCount >= _currentBrakeTriggerValue.BrakeCycle - _currentBrakeTriggerValue.EffectiveBrake;

                _brakeCycleElapsed++;
                if (_brakeCycleElapsed >= _currentBrakeTriggerValue.BrakeCycle)
                    _lostBrakeCount = 0;

                // ca freine
                if (!_braking)
                    _lostBrakeCount++;
                else
                {
                    // COmment prendre en compte la perte d'adhérence ?
                    // on fait un random pour déterminer si oui ou non la perte de grip annule le frein
                    if (brakeAdhesionLoss > 0 && randomBrakeLost.Next(0, 100) < (int)(brakeAdhesionLoss * 100))
                        _braking = false;
                }

                return _braking;
            }
        }

        // une fois que la poignée ne demande plus de frein, on reset tout
        public void ResetBrakingIntervalls()
        {
            _brakeCycleElapsed = 0;
            _lostBrakeCount = 0;


            //_brakeIntervalElapsed = 0;
            //_brakeInterval = 0;
            //_continuousBrakeCountElapsed = 0;
            _braking = false;
        }



        #endregion

        #region GESTION DU PIT STOP


        private void OnTryPitStopBegin()
        {
            if (TrackCallRunning)
                return;

            if (!PitStopRunning && CanDoPitStop)
            {
                PitStopRunning = true;
                _inPitTimer.Start();
                _pitStopBeginTime = DateTime.Now.TimeOfDay;

                if (PitStopBegin != null)
                    PitStopBegin(this, EventArgs.Empty);
            }
        }

        public void OnDoPitStop()
        {
            if (DoPitStop != null)
                DoPitStop(this, EventArgs.Empty);
        }

        public void StopPitStop()
        {
            _inPitTimer.Stop();
            PitStopRunning = false;
        }

        public void CheckForPitStopValidate()
        {
            if (!PitStopRunning || TrackCallRunning)
                return;

            if (DateTime.Now.TimeOfDay.TotalMilliseconds > _pitStopBeginTime.TotalMilliseconds + 250)
            {
                if (Throttle > 0)
                    OnPitStopValidateAction();
            }
        }

        private void OnPitStopValidateAction()
        {
            if (PitStopValidatetAction != null)
                PitStopValidatetAction(this, EventArgs.Empty);
        }
        private void OnPitStopNextAction()
        {
            if (PitStopNextAction != null)
                PitStopNextAction(this, EventArgs.Empty);
        }
        private void OnPitStopPrevAction()
        {
            if (PitStopPrevAction != null)
                PitStopPrevAction(this, EventArgs.Empty);
        }

        private void OnPitStopCancelAction()
        {
            if (PitStopCancelAction != null)
                PitStopCancelAction(this, EventArgs.Empty);
        }


        private bool CheckPitStopAction()
        {
            if (!PitStopRunning || TrackCallRunning)
                return false;

            if (DateTime.Now.TimeOfDay.TotalMilliseconds > _pitStopBeginTime.TotalMilliseconds + 500)
                return true;

            return false;
        }

        protected override void OnButtonXPressed()
        {

            OnTryPitStopBegin();

            base.OnButtonXPressed();
        }

        protected override void OnButtonAPressed()
        {
            if (CheckPitStopAction())
                OnPitStopValidateAction();

            base.OnButtonAPressed();
        }

        protected override void OnButtonBPressed()
        {
            if (CheckPitStopAction())
                OnPitStopCancelAction();

            base.OnButtonBPressed();
        }

        protected override void OnButtonLSPressed()
        {
            if (CheckPitStopAction())
                OnPitStopPrevAction();
            base.OnButtonLSPressed();
        }

        protected override void OnButtonRSPressed()
        {
            if (CheckPitStopAction())
                OnPitStopNextAction();
            base.OnButtonRSPressed();
        }


        public void StopAllTimers()
        {
            _inPitTimer.Stop();
        }

        #endregion

        #region BUTTONS STATE CHECK OVERRIDES

        protected override void CheckInput_A(GamePadState currentState)
        {
            if (!_isButtonA_Pressed && currentState.Buttons.A == ButtonState.Pressed)
            {
                _isButtonA_Pressed = true;
                OnButtonAPressed();
            }
            else if (currentState.Buttons.A == ButtonState.Released)
            {
                _isButtonA_Pressed = false;
            }
        }

        protected override void CheckInput_B(GamePadState currentState)
        {

            if (!_isButtonB_Pressed && currentState.Buttons.B == ButtonState.Pressed)
            {
                _isButtonB_Pressed = true;
                OnButtonBPressed();
            }
            else if (currentState.Buttons.B == ButtonState.Released)
                _isButtonB_Pressed = false;
        }

        protected override void CheckInput_Y(GamePadState currentState)
        {
            if (currentState.Buttons.Y == ButtonState.Pressed)
            {
                if (!_isButtonY_Pressed)
                {
                    _isButtonY_Pressed = true;
                    OnButtonYPressed();
                }
                if (!TrackCallRunning && DateTime.Now.TimeOfDay.TotalMilliseconds >= (_tcBeginPressTime + (double)_digitalParams.TrackCallPressDelay))
                {
                    BeginTrackCallIfPossible();
                }
                else if (TrackCallRunning && _tcButtonWasReleased)
                    EndTrackCallIfNeeded();
            }
            else if (currentState.Buttons.Y == ButtonState.Released)
            {
                _isButtonY_Pressed = false;
                if (TrackCallRunning && !_tcButtonWasReleased)
                    _tcButtonWasReleased = true;
            }
        }

        protected override void CheckInput_X(GamePadState currentState)
        {
            if (!_isButtonX_Pressed && currentState.Buttons.X == ButtonState.Pressed)
            {
                _isButtonX_Pressed = true;
                OnButtonXPressed();
            }
            else if (currentState.Buttons.X == ButtonState.Released)
                _isButtonX_Pressed = false;
        }


        protected override void CheckInput_LB(GamePadState currentState)
        {
            if (!_isButtonLB_Pressed && currentState.Buttons.LeftShoulder == ButtonState.Pressed)
            {
                _isButtonLB_Pressed = true;
                OnButtonLSPressed();
            }
            else if (currentState.Buttons.LeftShoulder == ButtonState.Released)
                _isButtonLB_Pressed = false;
        }

        protected override void CheckInput_RB(GamePadState currentState)
        {
            if (!_isButtonRB_Pressed && currentState.Buttons.RightShoulder == ButtonState.Pressed)
            {
                _isButtonRB_Pressed = true;
                OnButtonRSPressed();
            }
            else if (currentState.Buttons.RightShoulder == ButtonState.Released)
                _isButtonRB_Pressed = false;
        }

        protected override void OnButtonStartPressed()
        {
            base.OnButtonStartPressed();
            if (StartEvent != null)
                StartEvent(this, EventArgs.Empty);
        }

        protected override void OnButtonYPressed()
        {
            _tcBeginPressTime = DateTime.Now.TimeOfDay.TotalMilliseconds;
            base.OnButtonYPressed();
        }
        #endregion

        public void WarningVibration(float valueLeft, float valueRight)
        {
            //    Thread thread = new Thread(() => WarningVibrationInternal(value));
            //    thread.Priority = ThreadPriority.Normal;
            //    thread.Start();
            //}

            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.DoWork += worker_DoWork;
            VibrationValues values = new VibrationValues() { LeftValue = valueLeft, RightValue = valueRight };
            worker.RunWorkerAsync(values);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            (sender as BackgroundWorker).Dispose();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            WarningVibrationInternal((VibrationValues)e.Argument);
            //DoEndOfLap((e.Argument as LapEndedEventArgs).LaneId, (e.Argument as LapEndedEventArgs).PassTime);
        }

        private void WarningVibrationInternal(VibrationValues values)
        {
            if (values.LeftValue > _digitalParams.VibrationsLeftMotorMaxValue && _digitalParams.VibrationsLeftMotorMaxValue > 0)
                values.LeftValue = _digitalParams.VibrationsLeftMotorMaxValue;
            if (values.RightValue > _digitalParams.VibrationsRightMotorMaxValue && _digitalParams.VibrationsRightMotorMaxValue > 0)
                values.RightValue = _digitalParams.VibrationsRightMotorMaxValue;

            TimeSpan begintime = DateTime.Now.TimeOfDay.Add(new TimeSpan(0, 0, 0, 0, 1500));

            SetVibration(values.LeftValue, values.RightValue);
            while (DateTime.Now.TimeOfDay.TotalMilliseconds < begintime.TotalMilliseconds)
            {
                // nothing
            }
            SetVibration((float)0, (float)0);
        }
    }

    class VibrationValues
    {
        public float LeftValue { get; set; }
        public float RightValue { get; set; }
    }
}
