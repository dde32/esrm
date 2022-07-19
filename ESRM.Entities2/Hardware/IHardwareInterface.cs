using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRM.Entities;

namespace ESRM.Entities
{
    public delegate void PBDataReceivedEventHandler(Object sender, PBReceiveDataEventArgs e);
    public delegate void ErrorEventHandler(Object sender, ErrorEventArgs error);
    public delegate void TeamIdEventHandler(Object sender, TeamIdEventArgs e);
    public delegate void LapEndedEventHandler(Object sender, LapEndedEventArgs e);
    public delegate void HandSetThrottleParsedEventHandler(Object sender, ThrottleParsedEventArgs e);
    public delegate void HandSetThrottleInfosRecordedEventHandler(Object sender, ThrottleInfosRecordedEventArgs  e);
    public delegate void DelegateGetCarThrottleValueFromRace(int carId, int throtlleValue, float handsetBrakingForce, bool checkAutoTC, bool gamePadUsed, out int resultThrottle, out CantBrakeEnum canBrake, out bool highAcceleration, out bool strongBrakng, out float brakeAdhesionLoss, out float accelerationAdhesionLoss);
    public delegate void DelegateErrorLog(string message);


    public interface IHardwareInterface : IDisposable
    {
        string Port { get; }
        //List<string> GetComPorts();
        bool IsInitConnected();
        bool IsConnected();
        IDigitalParamsBase DigitalParams { get; }
        IHandsetList Handsets { get; }

        event PBDataReceivedEventHandler DataReceived;
        event EventHandler TimerStarted;
        event EventHandler TimerStoped;
        event EventHandler TimerPaused;
        event EventHandler TimerUnPaused;
        event EventHandler TimerReset;
        event EventHandler HandSetStartClick;
        event TeamIdEventHandler HandSetLBPressed;
        event TeamIdEventHandler HandSetRBPressed;
        event TeamIdEventHandler TrackCallEvent;
        event TeamIdEventHandler NonInitHandSetUsedEvent;
        event TeamIdEventHandler EndTrackCallEvent;
        event LapEndedEventHandler LapEnded;
        event LapEndedEventHandler PitStopBegin;
        //event LapEndedEventHandler PitStopEnd;
        event TeamIdEventHandler PitStopDo;
        event TeamIdEventHandler PitStopNextAction;
        event TeamIdEventHandler PitStopPrevAction;
        event TeamIdEventHandler PitStopCancelAction;
        event TeamIdEventHandler PitStopValidateAction;

        bool IsStarted { get;  }
        bool IsPaused { get; }
        bool IsTrackCallRunning { get; }       
        TimeSpan RaceElapsedTime { get; }

        void SetDigitalParams(IDigitalParamsBase digitalParams);
         void ActivateHandSet(TeamInRaceCollection teams, bool initialCanDoPitStop);
        void AffectGamePadToLaneId(int laneId, EsrmPlayerIndex gamePadIndex, GamePadThrottleCurve throttleCurve, GamePadThrottleCurve brakeCurve, bool incarPro,double vibrationsLevel, double triggerVibrationsLevel);
        void SetCallBackGetCarThrottleValueFromRace(DelegateGetCarThrottleValueFromRace callbackMethod);
        void SetCallBackLogging(DelegateErrorLog callbackMethod);

        void StartCommand();
        void PauseCommand();
        void UnPauseCommand();
        void StopCommand();
        void ResetCommand();
        void PauseAfterReconnexionCommand();

        void SetCurrentCarIdCommand(int Id);
        void SendCarLights(bool[] carLights);

        bool DetectCommand();
        void ConnectToCommand(bool sendResetPacket);
        void CloseConnexionCommand();

        void OnLapEnded(int laneId, TimeSpan lapTime);
        void OnLapEndedTestTimer(int laneId);
        void StopPitStop(int laneId);

        void ForceGreenFlag();
        void ForceTrackCall();
        void TeamIsInPitLane(int laneId, bool isInPitLane);
        void RefusePitStop(int laneId);

    }

}
