using System;
using System.Collections.Generic;

namespace ESRM.Entities
{
    public interface IHandSet : IDisposable
    {
        int LaneId { get; set; }
        bool IsPlugged { get; set; }
        bool IsLaneIdUsed { get; set; }
        bool LaneChangingPressed { get; set; }
        bool Braking { get; set; }
        double BrakingForceCoef{ get; }

        bool CanDoPitStop { get; set; }
        bool PitStopRunning { get; set; }
        bool TrackCallRunning { get; set; }
        int Throttle { get; set; }

        event EventHandler EndOfTrackCall;
        event EventHandler PitStopBegin;
        event EventHandler TrackCall;
        event EventHandler DoPitStop;
        //event EventHandler PitStopSelectAction;
        event EventHandler PitStopValidatetAction;
        event EventHandler PitStopNextAction;
        event EventHandler PitStopPrevAction;
        event EventHandler PitStopCancelAction;
        event EventHandler StartEvent;
        event EventHandler LBPressed;
        event EventHandler RBPressed;


        //void ProcessDoPitStop();
        void StopPitStop();
        void CheckForActions();


        //PitInMethodEnum PitInMethod { get; }
        //TrackCallMethodEnum TcMethod { get; }
        //void AddBrakingDuration(TimeSpan interval);
        //void AddLCDuration(TimeSpan interval);
        //TimeSpan BrakingDuration { get; }

        void StopAllTimers();

    }
}