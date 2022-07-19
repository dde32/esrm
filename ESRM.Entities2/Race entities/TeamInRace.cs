using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ESRM.Entities
{
    [DataContract]
    public class TeamInRace : Team, IComparable //,INotifyPropertyChanged
    {

        bool _passFirstTime = false;
        TeamState _state;
        TeamStatistics _statistics;
        double _maxPowerCoef;
        bool _changingTires;
        double _percentRepaired;
        double _lastPitAction;
        int _previousThrottleValue;
        private DateTime? _lastThrottleTime;

        public event EventHandler DriverChanged;
        public event EventHandler DriverCurvesChanged;

        Pacer _pacer;

        #region PROPERTIES POUR LA GESTION DES PITSTOPS
        [IgnoreDataMember]
        PitStopActionEnum _currentPitStopActionSelected;
        [IgnoreDataMember]
        PitStopActionEnum _currentPitStopActionShowed;
        [IgnoreDataMember]
        int _currentPitStopActionIndex;
        List<PitStopActionEnum> PossiblePitStopActions;
        [IgnoreDataMember]
        TireType _pitStopTireTypeShowed;
        [IgnoreDataMember]
        int? _pitStopNextTHCurve;
        [IgnoreDataMember]
        int? _pitStopNextBrakeCurve;
        [IgnoreDataMember]
        Pilot _pitStopNextPilot;
        [IgnoreDataMember]
        bool _isInPitLane;
        [IgnoreDataMember]
        bool _isInJokerlap;
        
        [IgnoreDataMember]
        public bool IsInPitLane
        {
            get { return _isInPitLane; }
        }

        public string IsInPitLaneText
        {
            get { return _isInPitLane ? "In pit lane" : string.Empty; }
        }
        
        #endregion PROPERTIES POUR LA GESTION DES PITSTOPS

        #region PROPERTIES FOR UI

        #region POUR LA GESTION DES PITSTOPS

        [IgnoreDataMember]
        public bool PitStopRunning
        {
            get
            {
               // return _currentPitStopActionSelected != PitStopActionEnum.None && _currentPitStopActionSelected != PitStopActionEnum.ReadyToRace;
                return _currentPitStopActionShowed != PitStopActionEnum.None && _currentPitStopActionShowed != PitStopActionEnum.ReadyToRace;
            }
        }

        public string MandatoryPSLeft
        {
            get
            {
                if (Race.RaceParams.MandatoryPitStopCount == 0 || Statisitics.PitStopCount > Race.RaceParams.MandatoryPitStopCount)
                    return string.Empty;
                else
                    return string.Format("{0} PS",Race.RaceParams.MandatoryPitStopCount - Statisitics.PitStopCount);
            }
        }

        public string JokerLapLeft
        {
            get
            {
                if (Race is RallyCrossRace && Race.RaceParams.JokerLapCount > 0)
                    return string.Format("{0} JL", Race.RaceParams.JokerLapCount - Statisitics.JokerLapCount);
                else
                    return string.Empty;
            }
        }

        [IgnoreDataMember]
        public Color PitStop_CurrentActionColor
        {
            get
            {
                if (_currentPitStopActionSelected != PitStopActionEnum.None)
                    return System.Drawing.Color.YellowGreen;
                else
                    return System.Drawing.Color.LightYellow;
            }
        }

        [IgnoreDataMember]
        public Pilot PitStop_NextPilot
        {
            get
            {
                return _pitStopNextPilot;
            }
        }

        [IgnoreDataMember]
        public string PitStop_NextPilotName
        {
            get
            {
                return _pitStopNextPilot.Name;
            }
        }
        [IgnoreDataMember]
        public PitStopActionEnum PitStop_CurrentAction
        {
            get { return _currentPitStopActionSelected; }
        }

       [IgnoreDataMember]
        public string PitStop_CurrentActionShowed
        {
            get
            {
                switch (_currentPitStopActionShowed)
                {
                    case PitStopActionEnum.ChangeTires:
                        return Textes.PitStopChangeTires;
                    case PitStopActionEnum.SelectTires:
                        return Textes.PitStopChangeTires;
                    case PitStopActionEnum.SelectPilot:
                        return Textes.PitStopSelectPilot;
                    //case PitStopActionEnum.BeforeRace:
                    //    return Textes.PrepareToRace;
                    case PitStopActionEnum.Repair:
                        return Textes.Repair;
                    case PitStopActionEnum.Refuel:
                        return Textes.Refuel;
                    case PitStopActionEnum.ChangeThCurve:
                        return Textes.ChangeThCurve;
                    case PitStopActionEnum.ChangeBrakeCurve:
                        return Textes.ChangeBrakeCurve;
                    case PitStopActionEnum.ReadyToRace:
                        return Textes.Ready;
                    case PitStopActionEnum.StopPitStop:
                        return Textes.PitStopEnd;
                    default:
                        return string.Empty;
                }
                // traduire en texte
            }
        }

        public string PitStop_CurrentSelectionTitle
        {
            get
            {
                //if (_currentPitStopActionSelected == PitStopActionEnum.ChangeTires)
                //    return Textes.Confirm;
                if (_currentPitStopActionSelected == PitStopActionEnum.SelectTires)
                    return _pitStopTireTypeShowed.ToString().Substring(0, 1);
                else if (_currentPitStopActionSelected == PitStopActionEnum.SelectPilot)
                    return _pitStopNextPilot.Name;
                else if (_currentPitStopActionSelected == PitStopActionEnum.ChangeThCurve)
                {
                    if (_pitStopNextTHCurve.HasValue)
                        return UseGamePadPlayerIndex.HasValue ? CurrentPilot.FavoriteGamePadThrottleCurve[_pitStopNextTHCurve.Value].Title : CurrentPilot.FavoriteHandsetThrottleCurve[_pitStopNextTHCurve.Value].Title;
                    else
                        return CurrentPilot.GamePadThrottleCurve.Title;
                }
                else if (_currentPitStopActionSelected == PitStopActionEnum.ChangeBrakeCurve)
                {
                    if (_pitStopNextBrakeCurve.HasValue)
                        return InCarPro ? CurrentPilot.FavoriteGamePadInCarProBrakeCurve[_pitStopNextBrakeCurve.Value].Title : CurrentPilot.FavoriteGamePadBrakeCurves[_pitStopNextBrakeCurve.Value].Title;
                    else
                        return CurrentPilot.GamePadBrakeCurve.Title;
                }
                //else if (_currentPitStopActionSelected == PitStopActionEnum.StopPitStop)
                //    return Textes.Confirm;
                else
                    return string.Empty;
            }
        }

        public int PitStop_TireTypeShowed
        {
            get
            {
                   return (int)_pitStopTireTypeShowed;
            }
        }

        public int CurrentTires
        {
            get { return (int)Car.Tires.Type; }
        }
        public string CurrentTiresFirstLetter
        {
            get { return Car.Tires.Type.ToString().Substring(0, 1); }
        }
        public string CurrentTiresTitle
        {
            get { return Car.Tires.Type.ToString(); }
        }

        public string CurrentCurves
        {
            get
            {
                string result = string.Format("PMax={0} ", MaxPowerPercent);
                if (UseGamePadPlayerIndex.HasValue)
                {
                    result += CurrentPilot.GamePadThrottleCurve != null ? CurrentPilot.GamePadThrottleCurve.Title : string.Empty ;
                    if(InCarPro)
                        result += CurrentPilot.GamePadInCarProBrakeCurve != null ? "-" + CurrentPilot.GamePadInCarProBrakeCurve.Title : "";
                    else
                        result += CurrentPilot.GamePadBrakeCurve != null ? "-" + CurrentPilot.GamePadBrakeCurve.Title : "";

                }
                else
                    result += CurrentPilot.HandsetThrottleCurve != null ? CurrentPilot.HandsetThrottleCurve.Title : string.Empty;

                return result;
            }
        }

        public string CurrentBrakeCurveTitlle
        {
            get
            {
                string result = string.Empty;

                if (UseGamePadPlayerIndex.HasValue)
                {
                    if (InCarPro)
                        result += CurrentPilot.GamePadInCarProBrakeCurve != null ? CurrentPilot.GamePadInCarProBrakeCurve.Title : string.Empty;
                    else
                        result += CurrentPilot.GamePadBrakeCurve != null ? CurrentPilot.GamePadBrakeCurve.Title : string.Empty;
                }

                return result;
            }
        }

        public string CurrentThrottleCurveTitlle
        {
            get
            {
                string result = string.Empty;
                if (UseGamePadPlayerIndex.HasValue)
                    result = CurrentPilot.GamePadThrottleCurve != null ? CurrentPilot.GamePadThrottleCurve.Title : string.Empty;
                else
                    result = CurrentPilot.HandsetThrottleCurve != null ? CurrentPilot.HandsetThrottleCurve.Title : string.Empty;

                return result;
            }
        }

        public string MaxPowerPercent
        {
            get
            {
                return (_maxPowerCoef * 100).ToString("N0") ;
            }

        }
        

        #endregion


        public string Gap { get { return Statisitics.Gap; } }
        public int Position { get { return Statisitics.Position; } }
        public bool FastestLap { get { return Statisitics.FastestLap; } }

        public bool ShowCar { get { return Race.RaceParams.ShowCars; } }
        public bool ShowPilot { get { return Race.RaceParams.ShowPilots; } }
        public bool ShowFuel { get { return Race.RaceParams.FuelImpact; } }
        public bool ShowTires { get { return Race.RaceParams.TiresImpact != TiresImpactEnum.None; } }
        public bool ShowHealth { get { return Race.RaceParams.Damages != DamagesEnum.None; } }
        public bool ShowStatePanel { get { return ShowHealth || ShowFuel || ShowTires; } }


        public string TeamAndPilotName
        {
            get
            {
                if (!IsMultiPilot)
                    return CurrentPilotName;
                else
                    return NameAndPilot;
            }
        }

        #region PROPERTIES FOR END RACE

        [IgnoreDataMember]
        public string UsedFuelForEndRace
        {
            get
            {
                  return Statisitics.UsedFuel;
            }
        }
        [IgnoreDataMember]
        public string UsedTiresForEndRace
        {
            get
            {
               return Statisitics.UsedTires;
            }
        }
        [IgnoreDataMember]
        public string GapForEndRace
        {
            get
            {
                if (Statisitics.Position == 1)
                    return Race.RaceDuration.ToString(@"hh\:mm\:ss");
                else
                    return Statisitics.Gap;
            }
        }



        [IgnoreDataMember]
        public string BestLapForEndRace
        {
            get
            {
                if (Statisitics.TeamBestLap.HasValue)
                {
                    if (this.Statisitics.FastestLap)
                        return string.Format("{0} {1}'{2}",Textes.LapRecord, Statisitics.TeamBestLap.Value.Seconds.ToString("D2"), Statisitics.TeamBestLap.Value.Milliseconds.ToString("D3"));
                    else
                        return string.Format("{0} {1}'{2}", Textes.BestLap, Statisitics.TeamBestLap.Value.Seconds.ToString("D2"), Statisitics.TeamBestLap.Value.Milliseconds.ToString("D3"));
                }
                else
                    return string.Empty;
            }
        }


        [IgnoreDataMember]
        public string AverageLapForEndRace
        {
            get
            {
                if (Statisitics.AverageLap.HasValue && Laps.Count > 0)
                {
                    return string.Format("{0} {1}'{2}", Textes.AverageLap, Statisitics.AverageLap.Value.Seconds.ToString("D2"), Statisitics.AverageLap.Value.Milliseconds.ToString("D3"));
                }
                else
                {
                    return string.Format("{0} {1}", Textes.AverageLap, "-");
                }
            }
        }

        [IgnoreDataMember]
        public string IncidentCountForEndRace
        {
            get
            {
                return string.Format("{0} {1}",Statisitics.IncidentCount, Textes.Incident);
            }
        }

        [IgnoreDataMember]
        public string TrackCallCountForEndRace
        {
            get
            {
                return string.Format("{0} {1}", Statisitics.TrackCallCount, Textes.TrackCall);
            }
        }

        public string PitStopForEndRace
        {
            get
            {
                if (EndOfRelayPenality)
                    return Textes.EndOfRelayPenality;
                else if (EndOfRelay)
                    return Textes.EndOfRelay;
                else
                {
                    if(Race.RaceParams.MandatoryPitStopCount > 0)
                        return string.Format("{0} Pitstop for {1} {2}", Statisitics.PitStopCount, Race.RaceParams.MandatoryPitStopCount, Textes.Mandatory.ToLower());
                    else
                        return string.Format("{0} Pitstop", Statisitics.PitStopCount);
                }
            }

        }

        #endregion 

        [IgnoreDataMember]
        public string NameAndPilot
        {
            get
            {
                //return string.Format("{0}{1}{2}", Name, Environment.NewLine, CurrentPilot != null ? CurrentPilot.Name : string.Empty);
                return string.Format("{0} . {1}", string.IsNullOrEmpty(Name) ? string.Empty : Name,CurrentPilot != null ? CurrentPilot.Name : string.Empty);
            }
        }

        [IgnoreDataMember]
        public string CurrentPilotName
        {
            get
            {
                return CurrentPilot.Name;
            }
        }

        [IgnoreDataMember]
        public string BestLapForUI
        {
            get
            {
                    if (Statisitics.TeamBestLap.HasValue)
                    {
                        if (this.Statisitics.FastestLap)
                            return string.Format("{0}'{1}", Statisitics.TeamBestLap.Value.Seconds.ToString("D2"), Statisitics.TeamBestLap.Value.Milliseconds.ToString("D3"));
                        else
                            return string.Format("{0}'{1}", Statisitics.TeamBestLap.Value.Seconds.ToString("D2"), Statisitics.TeamBestLap.Value.Milliseconds.ToString("D3"));
                    }
                    else
                        return string.Empty;
                    //return string.Format("{0}: {1}", Textes.BestLap, "-");
            }
        }


        [IgnoreDataMember]
        public string TeamBestLapForUI
        {
            get
            {
                if (Statisitics.TeamBestLap.HasValue && Laps.Count > 0)
                {
                    return string.Format("({0}'{1})", Statisitics.TeamBestLap.Value.Seconds.ToString("D2"), Statisitics.TeamBestLap.Value.Milliseconds.ToString("D3"));
                }
                else
                    return string.Empty;
            }
        }

        [IgnoreDataMember]
        public string LastLapForUI
        {
            get
            {
                if (Statisitics.RelayBestLap.HasValue && Laps.Count > 0)
                {
                    return string.Format("{0}'{1}", Laps[Laps.Count - 1].LapTime.Seconds.ToString("D2"), Laps[Laps.Count - 1].LapTime.Milliseconds.ToString("D3"));
                }
                else
                    return string.Empty;
            }
        }

        [IgnoreDataMember]
        public string LastLapForUIOrPitAction
        {
            get
            {
                if(State == TeamState.PitIn)
                {
                    return PitStop_CurrentActionShowed;
                }
                else
                {
                    return LastLapForUI;
                }
            }
        }
                

        [IgnoreDataMember]
        public string LapCountForUI
        {
            get
            {
                if (State == TeamState.Disqualified)
                    return Textes.Disqualified;
                if ((Race != null && Race.State == RaceState.NotStarted) || LastLapEnd == null)
                    return string.Empty;
                //else if (Race != null && Race.RaceParams.LapCount > 0)
                //{
                //    if ((Laps.Count == 0 && _passFirstTime) || Laps.Count > 0)
                //        return string.Format("{0} ", (Laps.Count + 1).ToString());
                //    else
                //        return string.Empty;
                //    //if ((Laps.Count == 0 && _passFirstTime))
                //    //    return Textes.First;
                //    //else if(Laps.Count > 0)
                //    //    return string.Format("{0} ", (Laps.Count + 1));
                //    //else
                //    //    return string.Empty;
                //}
                else
                {
                    if ((Laps.Count == 0 && _passFirstTime))
                          return "FL";
                    else if (Laps.Count > 0)
                        return string.Format("{0}", (Laps.Count).ToString());
                    else
                        return string.Empty;
                }
            }
        }

        [IgnoreDataMember]
        public string LapCountForMobileUI
        {
            get
            {
                if (State == TeamState.Finished)
                    return "---";
                else if (State == TeamState.Disqualified)
                    return Textes.Disqualified;
                if ((Race != null && Race.State == RaceState.NotStarted) || LastLapEnd == null)
                    return string.Empty;
                else if (Race != null && Race.RaceParams.LapCount > 0)
                {
                    if ((Laps.Count == 0 && _passFirstTime) || Laps.Count > 0)
                        return string.Format("{0}/{1}", (Laps.Count).ToString(), Race.RaceParams.LapCount);
                    else
                        return string.Empty;
                }
                else
                {
                    if ((Laps.Count == 0 && _passFirstTime))
                        return "FL";
                    else if (Laps.Count > 0)
                        return string.Format("{0}", (Laps.Count).ToString());
                    else
                        return string.Empty;


                }
            }
        }

        [IgnoreDataMember]
        public string TimeAttackBonusMalusForUI
        {
            get
            {
                if (TimeAttackBonusMalus.Milliseconds > 0)
                    return string.Format("{0}'{1}", TimeAttackBonusMalus.Seconds.ToString("D2"), TimeAttackBonusMalus.Milliseconds.ToString().Substring(0, 1));
                else
                    return string.Format("{0}'{1}", TimeAttackBonusMalus.Seconds.ToString("D2"), TimeAttackBonusMalus.Milliseconds.ToString());
            }
        }

        [IgnoreDataMember]
        public string TimeAttackTimeLeftForUI
        {
            get
            {
                if (TimeAttackTimeLeft.Milliseconds > 0)
                    return string.Format("{0}'{1}", TimeAttackTimeLeft.Seconds.ToString("D2"), TimeAttackTimeLeft.Milliseconds.ToString().Substring(0, 1));
                else
                    return string.Format("{0}'{1}", TimeAttackTimeLeft.Seconds.ToString("D2"), TimeAttackTimeLeft.Milliseconds.ToString());
            }
        }

        [IgnoreDataMember]
        public string TimeAttackLapTargetForUI
        {
            get
            {
                if (TimeAttackLapTarget.Milliseconds > 0)
                    return string.Format("{0}'{1}", TimeAttackLapTarget.Seconds.ToString("D2"), TimeAttackLapTarget.Milliseconds.ToString().Substring(0, 3));
                else
                    return string.Format("{0}'{1}", TimeAttackLapTarget.Seconds.ToString("D2"), TimeAttackLapTarget.Milliseconds.ToString());
            }
        }

        [IgnoreDataMember]
        public string FuelText
        {
            get { return Textes.FuelShort; }
        }

        [IgnoreDataMember]
        public string TiresText
        {
            get { return Textes.Tires; }
        }

        [IgnoreDataMember]
        public string CarText
        {
            get { return Textes.CarHealth; }
        }

        public int TeamPosition
        {
            get { return Statisitics.Position; }
        }

        public byte[] TeamImage
        {
            get
            {
                return CurrentPilot.Image;
            }
        }

        public byte[] CarImage
        {
            get
            {
                return Car.Image;
            }
        }


        public int StateImageIndex
        {
            get
            {
                // Priorité a la fin de course
                if (State == TeamState.Finished)
                    return (int)StateImageEnum.Finish;
                // si la course est en cours, priorité ensuite a ce qu'il se passe en cas d'arret au stands
                else if (State == TeamState.PitIn)
                {
                    return (int)StateImageEnum.PitStop;
                }
                // si on a une pénalité (limite la puissance pendant un tour) on affiche un drapeaux
                else if (State == TeamState.TCRunning || State == TeamState.RunningPenality)
                    return (int)StateImageEnum.YellowFlag;
                else if (EndOfRelay)
                    return (int)StateImageEnum.EndOfRelay;
                // si on a été victime d'un incident pendant le tour on affiche le picto correspondant
                else if (IncidentInThisLap.HasValue)
                {
                    switch (IncidentInThisLap.Value)
                    {
                        case DamageTypeEnum.Brake:
                            return (int)StateImageEnum.BrakesIncident;
                        case DamageTypeEnum.Engine:
                            return (int)StateImageEnum.EngineIncident;
                        case DamageTypeEnum.Suspension:
                            return (int)StateImageEnum.SuspensionIncident;
                        case DamageTypeEnum.Tires:
                            return (int)StateImageEnum.TiresIncident;
                        default:
                            return (int)StateImageEnum.Empty;
                    }
                }
                //else if (OutOfHealth || OutOfTires || OutOfFuel)
                //    return (int)StateImageEnum.Alert;
                //else if (LowFuel || LowHealth || LowTires)
                //    return (int)StateImageEnum.Warning;
                else
                    return (int)StateImageEnum.Empty;
            }
        }

        #endregion PROPERTIES FOR UI


        #region PROPERTIES
        [IgnoreDataMember]
        public Race Race
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public TeamStatistics Statisitics
        {
            get
            {
                if (_statistics == null)
                    _statistics = new TeamStatistics(Name);

                return _statistics;
            }
        }

        #region PILOTES

        public override void SetName(string name)
        {
            base.SetName(name);

            if (Statisitics != null && string.IsNullOrEmpty(this.Statisitics.TeamName))
                this.Statisitics.TeamName = name;

        }

        public bool IsMultiPilot
        {
            get
            {
                return Pilot2 != null;
            }

        }
        [DataMember]
        public override Pilot Pilot1
        {
            get
            {
                return base.Pilot1;
            }
            set
            {
                if (CurrentPilot == Pilot1)
                    CurrentPilot = value;
                base.Pilot1 = value;
            }
        }

        [DataMember]
        public override Pilot Pilot2
        {
            get
            {
                return base.Pilot2;
            }
            set
            {
                if (CurrentPilot == Pilot2)
                    CurrentPilot = value;
                base.Pilot2 = value;
            }
        }

        [DataMember]
        public override Pilot Pilot3
        {
            get
            {
                return base.Pilot3;
            }
            set
            {
                if (CurrentPilot == Pilot3)
                    CurrentPilot = value;
                base.Pilot3 = value;
            }
        }

        [IgnoreDataMember]
        public Pilot CurrentPilot
        {
            get;
            set;
        }
        #endregion

        [DataMember]
        public Car Car
        {
            get;
            set;
        }

        [DataMember]
        public bool InCarPro
        {
            get; set;
        }



        #region LAPS 

        [IgnoreDataMember]
        public List<Lap> Laps
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public int LapCount
        {
            get { return Laps.Count; }
        }

        [IgnoreDataMember]
        public bool IsInFirstLap
        {
            get { return LastLapEnd.TotalMilliseconds == 0; }
        }

        [IgnoreDataMember]
        public bool PassedFirstTime
        {
            get { return _passFirstTime; }
            set { _passFirstTime = value; }
        }

        [IgnoreDataMember]
        public TimeSpan LastLapEnd
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public TimeSpan LastLapTime
        {
            get
            {
                if (Laps.Count > 0)
                    return Laps[Laps.Count - 1].LapTime;
                else
                    return new TimeSpan();
            }
        }

        private Lap _currentLap;
        #endregion

        #region ETAT (dans la course, voiture ...)

        [IgnoreDataMember]
        public bool LightsOn
        {
            get;set;
        }

        [IgnoreDataMember]
        public bool PitStopInThisLap
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public DamageTypeEnum? IncidentInThisLap
        {
            get;
            set;
        }

        [IgnoreDataMember]
        bool _trackCallRunning;
        [IgnoreDataMember]
        public bool TrackCallRunning
        {
            get { return _trackCallRunning; }
        }


        [IgnoreDataMember]
        public bool CanHaveIncident
        {
            get { return !OutOfFuel && !OutOfHealth && !OutOfTires; }
        }

        [IgnoreDataMember]
        public TeamState State
        {
            get { return _state; }
            set
            {
                _state = value;
                CalculMaxPowerCoef();
            }
        }



        [IgnoreDataMember]
        public TimeSpan? RelayBeginTime
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public bool EndOfRelay
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public bool EndOfRelayPenality
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public int RelayNumber
        {
            get;
            set;
        }
        #endregion


        #region FOR TIME ATTACK

        public bool ModeTimeAttack
        {
            get { return Race is TimeAttackRace; }
        }
        [IgnoreDataMember]
        public int TimeAttackLevel
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public TimeSpan TimeAttackLapTarget
        {
            get
            {
                return Race.RaceParams.TimeAttackLapTarget - new TimeSpan(0, 0, 0, 0, (int)((TimeAttackLevel - 1) * (2 * Race.RaceParams.TimeAttackLapTarget.TotalMilliseconds / 100)));
            }
        }

        [IgnoreDataMember]
        public TimeSpan TimeAttackTimeLeft
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public TimeSpan TimeAttackBonusMalus // milli seconds
        {
            get;
            set;
        }

        #endregion  FOR TIME ATTACK



        #endregion

        #region PACER

        [DataMember]
        public bool IsPacer
        {
            get { return _pacer != null; }
            set
            {
                if (value == true && _pacer == null)
                    _pacer = new Pacer(this);
                else if (value == false)
                    _pacer = null;
            }
        }

        [DataMember]
        public Pacer Pacer
        {
            get { return _pacer; }
            set {  _pacer = value; }
        }

        [IgnoreDataMember]
        public int PacerPower
        {
            get { return _pacer != null ? _pacer.PacerPowerPercent : 0; }
            set
            {
                IsPacer = true;
                _pacer.PacerPowerPercent = value;
            }
        }

        #region GESTION DES TOURS VARIABLES POUR LES PACERS
        #endregion PACER

        #endregion

        #region REDIRECTION VERS  CAR

        [IgnoreDataMember]
        public bool IsBreakDown
        {
            get { return Car.IsBreakDown; }
        }

        [IgnoreDataMember]
        public bool LowTires
        {
            get { return Car.LowTires; }
        }

        [IgnoreDataMember]
        public bool OutOfTires
        {
            get { return Car.OutOfTires; }
        }


        [IgnoreDataMember]
        public bool LowFuel
        {
            get { return Car.LowFuel; }
        }

        [IgnoreDataMember]
        public bool OutOfFuel
        {
            get { return Car.OutOfFuel; }
        }

        [IgnoreDataMember]
        public bool LowHealth
        {
            get { return Car.LowHealth; }
        }

        [IgnoreDataMember]
        public bool OutOfHealth
        {
            get { return Car.OutOfHealth; }
        }

        public double TiresWearPercent
        {
            get { return Car.TiresWearPercent; }
        }

        [IgnoreDataMember]
        public double FuelPercent
        {
            get { return Car.FuelPercent; }
            set { Car.FuelPercent = value; }
        }

        [IgnoreDataMember]
        public double CarHealthPercent
        {
            get
            {
                return Car.CarHealthPercent;
            }
            set
            {
                Car.CarHealthPercent = value;
            }
        }

        public int TiresType
        {
            get { return (int)Car.Tires.Type; }
        }


        #endregion REDIRECTION VERS  CAR

        #region Throttle infos 

        [IgnoreDataMember]
        public int TotalThrotlleForFueUnit
        {
            get;
            set;
        }
        [IgnoreDataMember]
        public int TotalThrotlleForTiresUnit
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public List<HandSetThrotthleInfo> LapThrotlesInfos { get; set; }
        public int? _totalLapThrottle { get; set; }
        int? _calculationConsumptionIntervalThrottle { get; set; }
        int _thInfosLastUsedIdx;
        #endregion


        #region GESTION DU FREIN  
        [IgnoreDataMember]
        private int BrakeIntervalElapsed { get; set; }
        private double BrakeElapsedTime { get; set; }

        [IgnoreDataMember]
        private bool IsBraking { get; set; }
        #endregion


        public TeamInRace() : base()
        {
            _statistics = new TeamStatistics(this.Name);
            Laps = new List<Lap>();
            _currentLap = null;
            Car = new Car(TireType.Medium);
            Pilot1 = new Pilot() { Name = Textes.Pilot };
            IsPacer = false;
            Color = 0xFFFFFF;
            LightsOn = false;

            Reset(true, true, null);
        }

        public TeamInRace(int laneId) : base()
        {
            _statistics = new TeamStatistics(this.Name);
            Laps = new List<Lap>();
            Car = new Car(TireType.Medium);
            Pilot1 = new Pilot() { Name = Textes.Pilot };
            IsPacer = false;
            Color = 0xFFFFFF;
            Id = laneId;
            LightsOn = false;

            Reset(true, true, null);
        }

        public void Reset(bool resetPosition, bool resetInitialPosition, int? pbMaxThrottle)
        {
            Statisitics.Reset(resetPosition, resetInitialPosition);

            _passFirstTime = false;
            _isInPitLane = false;
            _isInJokerlap = false;
            if (Laps != null)
                Laps.Clear();
            Laps = null;
            Laps = new List<Lap>();
            _currentLap = null;

            CurrentPilot = Pilot1;
            LastLapEnd = new TimeSpan();
            if (Car == null)
                Car = new Car(TireType.Medium);
            CarHealthPercent = 100;
            FuelPercent = 100;
            IncidentInThisLap = null;
            State = TeamState.Normal;
            _trackCallRunning = false;
            State = TeamState.Normal;
            TotalThrotlleForFueUnit = 0;
            TotalThrotlleForTiresUnit = 0;
            _percentRepaired = 0;
            LightsOn = false;

            if (Race != null)
            {
                if (!(Race is EnduranceRace))
                {
                    Pilot2 = null;
                    Pilot3 = null;
                }

                if (Race is TimeAttackRace)
                {
                    TimeAttackBonusMalus = new TimeSpan(0, 0, 5);
                    TimeAttackTimeLeft = Race.RaceParams.TimeAttackLapTarget + TimeAttackBonusMalus;
                    TimeAttackLevel = 1;
                }
                else
                {
                    TimeAttackLevel = 0;
                    TimeAttackTimeLeft = new TimeSpan();
                    TimeAttackBonusMalus = new TimeSpan();
                }
            }

            RelayBeginTime = null;
            RelayNumber = 1;
            EndOfRelay = false;
            EndOfRelayPenality = false;

            Car.Reset();
            //Car.BrakeLimitation = CurrentPilot.BrakeLimitation;
            //Car.MaxPowerPercent = CurrentPilot.MaxPowerPercent;

            _maxPowerCoef = (double)CurrentPilot.MaxPowerPercent / 100;

            BrakeIntervalElapsed = 0;
            LapThrotlesInfos = new List<HandSetThrotthleInfo>();
            _totalLapThrottle = 0;
            _calculationConsumptionIntervalThrottle = 0;
            _thInfosLastUsedIdx = 0;

            if (IsPacer)
            {
                Pacer.Reset();
                if (pbMaxThrottle.HasValue)
                    Pacer.SetPacerPowerThrottle(pbMaxThrottle.Value);

                Pacer.LapThrotlesInfosCurrentIdx = 0;
                Pacer.ThrotthleAdjustCoef = 1;
            }
        }

        // départ de la course
        public void Start(TimeSpan passTime)
        {
            _currentPitStopActionSelected = PitStopActionEnum.None;
            _currentPitStopActionShowed = PitStopActionEnum.None;

            _passFirstTime = true;
            LastLapEnd = passTime;
            if (IsMultiPilot)
            {
                RelayBeginTime = passTime;
                RelayNumber = 1;
            }
            _currentLap = new Lap() { Relay = RelayNumber, Pilot = CurrentPilot, Number = 1,Position = this.Position };
            _lastThrottleTime = null;
        }

        // termine la course
        public void Finish()
        {
            if(Race.RaceParams.MandatoryPitStopCount > 0 && Statisitics.PitStopCount < Race.RaceParams.MandatoryPitStopCount)
                State = TeamState.Disqualified;
            else if ((Race is RallyCrossRace) && Race.RaceParams.JokerLapCount > 0 && Statisitics.JokerLapCount < Race.RaceParams.JokerLapCount)
                State = TeamState.Disqualified;
            else
                State = TeamState.Finished;
            // on recalcule la VMax
            CalculMaxPowerCoef();
        }

        public void ComputeStats()
        {
            Statisitics.ComputeStats(Laps);
        }


        public void PassJokerLapTrackSection()
        {
            _isInJokerlap = true;
        }

        // passage sur la ligne de chrono (temps relatif au départ )
        public bool AddLap(TimeSpan passTime,bool forceExitPitLane, bool isJokerLap )
        {
            if (State == TeamState.Finished)
                return false;

            isJokerLap = _isInJokerlap;
            _isInJokerlap = false;

            bool wasInPit = _isInPitLane;
            if (forceExitPitLane)
                _isInPitLane = false;

            // Si on est en panne et que le parametre d'action en cas de panne est de ne plus compter les tours jusqu'au pitStop alors on ne fait rien.
            if (IsBreakDown && Race.RaceParams.DigitalParams.ActionOnBreakdowmn == BreakdownActionEnum.WaitForPitStop)
                return false;

            // si c'est le premier passage sur la ligne de chrono, on commence le comptage
            if (!_passFirstTime)
                Start(passTime);

            // si ce n'est pas le premier passage, on va faire les calcul
            else
            {
                if (State == TeamState.TCRunning)
                    State = TeamState.Normal;

                TimeSpan lapTime = passTime - LastLapEnd;

                if (Race.RaceParams.MinLapTimeSeconds > 0 && lapTime.TotalSeconds < Race.RaceParams.MinLapTimeSeconds)
                    return false;

                LastLapEnd = passTime;


                if (!isJokerLap && !wasInPit && !IsInPitLane && !PitStopInThisLap && !PitStopRunning && TotalThrotlleForFueUnit == 0 && _totalLapThrottle.HasValue) // ici on va calculer une information de référence pour la consommation d'essence. La valeur totale d'accélération pendant un tour sera ensuite utilisée pour calculer la consommation de chaque pilote
                    CalculTotalLapThrottleReference();


                if (lapTime.TotalSeconds < 0) // possible en cas de reconnexion a la PB
                    lapTime = Laps[Laps.Count - 1].LapTime;

                // coef d'ajustement de la vitesse d'un pacer
                if (IsPacer)
                    Pacer.EndOfLap(lapTime);

                // Gestion TimeAttack
                if (Race is TimeAttackRace)
                    TimeAttackBonusMalus = TimeAttackLapTarget - lapTime;

                //si une pénalité était en cours, on la vire
                if (State == TeamState.RunningPenality)
                    State = TeamState.Normal;

                // ajout du tour au tableau
                _currentLap.LapTime = lapTime;
                _currentLap.IsJokerLap = isJokerLap;
                _currentLap.CarHealth = Car.CarHealthPercent;

                // historisation du tour
                Laps.Add(_currentLap);
                _currentLap = new Lap() { Relay = RelayNumber, Pilot = CurrentPilot, Number = Laps.Count + 1 };

                //après un tour on supprime l'état RandomIncident
                IncidentInThisLap = null;
                PitStopInThisLap = false;

                // gestion du best lap de la team et du relay en cours
                if (!isJokerLap)
                    Statisitics.ProcessLapTime(lapTime, CurrentPilot);
                else
                    Statisitics.JokerLapCount++;
                // est ce que le relais est terminé  ?
                CheckForEndOfRelay();

                // fuel et pneus
                if (State != TeamState.Finished)
                {
                    CalculIntervalFuelConsumption(true);

                    CalculIntervalTiresWear(true);

                    ResetCurrentLapThrottleInfos();
                }
            }

             CalculMaxPowerCoef();

            return true;
        }

        protected virtual void CalculTotalLapThrottleReference()
        {
            int TireLifeTime = Race.RaceParams.TireLifeTime > 0 ? Race.RaceParams.TireLifeTime : 50;
            int FullTankLifeTime = Race.RaceParams.FullTankLifeTime > 0 ? Race.RaceParams.FullTankLifeTime : 50;

            InitTankAndTiresPotentiel(TireLifeTime, FullTankLifeTime);
        }


        private void CheckForEndOfRelay()
        {
            // la fin de relais n'intervient qu'en cas de team à plusieurs pilotes (course d'endurance)
            if (IsMultiPilot && Race is EnduranceRace)
            {
                // si le délai de relai est fixé 
                if (Race.RaceParams.RelayTimeLimit.HasValue)
                {
                    // temps minimum de relais dépassé, on prévient que le prochain pit stop sera un changement de pilote
                    if (Race.RaceDuration - this.RelayBeginTime >= Race.RaceParams.RelayTimeLimit.Value)
                        EndOfRelay = true;
                }
            }
        }

        #region TRACK CALL & INCIDENTS


        public void CheckForAutoTrackCall()
        {
            if (!_lastThrottleTime.HasValue || IsInPitLane || PitStopRunning || IsPacer || !Race.IsRunning || Race.YellowFlag || !PassedFirstTime ||  this.State == TeamState.Finished || State != TeamState.Normal)
                return;

            if (Race.RaceParams.DeSlotAutoDetect && _lastThrottleTime < DateTime.Now.AddMilliseconds(-1000 * Race.RaceParams.DeSlotAutoDetectDelay))
            {
                if((Race.RaceParams.Damages == DamagesEnum.Both || Race.RaceParams.Damages == DamagesEnum.OnTrackCall))
                {
                    _lastThrottleTime = null;
                    CarHealthPercent -= Race.RaceParams.DigitalParams.DamagesPercentOnTrackCall;
                    if (Race.RaceParams.DigitalParams.PenalityOnTc)
                        State = TeamState.RunningPenality;
                    else
                        State = TeamState.TCRunning;

                    Statisitics.AddTrackCall(CurrentPilot);

                    CheckCarHealth();
                }
            }
        }

        public void DoTrackCall()
        {
            _trackCallRunning = true;
            if (_currentLap != null)
                _currentLap.TrackCallCount++;

            Statisitics.AddTrackCall(CurrentPilot);

            if (Race.RaceParams.Damages == DamagesEnum.Both || Race.RaceParams.Damages == DamagesEnum.OnTrackCall)
                CarHealthPercent -= Race.RaceParams.DigitalParams.DamagesPercentOnTrackCall;
            if (Race.RaceParams.DigitalParams.PenalityOnTc)
                State = TeamState.RunningPenality;
            else
                State = TeamState.TCRunning;

            CheckCarHealth();

            CalculMaxPowerCoef();
        }

        public void DoEndOfTrackCall()
        {
            _trackCallRunning = false;

            if (Race.RaceParams.DigitalParams.PenalityOnTc)
                State = TeamState.RunningPenality;
            else
                State = TeamState.Normal;

            CalculMaxPowerCoef();
        }

        // incident sur la voiture avec un impact correspondant au parametre passé
        public void Incident(int impactValue, DamageTypeEnum damageType)
        {
            IncidentInThisLap = damageType;
            if (_currentLap != null)
                _currentLap.IncidentCount++;

            Statisitics.AddIncident(CurrentPilot);
            // si l'incident est mécanique (pas sur les pneus)
            if (damageType != DamageTypeEnum.Tires)
            {
                // calcul de la valeur de l'impact de l'incident en cas de handicap du pilote
                impactValue = (int)(impactValue * (1 + CurrentPilot.DamagesHandicap));
                CarHealthPercent -= impactValue;
                // on ne peut pas avoir de valeur "état du vehicule" < 0 
                if (CarHealthPercent <= 0)
                    CarHealthPercent = 0;

                CheckCarHealth();

                // on recalcule la VMax
                CalculMaxPowerCoef();
            }
            else  // si l'incident est sur les pneus c'est une crevaison
                DoPuncture();


        }

        private void CheckCarHealth()
        {
            if (CarHealthPercent <= 30)
                Race.OnLowHealth(Id);
            else if (CarHealthPercent == 0)
                Race.OnOutOfHealth(Id);
        }

        #endregion TRACK CALL

        #region CONSUMPTION CALCULATION

        public void InitTankAndTiresPotentiel(int TireLifeTime, int FullTankLifeTime)
        {
            TotalThrotlleForFueUnit = FullTankLifeTime * this._totalLapThrottle.Value;
            TotalThrotlleForTiresUnit = TireLifeTime * this._totalLapThrottle.Value;

            Car.InitTiresPotentielIfNeeded(TotalThrotlleForTiresUnit);
        }

        public void CalculIntervalFuelConsumption(bool endOfLap = false)
        {
            if (!Race.RaceParams.FuelImpact || !_totalLapThrottle.HasValue || TotalThrotlleForFueUnit == 0 || IsPacer)
                return;
            if (State == TeamState.PitIn || IsInPitLane || IsInFirstLap)
                return;

           // pas de gestion de Fuel sur un Pacer
           if (IsPacer)
                return;

            bool isAlreadyOutofFuel = OutOfFuel;
            bool isAlreadyLowFuel = LowFuel;

            double nbFuelUnit = 0;
            // On fait un calcul entre la valeur totale d'accélération sur ce tour et une valeur de référence pour une dépense de 1% de fuel

            nbFuelUnit = (double)((_calculationConsumptionIntervalThrottle.Value * (1 + CurrentPilot.FuelHandicap)) / TotalThrotlleForFueUnit) * 100;
            _calculationConsumptionIntervalThrottle = 0;
            // on impacte le pourcentage de Fuel dans l'auto (qui ne peut pas descendre sous 0)
            FuelPercent -= nbFuelUnit;

            if (endOfLap)
            {
                Laps[Laps.Count - 1].FuelPercent = Car.FuelPercent;
                if (Laps.Count > 1)
                    Laps[Laps.Count - 1].FuelConso = Laps[Laps.Count - 2].FuelPercent - Car.FuelPercent;
                else
                    Laps[Laps.Count - 1].FuelConso = 100 - Car.FuelPercent;
            }

            if (FuelPercent <= 0)
                FuelPercent = 0;

            if (OutOfFuel && !isAlreadyOutofFuel)
                Race.OnOutOfFuel(Id);
            else if (LowFuel && !isAlreadyLowFuel)
                Race.OnLowFuel(Id);
        }

        public void CalculIntervalTiresWear(bool endOfLap = false)
        {
            if (Race.RaceParams.TiresImpact == TiresImpactEnum.None)
                return;

            if (State == TeamState.PitIn || IsInPitLane || IsInFirstLap)
                return;

            bool isAlreadyOutOf= OutOfTires;
            bool isAlreadyLow = LowTires;


            if (!IsPacer && LapThrotlesInfos.Count>1) // pas de gestion des pneus pour un pacer
            {
                int endIdx = LapThrotlesInfos.Count - 1;
                Car.Tires.CalculWearTotalValue(LapThrotlesInfos, _thInfosLastUsedIdx,endIdx, FuelPercent);
                _thInfosLastUsedIdx = endIdx;

                if (endOfLap)
                {
                    _thInfosLastUsedIdx = 0;
                    Laps[Laps.Count - 1].TiresPercent = Car.TiresWearPercent;
                    if (Laps.Count > 1)
                        Laps[Laps.Count - 1].TiresWear = Laps[Laps.Count - 2].TiresPercent - Car.TiresWearPercent;
                    else
                        Laps[Laps.Count - 1].TiresWear = 100 - Car.TiresWearPercent;
                }

                if (OutOfTires && !isAlreadyOutOf)
                    Race.OnOutOfTires(Id);
                else if (LowTires && !isAlreadyLow)
                    Race.OnLowTires(Id);
            }
        }

        private void ResetCurrentLapThrottleInfos()
        {
            LapThrotlesInfos.Clear();
            _totalLapThrottle = 0;
            _calculationConsumptionIntervalThrottle = 0;
        }

        private void DoPuncture()
        {
            if (_currentLap != null)
                _currentLap.IncidentCount++;
            Race.OnOutOfTires(Id);
            Car.Tires.DoPuncture();
            CalculMaxPowerCoef();
        }
        #endregion

        #region THROTTLE GESTION
        /// <summary>
        /// Methode de calcul du coefficient de puissance max de la voiture
        /// la puissance est impactée par :
        /// - La santé de la voiture : si la voiture est trop dégradée, la puissance baisse
        /// - La puissance max paramétrée pour le pilote en cours
        /// </summary>
        /// <returns></returns>
        public void CalculMaxPowerCoef()
        {
            if (Race == null)
                return;

            double initialCoef = 1;
            double result = 1;
            double degatsCoef = 1;

            try
            {
                if (IsPacer)
                {
                    if (Race.YellowFlag || Race.SafetyCar)
                    {
                        Pacer.BeginConstantPacer();
                    }
                    else
                    {
                        Pacer.CanStopConstantPacer();
                    }
                }
                else
                {
                    // on commence par limiter la vitesse par rapport à la puissance max du pilote
                    initialCoef = ((double)CurrentPilot.MaxPowerPercent / 100) * ((double)Car.MaxPowerPercent / 100);
                    result = initialCoef;

                    // équipe disqualifiée, stop.
                    if (State == TeamState.Disqualified)
                        result = 0;
                    else
                    {
                        double MaxPowerOnPenalityCoef = ((double)Race.RaceParams.DigitalParams.MaxPowerOnPenality / 100); // coef a appliqué en cas de penalité pour ne pas avantager un pilote sous pénalité

                        if (!(Race is TimeAttackRace))
                        {
                            // si l'auto est en rade (plus de pneus, plus d'essence ou plus de santé) 
                            // on déterminer le coef en fonction du paramètre digitial choisi en cas de panne
                            if (IsBreakDown)
                            {
                                if (this.Race.RaceParams.DigitalParams.ActionOnBreakdowmn == BreakdownActionEnum.EndLapWithPenalityPower) // on termine le tour en mode pénalité
                                    result = initialCoef * MaxPowerOnPenalityCoef;
                                else if (this.Race.RaceParams.DigitalParams.ActionOnBreakdowmn == BreakdownActionEnum.Disquafied) // crash = fin de course
                                {
                                    State = TeamState.Disqualified;
                                    result = 0;
                                    return; // on retunr car on ne doit pas passer dans le reste du traitement de calcul de coef
                                }
                                else // parametre "ne rien" faire ou "Attente prochain pit Stop" on applique le coef dégat
                                {
                                    degatsCoef = 1 - (((100 - CarHealthPercent) * (1 - (double)MaxPowerOnPenalityCoef)) / 100);
                                    result = (double)(initialCoef * degatsCoef);
                                }
                            }
                            // si on est pas en rade, on calcule le coef sur la santé du véhicule
                            else if (CarHealthPercent < 100)         // pas de pénalité, on applique le coef des dégats
                            {
                                degatsCoef = 1 - (((100 - CarHealthPercent) * (1 - (double)MaxPowerOnPenalityCoef)) / 100);
                                result = (double)(initialCoef * degatsCoef);
                            }
                        }

                        // pénalité en cours
                        if (State == TeamState.RunningPenality || EndOfRelayPenality)
                        {
                            //si le coef calculé par l'état de la voiture est donne une vitesse max supérieure à celle de la pénalité,
                            // on réduit pour tomber sur le coef de pénalité.
                            if (result > (initialCoef * MaxPowerOnPenalityCoef))
                                result = initialCoef * MaxPowerOnPenalityCoef;
                        }
                        // Drapeau jaune,  on limite la vitesse selon le paramete global. 
                        else if (Race.YellowFlag)
                        {
                            double yfCoef = initialCoef * ((double)(Race.RaceParams.DigitalParams.MaxPowerOnYellowFlag) / 100);
                            //si le coef calculé par l'état de la voiture  donne une vitesse max supérieure à celle du drapeau jaune, on réduit pour tomber sur le coef du drapeau jaune.
                            if (result > yfCoef)
                                result = yfCoef;
                        }
                        else if (Race.SafetyCar)
                        {
                            double yfCoef = initialCoef * ((double) 35 / 100);
                            //si le coef calculé par l'état de la voiture  donne une vitesse max supérieure à celle du drapeau jaune, on réduit pour tomber sur le coef du drapeau jaune.
                            if (result > yfCoef)
                                result = yfCoef;
                        }
                        if (IsInPitLane)
                        {
                            double pitCoef = initialCoef * ((double)Race.RaceParams.DigitalParams.MaxPowerInPit / 100);
                            if (result > pitCoef)
                                result = pitCoef;
                        }
                    }
                }

                // si le coef de puissance max est trop bas on ne l'applique pas pour ne pas bloquer une voiture sur la piste
                if (State != TeamState.Disqualified && result < 0.15 && !(Race.YellowFlag && Race.RaceParams.DigitalParams.MaxPowerOnYellowFlag > 0))
                    result = 0.15;
                _maxPowerCoef = result;
            }
            catch(Exception ex)
            {
                _maxPowerCoef = initialCoef;
            }
}


        public void GetThrottleValue(int throtlleValue, bool handsetBraking, out int resultThrottle,out CantBrakeEnum canBrake,bool checkAutoTC)
        {
            resultThrottle = throtlleValue;
            canBrake = CantBrakeEnum.Other;

            if (Race == null)
                return;
            // traitement pour un PACER sauf s'il est en mode enregisrement d'un tour
            if (IsPacer && !Pacer.IsRecordingLapThrothlesInfo)
            {
                Pacer.GetThrottleValue(out resultThrottle, out canBrake);
            }
            else if (State == TeamState.PitIn && throtlleValue > 5)
            {
                ThrottlelPitAction(throtlleValue);
                resultThrottle = 0;
                canBrake = CantBrakeEnum.CanBrake;
            }
            else if (State == TeamState.Finished)
            {
                //DDE 19/05/2017 désormais on ne bloque plus des voitures qui ont terminé
                // resultThrottle = 0;
                canBrake = CantBrakeEnum.CanBrake;
            }
            else // traitement pour une voiture normale
            {
                float adhesionLossLevel;
                Car.GetThrottleValue(_maxPowerCoef, throtlleValue, _previousThrottleValue, out resultThrottle, out adhesionLossLevel, Race.RaceParams.TiresImpact == TiresImpactEnum.Acceleration || Race.RaceParams.TiresImpact == TiresImpactEnum.Both);

                if ((resultThrottle == 0 && CurrentPilot.UseDynamicBrake) || handsetBraking)
                    canBrake = CanBrake();
                else
                    ResetBrakingIntervalls();
            }

            if (resultThrottle > this.Race.RaceParams.DigitalParams.SeuilZeroGaz)
                _lastThrottleTime = DateTime.Now;

            // on ajoute pas les valeurs 0 pendant les TC car c'est probablement une pause.
            // pour bien faire il faudrait plutot passer un paramètre permettant de savoir si les voitures roulent pendant les drapeaux jaunes mais
            // pour le moment le traitement reste tout de même équitable, on use moins les pneus pendant un TC.
            if (!(Race.YellowFlag && resultThrottle == 0) && this.State != TeamState.PitIn)
            {
                _totalLapThrottle += resultThrottle;
                _calculationConsumptionIntervalThrottle += resultThrottle;
                // On Enregistre les infos de throttle (pour les pacers à tour variable et aussi pour la gestion de l'usure des pneus)
                LapThrotlesInfos.Add(new HandSetThrotthleInfo(resultThrottle, canBrake == CantBrakeEnum.CanBrake));
            }
            _previousThrottleValue = resultThrottle;
            if(checkAutoTC)
                CheckForAutoTrackCall();
        }

        public void GetThrottleValueForGamePad(int throtlleValue, float gamePadBrakingForceCoef, bool checkAutoTC,
                                               out int resultThrottle, out CantBrakeEnum canBrake,
                                               out bool highAcceleration, out bool strongBraking,
                                               out float brakeAdhesionLoss,  out float accelerationAdhesionLoss)
        {
            resultThrottle = throtlleValue;
            canBrake = CantBrakeEnum.NoBrakeWanted;
            accelerationAdhesionLoss = 0;
            brakeAdhesionLoss = 0;
            highAcceleration = false;
            strongBraking = false;

            if (Race == null)
                return;

            // traitement pour un PACER sauf s'il est en mode enregisrement d'un tour
            if (IsPacer && !Pacer.IsRecordingLapThrothlesInfo)
            {
                Pacer.GetThrottleValue(out resultThrottle, out canBrake);
            }
            else if (State == TeamState.PitIn && throtlleValue > 5)
            {
                ThrottlelPitAction(throtlleValue);
                resultThrottle = 0;
                canBrake = CantBrakeEnum.CanBrake;
            }
            else if (State == TeamState.Finished)
            {
                //DDE 19/05/2017 désormais on ne bloque plus des voitures qui ont terminé
                // resultThrottle = 0;
                canBrake = CantBrakeEnum.CanBrake;
            }
            else // traitement pour une voiture normale
            {
                if (gamePadBrakingForceCoef > 0)
                {
                    canBrake = CanBrakeForGamePad(gamePadBrakingForceCoef, out brakeAdhesionLoss);
                }
                else
                {

                    Car.GetThrottleValue(_maxPowerCoef, throtlleValue, _previousThrottleValue, out resultThrottle, out accelerationAdhesionLoss,Race.RaceParams.TiresImpact == TiresImpactEnum.Acceleration || Race.RaceParams.TiresImpact == TiresImpactEnum.Both);
                    ResetBrakingIntervalls();

                }
            }

            if (resultThrottle > this.Race.RaceParams.DigitalParams.SeuilZeroGaz)
                _lastThrottleTime = DateTime.Now;
            if (resultThrottle > (int)(_previousThrottleValue + ((double)GlobalDatas.MAXACCELERATIONDELTA * 0.90)))
                highAcceleration = true;
            else if (gamePadBrakingForceCoef > 0.9)
                strongBraking = true;

            _previousThrottleValue = resultThrottle;

            // on ajoute pas les valeurs 0 pendant les TC car c'est probablement une pause.
            // pour bien faire il faudrait plutot passer un paramètre permettant de savoir si les voitures roulent pendant les drapeaux jaunes mais
            // pour le moment le traitement reste tout de même équitable, on use moins les pneus pendant un TC.
            if (!(Race.YellowFlag && resultThrottle == 0) && this.State != TeamState.PitIn)
            {
                _totalLapThrottle += resultThrottle;
                _calculationConsumptionIntervalThrottle += resultThrottle;
                // On Enregistre les infos de throttle (pour les pacers à tour variable et aussi pour la gestion de l'usure des pneus)
                LapThrotlesInfos.Add(new HandSetThrotthleInfo(resultThrottle, canBrake == CantBrakeEnum.CanBrake,brakeAdhesionLoss,accelerationAdhesionLoss));
            }

            if (checkAutoTC)
                CheckForAutoTrackCall();
        }



        #endregion THROTTLE GESTION

        #region PIT STOP

        public void SetPitInBeforeRace(bool inPit)
        {
            if (inPit)
            {
                _isInPitLane = true;
                PitIn();

                //_currentPitStopActionSelected = _currentPitStopActionShowed;
                //_currentPitStopActionShowed = PitStopActionEnum.BeforeRace;
            }
            else
            {
                _isInPitLane = false;
                _currentPitStopActionSelected = PitStopActionEnum.None;
                _currentPitStopActionShowed = PitStopActionEnum.None;
            }
        }

        public void EnterPitLane(TimeSpan passTime)
        {
            _isInPitLane = true;
            CalculMaxPowerCoef();
        }

        public void ExitPitLane(TimeSpan passTime)
        {
            _isInPitLane = false;
            CalculMaxPowerCoef();
        }


        public void PitIn()
        {
            if (Race == null)
                return;


            if (State != TeamState.Disqualified)
            {
                if (Race.IsRunning)
                    Statisitics.AddPitStop(CurrentPilot);
                State = TeamState.PitIn;

                SetAvalaiblePitActions();
                SetCurrentPitAction();
            }
        }

        private void SetAvalaiblePitActions()
        {
            _pitStopNextPilot = CurrentPilot;
            _pitStopNextBrakeCurve = null;
            _pitStopNextTHCurve = null;

            PossiblePitStopActions = new List<PitStopActionEnum>();

            if (Race.RaceParams.UseWeatherConditions)
                PossiblePitStopActions.Add(PitStopActionEnum.SelectTires);
            else if (Race.RaceParams.TiresImpact != TiresImpactEnum.None)
                PossiblePitStopActions.Add(PitStopActionEnum.ChangeTires);
            if (Race.RaceParams.ManualRefuel)
            {
                PossiblePitStopActions.Add(PitStopActionEnum.Refuel);
                PossiblePitStopActions.Add(PitStopActionEnum.Repair);
            }
            // Gestion des courbes de puissance et frein
            if (UseGamePadPlayerIndex.HasValue)
            {
                if (CurrentPilot.FavoriteGamePadThrottleCurve.Count > 1)
                    PossiblePitStopActions.Add(PitStopActionEnum.ChangeThCurve);
                if (!InCarPro && CurrentPilot.FavoriteGamePadBrakeCurves.Count > 1)
                    PossiblePitStopActions.Add(PitStopActionEnum.ChangeBrakeCurve);
                else if (InCarPro && CurrentPilot.FavoriteGamePadInCarProBrakeCurve.Count > 1)
                    PossiblePitStopActions.Add(PitStopActionEnum.ChangeBrakeCurve);
            }
            else
            {
                if (CurrentPilot.FavoriteHandsetThrottleCurve.Count > 1)
                    PossiblePitStopActions.Add(PitStopActionEnum.ChangeThCurve);
            }

            if (IsMultiPilot)
                PossiblePitStopActions.Add(PitStopActionEnum.SelectPilot);

            PossiblePitStopActions.Add(PitStopActionEnum.StopPitStop);

            _currentPitStopActionIndex = 0;
        }

        private void PitOut()
        {
            _totalLapThrottle = 0;
            _calculationConsumptionIntervalThrottle = 0;
            _pitStopNextBrakeCurve = null;
            _pitStopNextTHCurve = null;

            LapThrotlesInfos.Clear();
            if (Race.IsRunning)
                PitStopInThisLap = true;
            if (_currentLap != null)
                _currentLap.PitStopInLap = true;

            _pitStopNextPilot = CurrentPilot;
            _pitStopTireTypeShowed = 0;
            _currentPitStopActionIndex = 0;
            if (Race.RaceParams.UseWeatherConditions && !Race.IsRunning)
            {
                _currentPitStopActionSelected = PitStopActionEnum.ReadyToRace;
                _currentPitStopActionShowed = PitStopActionEnum.ReadyToRace;
                _isInPitLane = false;
            }
            else
            {
                _currentPitStopActionSelected = PitStopActionEnum.None;
                _currentPitStopActionShowed = PitStopActionEnum.None;
            }

            // si pas de detection de pitlane ou un seul capteur, une fin de pit = sortie de pitlane
            if (Race.RaceParams.DigitalParams.PitSmartSensorsParams.SensorsCount == 1 || !Race.RaceParams.DigitalParams.UsePitDetection)
                _isInPitLane = false;
            // si la course n'est pas encore commencée, c'est qu'on est en mode prépare to race
            if(!Race.IsRunning )
                _isInPitLane = false;

            State = TeamState.Normal; // on sort des pits, l'état de la team est donc normal.
            
            Race.EndPitStop(this.Id);
        }

        private void ThrottlelPitAction(int throtlleValue)
        {
            if (_currentPitStopActionSelected == PitStopActionEnum.Refuel)
                ManualRefuel(throtlleValue);
            else if (_currentPitStopActionSelected == PitStopActionEnum.Repair)
                ManualRepair(throtlleValue);
        }

        public void PitStopNextAction()
        {
            if (!CanChangePitStopAction())
                return;
            if (_lastPitAction > DateTime.Now.TimeOfDay.TotalMilliseconds - 200)
                return;
            _lastPitAction = DateTime.Now.TimeOfDay.TotalMilliseconds;


            if (_currentPitStopActionSelected == PitStopActionEnum.SelectTires)
            {
                _pitStopTireTypeShowed++;
                if (_pitStopTireTypeShowed > TireType.Wet)
                    _pitStopTireTypeShowed = TireType.Hard;
            }
            else if (_currentPitStopActionSelected == PitStopActionEnum.SelectPilot)
            {
                if (_pitStopNextPilot == Pilot1)
                    _pitStopNextPilot = Pilot2;
                else if (_pitStopNextPilot == Pilot2)
                {
                    if (Pilot3 != null)
                        _pitStopNextPilot = Pilot3;
                    else
                        _pitStopNextPilot = Pilot1;
                }
                else if (_pitStopNextPilot == Pilot3)
                    _pitStopNextPilot = Pilot1;
            }
            else if (_currentPitStopActionSelected == PitStopActionEnum.ChangeThCurve)
            {
                _pitStopNextTHCurve = _pitStopNextTHCurve.HasValue ? _pitStopNextTHCurve+1 : 0;

                if (UseGamePadPlayerIndex.HasValue && _pitStopNextTHCurve > CurrentPilot.FavoriteGamePadThrottleCurve.Count - 1)
                        _pitStopNextTHCurve = 0;
                else if (!UseGamePadPlayerIndex.HasValue  && _pitStopNextTHCurve > CurrentPilot.FavoriteHandsetThrottleCurve.Count - 1)
                    _pitStopNextTHCurve = 0;
            }
            else if (_currentPitStopActionSelected == PitStopActionEnum.ChangeBrakeCurve)
            {
                _pitStopNextBrakeCurve = _pitStopNextBrakeCurve.HasValue ? _pitStopNextBrakeCurve+1 : 0;

                if (UseGamePadPlayerIndex.HasValue)
                {
                    if (!InCarPro && _pitStopNextBrakeCurve > CurrentPilot.FavoriteGamePadBrakeCurves.Count - 1)
                        _pitStopNextBrakeCurve = 0;
                    else if (InCarPro && _pitStopNextBrakeCurve > CurrentPilot.FavoriteGamePadInCarProBrakeCurve.Count - 1)
                        _pitStopNextBrakeCurve = 0;
                }
            }
            else if (_currentPitStopActionSelected == PitStopActionEnum.StopPitStop)
            {
                _currentPitStopActionIndex = 0;
                SetCurrentPitAction();
            }
            else   // l'action en cours n'a pas de sous menu on peut naviguer vers l'action suivante
            {
                _currentPitStopActionIndex++;
                if (_currentPitStopActionIndex >= PossiblePitStopActions.Count)
                    _currentPitStopActionIndex = 0;

                SetCurrentPitAction();
            }

        }

        public void PitStopPrevAction()
        {
            if (!CanChangePitStopAction())
                return;

            if (_lastPitAction > DateTime.Now.TimeOfDay.TotalMilliseconds - 200)
                return;
            _lastPitAction = DateTime.Now.TimeOfDay.TotalMilliseconds;

            if (_currentPitStopActionSelected == PitStopActionEnum.SelectTires)
            {
                _pitStopTireTypeShowed--;
                if (_pitStopTireTypeShowed < TireType.Hard)
                    _pitStopTireTypeShowed = TireType.Wet;
            }
            else if (_currentPitStopActionSelected == PitStopActionEnum.SelectPilot)
            {
                if (_pitStopNextPilot == Pilot1)
                    _pitStopNextPilot = Pilot3 != null ? Pilot3 : Pilot2;
                else if (_pitStopNextPilot == Pilot2)
                {
                    _pitStopNextPilot = Pilot1;
                }
                else if (_pitStopNextPilot == Pilot3)
                    _pitStopNextPilot = Pilot2;
            }
            else if (_currentPitStopActionSelected == PitStopActionEnum.ChangeThCurve)
            {
                _pitStopNextTHCurve = _pitStopNextTHCurve.HasValue ? _pitStopNextTHCurve - 1 : 0;

                if (UseGamePadPlayerIndex.HasValue && _pitStopNextTHCurve < 0)
                    _pitStopNextTHCurve = CurrentPilot.FavoriteGamePadThrottleCurve.Count - 1;
                else if (_pitStopNextTHCurve < 0)
                    _pitStopNextTHCurve = CurrentPilot.FavoriteHandsetThrottleCurve.Count - 1;
            }
            else if (_currentPitStopActionSelected == PitStopActionEnum.ChangeBrakeCurve)
            {
                _pitStopNextBrakeCurve = _pitStopNextBrakeCurve.HasValue ? _pitStopNextBrakeCurve - 1 : 0;

                if (UseGamePadPlayerIndex.HasValue)
                {
                    if (!InCarPro && _pitStopNextBrakeCurve < 0)
                        _pitStopNextBrakeCurve = CurrentPilot.FavoriteGamePadBrakeCurves.Count - 1;
                    else if (InCarPro && _pitStopNextBrakeCurve < 0)
                        _pitStopNextBrakeCurve = CurrentPilot.FavoriteGamePadInCarProBrakeCurve.Count - 1;
                }
            }
            else if (_currentPitStopActionSelected == PitStopActionEnum.StopPitStop)
            {
                _currentPitStopActionIndex = 0;
                SetCurrentPitAction();
            }
            else  // l'action en cours n'a pas de sous menu on peut naviguer vers l'action suivante
            {
                _currentPitStopActionIndex--;
                if (_currentPitStopActionIndex < 0)
                    _currentPitStopActionIndex = PossiblePitStopActions.Count - 1;

                SetCurrentPitAction();
            }
        }

        private void SetCurrentPitAction()
        {
            _currentPitStopActionShowed = PossiblePitStopActions[_currentPitStopActionIndex];
            _currentPitStopActionSelected = PitStopActionEnum.None;
        }

        public void PitStopValidateAction()
        {
            if (_lastPitAction > DateTime.Now.TimeOfDay.TotalMilliseconds - 200 )
                return;
            _lastPitAction = DateTime.Now.TimeOfDay.TotalMilliseconds;

            if (_currentPitStopActionSelected == PitStopActionEnum.None)
            {
                _currentPitStopActionSelected = _currentPitStopActionShowed;
            }
            else
            {
                if (_currentPitStopActionSelected == PitStopActionEnum.ChangeTires)
                {
                    ChangeTires(Car.Tires.Type, true);
                    _currentPitStopActionSelected = PitStopActionEnum.None;
                    PitStopNextAction();
                }
                else if (_currentPitStopActionSelected == PitStopActionEnum.SelectTires)
                {
                    ChangeTires(_pitStopTireTypeShowed, false);

//                    _currentPitStopActionSelected = PitStopActionEnum.None;
                    _currentPitStopActionIndex++;
                    if (_currentPitStopActionIndex >= PossiblePitStopActions.Count)
                        _currentPitStopActionIndex = 0;

                    SetCurrentPitAction();
                }
                else if (_currentPitStopActionSelected == PitStopActionEnum.SelectPilot)
                {
                    ChangeCurrentPilot(_pitStopNextPilot);

                    _currentPitStopActionSelected = PitStopActionEnum.None;
                    //PitStopNextAction();

                    if (this.Race.IsRunning)
                        RelayNumber++; // on passe au relai suivant, même si on a pas changé réellement de pilote, pour le moment on ne controle pas qui était le currrent avant et après
                }
                else if (_currentPitStopActionSelected == PitStopActionEnum.ChangeThCurve)
                {
                    if (_pitStopNextTHCurve != null)
                        ChangeCurrentThrottleCurve(_pitStopNextTHCurve.Value);

                    _currentPitStopActionSelected = PitStopActionEnum.None;
                }
                else if (_currentPitStopActionSelected == PitStopActionEnum.ChangeBrakeCurve)
                {
                    if (_pitStopNextBrakeCurve != null)
                        ChangeCurrentBrakeCurve(_pitStopNextBrakeCurve.Value);

                    _currentPitStopActionSelected = PitStopActionEnum.None;
                }
                else if (_currentPitStopActionSelected == PitStopActionEnum.StopPitStop && CanEndPitStop())
                {
                    PitOut();
                    return;
                }
            }
        }

        public void PitStopCancelAction()
        {
            if (!CanChangePitStopAction())
                return;


            if (_currentPitStopActionSelected != PitStopActionEnum.None)
            {
                SetCurrentPitAction();
            }
        }

        public void DoPitStop(TimeSpan interval)
        {
            // déclenché toute les demies secondes.

            if (FuelPercent < 100 && !Race.RaceParams.ManualRefuel)
            {
                double addFuelValue = ((double)Race.RaceParams.RefuelSpeed * interval.TotalSeconds);
                FuelPercent += addFuelValue;
                if (FuelPercent > 100)
                    FuelPercent = 100;
            }

            if (CarHealthPercent < 100 && !Race.RaceParams.ManualRefuel)
            {
                if (Race.RaceParams.MaxRepairPercent > 0 && _percentRepaired >= Race.RaceParams.MaxRepairPercent)
                    return;

                double addHealthValue = ((double)Race.RaceParams.RepairSpeed * interval.TotalSeconds);
                CarHealthPercent += addHealthValue;
                _percentRepaired += addHealthValue;

                if (CarHealthPercent > 100)
                    CarHealthPercent = 100;
            }

            if(_changingTires)
            {
                Car.Tires.AddTireHealth(25);
                if (Car.Tires.Health == 100)
                    _changingTires = false;
            }

        }

        private void ManualRefuel(int throtlleValue)
        {
            double d = (double)Race.RaceParams.RefuelSpeed / (double)(1000/GlobalDatas.INTERVALBETWEENTWOSIGNALS);
            d = 2*(0.63 / d);

            FuelPercent += ((double)(throtlleValue * d) / (double)100) ;
            if (FuelPercent >= 100)
                FuelPercent = 100;
        }

        private void ManualRepair(int throtlleValue)
        {
            if (Race.RaceParams.MaxRepairPercent > 0 && _percentRepaired >= Race.RaceParams.MaxRepairPercent)
                return;

            double d = (double)Race.RaceParams.RepairSpeed / (double)(1000 / GlobalDatas.INTERVALBETWEENTWOSIGNALS);
            d = 2 * (0.63 / d);
            _percentRepaired += ((double)throtlleValue * d / (double)100);
            CarHealthPercent += ((double)throtlleValue * d / (double)100);

            if (CarHealthPercent >= 100)
                CarHealthPercent = 100;
        }

        private void ChangeCurrentPilot(Pilot pilot)
        {
            EndOfRelay = false;
            EndOfRelayPenality = false;
            Statisitics.RelayBestLap = null;
            RelayBeginTime = Race.RaceDuration;
            RelayNumber++;

            CurrentPilot = pilot;

            SetAvalaiblePitActions();

            // la voiture récupère les parametre du pilote.
            //Car.BrakeLimitation = CurrentPilot.BrakeLimitation;
            //Car.MaxPowerPercent = CurrentPilot.MaxPowerPercent;
            // calcul du coef de puissance
            CalculMaxPowerCoef();
            BrakeIntervalElapsed = 0;
            // Maintenant on va prévenir que l'on a changé de pilote
            OnDriverChanged();
        }


        private void ChangeTires(TireType newTireType,bool useChangeDelay)
        {
            if (_changingTires)
                return;

            if (Race.WeatherScenario != null)
                Car.ChangeTires(newTireType, Race.WeatherScenario.CurrentWeather);
            else
                Car.ChangeTires(newTireType, null);

            if(useChangeDelay)
            {
                Car.Tires.SetHealthToZeroForPitStop();
                _changingTires = true;
            }
        }

        private void ChangeCurrentThrottleCurve(int curveIndex)
        {
            if(UseGamePadPlayerIndex.HasValue)
                CurrentPilot.GamePadThrottleCurve = CurrentPilot.FavoriteGamePadThrottleCurve[curveIndex];
            else
                CurrentPilot.HandsetThrottleCurve = CurrentPilot.FavoriteHandsetThrottleCurve[curveIndex];
            OnDriverCurvesChanged();
        }

        private void ChangeCurrentBrakeCurve(int curveIndex)
        {
            if(InCarPro)
                CurrentPilot.GamePadBrakeCurve = CurrentPilot.FavoriteGamePadInCarProBrakeCurve[curveIndex];
            else
                CurrentPilot.GamePadBrakeCurve = CurrentPilot.FavoriteGamePadBrakeCurves[curveIndex];
            OnDriverCurvesChanged();
        }

        //public void ChangeTireType()
        //{
        //    Car.Tires = TiresManager.Instance.GetNextTires(Car.Tires.Type);
        //    _changingTires = true;
        //}

        protected virtual void OnDriverChanged()
        {
            if (DriverChanged != null)
                DriverChanged(this, EventArgs.Empty);
        }
        protected virtual void OnDriverCurvesChanged()
        {
            if (DriverCurvesChanged != null)
                DriverCurvesChanged(this, EventArgs.Empty);
        }

        private bool CanEndPitStop()
        {
            return !_changingTires;
        }
        private bool CanChangePitStopAction()
        {
            //return !_changingTires;
            return true;
        }

        #endregion PIT STOP


        public void CalculTimeAttackTimeLeft()
        {
            // Gestion TimeAttack
            if (Race is TimeAttackRace && PassedFirstTime)
            {
                if (TimeAttackTimeLeft > Race.RaceParams.TimeAttackStartBonus)
                    TimeAttackTimeLeft = TimeAttackLapTarget.Add(Race.RaceParams.TimeAttackStartBonus);
                else
                    TimeAttackTimeLeft = TimeAttackLapTarget.Add(TimeAttackTimeLeft);
            }
        }

        #region PACER RECORDING LAP

        public void IniRecordingPacerLap()
        {
            IsPacer = true;
            if (Pacer.LapThrotlesInfos_Initial == null)
                Pacer.LapThrotlesInfos_Initial = new List<HandSetThrotthleInfo>();
            Pacer.LapThrotlesInfos_Initial.Clear();
            Pacer.IsRecordingLapThrothlesInfo = true;
            Laps.Clear();
        }
        #endregion PACER RECORDING LAP


        #region GESTION DU FREIN 
        public CantBrakeEnum CanBrake()
        {
            CantBrakeEnum canBrakeResult = CantBrakeEnum.CanBrake;

            // si on est pas encore entrain de freiner on commencer par appliquer le délai de freinage
            // si le délai de freinage est dépassé alors on applique la méthode de limitation du frein
            if (!IsBraking && Car.Tires.BrakingDelai > 0)
            {
                canBrakeResult = CantBrakeEnum.Delay;

                //if (DateTime.Now.TimeOfDay.TotalMilliseconds - BrakeElapsedTime >= Car.Tires.BrakingDelai)
                if (BrakeElapsedTime > 0 && DateTime.Now.TimeOfDay.TotalMilliseconds - BrakeElapsedTime >= Car.Tires.BrakingDelai)
                {
                    canBrakeResult = CantBrakeEnum.CanBrake;
                    IsBraking = true;
                    BrakeElapsedTime = 0;
                }
            }
            else // le freinage est déja déclenché
            {
                int dynamicBrakeInterval = CurrentPilot.BrakeLimitation + Car.BrakeLimitation + Car.Tires.BrakingIntervall; // limitation du frein si la gestion des pneus est activée
                // si pas de limitation du frein ou que le cycle est dépassé, on freine
                if (dynamicBrakeInterval == 0 || BrakeIntervalElapsed >= dynamicBrakeInterval)
                    canBrakeResult = CantBrakeEnum.CanBrake;
                else
                    canBrakeResult = CantBrakeEnum.SoftBraking;

            }

            if (canBrakeResult != CantBrakeEnum.CanBrake)
            {
                BrakeIntervalElapsed++;
                if (BrakeElapsedTime == 0)
                    BrakeElapsedTime = DateTime.Now.TimeOfDay.TotalMilliseconds;
            }
            else
                BrakeIntervalElapsed = 0;

            return canBrakeResult;
        }


        public CantBrakeEnum CanBrakeForGamePad(float brakeForceCoef,out float adhesionLossLevel)
        {
            CantBrakeEnum canBrakeResult = CantBrakeEnum.CanBrake;
            adhesionLossLevel = 0;

            if (brakeForceCoef > 0)
            {

                // si on est pas encore entrain de freiner on commencer par appliquer le délai de freinage
                // si le délai de freinage est dépassé alors on applique la méthode de limitation du frein
                if (!IsBraking && Car.Tires.BrakingDelai > 0)
                {
                    canBrakeResult = CantBrakeEnum.Delay;
                    adhesionLossLevel = (float)0.5;
                    if (BrakeElapsedTime > 0 && DateTime.Now.TimeOfDay.TotalMilliseconds - BrakeElapsedTime >= Car.Tires.BrakingDelai)
                    {
                        canBrakeResult = CantBrakeEnum.CanBrake;
                        IsBraking = true;
                        BrakeElapsedTime = 0;
                    }
                }
                else // le freinage est déja déclenché, on est plus soumis au délais mais  juste à la problématique d'adhérence
                {
                    // comme on a un frein progressif, on peut utiliser le brakeforce pour savoir si on ne demande pas un freinage trop appuyé.
                    // si la force du freinage demandé est trop importante, alors on dérape, donc perte d'adhérence.

                    float tireMaxBrakeForce = (float)(1 - ((double)Car.Tires.BrakingIntervall / (double)GlobalDatas.BTV_1.BrakeCycle));
                    // Plutot que de limiter le frein, on va plutot autoriser le freinage,mais passer la perte d'adhérence au gamepad.
                    // il pourra l'utiliser pour valider ou non freinage.
                    if (Race.RaceParams.TiresImpact == TiresImpactEnum.Both || Race.RaceParams.TiresImpact == TiresImpactEnum.Braking)
                    {
                        adhesionLossLevel = brakeForceCoef - tireMaxBrakeForce;
                        if (adhesionLossLevel < 0)
                            adhesionLossLevel = 0;
                    }
                }

                // on ne freine pas mais on a demandé le freinage, donc on fix le délai 
                if (canBrakeResult != CantBrakeEnum.CanBrake && brakeForceCoef > 0)
                {
                    if (BrakeElapsedTime == 0)
                        BrakeElapsedTime = DateTime.Now.TimeOfDay.TotalMilliseconds;
                }
            }
            else
                canBrakeResult = CantBrakeEnum.NoBrakeWanted;

            return canBrakeResult;
        }

        // une fois que l'auto reprend une phase d'accélération on remet à 0 les compteurs
        public void ResetBrakingIntervalls()
        {
            BrakeIntervalElapsed = 0;
            BrakeElapsedTime = 0;
            IsBraking = false;
        }

        #endregion


        #region COMPARE POUR SORT AUTOMATIQUE SUR LA POSITION

        public int CompareTo(object y)
        {
            if (Race is Qualification)
            {
                if (Statisitics.TeamBestLap == null && (y as TeamInRace).Statisitics.TeamBestLap == null)
                    return 0;
                else if (Statisitics.TeamBestLap == null)
                    return 1;
                else if ((y as TeamInRace).Statisitics.TeamBestLap == null)
                    return -1;
                else
                    return Statisitics.TeamBestLap.Value.CompareTo((y as TeamInRace).Statisitics.TeamBestLap.Value);

            }
            else
            {
                // si les deux équipes sont disqualifiées ou aucune n'est disqualifiée le classement se fait sur les tours couverts.
                if ((State == TeamState.Disqualified && (y as TeamInRace).State == TeamState.Disqualified) || (State != TeamState.Disqualified && (y as TeamInRace).State != TeamState.Disqualified))
                {
                    if (this.LapCount > (y as TeamInRace).LapCount) // X est avant Y
                        return -1;
                    else if ((y as TeamInRace).LapCount > this.LapCount) // Y est avant X
                        return 1;
                    else
                    {
                        //if (this.PassedFirstTime && !(y as TeamInRace).PassedFirstTime)
                        //    return -1;
                        //else if (!this.PassedFirstTime && (y as TeamInRace).PassedFirstTime)
                        //    return 1;
                        if ((!this.IsInFirstLap && !(y as TeamInRace).IsInFirstLap) || (this.IsInFirstLap && (y as TeamInRace).IsInFirstLap))
                            return TimeSpan.Compare(this.LastLapEnd, (y as TeamInRace).LastLapEnd);
                        else if (!this.IsInFirstLap && (y as TeamInRace).IsInFirstLap)
                            return -1;
                        else if (this.IsInFirstLap && !(y as TeamInRace).IsInFirstLap)
                            return 1;
                        else
                            return 0;
                    }
                }
                else // si seulement une des équipe est disqualifiée
                {
                    if (State == TeamState.Disqualified)
                        return 1;
                    else
                        return -1;
                }
            }

        }

        #endregion
    }


    public class TeamInRaceCollection : Dictionary<int, TeamInRace>
    {
        // key = team lane ID
        // value = team

        public TeamInRaceCollection()
        {

        }

        public void AddTeam(int laneId)
        {
            if (!this.ContainsKey(laneId))
            {
                this.Add(laneId, new TeamInRace(laneId));
                if (this[laneId].Statisitics != null)
                    this[laneId].Statisitics.Position = this.Count;

            }
        }
        public void AddTeam(int laneId, TeamInRace team)
        {
            if (!this.ContainsKey(laneId))
            {
                team.Id = laneId;
                this.Add(laneId, team);
                if (team.Statisitics != null)
                    this[laneId].Statisitics.Position = this.Count;
            }
        }

        public void AddTeam(TeamInRace team)
        {
            if (!this.ContainsKey(team.Id))
            {
                this.Add(team.Id, team);
                if (team.Statisitics != null)
                    this[team.Id].Statisitics.Position = this.Count;
            }
        }

        public void ChangeLaneId(int oldId, int newId)
        {
            TeamInRace teamToChange = null;
            TeamInRace teamToReplace = null;

            if (this.ContainsKey(oldId))
            {
                teamToChange = this[oldId];
                this.Remove(oldId);

                if (this.ContainsKey(newId))
                {
                    teamToReplace = this[newId];
                    this.Remove(newId);
                }
            }


            if (teamToChange != null)
            {
                teamToChange.Id = newId;
                this.Add(newId, teamToChange);
                if (teamToReplace != null)
                {
                    teamToReplace.Id = oldId;
                    this.Add(oldId, teamToReplace);
                }
            }

        }

    }



    public class TeamInRaceSortedList : List<TeamInRace>
    {

        public TeamInRaceSortedList()
        {
        }

        public void SortByLapCount()
        {
            this.Sort(delegate (TeamInRace x, TeamInRace y)
            {
                if (x.LapCount == 0 && y.LapCount == 0)
                    return 0;
                else if (x.LapCount == 0)
                    return -1;
                else if (y.LapCount == 0)
                    return 1;
                else
                    return x.LapCount.CompareTo(y.LapCount);
            });
        }


        public void SortByPosition()
        {
            this.Sort(delegate (TeamInRace x, TeamInRace y)
            {
                if (x.Statisitics.Position == 0 && y.Statisitics.Position == 0)
                    return 0;
                else if (x.Statisitics.Position == 0)
                    return -1;
                else if (y.Statisitics.Position == 0)
                    return 1;
                else
                    return x.Statisitics.Position.CompareTo(y.Statisitics.Position);
            });
        }
    }

}
