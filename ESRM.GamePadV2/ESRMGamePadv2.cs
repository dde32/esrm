using ESRM.Entities;
using ESRM.GamePads;
using ESRM.GamePads.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Gaming.Input;

namespace ESRM.GamePadV2
{

    public class ESRMGamePadv2  : IDisposable, IESRMGamePad
    {
        protected EsrmPlayerIndex _playerIndex;
        Gamepad _controller;

        double _rightTriggerValue;
        double _leftTriggerValue;
        double _leftThumbstickX;
        double _leftThumbstickY;
        double _rightThumbstickX;
        double _rightThumbstickY;

        bool _isButtonA_Pressed = false;
        bool _isButtonB_Pressed = false;
        bool _isButtonY_Pressed = false;
        bool _isButtonX_Pressed = false;
        bool _isButtonLB_Pressed = false;
        bool _isButtonRB_Pressed = false;
        bool _isButtonStart_Pressed = false;
        bool _isButtonBack_Pressed = false;
        bool _isDpad_Pressed = false;
        bool _isButtonY_Released = false;

        #region EVENTS

        //public event GamePadTriggerventHandler RightTriggerValueChanged;
        //public event GamePadTriggerventHandler LeftTriggerValueChanged;
        //public event EventHandler ButtonAPressed;
        //public event EventHandler ButtonBPressed;
        //public event EventHandler ButtonYPressed;
        //public event EventHandler ButtonYReleased;
        // public event EventHandler ButtonXPressed;
        //public event EventHandler ButtonLSPressed;
        //public event EventHandler ButtonRSPressed;
        //public event EventHandler ButtonStartPressed;
        //public event EventHandler ButtonBackPressed;
        //public event EventHandler DPadPressed;

        #endregion EVENTS

        #region PROPERTIES


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


        public virtual double RightTriggerValue
        {
            get { return (_rightTriggerValue); }
        }

        public virtual double LeftTriggerValue
        {
            get { return _leftTriggerValue; }
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


        public ESRMGamePadv2(EsrmPlayerIndex playerIndex)
        {
            _playerIndex = playerIndex;
            GetControllerIfNeeded();
        }



        #region DISPOSE
        ~ESRMGamePadv2()
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
            }
        }
        #endregion


