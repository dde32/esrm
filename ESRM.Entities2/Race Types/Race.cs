using ESRM.Entities.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{

    public delegate void PitStopEventHandler(object sender, LaneIdEventArgs e);
    public delegate void TeamEventHandler(object sender, LaneIdEventArgs e);

    public abstract class Race
    {
        #region FIELDS
        protected IDigitalParamsBase _digitalParams;
        protected TeamInRaceSortedList _classement;
        Dictionary<int, int> _classementByColors;
        protected RaceState _state = RaceState.NotStarted;
        protected bool _yellowFlag;


        protected Random random;
        public string _log = string.Empty;

        #region EVENTS

        public event EventHandler LapEndedEvent;
        public event EventHandler RaceFinished;
        public event EventHandler RacePaused;
        public event EventHandler RaceUnPaused;
        public event EventHandler RaceStarted;
        public event EventHandler YellowFlagEvent;
        public event EventHandler GreenFlagEvent;
        public event PitStopEventHandler PitStopBegin;
        public event PitStopEventHandler PitStopEnded;
        public event PitStopEventHandler PitStopRefresh;
        public event TeamEventHandler LapRecordEvent;
        public event TeamEventHandler LowFuelEvent;
        public event TeamEventHandler OutOfFuelEvent;
        public event TeamEventHandler LowTiresEvent;
        public event TeamEventHandler OutOfTiresEvent;
        public event TeamEventHandler LowHealthEvent;
        public event TeamEventHandler OutOfHealthEvent;
        public event TeamEventHandler IncidentEvent;
        public event TeamEventHandler TeamFinish;
        public event TeamEventHandler TeamEndRelay;
        public event TeamEventHandler TeamAdded;
        public event EventHandler WeatherChanged;
        
        public event EventHandler DebugEvent;


        #endregion

        #endregion

        #region PROPERTIES

        public RaceParameters RaceParams
        {
            get;
            set;
        }

        public WeatherScenario WeatherScenario
        {
            get; set;
        }

        public TeamInRaceCollection Teams
        {
            get { return RaceParams.Teams; }
        }

        public virtual string GetTitle()
        {
            return Textes.Race;
        }

        #region INDICATIONS D'ETAT

        public RaceState State
        {
            get { return _state; }
        }

        public bool IsRunning
        {
            get { return _state == RaceState.Started; }
        }


        public bool YellowFlag
        {
            get { return _state == RaceState.Started && _yellowFlag; }
        }

        public bool IsFirstLap
        {
            get { return CurrentLap == 1 && _state == RaceState.Started; }
        }

        public bool IsLastLap
        {
            get { return CurrentLap == RaceParams.LapCount && _state == RaceState.Started; }
        }

        public int? FastestTeamId
        {
            get;
            set;
        }

        public TimeSpan? FastestLap
        {
            get;
            set;
        }

        protected int? CurrentTeamId
        {
            get;
            set;
        }
        
        public string ForeCastProbabilityForUI
        {
            get
            {
                if (WeatherScenario == null || WeatherScenario.CurrentWeather == null)
                    return string.Empty;
                return string.Format("{0}{1}{2}%", WeatherScenario.TimeBeforeNextEvolutionForUI, Environment.NewLine, WeatherScenario.NextWeather.ForeCastProbability);
            }
        }
        public string TemperatureForUI
        {
            get
            {
                if (WeatherScenario == null || WeatherScenario.CurrentWeather == null)
                    return string.Empty;
                return string.Format("{0}°C", WeatherScenario.CurrentWeather.Temperature);

            }
        }
        public string TrackTemperatureForUI
        {
            get
            {
                if (WeatherScenario == null || WeatherScenario.CurrentWeather == null)
                    return string.Empty;
                return string.Format("{0}°C", WeatherScenario.CurrentWeather.TrackTemperature);
            }
        }
        public string GlobalTrackTemperatureForUI
        {
            get
            {
                if (WeatherScenario == null || WeatherScenario.CurrentWeather == null)
                    return string.Empty;
                return string.Format("{0}{1}Track{2}{3}", TemperatureForUI, Environment.NewLine, Environment.NewLine, TrackTemperatureForUI);
            }
        }


        #endregion

        // temps de course déja passé
        public TimeSpan RaceDuration { get; set; }

        public int CurrentLap
        {
            get;
            set;
        }

        public int MaxRamdomValueForIncident
        {
            get;
            set;
        }

        public List<TeamInRace> ClassedTeams
        {
            get { return _classement; }
        }
        public Dictionary<int, int> ClassementByColors
        {
            get { return _classementByColors; }
        }

        public bool SafetyCar { get; set; }
        public bool EndSafetyCarInThisLap { get; set; }

        #endregion

        protected void Init(IDigitalParamsBase digitalParams)
        {
            _digitalParams = digitalParams;
            random = new Random();
            _classement = new TeamInRaceSortedList();
            _classementByColors = new Dictionary<int, int>();

            foreach (KeyValuePair<int, TeamInRace> entry in RaceParams.Teams)
            {
                entry.Value.Race = this;
            }

            if (RaceParams.UseWeatherConditions && WeatherScenario == null && RaceParams.WeatherParams != null &&
                            (RaceParams.LapCount.HasValue || RaceParams.TimeLimit.HasValue))
            {
                WeatherScenario = new WeatherScenario(RaceParams.WeatherParams, RaceParams);

                WeatherScenario.WeatherChanged += WeatherScenario_WeatherChanged;
            }

            ResetRace(false, false);

        }

        private void WeatherScenario_WeatherChanged(object sender, EventArgs e)
        {
            OnWeatherChanged();

            foreach (KeyValuePair<int, TeamInRace> entry in Teams)
                entry.Value.Car.Tires.SetCurrentWeatherConditions(WeatherScenario.CurrentWeather);
        }

        public virtual void ResetRace(bool resetPosition, bool resetQualifPosition)
        {
            _state = RaceState.NotStarted;
            CurrentLap = 0;
            FastestLap = null;
            FastestTeamId = null;
            CurrentTeamId = null;

            foreach (KeyValuePair<int, TeamInRace> entry in Teams)
            {
                entry.Value.Reset(resetPosition, resetQualifPosition, _digitalParams.PowerBaseMaxThrottleValue);

                // Race max power ?
                if (!RaceParams.EnablePowerAdjustement)
                    entry.Value.Car.MaxPowerPercent = RaceParams.CarsMaxPower;


                if (RaceParams.UseWeatherConditions && WeatherScenario != null && RaceParams.WeatherParams != null)
                    entry.Value.Car.Tires = TiresManager.Instance.GetNewtTires(WeatherScenario.CurrentWeather.OptimalTireType);
                else
                    entry.Value.Car.Tires = TiresManager.Instance.GetNewtTires(TireType.Medium);

                entry.Value.Car.Tires.SetPowerBaseMaxThrottleValue(_digitalParams.PowerBaseMaxThrottleValue);

                if (RaceParams != null && (RaceParams.UseWeatherConditions || entry.Value.IsMultiPilot) && !IsRunning)
                {
                    entry.Value.SetPitInBeforeRace(true);
                }
                else
                    entry.Value.SetPitInBeforeRace(false);
            }
            _classement.Clear();
            _classementByColors.Clear();

            if (RaceParams.OneByOneRace && Teams.Count > 0)
                CurrentTeamId = 1;

        }

        #region RACE COMMANDES

        public virtual bool CanStart()
        {
            if (State == RaceState.NotStarted)
            {
                foreach (KeyValuePair<int, TeamInRace> entry in Teams)
                {
                    if (entry.Value.PitStopRunning)
                        return false;
                }
                return true;
            }
            else
                return true;
        }

        
        public virtual void Start()
        {
            _log = string.Empty;
            InitIncidentInterval();
            _state = RaceState.Started;

            if (RaceParams.RollingStartLapCount > 0)
                SafetyCar = true;

            OnRaceStarted();
        }

        public virtual void Pause()
        {
            if (_state == RaceState.Started)
            {
                _state = RaceState.Paused;
                foreach (KeyValuePair<int, TeamInRace> entry in Teams)
                {
                    if (entry.Value.IsPacer)
                        entry.Value.Pacer.BeginConstantPacer();
                }

                OnRacePaused();
            }
        }

        public virtual void UnPause()
        {
            if (_state == RaceState.Paused)
            {
                _state = RaceState.Started;
                foreach (KeyValuePair<int, TeamInRace> entry in Teams)
                {
                    if (entry.Value.IsPacer)
                        entry.Value.Pacer.CanStopConstantPacer();
                }
                OnRaceUnPaused();
            }
        }

        public virtual void Finish()
        {
            if (_state == RaceState.Started || _state == RaceState.Paused)
            {
                _state = RaceState.Ended;
                foreach (KeyValuePair<int, TeamInRace> entry in Teams)
                {
                    entry.Value.ComputeStats();
                    entry.Value.CalculMaxPowerCoef();
                    if (!_classementByColors.ContainsKey(entry.Value.Color))
                        _classementByColors.Add(entry.Value.Color, entry.Value.LapCount);
                    else
                        _classementByColors[entry.Value.Color] = _classementByColors[entry.Value.Color] + entry.Value.LapCount;
                }

                _classementByColors = _classementByColors.OrderByDescending(e => e.Value).ToDictionary(k => k.Key,v=>v.Value) ;

                OnRaceFinished();
            }
        }

        public virtual void PutYellowFlag()
        {
            if (_state == RaceState.Started || _state == RaceState.Paused)
            {
                _yellowFlag = true;

                // si on déclenche un YF on doit calculer les nouvelles VMAx de chaque voitures
                foreach (KeyValuePair<int, TeamInRace> entry in Teams)
                    entry.Value.CalculMaxPowerCoef(); // si la team est en mode pacer elle va gérer le passage en mode constant.

                OnYellowFlag();
            }
        }
        public virtual void PutGreenFlag()
        {
            if (_state == RaceState.Started || _state == RaceState.Paused)
            {
                _yellowFlag = false;
                // si on déclenche un GF on doit calculer les nouvelles VMAx de chaque voitures
                foreach (KeyValuePair<int, TeamInRace> entry in Teams)
                    entry.Value.CalculMaxPowerCoef();// si la team est en mode pacer elle va gérer le passage en mode constant.

                OnGreenFlag();
            }
        }


        #endregion RACE STATE

        #region EVENTS
        protected virtual void OnRaceStarted()
        {
            if (RaceStarted != null)
                RaceStarted(this, EventArgs.Empty);
        }

        protected virtual void OnRaceFinished()
        {
            if (RaceFinished != null)
                RaceFinished(this, EventArgs.Empty);

        }

        protected virtual void OnRacePaused()
        {
            if (RacePaused != null)
                RacePaused(this, EventArgs.Empty);
        }

        protected virtual void OnRaceUnPaused()
        {
            if (RaceUnPaused != null)
                RaceUnPaused(this, EventArgs.Empty);
        }

        protected virtual void OnYellowFlag()
        {
            if (YellowFlagEvent != null)
                YellowFlagEvent(this, EventArgs.Empty);
        }
        protected virtual void OnWeatherChanged()
        {
            if (WeatherChanged != null)
                WeatherChanged(this, EventArgs.Empty);
        }
               

        protected virtual void OnGreenFlag()
        {
            if (GreenFlagEvent != null)
                GreenFlagEvent(this, EventArgs.Empty);
        }

        protected virtual void OnIncident(int laneId)
        {
            if (IncidentEvent != null)
                IncidentEvent(this, new LaneIdEventArgs(laneId));
        }

        protected virtual void OnTeamFinish(int laneId)
        {
            if (TeamFinish != null)
                TeamFinish(this, new LaneIdEventArgs(laneId));
        }

        protected void OnLapEndedEvent()
        {
            if (LapEndedEvent != null)
                LapEndedEvent(this, EventArgs.Empty);
        }

        protected virtual void OnLapRecord(int laneId)
        {
            if (LapRecordEvent != null)
                LapRecordEvent(this, new LaneIdEventArgs(laneId));
        }

        public virtual void OnLowFuel(int laneId)
        {
            if (LowFuelEvent != null)
                LowFuelEvent(this, new LaneIdEventArgs(laneId));
        }

        public virtual void OnOutOfFuel(int laneId)
        {
            if (OutOfFuelEvent != null)
                OutOfFuelEvent(this, new LaneIdEventArgs(laneId));
        }

        public virtual void OnLowTires(int laneId)
        {
            if (LowTiresEvent != null)
                LowTiresEvent(this, new LaneIdEventArgs(laneId));
        }

        public virtual void OnOutOfTires(int laneId)
        {
            if (OutOfTiresEvent != null)
                OutOfTiresEvent(this, new LaneIdEventArgs(laneId));
        }

        public virtual void OnLowHealth(int laneId)
        {
            if (LowHealthEvent != null)
                LowHealthEvent(this, new LaneIdEventArgs(laneId));
        }

        public virtual void OnOutOfHealth(int laneId)
        {
            if (OutOfHealthEvent != null)
                OutOfHealthEvent(this, new LaneIdEventArgs(laneId));
        }


        protected virtual void OnEndOfRealy(int laneId)
        {
            if (TeamEndRelay != null)
                TeamEndRelay(this, new LaneIdEventArgs(laneId));
        }

        protected virtual void OnTeamAdded(int laneId)
        {
            if (TeamAdded != null)
                TeamAdded(this, new LaneIdEventArgs(laneId));
            
        }
        #endregion


        public void TimeAttackTickTime(TimeSpan interval)
        {
            //bool oneFinished = false;
            //int countFinished = 0;

            foreach (KeyValuePair<int, TeamInRace> entry in Teams)
            {
                if (entry.Value.State == TeamState.Finished)
                {
                }
                else
                {
                    entry.Value.TimeAttackTimeLeft = entry.Value.TimeAttackTimeLeft - interval;

                    if (entry.Value.TimeAttackTimeLeft.TotalMilliseconds <= 0)
                    {
                        entry.Value.Finish();
                        OnTeamFinish(entry.Value.Id);
                    }
                }
            }

            CheckForRaceEnd();
        }


        // fin de tour pour une ligne avec information de lapTime
        public virtual void DoEndOfLap(int laneId, TimeSpan passTime,bool forceExitPitLane,bool isJokerLap)
        {
            if (!IsRunning)
                return;
            if (!Teams.ContainsKey(laneId))
                return;

            RaceDuration = passTime; // mise à jour du temps de course directement en fonction de l'information passée par la PB

            if (CurrentLap == 0) // mise à jour du tour en cours si on est sur le premier tour.
                CurrentLap++;

            TeamInRace team = Teams[laneId];
            if (team.State != TeamState.Finished) // Si la team qui vient de passer la ligne n'a pas déja terminée
            {
                bool added = team.AddLap(passTime, forceExitPitLane, isJokerLap); // Gestion du tour pour la team
                if (!added)
                    return;

                bool isFirstLapOnPass = IsFirstLap;

                // si la voiture qui vient de passer est dans le tour courrant, c'est celle de tête, on augmente le tour en cours
                bool raceNextLap = team.LapCount == CurrentLap && team.LapCount > 0;
                if (raceNextLap)
                    CurrentLap++;

                try
                {
                    //// Est ce qu'au moins une équipe à déja terminé la course 
                    bool oneFinished = Teams.Count(t => t.Value.State == TeamState.Finished) > 0;
                    CheckIfTeamFinishRace(team, oneFinished);

                    // Classement de la course
                    DoClassement();
                    // event de fin de tour pour prévenir l'UI.
                    OnLapEndedEvent();
                    // est ce que la course est finie
                    CheckForRaceEnd();

                    EndLapCalculs(laneId, isFirstLapOnPass, raceNextLap, isJokerLap);
                }
                catch(Exception ex)
                {
                    string mess = ex.Message;
                }

            }
        }

        // fin de tour pour une ligne avec information de lapTime
        protected virtual void EndLapCalculs(int laneId,bool isFirstLap,bool raceNextLap,bool isJokerLap)
        {
            if (!IsRunning)
                return;
            if (!Teams.ContainsKey(laneId))
                return;

            TeamInRace team = Teams[laneId];
            if (team.State != TeamState.Finished) // Si la team qui vient de passer la ligne n'a pas déja terminée
            {
                if (!isFirstLap && WeatherScenario != null)
                    WeatherScenario.EvolveWeather(RaceDuration);

                // si la voiture qui vient de passer est dans le tour courrant, c'est celle de tête, on augmente le tour en cours
                if (raceNextLap)
                {
                    if (EndSafetyCarInThisLap)
                    {
                        SafetyCar = false;
                        EndSafetyCarInThisLap = false;
                        // safety car est rentrée on recalcule les coef de toutes les teams
                        foreach (KeyValuePair<int, TeamInRace> entry in Teams)
                            entry.Value.CalculMaxPowerCoef();
                    }
                    if (RaceParams.RollingStartLapCount > 0 && SafetyCar && CurrentLap >= RaceParams.RollingStartLapCount)
                        EndSafetyCarInThisLap = true;
                }

                try
                {
                    // gestion du meilleur tour 
                    if (!isJokerLap && !isFirstLap && (!FastestLap.HasValue || (team.LapCount > 0 && team.LastLapTime < FastestLap.Value)))
                    {
                        OnLapRecord(team.Id);

                        if (FastestTeamId.HasValue)
                            Teams[FastestTeamId.Value].Statisitics.SetFastestLap(false); // l'ancienne team disposant du fastest lap est mise à false

                        FastestLap = team.LastLapTime;
                        FastestTeamId = team.Id;
                        team.Statisitics.SetFastestLap(true);
                    }
                    // FIN gestion du meilleur tour

                    // incidents aléatoires + declencement de l'évent si nécessaire
                    if (RaceParams.Damages == DamagesEnum.Random || RaceParams.Damages == DamagesEnum.Both)
                        PerformRandomIncident();

                    // Est ce que la team en cours est en fin de relais ?
                    if (team.EndOfRelay)
                        OnEndOfRealy(team.Id);

                    team.CalculMaxPowerCoef();
                }
                catch (Exception ex)
                {
                    string mess = ex.Message;
                }
            }
        }


        protected virtual void CheckIfTeamFinishRace(TeamInRace team, bool oneFinished)
        {
            // si au moins une équipe a terminé la course et que la fin de course est standard, tout le monde à terminé
            if (oneFinished && this.RaceParams.EndRaceType == EndRaceType.Standard)
            {
                if (RaceParams.OneByOneRace)
                    CurrentTeamId = team.Id + 1;
                team.Finish();
                OnTeamFinish(team.Id);
            }
            else
            {
                // si la course est une course à nombre de tour défini
                if (this.RaceParams.RaceType == RaceType.GP)
                {
                    // l'équipe en cours vient de terminer la course (nombre tour et état pas encore finish)
                    if (team.LapCount >= this.RaceParams.LapCount)
                    {
                        if (RaceParams.OneByOneRace)
                            CurrentTeamId = team.Id + 1;

                        team.Finish();
                        OnTeamFinish(team.Id);
                    }
                }
                // Est ce que l'équipe qui vient de terminer le tour a fini la course.
                else if ((this.RaceParams.RaceType == RaceType.Endurance || this.RaceParams.RaceType == RaceType.Qualification) && RaceDuration >= this.RaceParams.TimeLimit.Value)
                {
                    if (RaceParams.OneByOneRace)
                        CurrentTeamId = team.Id + 1;

                    team.Finish();
                    OnTeamFinish(team.Id);
                }
            }
        }

        protected virtual void DoClassement() //, out int countFinished)
        {
            if (_classement.Count == 0)
                _classement.AddRange(Teams.Values.ToList());

            _classement.Sort();

            int leaderLapCount = 0;
            // calcul de la position et du gap mais aussi controle de chaque équipe pour savoir si elles ont terminé la course
            for (int i = 0; i < _classement.Count; i++)
            {
                if (_classement[i].LapCount > 0 && _classement[i].State != TeamState.Finished)
                {
                    if (i == 0) // si l'équipe est en tête, pas de Gap
                    {
                        leaderLapCount = _classement[i].LapCount;
                        _classement[i].Statisitics.Gap = string.Empty;
                    }
                    else
                    {
                        int lapDiff = _classement[i - 1].LapCount - _classement[i].LapCount;
                        if (lapDiff < 2 && !_classement[i].IsInFirstLap && !_classement[i - 1].IsInFirstLap)
                        {
                            TimeSpan gap = (_classement[i].LastLapEnd - _classement[i - 1].LastLapEnd);
                            _classement[i].Statisitics.Gap = string.Format("+{0}", gap.ToString(@"ss\.ff"));
                        }
                        else if (_classement[i].LapCount > 1)
                            _classement[i].Statisitics.Gap = string.Format("{0} {1}", lapDiff - 1, Textes.Laps);
                    }

                }
                _classement[i].Statisitics.Position = i + 1;
                //if(leaderLapCount == _classement[i].Laps.Count)
                //    _classement[i].Laps[leaderLapCount - 1].Position = _classement[i].Position;
            }

        }
        public abstract void CheckForRaceEnd();//, int countFinished);


        #region FUEL ET HEALTH

        protected virtual void InitIncidentInterval()
        {
        }


        // Déclenche un éventuel incident aléatoire sur les teams en course
        protected virtual void PerformRandomIncident()
        {
            if ((RaceParams.Damages == DamagesEnum.Random || RaceParams.Damages == DamagesEnum.Both))
            {
                // le principe est de tirer un numéro random entre 0 et une valeur max, cette valeur max est calculée en fonction
                // du nombre de tours, du nombre d'équipe et du coefficient de probabilité que l'on souhaite appliquer (très rare, rare, moyen, fréquent, très fréquent)
                int res = random.Next(0, MaxRamdomValueForIncident); //for ints
                if (res == 1)
                {
                    int teamId = random.Next(0, Teams.Count); // on choisi la team impactée au hasard. (la borne max est exclusive, donc on met le nbre de team et pas team-1)

                    if (Teams[teamId].CanHaveIncident && !Teams[teamId].IsPacer)
                    {
                        int dammages = random.Next(1, 11);
                        DamageTypeEnum damageType = DamageTypeEnum.None;

                        if (dammages <= 2) // entre 1 et 2 c'est du dommage moteur -> on prend la valeur maxi
                        {
                            damageType = DamageTypeEnum.Engine;
                            Teams[teamId].Incident(RaceParams.DigitalParams.DamagesPercentMax, damageType);
                        }
                        else if (dammages <= 6) // entre 3,4,5,6 (40% de chance) c'est du dommage suspenssion 
                        {
                            damageType = DamageTypeEnum.Suspension;
                            Teams[teamId].Incident(RaceParams.DigitalParams.DamagesPercentNormal, damageType);
                        }
                        else if (dammages <= 8) // entre 7 ou 8 (20% de chance) c'est du dommage carrosseries -> on prend la valeur maxi
                        {
                            damageType = DamageTypeEnum.Brake;
                            Teams[teamId].Incident(RaceParams.DigitalParams.DamagesPercentMin, damageType);
                        }
                        else if (dammages <= 10 && RaceParams.TiresImpact != TiresImpactEnum.None) // 9 ou 10 (20% de chance) c'est une crevaison 
                        {
                            damageType = DamageTypeEnum.Tires;
                            Teams[teamId].Incident(0, damageType);
                        }

                        OnIncident(teamId); // +1 car on doit passer le laneId et pas l'index dans le tableau
                    }
                }
            }
        }

        #endregion


        #region TRACKCALL

        public virtual void DoTrackCall(int laneId)
        {
            int teamId = laneId ;

            if (teamId >= 0)
            {
                Teams[teamId].DoTrackCall();
            }

            PutYellowFlag();
        }

        public void DoEndOfTrackCall(int laneId)
        {
            if (laneId > 0)
                Teams[laneId].DoEndOfTrackCall();
            PutGreenFlag();
        }

        #endregion


        #region GESTION DES PITSTOPS

        public virtual void TeamEnterPitLane(int laneId, TimeSpan passTime)
        {
            Teams[laneId].EnterPitLane(passTime);

            if (RaceParams.DigitalParams.AddLapOnPitStop == AddlapOnPitStopEnum.EnterPitLane && !Teams[laneId].PitStopInThisLap)
                DoEndOfLap(laneId, passTime,false,false);
        }

        public virtual void TeamExitPitLane(int laneId, TimeSpan passTime)
        {
            Teams[laneId].ExitPitLane(passTime);

            if (RaceParams.DigitalParams.AddLapOnPitStop == AddlapOnPitStopEnum.ExitPitLane && !Teams[laneId].PitStopInThisLap)
                DoEndOfLap(laneId, passTime,true, false);

        }


        public virtual bool BeginPitStop(int laneId, TimeSpan passTime)
        {
            // on ne peut pas faire de pitstop pendant une neutralisation totale de la course 
            if (YellowFlag && _digitalParams.MaxPowerOnYellowFlag == 0)
                return false;

            if (!_digitalParams.UsePitDetection || (_digitalParams.UsePitDetection && Teams[laneId].IsInPitLane))
            {
                // si besoin, on ajoute un tour au moment du pitstop
                if (IsRunning && _digitalParams.AddLapOnPitStop == AddlapOnPitStopEnum.OnPitStop && !Teams[laneId].PitStopInThisLap)
                    DoEndOfLap(laneId, passTime,true,false);

                Teams[laneId].PitIn();
                OnPitStopBegin(laneId);

                return true;
            }
            else
                 return false;
        }

        public virtual void PitStopNextAction(int laneId)
        {
            Teams[laneId].PitStopNextAction();
        }

        public virtual void PitStopPrevAction(int laneId)
        {
            Teams[laneId].PitStopPrevAction();
        }

        public virtual void PitStopCancelAction(int laneId)
        {
            Teams[laneId].PitStopCancelAction();
        }
        
        public virtual void PitStopValidateAction(int laneId)
        {
            Teams[laneId].PitStopValidateAction();
        }

        public virtual void EndPitStop(int laneId)
        {
            OnPitStopEnded(laneId);
        }

        public virtual void DoPitStop(int laneId, TimeSpan interval)
        {
            if (Teams[laneId].State != TeamState.Normal)
            {
                Teams[laneId].DoPitStop(interval);
                OnPitStopRefresh(laneId);
            }
        }


        protected virtual void OnPitStopBegin(int laneId)
        {
            if (PitStopBegin != null)
                PitStopBegin(this, new LaneIdEventArgs(laneId));
        }

        protected virtual void OnPitStopEnded(int laneId)
        {
            if (PitStopEnded != null)
                PitStopEnded(this, new LaneIdEventArgs(laneId));
        }

        protected virtual void OnPitStopRefresh(int laneId)
        {
            if (PitStopRefresh != null)
                PitStopRefresh(this, new LaneIdEventArgs(laneId));
        }

        #endregion GESTION DES PITSTOPS

        public void AddNewTeamInRace(int laneId)
        {
            if (Teams.Count < laneId)
            {
                Teams.AddTeam(laneId);

                OnTeamAdded(laneId);
            }
        }

        // gestion du Max Power par rapport a la voiture / pilote etc.bool
        public virtual void GetThrottleForCar(int carId, int throtlleValue,float handsetBrakingForce,bool checkAutoTC, bool gamePadUsed, out int resultThrottle, out CantBrakeEnum canBrake, out bool highAcceleration, out bool strongBraking, out float brakeAdhesionLoss, out float accelerationAdhesionLoss)
        {
            resultThrottle = 0;
            canBrake  = CantBrakeEnum.NoBrakeWanted;
            brakeAdhesionLoss = 0;
            accelerationAdhesionLoss = 0;
            highAcceleration = false;
            strongBraking = false;

            if (Teams == null || !Teams.ContainsKey(carId) || State == RaceState.Ended || State == RaceState.Paused) 
                return;

            // si on est en mode One By One
            if (RaceParams.OneByOneRace && carId != CurrentTeamId)
                return;

            TeamInRace curTeam = Teams[carId];

            if (!gamePadUsed)
                curTeam.GetThrottleValue(throtlleValue, handsetBrakingForce > 0, out resultThrottle, out canBrake, checkAutoTC);
            else
                curTeam.GetThrottleValueForGamePad(throtlleValue, handsetBrakingForce, checkAutoTC, out resultThrottle, out canBrake, out highAcceleration, out strongBraking, out brakeAdhesionLoss, out accelerationAdhesionLoss);
        }
    }
}
