using System;
using ESRM.Entities;
using ESRM.GamePads.Common;

namespace ESRM.GamePads
{
    public interface IGamePadHandSet : IHandSet, IDisposable // IESRMGamePad, IHandSet,IDisposable
    {
        //bool Braking { get; set; }
        bool InCarPro { get; set; }
        //bool CanDoPitStop { get; set; }
        //bool IsLaneIdUsed { get; set; }
        //bool IsPlugged { get; set; }
        //bool LaneChangingPressed { get; set; }
        //int LaneId { get; set; }
        //bool PitStopRunning { get; set; }
        bool StartPressed { get; set; }
        //int Throttle { get; set; }
        double ThrottleCoef { get; }
        //int BrakingForceValue { get; }
        //double BrakingForceCoef{ get; }
        //bool TrackCallRunning { get; set; }

        //event EventHandler DoPitStop;
        //event EventHandler EndOfTrackCall;
        //event EventHandler PitStopBegin;
        //event EventHandler PitStopCancelAction;
        //event EventHandler PitStopNextAction;
        //event EventHandler PitStopPrevAction;
        //event EventHandler PitStopValidatetAction;
        //event EventHandler StartEvent;
        //event EventHandler TrackCall;

        //void CheckForPitStopValidate();
        bool DoNeedBrake(float brakeAdhesionLoss);
        void OnDoPitStop();
        void ResetBrakingIntervalls();
        void SetParams(IDigitalParamsBase digitalParams);
        void SetDriverSettings(GamePadThrottleCurve thCurve, GamePadThrottleCurve brakeCurve,bool incarPro,double vibrationsLevel, double triggerVibrationsLevel);
        //void StopAllTimers();
        //void StopPitStop();
        void AdhesionLossVibrations(double brakeAdhesionLoss, double accelerationAdhesionLoss);
        void InformationVibrations(RumblesEventsEnums rumbleEvent);
        void WarningVibrationsInfos(double fuelLevel, double tiresLevel, double healthLevel);
        void StopVibrations();
    }
}