using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

using System.Threading;
using Microsoft.Xna.Framework.Input;

namespace ESRM.HWInterfaces.X360
{
    public delegate void GamePadTriggerventHandler(object sender, GamePadTriggerEventArgs e);

    public class GamePadTriggerEventArgs : EventArgs
    {
        public float Value { get; set; }
        public GamePadTriggerEventArgs(float value)
        {
            Value = value;
        }
    }

    public class ESRMGamePad : IDisposable
    {
        protected PlayerIndex _playerIndex;
        protected GamePadCapabilities _gamepadCaps;
        Thread _checkStateThread;

        protected float _rightTriggerValue;
        protected float _leftTriggerValue;
        protected bool _isButtonA_Pressed = false;
        protected bool _isButtonB_Pressed = false;
        protected bool _isButtonY_Pressed = false;
        protected bool _isButtonX_Pressed = false;
        protected bool _isButtonLB_Pressed = false;
        protected bool _isButtonRB_Pressed = false;
        protected bool _isButtonStart_Pressed = false;
        protected bool _isButtonBack_Pressed = false;
        protected bool _isDpad_Pressed = false;
        
        public event GamePadTriggerventHandler RightTriggerValueChanged;
        public event GamePadTriggerventHandler LeftTriggerValueChanged;
        public event EventHandler ButtonAPressed;
        public event EventHandler ButtonBPressed;
        public event EventHandler ButtonYPressed;
        public event EventHandler ButtonXPressed;
        public event EventHandler ButtonLSPressed;
        public event EventHandler ButtonRSPressed;
        public event EventHandler ButtonStartPressed;
        public event EventHandler ButtonBackPressed;
        public event EventHandler DPadPressed;


        public virtual float RightTriggerValue
        {
            get  { return  (_rightTriggerValue); }
        }

        public virtual float LeftTriggerValue
        {
            get { return _leftTriggerValue; }
        }


        public ESRMGamePad(int playerIndex)
        {
            _playerIndex = (PlayerIndex)playerIndex;

            GamePadState currentState = GamePad.GetState(_playerIndex);
            if(currentState.IsConnected)
            _gamepadCaps = GamePad.GetCapabilities(_playerIndex);

            //int n = GamePad.MaximumGamePadCount;
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
                if (_checkStateThread != null)
                {
                    _checkStateThread.Abort();
                    Thread.Sleep(0);
                    _checkStateThread= null;
                }

            }
        }
        #endregion



        public virtual void BeginStateCheck()
        {
            if(_checkStateThread == null)
                _checkStateThread = new Thread(CheckButtonStateLoop);
            if(_checkStateThread.ThreadState != ThreadState.Running)
                _checkStateThread.Start();
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
            GamePadState currentState = GamePad.GetState(_playerIndex);
            return currentState.IsConnected;
        }

        public string GetGamePadType()
        {
            _gamepadCaps = GamePad.GetCapabilities(_playerIndex);
            return _gamepadCaps.GamePadType.ToString();
        }
        #region BUTTONS STATE CHECK



        public void CheckButtonState()
        {
            try
            {
                GamePadState currentState = GamePad.GetState(_playerIndex);

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
            }
            catch(Exception ex)
            {
    
            }
        }

        public bool TestButtons(ref string error)
        {
            try
            {
                GamePadState currentState = GamePad.GetState(_playerIndex);
                _gamepadCaps = GamePad.GetCapabilities(_playerIndex);


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
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return false;
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
                else if (currentState.Buttons.Y == ButtonState.Released)
                    _isButtonY_Pressed = false;
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
            if (DPadPressed != null)
                DPadPressed(this, EventArgs.Empty);
        }

        protected  virtual void OnRightTriggerValueChanged()
        {
            if (RightTriggerValueChanged != null)
                RightTriggerValueChanged(this, new GamePadTriggerEventArgs(RightTriggerValue));
        }

        protected  virtual void OnLeftTriggerValueChanged()
        {
            if (LeftTriggerValueChanged != null)
                LeftTriggerValueChanged(this, new GamePadTriggerEventArgs(LeftTriggerValue));
        }

        protected  virtual void OnButtonAPressed()
        {
            if (ButtonAPressed != null)
                ButtonAPressed(this, EventArgs.Empty);
        }

        protected  virtual void OnButtonBPressed()
        {
            if (ButtonBPressed != null)
                ButtonBPressed(this, EventArgs.Empty);
        }

        protected  virtual void OnButtonXPressed()
        {
            if (ButtonXPressed != null)
                ButtonXPressed(this, EventArgs.Empty);
        }

        protected  virtual void OnButtonYPressed()
        {
            if (ButtonYPressed != null)
                ButtonYPressed(this, EventArgs.Empty);
        }

        protected  virtual void OnButtonLSPressed()
        {
            if (ButtonLSPressed != null)
                ButtonLSPressed(this, EventArgs.Empty);
        }

        protected virtual void OnButtonRSPressed()
        {
            if (ButtonRSPressed != null)
                ButtonRSPressed(this, EventArgs.Empty);
        }
        protected virtual void OnButtonStartPressed()
        {
            if (ButtonStartPressed != null)
                ButtonStartPressed(this, EventArgs.Empty);
        }

        protected virtual void OnButtonBackPressed()
        {
            if (ButtonBackPressed != null)
                ButtonBackPressed(this, EventArgs.Empty);
        }


        #endregion


        public virtual void SetVibration(float value,float value2)
        {
            if (_gamepadCaps.HasLeftVibrationMotor && _gamepadCaps.HasRightVibrationMotor)
            {
                GamePad.SetVibration(_playerIndex, value, value2);
            }
        }


    }



}
