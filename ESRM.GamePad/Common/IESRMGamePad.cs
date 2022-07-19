using System;
using ESRM.GamePads.Common;

namespace ESRM.GamePads
{
    public interface IESRMGamePad : IDisposable
    {
        double LeftTriggerValue { get; }
        double RightTriggerValue { get; }
        bool IsButtonA_Pressed { get; }
        bool IsButtonB_Pressed { get; }
        bool IsButtonY_Pressed { get; }
        bool IsButtonY_Released { get; }
        bool IsButtonX_Pressed { get; }
        bool IsButtonLB_Pressed { get; }
        bool IsButtonRB_Pressed { get; }
        bool IsButtonStart_Pressed { get; }
        bool IsButtonBack_Pressed { get; }
        bool IsDpad_Pressed { get; }
        double LeftThumbstickX { get; }
        double LeftThumbstickY { get; }
        double RightThumbstickX { get; }
        double RightThumbstickY { get; }

        //event EventHandler ButtonAPressed;
        //event EventHandler ButtonBackPressed;
        //event EventHandler ButtonBPressed;
        //event EventHandler ButtonLSPressed;
        //event EventHandler ButtonRSPressed;
        //event EventHandler ButtonStartPressed;
        //event EventHandler ButtonXPressed;
        //event EventHandler ButtonYPressed;
        //event EventHandler ButtonYReleased;
        //event EventHandler DPadPressed;
        //event GamePadTriggerventHandler LeftTriggerValueChanged;
        //event GamePadTriggerventHandler RightTriggerValueChanged;

        void CheckButtonState();
        bool IsConnected();
        void SetVibration(VibrationValues vibrationSettings);
        void StopVibrations();
    }
}