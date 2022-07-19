using ESRM.Entities.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ESRM.Entities
{
    [DataContract]
    public class RaceParameters
    {
        int _pilotPerTeam = 1;

        #region PROPERTIES

        //public ESRMLicence License
        //{
        //    get;
        //    set;
        //}

        #region FOR UI

        public bool ShowPilotCount
        {
            get { return RaceType == Entities.RaceType.Endurance; }
        }
        public bool ShowRelayTime
        {
            get { return RaceType == Entities.RaceType.Endurance; }
        }
        public bool ShowLapCount
        {
            get { return RaceType == RaceType.GP || RaceType == RaceType.RallyCross; }
        }

        public bool ShowTimeDuration
        {
            //get { return RaceType == Entities.RaceType.Endurance || RaceType == RaceType.RallyCross; }
            get { return RaceType == Entities.RaceType.Endurance || RaceType == RaceType.Qualification || RaceType == RaceType.Practice; }
        }



        public bool ShowDamages
        {
            get { return RaceType != Entities.RaceType.Practice && RaceType != Entities.RaceType.TimeAttack; }
        }
        public bool ShowIncidentFrequency
        {
            get { return Damages != DamagesEnum.None; }
        }

        public bool ShowFuelImpact
        {
            get { return  RaceType != Entities.RaceType.TimeAttack; }
        }

        

        public bool ShowEndRace
        {
            get { return RaceType != Entities.RaceType.Practice; }
        }

        public string EndRaceTypeForUI
        {
            get
            {
                if (EndRaceType == Entities.EndRaceType.Standard)
                    return Textes.EndRaceType_Standard;
                else if (EndRaceType == Entities.EndRaceType.FirstFinish)
                    return Textes.EndRaceType_FirstFinish;
                else
                    return Textes.EndRaceType_AllFinish;
            }
        }

        public string IncidentForUI
        {
            get
            {
                if (Damages == DamagesEnum.None)
                    return Textes.Disabled;
                else if (Damages == DamagesEnum.Both)
                    return Textes.DamagesRandomAndTC;
                else if (Damages == DamagesEnum.OnTrackCall)
                    return Textes.DamagesTrackCall;
                else if (Damages == DamagesEnum.Random)
                    return Textes.DamagesRandom;
                else
                    return string.Empty;
            }
        }

        public string FuelImpactForUI
        {
            get
            {
                if (FuelImpact)
                    return Textes.Enabled;
                else
                    return Textes.Disabled;
            }
        }

        public string TiresImpactForUI
        {
            get
            {
                if (TiresImpact == TiresImpactEnum.None)
                    return Textes.Disabled;
                else if (TiresImpact == TiresImpactEnum.Acceleration)
                    return Textes.Acceleration;
                else if (TiresImpact == TiresImpactEnum.Braking)
                    return Textes.Brake;
                else 
                    return Textes.Both;
            }
        }

        public string TrackName
        {
            get { return Track != null ? Track.Name : string.Empty; }
        }

        #endregion

        [DataMember]
        public bool  DoQualification
        {
            get;
            set;
        }
        [DataMember]
        public TimeSpan QualificationTime
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public TeamInRaceCollection Teams
        {
            get;
            set;
        }

        [DataMember]
        public RaceType RaceType
        {
            get;
            set;
        }

        [DataMember]
        public string Title
        {
            get;
            set ;
        }

        [DataMember]
        public int MaxTeamsCount
        {
            get;
            set;
        }

        [DataMember]
        public Track Track
        {
            get;
            set;
        }

        [DataMember]
        public int? LapCount
        {
            get;
            set;
        }

        [DataMember]
        public int? RelayLapCount
        {
            get;
            set;
        }

        [DataMember]
        public bool FuelImpact
        {
            get;
            set;
        }

        [DataMember]
        public TiresImpactEnum TiresImpact
        {
            get;
            set;
        }

        [DataMember]
        public bool UseWeatherConditions
        {
            get;
            set;
        }

        [DataMember]
        public WeatherParams WeatherParams
        {
            get;
            set;
        }

        [DataMember]
        public bool ManualRefuel
        {
            get;
            set;
        }

        [DataMember]
        public bool ShowOptimalTiresType
        {
            get;
            set;
        }

        [DataMember]
        public EndRaceType EndRaceType
        {
            get;
            set;
        }

        [DataMember]
        public DamagesEnum Damages
        {
            get;
            set;
        }

        [DataMember]
        public TimeSpan? TimeLimit
        {
            get;set;
        }

        [DataMember]
        public TimeSpan? RelayTimeLimit
        {
            get;
            set;
        }

        [DataMember]
        public int? TimeAttackLevelLimit
        {
            get;
            set;
        }

        [DataMember]
        public int PilotPerTeam
        {
            //get { return 1; }


            get
            {
                if (_pilotPerTeam == 0)
                    _pilotPerTeam = 1;

                return _pilotPerTeam; }
            set
            {
                if (value == 0)
                    value = 1;


                if (_pilotPerTeam != value)
                {
                    _pilotPerTeam = value;
                    EnsureTeamsHavePilot();
                }
            }
        }

        [DataMember]
        public int DamagesFrequency { get; set; }
        public string DamagesFrequencyForUI
        {
            get
            {
                switch (DamagesFrequency)
                {
                    case 1:
                        return Textes.TresRare;
                    case 2:
                        return Textes.Rare;
                    case 3:
                        return Textes.Moyen;
                    case 4:
                        return Textes.Frequent;
                    case 5:
                        return Textes.TresFrequent;
                    default: return string.Empty;
                }

            } 
        }

        [DataMember]
        public int TireLifeTime { get; set; }
        [DataMember]
        public int FullTankLifeTime{ get; set; }

        [DataMember]
        public TimeSpan TimeAttackLapTarget
        {
            get;
            set;
        }

        [DataMember]
        public TimeSpan TimeAttackStartBonus
        {
            get;
            set;
        }

        [DataMember]
        public bool ApplyColorOnAllTeamPanel
        {
            get;
            set;
        }

        [DataMember]
        public bool RollingStart { get; set; }
        [DataMember]
        public int RollingStartLapCount { get; set; }

        [DataMember]
        public int MandatoryPitStopCount { get; set; }
        [DataMember]
        public int MinLapTimeSeconds { get; set; }
        [DataMember]
        public int MaxRepairPercent { get; set; }
        //[DataMember]
        public bool DeSlotAutoDetect
        {
            get { return DeSlotAutoDetectDelay > 0; }
        }
        [DataMember]
        public double DeSlotAutoDetectDelay { get; set; }
        [DataMember]
        public int RefuelSpeed { get; set; }
        [DataMember]
        public int RepairSpeed { get; set; }


        [DataMember]
        public bool ShowCars
        {
            get;
            set;
        }

        [DataMember]
        public bool ShowPilots
        {
            get;
            set;
        }

        [DataMember]
        public int JokerLapCount
        {
            get;
            set;
        }

        [DataMember]
        public int CarsMaxPower{get;set;}
        [DataMember]
        public bool MultiCarTeams { get; set; }
        [DataMember]
        public bool EnablePowerAdjustement { get; set; }
        [DataMember]
        public bool OneByOneRace { get; set; }
        [DataMember]
        public bool EnablePauseWithGamePad { get; set; }

        
        [IgnoreDataMember]
        public int TeamsCount
        {
            get { return Teams.Count; }
        }
        [IgnoreDataMember]
        IDigitalParamsBase _digitalParams;
        [IgnoreDataMember]
        public IDigitalParamsBase DigitalParams
        {
            get { return _digitalParams; }
        }



        public string ShowCarsForUI
        {
            get
            {
                if (ShowCars)
                    return Textes.Enabled;
                else
                    return Textes.Disabled;
            }
        }

        public string ShowPilotsForUI
        {
            get
            {
                if (ShowPilots)
                    return Textes.Enabled;
                else
                    return Textes.Disabled;
            }
        }

        #endregion

        public RaceParameters()
        {
            InitParameters();
            //_pilotPerTeam = 1;
        }

        public RaceParameters(IDigitalParamsBase digitalParams )
        {
            _digitalParams = digitalParams;
            InitParameters();
        }

        private void InitParameters()
        {
            Teams = new TeamInRaceCollection();
            RaceType = Entities.RaceType.GP;
            EndRaceType = Entities.EndRaceType.Standard;
            MaxTeamsCount = 6;
            //PilotPerTeam = 1;
            LapCount = 20;
            Damages = DamagesEnum.Both;
            DamagesFrequency = 2;
            //PenalityOnTrackCall = true;
            TimeAttackLapTarget = new TimeSpan(0, 0, 0, 6, 500);
            TimeAttackStartBonus = new TimeSpan(0, 0, 0, 10, 0);
            ApplyColorOnAllTeamPanel = false;
            UseWeatherConditions = false;
            TireLifeTime = 15;
            FullTankLifeTime = 30;
            RollingStart = false;
            RollingStartLapCount = 0;

            MandatoryPitStopCount = 0;
            MinLapTimeSeconds = 2;
            MaxRepairPercent = 0;
            RefuelSpeed = 15;
            RepairSpeed = 15;
            DeSlotAutoDetectDelay = 0;

            CarsMaxPower = 100;
            MultiCarTeams = false;
            EnablePowerAdjustement = true;
            OneByOneRace = false;
            EnablePauseWithGamePad = true;
    }

    public void SetDigitalParams(IDigitalParamsBase digitalParams )
        {
            _digitalParams = digitalParams;
        }

        public void EnsureTeamsHavePilot()
        {
            if (Teams == null)
                return;
            foreach (KeyValuePair<int, TeamInRace> entry in Teams)
            {
                if (_pilotPerTeam == 1)
                    entry.Value.Pilot2 = null;
                if (_pilotPerTeam == 2)
                    entry.Value. Pilot3 = null;


                if (PilotPerTeam > 1 && entry.Value.Pilot2 == null)
                    entry.Value.Pilot2 = new Pilot();
                if (PilotPerTeam > 2 && entry.Value.Pilot3 == null)
                    entry.Value.Pilot3 = new Pilot();

            }
        }

        public void CalculRelayDuration()
        {
            // Pour le moment on ne fait plus de courses à plusieurs pilotes par équipe. a priori innutile et cela complexifie l'UI

            //if (PilotPerTeam > 1)
            //{
            //    if (RaceType == Entities.RaceType.Endurance)
            //    {
            //        double relay = TimeLimit.Value.TotalMilliseconds / PilotPerTeam;
            //        RelayTimeLimit = TimeSpan.FromMilliseconds(relay);
            //    }
            //    else
            //    {
            //        double relay =  Laps.Value / PilotPerTeam;
            //        RelayLapCount = (int) relay;

            //    }
            //}
        }
    }
}
