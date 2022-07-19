using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{

    public enum EsrmPlayerIndex
    {
        One = 0,
        Two = 1,
        Three = 2,
        Four = 3,
        Five = 4,
        Six = 5,
        None = 99
    }

    public enum TireType
    {
        Hard = 0,
        Medium = 1,
        Soft = 2,
        Intermediate = 3,
        Wet = 4
    }

    public enum CantBrakeEnum
    {
        Delay = 0,
        AdhesionLoss = 1,
        Other = 2,
        NoBrakeWanted = 3,
        SoftBraking = 4,
        CanBrake = 9,
    }


    public enum PitStopActionEnum
    {
        ChangeTires = 0,
        SelectTires = 1,
        SelectPilot = 2,
        Refuel = 3,
        Repair = 4,
        ChangeThCurve = 5,
        ChangeBrakeCurve = 6,
        //BeforeRace = 7,
        ReadyToRace = 8,
        None = 9,
        StopPitStop = 10,
    }

    public enum EndRaceType
    {
        Standard = 0,
        FirstFinish = 1,
        AllMustFinish = 2,
    }

    public enum RaceType
    {
        Practice = 0,
        GP = 1,
        Endurance = 2,
        TimeAttack = 3,
        Qualification = 4,
        RallyCross = 5,
    }


    public enum TeamState
    {
        Normal = 0,
        RunningPenality = 1,
        PitIn = 2,
        Finished = 3,
        Disqualified = 4,
        EndOfRelay = 5,
        TCRunning = 6,
    }


    public enum RaceState
    {
        NotStarted = 0,
        Started = 1,
        Paused = 2,
        Ended = 3,
    }

    public enum DamagesEnum
    {
        None = 0,
        Random = 1,
        OnTrackCall = 2,
        Both = 3,
    }

    public enum DamageTypeEnum
    {
        None = 0,
        Engine = 1,
        Suspension = 2,
        Brake = 3,
        Tires = 4,
    }

    public enum TiresImpactEnum
    {
        None = 0,
        Acceleration = 1,
        Braking = 2,
        Both = 3,
    }

    public enum TrackCallMethodEnum
    {
        BrakeAndZGaz = 0,
        LCAndBrake = 1,
        LCAndBrakeAndZGaz = 2,
        None = 3,
    }

    public enum PitInMethodEnum
    {
        Brake = 0,
        LC = 1,
        LCAndBrake = 2,
        None = 3,
    }

    public enum AddlapOnPitStopEnum
    {
        No = 0,
        OnPitStop = 1,
        EnterPitLane = 2,
        ExitPitLane = 3,
    }

    public enum BreakdownActionEnum
        {
        DoNothing = 0,
        Disquafied = 1,
        EndLapWithPenalityPower = 2,
        WaitForPitStop = 3,
        }

    public enum SoundEnum
    {
        Go = 0,
        YellowFlag = 1,
        GreenFlag = 2,
        PitIn = 3,
        Warning = 4,
        Alert = 5,
        LapRecord = 6,
        Incident = 7,
        Finish = 8,
        Beep = 9,
        TA_ChangeLevel = 10,
        TA_Negative=11,
        TA_Positive = 12,
        EndRealy =13,
        LightRain = 14,
        MediumRain = 15,
        HardRain = 16,
        EnterPitlane = 17,
        PassSFLine = 18,
    }

    public enum RumblesEventsEnums
    {
        TiresWarning = 0,
        HealthWaring = 1,
        FuelWarning = 2,
        Puncture = 3,
        BreakDown = 4,
        NoFuel = 5,
        PitLaneIn = 6,
        PitLaneOut = 7,
        AccelerationAdhesionLoss = 8,
        BrakeAdhesionLoss  = 9,
        Incident = 10
    }

    public enum StateImageEnum
    {
        Finish = 0,
        PitStop = 1,
        GreenFlag = 2,
        YellowFlag = 3,
        EndOfRelay = 4,
        BrakesIncident = 5,
        EngineIncident = 6,
        SuspensionIncident = 7,
        TiresIncident = 8,
        Alert = 9,
        Warning = 10,
        Empty = 11
    }


    public enum WeatherEnum
    {
        Sunny = 0,
        SunnyCloudy = 1,
        Thinning = 2,
        Covered = 3,
        SunnyRain1 = 4,
        SunnyRain2 = 5,
        Raining = 6,
        NightClear = 7,
        NightCloudy = 8,
        NightRain1 = 9,
        NightRain2 = 10,
        Unknown = 99,
    }


    public enum WeatherChangeFrequencyEnum
    {
        Quick = 0,
        Normal = 1,
        Slow = 2,
    }

    public enum RainriskEnum
    {
        Low = 0,
        Normal = 1,
        High = 2,
    }


    public enum SeasonEnum
    {
        Winter = 0,
        Spring = 1,
        Summer = 2,
        Automun = 3
    }

    public enum CalibrationHandsetType
    {
        HandSet = 1,
        GamePad = 2,
    }
}