        public bool IsConnected()
        {
            try
            {
                return Gamepad.Gamepads.Count > (int)_playerIndex;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        static public bool IsConnectedByIndex(int index)
        {
            try
            {
                bool result = Gamepad.Gamepads.Count > index;
                if (!result)
                {
                    Thread.Sleep(25);
                    return Gamepad.Gamepads.Count > index;
                }
                else
                    return result;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        #region BUTTONS STATE CHECK


        public void CheckButtonState()
        {
            try
            {
                GetControllerIfNeeded();

                if (_controller == null)
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
                else
                {
                    GamepadReading reading = _controller.GetCurrentReading();
                    CheckInput_LeftTrigger(reading);
                    CheckInput_RightTrigger(reading);
                    CheckInput_A(reading);
                    CheckInput_B(reading);
                    CheckInput_Y(reading);
                    CheckInput_X(reading);
                    CheckInput_LB(reading);
                    CheckInput_RB(reading);
                    CheckInput_DPad(reading);
                    CheckInput_Back(reading);
                    CheckInput_Start(reading);
                    CheckInput_TS(reading);
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected virtual void CheckInput_RightTrigger(GamepadReading currentState)
        {
            _rightTriggerValue = currentState.RightTrigger;

            OnRightTriggerValueChanged();
        }

        protected virtual void CheckInput_LeftTrigger(GamepadReading currentState)
        {
            _leftTriggerValue = currentState.LeftTrigger;

            OnLeftTriggerValueChanged();
        }

        protected virtual void CheckInput_TS(GamepadReading currentState)
        {
            _leftThumbstickX = currentState.LeftThumbstickX;
            _leftThumbstickY = currentState.LeftThumbstickY;
            _rightThumbstickX = currentState.RightThumbstickX;
            _rightThumbstickY = currentState.RightThumbstickY;
        }


        protected virtual void CheckInput_DPad(GamepadReading currentState)
        {
            GamepadButtons buttons = currentState.Buttons;

            bool dpadPressed = buttons.HasFlag(GamepadButtons.DPadDown) ||
                buttons.HasFlag(GamepadButtons.DPadLeft) ||
                buttons.HasFlag(GamepadButtons.DPadRight) ||
                buttons.HasFlag(GamepadButtons.DPadUp);

            if (!_isDpad_Pressed && dpadPressed)
            {
                _isDpad_Pressed = true;
                OnDPadPressed();
            }
            else if (!dpadPressed)
            {
                _isDpad_Pressed = false;
            }
        }


        protected virtual void CheckInput_A(GamepadReading currentState)
        {
            if (!_isButtonA_Pressed && currentState.Buttons.HasFlag(GamepadButtons.A))
            {
                _isButtonA_Pressed = true;
                OnButtonAPressed();
            }
            else if (!currentState.Buttons.HasFlag(GamepadButtons.A))
            {
                _isButtonA_Pressed = false;
            }
        }

        protected virtual void CheckInput_B(GamepadReading currentState)
        {
            if (!_isButtonB_Pressed && currentState.Buttons.HasFlag(GamepadButtons.B))
            {
                _isButtonB_Pressed = true;
                OnButtonBPressed();
            }
            else if (!currentState.Buttons.HasFlag(GamepadButtons.B))
            {
                _isButtonB_Pressed = false;
            }
        }

        protected virtual void CheckInput_Y(GamepadReading currentState)
        {
            //if (!_isButtonY_Pressed && currentState.Buttons.HasFlag(GamepadButtons.Y))
            // on lance l'event tant que le bouton est pressé pour la détection des TC
            if (!_isButtonY_Pressed && currentState.Buttons.HasFlag(GamepadButtons.Y))
            {
                _isButtonY_Pressed = true;
                OnButtonYPressed();
            }
            else if (_isButtonY_Pressed && !currentState.Buttons.HasFlag(GamepadButtons.Y))
            {
                _isButtonY_Pressed = false;
                _isButtonY_Released = true;
                OnButtonYReleased();
            }
        }

        protected virtual void CheckInput_X(GamepadReading currentState)
        {
            if (!_isButtonX_Pressed && currentState.Buttons.HasFlag(GamepadButtons.X))
            {
                _isButtonX_Pressed = true;
                OnButtonXPressed();
            }
            else if (!currentState.Buttons.HasFlag(GamepadButtons.X))
            {
                _isButtonX_Pressed = false;
            }
        }


        protected virtual void CheckInput_LB(GamepadReading currentState)
        {
            if (!_isButtonLB_Pressed && currentState.Buttons.HasFlag(GamepadButtons.LeftShoulder))
            {
                _isButtonLB_Pressed = true;
                OnButtonLSPressed();
            }
            else if (!currentState.Buttons.HasFlag(GamepadButtons.LeftShoulder))
            {
                _isButtonLB_Pressed = false;
            }
        }

        protected virtual void CheckInput_RB(GamepadReading currentState)
        {
            if (!_isButtonRB_Pressed && currentState.Buttons.HasFlag(GamepadButtons.RightShoulder))
            {
                _isButtonRB_Pressed = true;
                OnButtonRSPressed();
            }
            else if (!currentState.Buttons.HasFlag(GamepadButtons.RightShoulder))
            {
                _isButtonRB_Pressed = false;
            }
        }

        protected virtual void CheckInput_Start(GamepadReading currentState)
        {
            if (!_isButtonStart_Pressed && currentState.Buttons.HasFlag(GamepadButtons.Menu))
            {
                _isButtonStart_Pressed = true;
                OnButtonStartPressed();
            }
            else if (!currentState.Buttons.HasFlag(GamepadButtons.Menu))
            {
                _isButtonStart_Pressed = false;
            }
        }


        protected virtual void CheckInput_Back(GamepadReading currentState)
        {
            if (!_isButtonBack_Pressed && currentState.Buttons.HasFlag(GamepadButtons.View))
            {
                _isButtonBack_Pressed = true;
                OnButtonBackPressed();
            }
            else if (!currentState.Buttons.HasFlag(GamepadButtons.View))
            {
                _isButtonBack_Pressed = false;
            }
        }

        #endregion

        #region EVENTS

        protected virtual void OnDPadPressed()
        {
            //if (DPadPressed != null)
            //    DPadPressed(this, EventArgs.Empty);
        }

        protected virtual void OnRightTriggerValueChanged()
        {
            //if (RightTriggerValueChanged != null)
                //RightTriggerValueChanged(this, new GamePadTriggerEventArgs(RightTriggerValue));
        }

        protected virtual void OnLeftTriggerValueChanged()
        {
            //if (LeftTriggerValueChanged != null)
            //    LeftTriggerValueChanged(this, new GamePadTriggerEventArgs(LeftTriggerValue));
        }

        protected virtual void OnButtonAPressed()
        {
            //if (ButtonAPressed != null)
            //    ButtonAPressed(this, EventArgs.Empty);
        }

        protected virtual void OnButtonBPressed()
        {
            //if (ButtonBPressed != null)
            //    ButtonBPressed(this, EventArgs.Empty);
        }

        protected virtual void OnButtonXPressed()
        {
            //if (ButtonXPressed != null)
            //    ButtonXPressed(this, EventArgs.Empty);
        }

        protected virtual void OnButtonYPressed()
        {
            //if (ButtonYPressed != null)
            //    ButtonYPressed(this, EventArgs.Empty);
        }
        protected virtual void OnButtonYReleased()
        {
            //if (ButtonYReleased != null)
            //    ButtonYReleased(this, EventArgs.Empty);
        }

        

        protected virtual void OnButtonLSPressed()
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
            GetControllerIfNeeded();

            GamepadVibration vib = new GamepadVibration();
            vib.LeftMotor = vibrationSettings.LeftValue;
            vib.RightMotor = vibrationSettings.RightValue;
            vib.LeftTrigger = vibrationSettings.LeftTriggerValue;
            vib.RightTrigger = vibrationSettings.RightTriggerValue;

            if (_controller != null)
                _controller.Vibration = vib;
        }

        private void GetControllerIfNeeded()
        {
            try
            {
                if (_controller == null)
                    _controller = Gamepad.Gamepads[(int)_playerIndex];
            }
            catch(Exception ex)
            {

            }
        }

        public virtual void StopVibrations()
        {
            VibrationValues stopValues = new VibrationValues();
            SetVibration(stopValues);
        }

    }



}
