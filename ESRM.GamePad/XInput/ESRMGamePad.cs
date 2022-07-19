using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

using System.Threading;
using Microsoft.Xna.Framework.Input;
using ESRM.GamePads.Common;
using ESRM.Entities;

namespace ESRM.GamePads
{
    public class ESRMGamePad : IDisposable, IESRMGamePad
    {
        protected PlayerIndex _playerIndex;
        protected GamePadCapabilities _gamepadCaps;
       // Thread _checkStateThread;

        protected float _rightTriggerValue;
        protected float _leftTriggerValue;
        double _leftThumbstickX;
        double _leftThumbstickY;
        double _rightThumbstickX;
        double _rightThumbstickY;
        protected bool _isButtonA_Pressed = false;
        protected bool _isButtonB_Pressed = false;
        protected bool _isButtonY_Pressed = false;
        protected bool _isButtonY_Released = false;
        protected bool _isButtonX_Pressed = false;
        protected bool _isButtonLB_Pressed = false;
        protected bool _isButtonRB_Pressed = false;
        protected bool _isButtonStart_Pressed = false;
        protected bool _isButtonBack_Pressed = false;
        protected bool _isDpad_Pressed = false;


        //public event GamePadTriggerventHandler RightTriggerValueChanged;
        //public event GamePadTriggerventHandler LeftTriggerValueChanged;
        //public event EventHandler ButtonAPressed;
        //public event EventHandler ButtonBPressed;
        //public event EventHandler ButtonYPressed;
        //public event EventHandler ButtonYReleased;
        //public event EventHandler ButtonXPressed;
        //public event EventHandler ButtonLSPressed;
        //public event EventHandler ButtonRSPressed;
        //public event EventHandler ButtonStartPressed;
        //public event EventHandler ButtonBackPressed;
        //public event EventHandler DPadPressed;


        #region PROPERTIES


        public virtual double RightTriggerValue
        {
            get { return (double)(_rightTriggerValue); }
        }

        public virtual double LeftTriggerValue
        {
            get { return (double) _leftTriggerValue; }
        }

        public virtual double LeftThumbstickX
        {
            get { return (_leftThumbstickX); }
        }
        public virtual double LeftThumbstickY
        {
            get { return (_leftThumbstickY); }
        }
        public virtual double RightThumbstickX
        {
            get { return (_rightThumbstickX); }
        }
        public virtual double RightThumbstickY
        {
            get { return (_rightThumbstickY); }
        }

        public virtual bool IsButtonA_Pressed
        {
            get { return _isButtonA_Pressed; }
        }
        public virtual bool IsButtonB_Pressed
        {
            get { return _isButtonB_Pressed; }
        }
        public virtual bool IsButtonY_Pressed
        {
            get { return _isButtonY_Pressed; }
        }
        public virtual bool IsButtonY_Released
        {
            get { return _isButtonY_Released; }
        }
        public virtual bool IsButtonX_Pressed
        {
            get { return _isButtonX_Pressed; }
        }
        public virtual bool IsButtonLB_Pressed
        {
            get { return _isButtonLB_Pressed; }
        }
        public virtual bool IsButtonRB_Pressed
        {
            get { return _isButtonRB_Pressed; }
        }
        public virtual bool IsButtonStart_Pressed
        {
            get { return _isButtonStart_Pressed; }
        }
        public virtual bool IsButtonBack_Pressed
        {
            get { return _isButtonBack_Pressed; }
        }
        public virtual bool IsDpad_Pressed
        {
            get { return _isDpad_Pressed; }
        }
        #endregion PROPERTIES


        public ESRMGamePad(EsrmPlayerIndex playerIndex)
        {
            _playerIndex = (PlayerIndex)playerIndex;
            

            GamePadState currentState = GamePad.GetState((int)_playerIndex);
            if(currentState.IsConnected)
                    _gamepadCaps = GamePad.GetCapabilities((int)_playerIndex);
        }



