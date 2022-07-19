using ESRM.Entities;
using ESRM.GamePads;
using ESRM.GamePads.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ESRM.GamePads
{
    public class GlobalGamePadHandSet :  IHandSet, IGamePadHandSet,IDisposable
    {
        #region Application Settings
        double _vibrationsLevel;
        double _vibrationsTriggerLevel;
        bool _autoGreenFlag;
        double _trackCallPressDelay;
        bool _waitingForPitStop;
        double _tiresRumblesLevel;
        double _healthRumblesLevel;
        double _fuelRumblesLevel;
        #endregion Application Setting

        #region TIMER POUR TC, PIT ...

        System.Timers.Timer _inPitTimer;
        TimeSpan _pitStopBeginTime;
        DateTime _lastStartEvent;
        DateTime _lastTCEvent;

        #endregion TIMERS


        #region fields

        IESRMGamePad _esrmGamePad;

        GamePadThrottleCurve _brakeCurve;
        GamePadThrottleCurve _throttleCurve;
        
        int _throttleValue;
        int _brakeForceValue;
        bool _tcButtonWasReleased;

        // For Non InCarPro progressive braking
        List<BrakeTriggerValue> _brakeForceValues;
        int _maxBrakeIntervals = GlobalDatas.BTV_1.BrakeCycle;
        int _brakeCycleElapsed = 0;
        int _lostBrakeCount;
        BrakeTriggerValue _currentBrakeTriggerValue;
        Random randomBrakeLost;
        bool _braking;

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
        public event EventHandler LBPressed;
        public event EventHandler RBPressed;

        public event EventHandler Down;
        public event EventHandler Up;
        public event EventHandler Left;
        public event EventHandler Right;
        public event EventHandler ButtonAPressed;
        public event EventHandler ButtonBPressed;
        

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

        public bool InCarPro
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



        public bool LaneChangingPressed
        {
            get { return _esrmGamePad != null && _esrmGamePad.IsButtonA_Pressed || _esrmGamePad.IsDpad_Pressed; }
            set { }
        }

        public bool StartPressed
        {
            get { return _esrmGamePad != null && _esrmGamePad.IsButtonStart_Pressed; }
            set { }
        }

        public int Throttle
        {
            get { return _throttleValue; }
            set { }
        }
        public double ThrottleCoef
        {
            get { return (double)(_throttleValue / GlobalDatas.POWERBASEMAXTHROTTLEVALUE); }
        }

        public bool Braking
        {
            get { return _braking; }
            set { }
        }

        // Valeur comprise entre 0 et 63 (si InCarPro) ou entre 0 et 10 si SDD classique.
        // cette valeur est utilisée pour envoyer à la PB
        //public int BrakingForceValue
        //{
        //    get
        //    {
        //        return _brakeForceValue;
        //    }
        //}

        public int InCarProBrakingForceValue
        {
            get
            {
                return (GlobalDatas.POWERBASEMAXTHROTTLEVALUE - _brakeForceValue);
            }
        }

        // Coefficient de freinage, utilisé pour les calculs de perte d'adhérence
        public double BrakingForceCoef
        {
            get
            {
                if (LeftTriggerValue < 0.05)
                    return 0;

               if (_currentBrakeTriggerValue != null)
                    return _currentBrakeTriggerValue.BrakeForceCoef;
                else
                {
                    return ((double)_brakeForceValue / (double)GlobalDatas.POWERBASEMAXTHROTTLEVALUE);
                }
            }
        }


        public double LeftTriggerValue
        {
            get { return _esrmGamePad != null ? _esrmGamePad.LeftTriggerValue : 0; }
        }
        public double RightTriggerValue
        {
            get { return _esrmGamePad != null ? _esrmGamePad.RightTriggerValue : 0; }
        }

        public double LeftThumbstickX
        {
            get { return _esrmGamePad != null ? _esrmGamePad.LeftThumbstickX : 0; }
        }

        public double LeftThumbstickY
        {
            get { return _esrmGamePad != null ? _esrmGamePad.LeftThumbstickY : 0; }
        }

        public double RightThumbstickX
        {
            get { return _esrmGamePad != null ? _esrmGamePad.RightThumbstickX : 0; }
        }
        public double RightThumbstickY
        {
            get { return _esrmGamePad != null ? _esrmGamePad.RightThumbstickY : 0; }
        }


        #endregion PROPERTIES

        public GlobalGamePadHandSet(IESRMGamePad esrmGamePad) 
        {

            _vibrationsLevel = 100;
            _vibrationsTriggerLevel = 100;

            _esrmGamePad = esrmGamePad;
            if (_esrmGamePad != null)
            {
                //_esrmGamePad.ButtonXPressed += _esrmGamePad_ButtonXPressed;
                //_esrmGamePad.ButtonYPressed += _esrmGamePad_ButtonYPressed;
                //_esrmGamePad.ButtonYReleased += _esrmGamePad_ButtonYReleased;
                //_esrmGamePad.ButtonStartPressed += _esrmGamePad_ButtonStartPressed;
                //_esrmGamePad.ButtonRSPressed += _esrmGamePad_ButtonRSPressed;
                //_esrmGamePad.ButtonLSPressed += _esrmGamePad_ButtonLSPressed;
                //_esrmGamePad.ButtonBPressed += _esrmGamePad_ButtonBPressed;
                //_esrmGamePad.ButtonBackPressed += _esrmGamePad_ButtonBackPressed;
                //_esrmGamePad.ButtonAPressed += _esrmGamePad_ButtonAPressed;
            }

            _inPitTimer = new System.Timers.Timer();
            _inPitTimer.Interval = GlobalDatas.PITSTOPREFRESHINTERVAL;
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
            _currentBrakeTriggerValue = null;
            _brakeForceValue = 0;
            _lastStartEvent = DateTime.Now;
            _lastTCEvent = DateTime.Now;
            _waitingForPitStop = false;
        }


        #region DISPOSE
        ~GlobalGamePadHandSet()
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
                if (_inPitTimer != null)
                {
                    _inPitTimer.Stop();
                    _inPitTimer.Dispose();
                    _inPitTimer = null;
                }

                if (_esrmGamePad != null)
                {
                    //_esrmGamePad.ButtonXPressed -= _esrmGamePad_ButtonXPressed;
                    //_esrmGamePad.ButtonYPressed -= _esrmGamePad_ButtonYPressed;
                    //_esrmGamePad.ButtonYReleased -= _esrmGamePad_ButtonYReleased;
                    //_esrmGamePad.ButtonStartPressed -= _esrmGamePad_ButtonStartPressed;
                    //_esrmGamePad.ButtonRSPressed -= _esrmGamePad_ButtonRSPressed;
                    //_esrmGamePad.ButtonLSPressed -= _esrmGamePad_ButtonLSPressed;
                    //_esrmGamePad.ButtonBPressed -= _esrmGamePad_ButtonBPressed;
                    //_esrmGamePad.ButtonBackPressed -= _esrmGamePad_ButtonBackPressed;
                    //_esrmGamePad.ButtonAPressed -= _esrmGamePad_ButtonAPressed;

                    _esrmGamePad.Dispose();
                    _esrmGamePad = null;
                }

                disposed = true;
            }
        }
        #endregion

        public bool IsConnected()
        {
            if (_esrmGamePad != null && _esrmGamePad.IsConnected())
                return true;
            else return false;
        }

        public void SetParams(IDigitalParamsBase digitalParams)
        {
            _autoGreenFlag = digitalParams.AutoGreenFlag;
            _trackCallPressDelay = digitalParams.TrackCallPressDelay;

            CanDoPitStop = true;
        }

        public void SetDriverSettings(GamePadThrottleCurve thCurve, GamePadThrottleCurve brakeCurve,bool incarPro,double vibrationsLevel, double triggerVibrationsLevel)
        {
            InCarPro = incarPro;
            _vibrationsLevel = vibrationsLevel > 0 ? vibrationsLevel : 100;
            _vibrationsTriggerLevel = triggerVibrationsLevel > 0 ? triggerVibrationsLevel :100;

            if (thCurve != null && thCurve.Values.Count == 0)
                _throttleCurve = null;
            else
                _throttleCurve = thCurve;
            if (brakeCurve != null && brakeCurve.Values.Count == 0)
                _brakeCurve = null;
            else
                _brakeCurve = brakeCurve;

            if (_brakeCurve != null && !InCarPro)
                _maxBrakeIntervals = _brakeCurve.Values.Max(t => t.ResultValue);
            else
                _maxBrakeIntervals = GlobalDatas.MAXBRAKEINTERVAL;
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
            if (DateTime.Now > _lastTCEvent.AddMilliseconds(500))
            {
                if (PitStopRunning)
                    return;
                if (!TrackCallRunning) // pas encore de TC 
                {
                    OnTrackCall();
                }
                else if (_autoGreenFlag && TrackCallRunning) // remise du drapeau vert automatiquement
                {
                    if (_tcButtonWasReleased)
                    {
                        OnEndOfTrackCall();
                    }
                }
            }
        }

        private void OnTrackCall()
        {
            if (TrackCallRunning)
                return;

                if (DateTime.Now > _lastTCEvent.AddMilliseconds(500))
            {
                _waitingForPitStop = false;
                TrackCallRunning = true;
                _tcButtonWasReleased = false;
                _lastTCEvent = DateTime.Now;

                if (TrackCall != null)
                    TrackCall(this, EventArgs.Empty);
            }
        }

        private void OnEndOfTrackCall()
        {
            if (DateTime.Now > _lastTCEvent.AddMilliseconds(500))
            {
                _waitingForPitStop = false;
                _lastTCEvent = DateTime.Now;
                _pitStopBeginTime = new TimeSpan();
                TrackCallRunning = false;
                _tcButtonWasReleased = false;

                if (EndOfTrackCall != null)
                    EndOfTrackCall(this, EventArgs.Empty);
            }
        }

        #endregion

        public void CheckStates()
        {
            _esrmGamePad.CheckButtonState();

            if (_esrmGamePad.IsButtonX_Pressed)
                _esrmGamePad_ButtonXPressed();

            if (_esrmGamePad.IsButtonY_Pressed)
                _esrmGamePad_ButtonYPressed();
            if (_esrmGamePad.IsButtonY_Released)
                _esrmGamePad_ButtonYReleased();

            if (_esrmGamePad.IsButtonA_Pressed)
                _esrmGamePad_ButtonAPressed();
            if (_esrmGamePad.IsButtonB_Pressed)
                _esrmGamePad_ButtonBPressed();

            if (_esrmGamePad.IsButtonStart_Pressed)
                ButtonStartPressed();
            if (_esrmGamePad.IsButtonLB_Pressed)
                _esrmGamePad_ButtonLSPressed();
            if (_esrmGamePad.IsButtonRB_Pressed)
                ButtonRSPressed();
            if (LeftThumbstickX < -0.75)
                OnLeft();
            if (LeftThumbstickX > 0.75)
                OnRight();
            if (LeftThumbstickY > 0.75)
                OnUp();
            if (LeftThumbstickY < -0.75)
                OnDown();


            CalculThrottleFromCurve();
            CalculBrakingValues();
        }

        #region ACCELERATION


        private void CalculThrottleFromCurve()
        {
            if (_throttleCurve != null)
            {
                if (_esrmGamePad.RightTriggerValue >= _throttleCurve.MaxTriggerValue)
                    _throttleValue = _throttleCurve.Values[_throttleCurve.Values.Count - 1].ResultValue;
                else if (_esrmGamePad.RightTriggerValue <= _throttleCurve.MinTriggerValue)
                    _throttleValue = _throttleCurve.Values[0].ResultValue;
                else
                    _throttleValue = _throttleCurve.Values.First(t => t.Value >= _esrmGamePad.RightTriggerValue).ResultValue;
            }
            else
                _throttleValue = (int)(_esrmGamePad.RightTriggerValue * GlobalDatas.POWERBASEMAXTHROTTLEVALUE);

        }

        #endregion 


        #region GESTION DU FREIN PROGRESSIF 
        

        protected void CalculBrakingValues()
        {
            if(InCarPro)
            {
                if (_brakeCurve != null)
                {
                    if (_esrmGamePad.LeftTriggerValue >= _brakeCurve.MaxTriggerValue)
                        _brakeForceValue = _brakeCurve.Values[_brakeCurve.Values.Count - 1].ResultValue;
                    else if (_esrmGamePad.LeftTriggerValue <= _brakeCurve.MinTriggerValue)
                        _brakeForceValue = _brakeCurve.Values[0].ResultValue;
                    else
                        _brakeForceValue = _brakeCurve.Values.First(t => t.Value >= _esrmGamePad.LeftTriggerValue).ResultValue;
                }
                else
                {
                    _brakeForceValue = (int)(_esrmGamePad.LeftTriggerValue * GlobalDatas.POWERBASEMAXTHROTTLEVALUE);
                }
            }
            else
            {
                int bf = 0;

                if (_brakeCurve != null)
                    bf = _brakeCurve.Values.First(b => b.Value >= _esrmGamePad.LeftTriggerValue).ResultValue;
                else
                    bf = (int)(_esrmGamePad.LeftTriggerValue * _maxBrakeIntervals);

                _currentBrakeTriggerValue = _brakeForceValues[bf];
                _brakeForceValue = _currentBrakeTriggerValue.BrakeForceValue;
            }

            // si aucune force de freinage demandée, alors on remet à 0 les compteurs
            if (_brakeForceValue == 0)
            {
                ResetBrakingIntervalls();
                _braking = false;
            }
        }

        public bool DoNeedBrake(float brakeAdhesionLoss)
        {
            if (!InCarPro)  // sinon, c'est qu'il y a demande de freinage
            {
                if (_currentBrakeTriggerValue == null)
                    _braking = false;
                else
                {
                    _brakeCycleElapsed++;

                    _braking = _lostBrakeCount >= _currentBrakeTriggerValue.BrakeCycle - _currentBrakeTriggerValue.EffectiveBrake ;

                    if (_brakeCycleElapsed >= _currentBrakeTriggerValue.BrakeCycle)
                    {
                        _lostBrakeCount = 0;
                        _brakeCycleElapsed = 0;
                    }

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
                }
                return _braking ;
            }
            else  //if(InCarPro) // on est en mode InCarPro
            {
                // En mode InCarPro, si on a une perte d'adhérence on peut se contenter de limiter le freinage plutot que de  l'annuler
                if (brakeAdhesionLoss > 0)
                {
                    _brakeForceValue = (int)(_brakeForceValue - ((double)_brakeForceValue * brakeAdhesionLoss));

                    if (_brakeForceValue <= 0)
                    {
                        _brakeForceValue = 0;
                        _braking = true;
                    }
                }
                else
                {
                    _braking = true;
                }

                return _braking;
            }

        }

        // une fois que la poignée ne demande plus de frein, on reset tout
        public void ResetBrakingIntervalls()
        {
            _brakeCycleElapsed = 0;
            _lostBrakeCount = 0;
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

        public void CheckForActions()
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
        private void OnButtonAPressed()
        {
            if (ButtonAPressed != null)
                ButtonAPressed(this, EventArgs.Empty);
        }
        private void OnButtonBPressed()
        {
            if (ButtonBPressed != null)
                ButtonBPressed(this, EventArgs.Empty);
        }




        private bool CheckPitStopAction()
        {
            if (!PitStopRunning || TrackCallRunning)
                return false;

            if (DateTime.Now.TimeOfDay.TotalMilliseconds > _pitStopBeginTime.TotalMilliseconds + 500)
                return true;

            return false;
        }

        private void _esrmGamePad_ButtonXPressed()
        {
            OnTryPitStopBegin();
        }

        private void _esrmGamePad_ButtonYPressed()
        {
            if (TrackCallRunning && _tcButtonWasReleased)
                EndTrackCallIfNeeded();
            else if(!_waitingForPitStop)
                WaitPitStopDelay();
        }

        private void WaitPitStopDelay()
        {
            _waitingForPitStop = true;
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += PSWorker_RunWorkerCompleted;
            worker.DoWork += PSWorker_DoWork;
            worker.RunWorkerAsync();
        }
        void PSWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _waitingForPitStop = false;
            (sender as BackgroundWorker).Dispose();
        }

        void PSWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep((int)_trackCallPressDelay);
            if (_esrmGamePad != null && _esrmGamePad.IsButtonY_Pressed)
                BeginTrackCallIfPossible();
        }


        private void _esrmGamePad_ButtonYReleased()
        {
            _waitingForPitStop = false;

            if (TrackCallRunning && !_tcButtonWasReleased)
                _tcButtonWasReleased = true;      
        }

        private void _esrmGamePad_ButtonAPressed ()
        {
            if (CheckPitStopAction())
                OnPitStopValidateAction();
            else
                OnButtonAPressed();
        }

        private void _esrmGamePad_ButtonBPressed()
        {
            if (CheckPitStopAction())
                OnPitStopCancelAction();
            else
                OnButtonBPressed();
        }

        private void _esrmGamePad_ButtonLSPressed()
        {
            if (CheckPitStopAction())
                OnPitStopPrevAction();
            else
            {
                if (this.LBPressed != null)
                    LBPressed(this, EventArgs.Empty);
            }

        }

        private void ButtonRSPressed()
        {
            if (CheckPitStopAction())
                OnPitStopNextAction();
            else
            {
                if (RBPressed != null)
                    RBPressed(this, EventArgs.Empty);
            }
        }

        private void ButtonStartPressed()
        {
            if (StartEvent != null && DateTime.Now > _lastStartEvent.AddMilliseconds(500))
            {
                _lastStartEvent = DateTime.Now;
                StartEvent(this, EventArgs.Empty);
                
            }
        }

        private void ButtonBackPressed()
        {
            InformationIdWithVibrations();
        }


        private void OnLeft()
        {
            if (Left != null)
            {
                //  _lastStartEvent = DateTime.Now;
                Left(this, EventArgs.Empty);

            }
        }
        private void OnRight()
        {
            if (Right != null)
            {
                //  _lastStartEvent = DateTime.Now;
                Right(this, EventArgs.Empty);

            }
        }
        private void OnUp()
        {
            if (Up != null)
            {
                //  _lastStartEvent = DateTime.Now;
                Up(this, EventArgs.Empty);

            }
        }
        private void OnDown()
        {
            if (Down != null)
            {
                //  _lastStartEvent = DateTime.Now;
                Down(this, EventArgs.Empty);

            }
        }




        public void StopAllTimers()
        {
            _inPitTimer.Stop();
        }

        #endregion


        #region VIBRATIONS MANAGEMENT

        public void HighSpeedVibrations()
        {
            VibrationValues values = new VibrationValues();
            values.LeftValue = 0.75;
            values.RightValue = 0.75;
            values.RightTriggerValue = 0.5;
            values.Duration = 200;

            DoVibrationsThread(values);
        }

        public void StrongBrakingVibrations()
        {
            VibrationValues values = new VibrationValues();
            values.LeftValue = 0.75;
            values.RightValue = 0.75;
            values.LeftTriggerValue = 0.5;
            values.Duration = 200;

            DoVibrationsThread(values);
        }

        public void AdhesionLossVibrations(double brakeAdhesionLoss, double accelerationAdhesionLoss)
        {
            //AccelerationAdhesionLoss = 8,
            //BrakeAdhesionLoss = 9,
            VibrationValues values = new VibrationValues();
            values.LeftValue = (_tiresRumblesLevel + (_healthRumblesLevel / 2)) ;
            values.RightValue = _fuelRumblesLevel + (_fuelRumblesLevel / 2) ;
            values.LeftTriggerValue = brakeAdhesionLoss  ;
            values.RightTriggerValue = accelerationAdhesionLoss ;
            values.Duration = 200;

            if (brakeAdhesionLoss > 0 || accelerationAdhesionLoss > 0)
            {
                DoVibrationsThread(values);
            }
            else
                SetVibration(values);
        }

        // ici on traite les vibrations liées à l'état du véhicule (Fuel, tires, Health)
        // l'intensité est variable selon le niveau de Warning
        // la vibration est constante jusqu'a ce que l'état change
        public void WarningVibrationsInfos(double fuelLevel,double tiresLevel, double healthLevel)
        {
            bool needStopVibrations = _tiresRumblesLevel > 0 || _fuelRumblesLevel > 0 || _healthRumblesLevel > 0;
            
            fuelLevel = fuelLevel <= GlobalDatas.LOWFUELLEVEL ?  1 - (fuelLevel * 0.01) : 0;
            tiresLevel = tiresLevel <= GlobalDatas.LOWTIRESLEVEL ? 1 - (tiresLevel * 0.01) : 0;
            healthLevel = healthLevel <= GlobalDatas.LOWHEALTHLEVEL ? 1 - (healthLevel * 0.01) : 0;

            //TiresWarning = vibrations sur le moteur de gauche niveau important,
            //Puncture = 0,
            _tiresRumblesLevel = tiresLevel;
            //FuelWarning  = vibrations sur le moteur de droite légère,
            //NoFuel ,
            _fuelRumblesLevel = fuelLevel;
            //HealthWarning = vibrations sur les deux moteurs,
            //BreakDown = 1,
            _healthRumblesLevel = healthLevel;

            DoCarStateVibrations(needStopVibrations);
        }

        private void DoCarStateVibrations(bool needStopVibrations)
        {
            if (needStopVibrations && _tiresRumblesLevel == 0 && _fuelRumblesLevel == 0 && _healthRumblesLevel == 0)
                StopVibrations();
            else if(_tiresRumblesLevel > 0 || _fuelRumblesLevel > 0 || _healthRumblesLevel > 0)
            {
                VibrationValues values = new VibrationValues();
                values.LeftValue = (_tiresRumblesLevel + (_healthRumblesLevel / 2));
                values.RightValue = _fuelRumblesLevel + (_fuelRumblesLevel / 2);
                values.Duration = 1000;

                if (values.HasOnePositive)
                {
                    DoVibrationsThread(values);
                }
            }
        }

        // ici on traite les vibrations qui ont pour but de donner une information au pilote
        // la durée et l'intensité sont fixes, seul le type de vibration change en fonction de l'event
        // pendant ce type de vibration, on remplace tout le reste et en fin de vibration on remettra les vibrations précédentes
        public void InformationVibrations(RumblesEventsEnums rumbleEvent)
        {
            // PitLaneIn
            // PitLaneOut
            // Incident

            VibrationValues values = new VibrationValues();
            values.LeftValue = (_tiresRumblesLevel + (_healthRumblesLevel / 2));
            values.RightValue = _fuelRumblesLevel + (_fuelRumblesLevel / 2);

            if (rumbleEvent == RumblesEventsEnums.PitLaneIn || rumbleEvent == RumblesEventsEnums.PitLaneOut)
            {
                values.LeftTriggerValue = 0.25 ;
                values.RightTriggerValue = 0.25;
                values.Duration = 200;
            }
            else if (rumbleEvent == RumblesEventsEnums.Incident)
            {
                // en cas d'incident on fait une vibration les deux moteurs
                values.LeftValue += 0.25 ;
                values.RightValue += 0.25 ;
                values.Duration = 1000;
            }

            DoVibrationsThread(values);
        }


        public void InformationIdWithVibrations()
        {
            VibrationValues values = new VibrationValues();
            values.LeftValue = (_tiresRumblesLevel + (_healthRumblesLevel / 2));
            values.RightValue = _fuelRumblesLevel + (_fuelRumblesLevel / 2);

            // en cas d'incident on fait une vibration les deux moteurs
            values.LeftValue += 0.25;
            values.RightValue += 0.25;
            values.Duration = 500;
            values.RepeatCount = this.LaneId - 1;

            DoVibrationsThread(values);
        }

        private void DoVibrationsThread(VibrationValues vibrationSettings)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync(vibrationSettings);
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            (sender as BackgroundWorker).Dispose();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            DoVibrations((VibrationValues)e.Argument);
        }

        private void DoVibrations(VibrationValues vibrationSettings)
        {
            if (_esrmGamePad == null)
                return;

            SetVibration(vibrationSettings);

            Thread.Sleep(vibrationSettings.Duration);

            //TimeSpan begintime = DateTime.Now.TimeOfDay.Add(new TimeSpan(0, 0, 0, 0, vibrationSettings.Duration));
            //while (DateTime.Now.TimeOfDay.TotalMilliseconds < begintime.TotalMilliseconds)
            //{
            ////    // NOTHING, WAITING
            //}

            //DoCarStateVibrations();
            StopVibrations();

            while(vibrationSettings.RepeatCount > 0)
            {
                SetVibration(vibrationSettings);
                Thread.Sleep(vibrationSettings.Duration);
                StopVibrations();
                vibrationSettings.RepeatCount--;
            }
    }

        public void SetVibration(VibrationValues vibrationSettings)
        {
            if (_esrmGamePad == null)
                return;

            vibrationSettings.Normalize(_vibrationsLevel, _vibrationsTriggerLevel);

            _esrmGamePad.SetVibration(vibrationSettings);
        }

        public void StopVibrations()
        {
            if (_esrmGamePad == null)
                return;

            _esrmGamePad.StopVibrations();
        }

        #endregion VIBRATIONS MANAGEMENT

    }
}
