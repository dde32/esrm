using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ESRM.Entities
{

    public class DigitalParamsBase : IDigitalParamsBase
    {
        public List<string> OpenedComPort { get; set; }
        public string ComPort { get; set; }
        public string StartLightComPort { get; set; }
        public string CarIdProgrammerComPort { get; set; }

        public PitSensorsParams PitSmartSensorsParams { get; set; }

        public int MaxPowerInPit { get; set; } // innutile a ce jour 
        public int PenalityTimeBeforeTrackCall { get; set; } // miliseconds  ; innutile a ce jour

        public int SeuilZeroGaz { get; set; }
        public TrackCallMethodEnum TrackCallMethod { get; set; }
        public PitInMethodEnum PitInMethod { get; set; }
        public int PitInPressDelay { get; set; } // miliseconds
        public int TrackCallPressDelay { get; set; } // miliseconds
        public bool AutoGreenFlag{ get; set; } 
        public int MaxPowerOnYellowFlag { get; set; }
        public int MaxPowerOnPenality { get; set; }
        public bool PenalityOnTc { get; set; }
        
        public int DamagesPercentOnTrackCall { get; set; }
        public int DamagesPercentMin{ get; set; }
        public int DamagesPercentNormal{ get; set; }
        public int DamagesPercentMax { get; set; }
        public int PowerBaseMaxThrottleValue { get; set; }
        public int PowerBaseMaxAcceleration { get; set; }
        public int TiresWearPerformanceMax { get; set; }
        public BreakdownActionEnum ActionOnBreakdowmn { get; set; }
        public AddlapOnPitStopEnum AddLapOnPitStop { get; set; }
        public bool ShowRaceStartConsign { get; set; }
        public bool RainSound { get; set; }
        public bool UsePitDetection { get; set; }
        public bool UseStartLight { get; set; }
        public bool UseCarIdProgrammer { get; set; }


        public int LowFuelLevel { get; set; }
        public int LowHealthLevel { get; set; }
        public int LowTiresLevel { get; set; }
        public int MaxAccelerationDelta { get; set; }
        public int MaxBrakeIntervals { get; set; }
        public int TimeBetweenData { get; set; }
        public bool RumblesOnHighAcceleration { get; set; }
        public bool RumblesOnStrongBraking { get; set; }


        #region Weather Params

        public int MinEvolutionLapCount { get; set; }
        public TimeSpan MinEvolutionTime { get; set; }


        #endregion

        public SoundSettings SoundSettings { get; set; }


        public DigitalParamsBase()
        {
            SetDefaultValue();
        }

        public void SetDefaultValue()
        {
            //UseHardwareLapTime = true;
            TiresWearPerformanceMax = 70;
            SeuilZeroGaz = 1;
            TrackCallMethod = TrackCallMethodEnum.BrakeAndZGaz;
            PitInMethod = PitInMethodEnum.LC;
            TrackCallPressDelay = 1500; // mili seconds
            PitInPressDelay = 1500; // mili seconds
            MaxPowerInPit = 40;
            PenalityTimeBeforeTrackCall = 0; // miliseconds
            AutoGreenFlag = true;
            MaxPowerOnYellowFlag = 50;
            MaxPowerOnPenality = 40;
            DamagesPercentMin = 10;
            DamagesPercentNormal = 20;
            DamagesPercentMax = 30;
            ActionOnBreakdowmn = BreakdownActionEnum.EndLapWithPenalityPower;
            AddLapOnPitStop = AddlapOnPitStopEnum.No;
            ShowRaceStartConsign = true;
            RainSound = true;
            PenalityOnTc = true;
            UsePitDetection = false;
            LowFuelLevel = 25;
            LowHealthLevel = 25;
            LowTiresLevel = 25;
            MaxAccelerationDelta = 25;
            MaxBrakeIntervals = 10;
            TimeBetweenData = 25;
            RumblesOnHighAcceleration = true;
            RumblesOnStrongBraking = true;

            MinEvolutionLapCount = 10;
            MinEvolutionTime = new TimeSpan(0, 1, 0);

            PitSmartSensorsParams = new PitSensorsParams();
        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            //AddLapOnPitStop = AddlapOnPitStopEnum.No;
        }

    }

    public enum SensorProtocolEnum
    {
        None = 0,
        PP = 1,
        SS = 2,
    }

    public class PitSensorsParams
    {
        public List<string> OpenedComPort { get; set; }
        //public bool UsePitDetection
        //{
        //    get { return !string.IsNullOrEmpty(ComPort); }
        //}
        public string ComPort { get; set; }
        public bool Reverse { get; set; }

        public bool UseStartLights{get; set;}

        public int SensorsCount { get; set; }
        public SensorProtocolEnum SensorProtocol { get; set; }
        public SensorProtocolEnum SensorType { get; set; }

        public PitSensorsParams()
        {
            Reverse = false;
            UseStartLights = true;
            SensorsCount = 2;
            SensorProtocol = SensorProtocolEnum.PP;
            SensorType = SensorProtocolEnum.PP;

        }
    }
}