        #region DISPOSE
        ~ESRMGamePad()
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
                //if (_checkStateThread != null)
                //{
                //    _checkStateThread.Abort();
                //    Thread.Sleep(0);
                //    _checkStateThread= null;
                //}

            }
        }
        #endregion



        public virtual void BeginStateCheck()
        {
            //if(_checkStateThread == null)
            //    _checkStateThread = new Thread(CheckButtonStateLoop);
            //if(_checkStateThread.ThreadState != ThreadState.Running)
            //    _checkStateThread.Start();
        }

        private  void CheckButtonStateLoop()
        {
            while(true)
            {
                CheckButtonState();
            }
        }

        public bool IsConnected()
        {
            GamePadState currentState = GamePad.GetState((int)_playerIndex);
            return currentState.IsConnected;
        }

        static public bool IsConnected(int index)
        {
            GamePadState currentState = GamePad.GetState(index);
            return currentState.IsConnected;
        }

        public string GetGamePadType()
        {
            _gamepadCaps = GamePad.GetCapabilities((int)_playerIndex);
            return _gamepadCaps.GamePadType.ToString();
        }

        #region BUTTONS STATE CHECK

        public void CheckButtonState()
        {
            try
            {
                GamePadState currentState = GamePad.GetState((int)_playerIndex);

                if (currentState.IsConnected) //Si le pad est bien branché
                {
                    CheckInput_RightTrigger(currentState);
                    CheckInput_LeftTrigger(currentState);
                    CheckInput_A(currentState);
                    CheckInput_B(currentState);
                    CheckInput_Y(currentState);
                    CheckInput_X(currentState);
                    CheckInput_LB(currentState);
                    CheckInput_RB(currentState);
                    CheckInput_DPad(currentState);
                    CheckInput_Back(currentState);
                    CheckInput_Start(currentState);
                }
                else
                {
                    _rightTriggerValue = 0;
                    _leftTriggerValue = 0;
                    _isButtonY_Pressed = false;
                    _isButtonA_Pressed = false;
                    _isButtonBack_Pressed = false;
                    _isButtonB_Pressed = false;
                    _isButtonLB_Pressed = false;
                    _isButtonRB_Pressed = false;
                    _isButtonStart_Pressed = false;
                    _isButtonX_Pressed = false;
                    _isButtonY_Pressed = false;
                    _isButtonY_Released = false;
                    _isDpad_Pressed = false;
                }

            }
            catch(Exception ex)
            {
    
            }
        }

        protected  virtual void CheckInput_RightTrigger(GamePadState currentState)
        {
                _rightTriggerValue =  currentState.Triggers.Right;
                OnRightTriggerValueChanged();
        }

        protected  virtual void CheckInput_LeftTrigger(GamePadState currentState)
        {
                _leftTriggerValue = currentState.Triggers.Left;
                OnLeftTriggerValueChanged();
        }

        protected virtual void CheckInput_DPad(GamePadState currentState)
        {
            bool dpadPressed =  currentState.DPad.Down == ButtonState.Pressed ||
                currentState.DPad.Up == ButtonState.Pressed ||
                currentState.DPad.Left == ButtonState.Pressed ||
                currentState.DPad.Right == ButtonState.Pressed;

            if (!_isDpad_Pressed && dpadPressed)
            {
                _isDpad_Pressed = true;
                OnDPadPressed();
            }
            else if (currentState.DPad.Down == ButtonState.Released &&
                    currentState.DPad.Up == ButtonState.Released &&
                    currentState.DPad.Left == ButtonState.Released &&
                    currentState.DPad.Right == ButtonState.Released )
            {
                _isDpad_Pressed = false;
            }

            _leftThumbstickX = currentState.ThumbSticks.Left.X;
            _leftThumbstickY = currentState.ThumbSticks.Left.Y;
            _rightThumbstickX = currentState.ThumbSticks.Right.X;
            _rightThumbstickY = currentState.ThumbSticks.Right.Y;
        }


        protected  virtual void CheckInput_A(GamePadState currentState)
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

        protected  virtual void CheckInput_B(GamePadState currentState)
        {
                if (!_isButtonB_Pressed && currentState.Buttons.B == ButtonState.Pressed)
                {
                    _isButtonB_Pressed = true;
                    OnButtonBPressed();
                }
                else if (currentState.Buttons.B == ButtonState.Released)
                    _isButtonB_Pressed = false;
        }

        protected  virtual void CheckInput_Y(GamePadState currentState)
        {
            if (!_isButtonY_Pressed && currentState.Buttons.Y == ButtonState.Pressed)
            {
                _isButtonY_Pressed = true;
                OnButtonYPressed();
            }
            else if (_isButtonY_Pressed && currentState.Buttons.Y == ButtonState.Released)
            {
                _isButtonY_Pressed = false;
                _isButtonY_Released = true;
                OnButtonYReleased();
            }
        }

        protected  virtual void CheckInput_X(GamePadState currentState)
        {
                if (!_isButtonX_Pressed && currentState.Buttons.X == ButtonState.Pressed)
                {
                    _isButtonX_Pressed = true;
                    OnButtonXPressed();
                }
                else if (currentState.Buttons.X == ButtonState.Released)
                    _isButtonX_Pressed = false;
        }

        
        protected  virtual void CheckInput_LB(GamePadState currentState)
        {
                if (!_isButtonLB_Pressed && currentState.Buttons.LeftShoulder == ButtonState.Pressed)
                {
                    _isButtonLB_Pressed = true;
                    OnButtonLSPressed();
                }
                else if (currentState.Buttons.LeftShoulder == ButtonState.Released)
                    _isButtonLB_Pressed = false;
        }

        protected  virtual void CheckInput_RB(GamePadState currentState)
        {
                if (!_isButtonRB_Pressed && currentState.Buttons.RightShoulder == ButtonState.Pressed)
                {
                    _isButtonRB_Pressed = true;
                    OnButtonRSPressed();
                }
                else if (currentState.Buttons.RightShoulder == ButtonState.Released)
                    _isButtonRB_Pressed = false;
        }

        protected virtual void CheckInput_Start(GamePadState currentState)
        {
            if (!_isButtonStart_Pressed && currentState.Buttons.Start == ButtonState.Pressed)
            {
                _isButtonStart_Pressed = true;
                OnButtonStartPressed();
            }
            else if (currentState.Buttons.Start == ButtonState.Released)
                _isButtonStart_Pressed = false;
        }


        protected virtual void CheckInput_Back(GamePadState currentState)
        {
            if (!_isButtonBack_Pressed && currentState.Buttons.Back == ButtonState.Pressed)
            {
                _isButtonBack_Pressed = true;
                OnButtonBackPressed();
            }
            else if (currentState.Buttons.Back == ButtonState.Released)
                _isButtonBack_Pressed = false;
        }

        #endregion

        #region EVENTS

        protected virtual void OnDPadPressed()
        {
            //if (DPadPressed != null)
            //    DPadPressed(this, EventArgs.Empty);
        }

        protected  virtual void OnRightTriggerValueChanged()
        {
            //if (RightTriggerValueChanged != null)
            //    RightTriggerValueChanged(this, new GamePadTriggerEventArgs(RightTriggerValue));
        }

        protected  virtual void OnLeftTriggerValueChanged()
        {
            //if (LeftTriggerValueChanged != null)
            //    LeftTriggerValueChanged(this, new GamePadTriggerEventArgs(LeftTriggerValue));
        }

        protected  virtual void OnButtonAPressed()
        {
            //if (ButtonAPressed != null)
            //    ButtonAPressed(this, EventArgs.Empty);
        }

        protected  virtual void OnButtonBPressed()
        {
            //if (ButtonBPressed != null)
            //    ButtonBPressed(this, EventArgs.Empty);
        }

        protected  virtual void OnButtonXPressed()
        {
            //if (ButtonXPressed != null)
            //    ButtonXPressed(this, EventArgs.Empty);
        }

        protected  virtual void OnButtonYPressed()
        {
            //if (ButtonYPressed != null)
                //ButtonYPressed(this, EventArgs.Empty);
        }

        protected virtual void OnButtonYReleased()
        {
            //if (ButtonYReleased != null)
            //    ButtonYReleased(this, EventArgs.Empty);
        }
        protected  virtual void OnButtonLSPressed()
        {
            //if (ButtonLSPressed != null)
            //    ButtonLSPressed(this, EventArgs.Empty);
        }

        protected virtual void OnButtonRSPressed()
        {
            //if (ButtonRSPressed != null)
            //    ButtonRSPressed(this, EventArgs.Empty);
        }
        protected virtual void OnButtonStartPressed()
        {
            //if (ButtonStartPressed != null)
            //    ButtonStartPressed(this, EventArgs.Empty);
        }

        protected virtual void OnButtonBackPressed()
        {
            //if (ButtonBackPressed != null)
            //    ButtonBackPressed(this, EventArgs.Empty);
        }


        #endregion


        public virtual void SetVibration(VibrationValues vibrationSettings)
        {
            //if (_gamepadCaps.HasLeftVibrationMotor && _gamepadCaps.HasRightVibrationMotor)
            //{
                if(vibrationSettings.LeftTriggerValue  > 0 && vibrationSettings.RightTriggerValue > 0)
                GamePad.SetVibration((int)_playerIndex, (float)vibrationSettings.LeftTriggerValue, (float)vibrationSettings.RightTriggerValue);
            else if (vibrationSettings.LeftTriggerValue > 0)
                GamePad.SetVibration((int)_playerIndex, (float)vibrationSettings.LeftTriggerValue, 0);
            else if (vibrationSettings.RightTriggerValue > 0)
                GamePad.SetVibration((int)_playerIndex, 0,(float)vibrationSettings.RightTriggerValue);
            else
                GamePad.SetVibration((int)_playerIndex, (float)vibrationSettings.LeftValue, (float)vibrationSettings.RightValue);

            //}
        }

        public virtual void StopVibrations()
        {
            //if (_gamepadCaps.HasLeftVibrationMotor && _gamepadCaps.HasRightVibrationMotor)
            //{
                GamePad.SetVibration(_playerIndex, 0, 0);
           // }
        }

    }



}
