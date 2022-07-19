using System;
using System.Collections.Generic;

namespace ESRM.Entities
{
    public interface IDigitalParamsBase
    {
        List<string> OpenedComPort { get; set; }
        string ComPort { get; set; }
        string StartLightComPort { get; set; }
        string CarIdProgrammerComPort { get; set; }

        // bool UseHardwareLapTime { get; set; }
        PitSensorsParams PitSmartSensorsParams { get; set; }
        int SeuilZeroGaz { get; set; }
         TrackCallMethodEnum TrackCallMethod { get; set; }
         PitInMethodEnum PitInMethod { get; set; }
       
        int TrackCallPressDelay { get; set; } // miliseconds
        int PitInPressDelay { get; set; } // miliseconds
        int PenalityTimeBeforeTrackCall { get; set; } // miliseconds
         bool AutoGreenFlag { get; set; }

         int MaxPowerOnYellowFlag { get; set; }
         int MaxPowerOnPenality { get; set; }
        int MaxPowerInPit { get; set; }
        bool PenalityOnTc{ get; set; }

        int DamagesPercentOnTrackCall { get; set; }
         int DamagesPercentMin { get; set; }
         int DamagesPercentNormal { get; set; }
        int DamagesPercentMax { get; set; }

        int PowerBaseMaxThrottleValue { get; set; }
        int TiresWearPerformanceMax { get; set; }
        int MinEvolutionLapCount { get; set; }
        TimeSpan MinEvolutionTime { get; set; }

        BreakdownActionEnum ActionOnBreakdowmn { get; set; }
        AddlapOnPitStopEnum AddLapOnPitStop { get; set; }
        bool UsePitDetection { get; set; }
        bool UseStartLight { get; set; }
        bool UseCarIdProgrammer { get; set; }


        int LowFuelLevel { get; set; }
        int LowHealthLevel { get; set; }
        int LowTiresLevel { get; set; }
        int MaxAccelerationDelta { get; set; }
        int MaxBrakeIntervals { get; set; }
        int TimeBetweenData { get; set; }

        bool RumblesOnHighAcceleration { get; set; }
        bool RumblesOnStrongBraking { get; set; }

    }
}
