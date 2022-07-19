using ESRM.Entities;
using ESRM.HWInterfaces;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using ESRM.GamePads;
using ESRM.GamePads.Common;

namespace ESRM.Win.Views
{
    public delegate void AsyncMethodCaller(SoundEnum sound);
    public delegate void HardwareInterfaceGetDatasCallback(IHandsetList datas);
    public delegate void StandardCallBack();
    //public delegate void RefreshAllTeamsCallBack();
    public delegate void RefreshAllTeamsWithRace(Race currentRace);
    public delegate void RefreshAllTeamsWithRaceAndPassTimeCallback(Race currentRace, TimeSpan time);
    public delegate void RefreshOneTeamWithRaceCallback(Race race, int teamId);
    public delegate void RefreshOneTeamCallback(int teamId);
    public delegate void RefreshStartCountdown(int? count);
    public delegate void RefreshWithoutArgs();


    public class RaceManager : IDisposable
    {
        #region ATTRIBUTS
        ESRMSoundPlayer _esrmSoundPlayer;

        System.Timers.Timer _starterTimer;
        int _startCountDown = 5;
        int _startLed = 0;
        System.Timers.Timer _raceTimerForUI;
        TimeSpan _raceDurationForUI;
        BackgroundWorker _raceDurationWorker;
        BackgroundWorker _calculationConsumptionworker;
        int _timerTickForConnectionState = 0;
        DateTime _lastLightSwitchTime;

        // UI
        IRacePage _racePage;
        IRacePage _secondRacePage;
        // Hardware
        IHardwareInterface _hwi;
        SmartSensorInterface_ForPitLane _pitSensors;
        StartLights _startLights;
        CarIdProgrammer _idProgrammer;
        // Entities
        DigitalParamsBase _digitalParams;
        Race _race;
        RecordList _records;
        #endregion



        private static RaceManager instance = null;
        private static readonly object padlock = new object();



        public static RaceManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new RaceManager();
                    }
                    return instance;
                }
            }
        }

        public Race Race
        {
            get { return _race; }
        }

        public TimeSpan RaceDurationForUI
        {
        get { return _raceDurationForUI; }
        }

        public bool SendStartEventToRacePage { get; set; }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.CancelEventsHandler();

                _hwi = null;
                _pitSensors = null;
                _startLights = null;
                _idProgrammer = null;

                _racePage = null;
                _secondRacePage = null;
                if (_raceTimerForUI != null)
                {
                    _raceTimerForUI.Dispose();
                    _raceTimerForUI = null;
                }
                if (_starterTimer != null)
                {
                    _starterTimer.Dispose();
                    _starterTimer = null;
                }
            }
        }

        private RaceManager()
        {
            _raceTimerForUI = new System.Timers.Timer();
            _raceTimerForUI.Elapsed += raceTimer_Tick;
            _calculationConsumptionworker = new BackgroundWorker();
            _calculationConsumptionworker.WorkerReportsProgress = false;
            _raceDurationWorker = new BackgroundWorker();
            _raceDurationWorker.WorkerReportsProgress = false;
            _raceDurationWorker.WorkerSupportsCancellation = true;
            _lastLightSwitchTime = DateTime.Now;
            SendStartEventToRacePage = true;
        }

        #region COMPTE A REBOURS DE DEMARRAGE

        public  void StartTimer()
        {
            _starterTimer = new System.Timers.Timer();
            _starterTimer.Elapsed += starterTimer_Tick;
            _starterTimer.Interval = 1000;
            PrepareToRace();

            _startCountDown = 5;
            _startLed = 0;

            if (_racePage != null)
                _racePage.ResfreshStartLightCommand();
            if (_secondRacePage != null)
                _secondRacePage.ResfreshStartLightCommand();

            _pitSensors.ResetLed();
            _startLights.ResetLed();
            _starterTimer.Start();
        }

        private void PrepareToRace()
        {
            _hwi.SetCallBackGetCarThrottleValueFromRace(_race.GetThrottleForCar);

            // la course commence donc plus personne n'est en mode pitstop (mode sélection de pneu avant départ de la course)
            foreach (KeyValuePair<int, TeamInRace> entry in Race.Teams)
            {
                _hwi.Handsets.PitStopEnded(entry.Value.Id);
                // si on utilise la detection de présence dans la pitlane, on doit prévenir qu'on ne peut plus faire de pitstop
                if (_digitalParams.UsePitDetection)
                    _hwi.TeamIsInPitLane(entry.Value.Id, false);
            }
        }

        private void starterTimer_Tick(object sender, EventArgs e)
        {
            // Updating the Label which displays the current second
            if (_startCountDown > 0)
            {
                _startLights.RedLight(_startLed);
                if (_racePage != null)
                    _racePage.ResfreshStarterCommand(_startCountDown);
                if (_secondRacePage != null)
                    _secondRacePage.ResfreshStarterCommand(_startCountDown);
                PlaySoundAsync(SoundEnum.Beep);

                _startLed++;
            }
            else
            {

            }

            _startCountDown--;

            // on attends deux secondes entre le derniers comptage et le start
            if (_startCountDown < 0)
            {
                if (_racePage != null)
                    _racePage.ResfreshStarterCommand(_startCountDown);
                if (_secondRacePage != null)
                    _secondRacePage.ResfreshStarterCommand(_startCountDown);

                _startLights.GreenFlag();

                StartRace();

                if (_starterTimer != null)
                {
                    _starterTimer.Stop();
                    _starterTimer.Dispose();
                    _starterTimer = null;

                    if (_racePage != null)
                        _racePage.ResfreshStarterCommand(null);
                    if (_secondRacePage != null)
                        _secondRacePage.ResfreshStarterCommand(null);
                }

            }
        }


        #endregion COMPTE A REBOURS DE DEMARRAGE

        // initialisation de l'UI, abonnement aux évents de l'interface matériel 
        public void InitHelper(IHardwareInterface hwi, SmartSensorInterface_ForPitLane pitSensors,StartLights startLights, CarIdProgrammer idProgrammer, IRacePage racePage, IRacePage secondRacePage,
                               DigitalParamsBase digitalParams, SoundSettings soundsSettings, Race race, RecordList records, bool resetRace)
        {
            // initialisation des données de la course
            CancelEventsHandler();

            _hwi = hwi;
            _pitSensors = pitSensors;
            _startLights = startLights;
            _idProgrammer = idProgrammer;
            _racePage = racePage;
            _secondRacePage = secondRacePage;
            _race = race;
            _records = records;
            _digitalParams = digitalParams;

            _esrmSoundPlayer = ESRMSoundPlayer.Instance;
            _esrmSoundPlayer.InitializeWithSettings(soundsSettings);

            //ici plutot que de créer des gamespads on devraiment vider totalement la liste des handset et tout recréer pour éviter d'etre abonné plusieurs
            // fois au même évents (ce qui est le cas actuellement)

            _hwi.NonInitHandSetUsedEvent += hwInterface_NonInitHandSetUsedEvent;
            _hwi.TrackCallEvent += hwInterface_TrackCallEvent;
            _hwi.EndTrackCallEvent += hwInterface_GreenFlagEvent;
            _hwi.LapEnded += hwInterface_LapEnded;
            _hwi.TimerReset += hwInterface_TimerReset;
            _hwi.TimerStarted += hwInterface_TimerStarted;
            _hwi.TimerStoped += hwInterface_TimerStoped;
            _hwi.TimerPaused += hwInterface_TimerPaused;
            _hwi.TimerUnPaused += hwInterface_TimerUnPaused;
            _hwi.PitStopBegin += hwInterface_PitStopBegin;
            //_hwi.PitStopEnd += hwInterface_PitStopEnd;
            _hwi.PitStopDo += hwInterface_PitStopDo;
            _hwi.PitStopNextAction += _hwi_PitStopNextAction;
            _hwi.PitStopValidateAction += _hwi_PitStopValidateAction;
            _hwi.PitStopCancelAction += _hwi_PitStopCancelAction;
            _hwi.PitStopPrevAction += _hwi_PitStopPrevAction;
            _hwi.HandSetStartClick += _hwi_HandSetStartClick;
            _hwi.HandSetLBPressed += hwi_HandSetLBPressed;
            _hwi.HandSetRBPressed += hwi_HandSetRBPressed;


            _hwi.SetCallBackGetCarThrottleValueFromRace(_race.GetThrottleForCar);
            _hwi.ActivateHandSet(_race.Teams, !digitalParams.UsePitDetection);


            if (_pitSensors != null)
            {
                _pitSensors.CarEnterInPitLane += PitSensors_CarEnterInPitLane;
                _pitSensors.CarExitPitLane += PitSensors_CarExitPitLane;
            }

            _race.GreenFlagEvent += Race_GreenFlagEvent;
            _race.LapEndedEvent += Race_LapEndedEvent;
            _race.RaceFinished += Race_RaceFinished;
            _race.YellowFlagEvent += Race_YellowFlagEvent;
            _race.PitStopBegin += Race_PitStopBegin;
            _race.PitStopEnded += Race_PitStopEnded;
            _race.PitStopRefresh += Race_PitStopRefresh;
            _race.RaceStarted += Race_RaceStarted;
            _race.TeamFinish += Race_TeamFinish;
            _race.LapRecordEvent += CurrentRace_LapRecordEvent;
            _race.RacePaused += _race_RacePaused;
            _race.RaceUnPaused += _race_RaceUnPaused;
            _race.WeatherChanged += _race_WeatherChanged;
            _race.TeamEndRelay += CurrentRace_TeamEndRelay;
            // Event qui entraine des vibrations dans le Gamepad
            _race.LowFuelEvent += CurrentRace_LowFuelEvent;
            _race.OutOfFuelEvent += CurrentRace_OutOfFuelEvent;
            _race.LowHealthEvent += CurrentRace_LowHealthEvent;
            _race.OutOfHealthEvent += CurrentRace_OutOfHealthEvent;
            _race.LowTiresEvent += CurrentRace_LowTiresEvent;
            _race.OutOfTiresEvent += CurrentRace_OutOfTiresEvent;
            _race.IncidentEvent += Race_IncidentEvent;

            foreach (KeyValuePair<int, TeamInRace> entry in Race.Teams)
            {
                entry.Value.DriverChanged += Team_PilotChanged;
                entry.Value.DriverCurvesChanged += TeamDriverCurvesChanged;
            }
#if DEBUG
            _race.DebugEvent += CurrentRace_DebugEvent;
#endif

            if (_race is TimeAttackRace)
                (_race as TimeAttackRace).LevelChangedEvent += RacePage_LevelChangedEvent;

            _calculationConsumptionworker.DoWork += CalculationConsumptionWorker_DoWork;
            _raceDurationWorker.DoWork += RaceDurationWorker_DoWork;

            if (resetRace)
                ResetRace();
        }

        private void CancelEventsHandler()
        {
            _calculationConsumptionworker.DoWork -= CalculationConsumptionWorker_DoWork;
            _raceDurationWorker.DoWork -= RaceDurationWorker_DoWork;

            if (_hwi != null)
            {
                _hwi.NonInitHandSetUsedEvent -= hwInterface_NonInitHandSetUsedEvent;
                _hwi.TrackCallEvent -= hwInterface_TrackCallEvent;
                _hwi.EndTrackCallEvent -= hwInterface_GreenFlagEvent;
                _hwi.LapEnded -= hwInterface_LapEnded;
                _hwi.TimerPaused -= hwInterface_TimerPaused;
                _hwi.TimerReset -= hwInterface_TimerReset;
                _hwi.TimerStarted -= hwInterface_TimerStarted;
                _hwi.TimerStoped -= hwInterface_TimerStoped;
                _hwi.TimerUnPaused -= hwInterface_TimerUnPaused;
                _hwi.PitStopBegin -= hwInterface_PitStopBegin;
               // _hwi.PitStopEnd -= hwInterface_PitStopEnd;
                _hwi.PitStopDo -= hwInterface_PitStopDo;
                _hwi.PitStopNextAction -= _hwi_PitStopNextAction;
                _hwi.PitStopValidateAction -= _hwi_PitStopValidateAction;
                _hwi.PitStopCancelAction -= _hwi_PitStopCancelAction;
                _hwi.PitStopPrevAction -= _hwi_PitStopPrevAction;
                _hwi.HandSetStartClick -= _hwi_HandSetStartClick;
                _hwi.HandSetLBPressed -= hwi_HandSetLBPressed;
                _hwi.HandSetRBPressed -= hwi_HandSetRBPressed;
            }
            if (_pitSensors != null)
            {
                _pitSensors.CarEnterInPitLane -= PitSensors_CarEnterInPitLane;
                _pitSensors.CarExitPitLane -= PitSensors_CarExitPitLane;
            }
            if (_race != null)
            {
                _race.GreenFlagEvent -= Race_GreenFlagEvent;
                _race.LapEndedEvent -= Race_LapEndedEvent;
                _race.RaceFinished -= Race_RaceFinished;
                _race.YellowFlagEvent -= Race_YellowFlagEvent;
                _race.IncidentEvent -= Race_IncidentEvent;
                _race.PitStopBegin -= Race_PitStopBegin;
                _race.PitStopEnded -= Race_PitStopEnded;
                _race.PitStopRefresh -= Race_PitStopRefresh;
                _race.RaceStarted -= Race_RaceStarted;
                _race.LapRecordEvent -= CurrentRace_LapRecordEvent;
                _race.LowFuelEvent -= CurrentRace_LowFuelEvent;
                _race.OutOfFuelEvent -= CurrentRace_OutOfFuelEvent;
                _race.LowHealthEvent -= CurrentRace_LowHealthEvent;
                _race.OutOfHealthEvent -= CurrentRace_OutOfHealthEvent;
                _race.TeamEndRelay -= CurrentRace_TeamEndRelay;
                _race.LowTiresEvent -= CurrentRace_LowTiresEvent;
                _race.OutOfTiresEvent -= CurrentRace_OutOfTiresEvent;
                _race.RacePaused -= _race_RacePaused;
                _race.RaceUnPaused -= _race_RaceUnPaused;
                _race.WeatherChanged -= _race_WeatherChanged;

                foreach (KeyValuePair<int, TeamInRace> entry in Race.Teams)
                {
                    entry.Value.DriverChanged -= Team_PilotChanged;
                    entry.Value.DriverCurvesChanged -= TeamDriverCurvesChanged;
                }

#if DEBUG
                _race.DebugEvent -= CurrentRace_DebugEvent;
#endif
                if (_race is TimeAttackRace)
                    (_race as TimeAttackRace).LevelChangedEvent -= RacePage_LevelChangedEvent;
            }

        }

        public void SetSecondRacePage(IRacePage secondRacePage)
        {
            _secondRacePage = secondRacePage;
        }

        public void UpdateTeamGamePadSettings(int teamId)
        {
            TeamInRace team = _race.Teams[teamId];
            if (team.UseGamePadPlayerIndex.HasValue)
            {
                (_hwi.Handsets.Get(team.Id) as GlobalGamePadHandSet).SetDriverSettings(team.CurrentPilot.GamePadThrottleCurve, team.InCarPro ? team.CurrentPilot.GamePadInCarProBrakeCurve : team.CurrentPilot.GamePadBrakeCurve, team.InCarPro, team.CurrentPilot.VibrationLevel, team.CurrentPilot.VibrationTriggerLevel);
            }
        }

        public void ReaffectGamePadsToTeams()
        {

            if (!_hwi.IsPaused)
                PauseHwi();

            _hwi.ActivateHandSet(_race.Teams, !_digitalParams.UsePitDetection);

            _hwi.UnPauseCommand();
        }


        #region UI COMMANDS

        public void ResetRace()
        {
            _hwi.StopCommand();

            Race.ResetRace(false, false);

            foreach (KeyValuePair<int, TeamInRace> entry in Race.Teams)
            {
                if (entry.Value.PitStopRunning)
                {
                    _hwi.Handsets.PitStopRunning(entry.Value.Id);
                }
            }

        }
        private void StartRace()
        {
            if (_race.State == RaceState.Started && _race.YellowFlag)
            {
               _hwi.ForceGreenFlag();
            }
            else
            {
                _hwi.ResetCommand();

                _raceDurationForUI = new TimeSpan();
                StartRaceTimerForUI();
                _hwi.StartCommand();
            }
        }

        public void StoptHwi()
        {
            StopRaceTimerForUI();
            _raceDurationForUI = new TimeSpan();
            _hwi.StopCommand();
            StopRainSound();
        }

        public void PauseHwi()
        {
            _hwi.PauseCommand();
        }


        public void UnPauseHwi()
        {
            _hwi.UnPauseCommand();
        }

        public void ForceYellowFlag()
        {
            _hwi.ForceTrackCall();
        }
        public void ForceGreenFlag()
        {
            _hwi.ForceGreenFlag();
        }


        public void ApplyPenality(int teamId)
        {
            _race.Teams[teamId].State = TeamState.RunningPenality;
            if(_racePage != null)
                _racePage.RefreshOneTeamCommand(_race, teamId);
            if(_secondRacePage != null)
                _secondRacePage.RefreshOneTeamCommand(_race, teamId);
        }

        public void StopPenality(int teamId)
        {
            _race.Teams[teamId].State = TeamState.Normal;
            if (_racePage != null)
                _racePage.RefreshOneTeamCommand(_race, teamId);
            if (_secondRacePage != null)
                _secondRacePage.RefreshOneTeamCommand(_race, teamId);
        }

        public void AffectID(int Id)
        {
            if (_idProgrammer != null && _idProgrammer.IsConnected)
                _idProgrammer.ProgramCar(Id);
            else
                _hwi.SetCurrentCarIdCommand(Id);
        }

        #endregion COMMANDS

        #region HI EVENTS
        private void hwInterface_NonInitHandSetUsedEvent(object sender, TeamIdEventArgs e)
        {
            //AddNewTeamInRace(e.LaneId);
        }

        public void AddNewTeamInRace(int laneId)
        {
            _race.AddNewTeamInRace(laneId);
            if (_racePage != null)
                _racePage.ResizeTeamsListCommand();
            if (_secondRacePage != null)
                _secondRacePage.ResizeTeamsListCommand();
        }

        void hwInterface_PitStopDo(object sender, TeamIdEventArgs e)
        {
            _race.DoPitStop(e.LaneId, new TimeSpan(0, 0, 0, 0, GlobalDatas.PITSTOPREFRESHINTERVAL));
        }

        void hwInterface_PitStopEnd(object sender, LapEndedEventArgs e)
        {
            //_race.EndPitStop(e.LaneId,e.PassTime);
        }

        void hwInterface_PitStopBegin(object sender, LapEndedEventArgs e)
        {
            bool ok = _race.BeginPitStop(e.LaneId,e.PassTime);
            if (!ok)
                _hwi.RefusePitStop(e.LaneId);
            else
            {
                if (_race.Teams[e.LaneId].UseGamePadPlayerIndex.HasValue)
                    (_hwi.Handsets.Get(_race.Teams[e.LaneId].Id) as GlobalGamePadHandSet).StopVibrations();
            }
        }

        private void _hwi_PitStopValidateAction(object sender, TeamIdEventArgs e)
        {
            _race.PitStopValidateAction(e.LaneId);
            Thread.Sleep(100);
            _racePage.RacePitStopRefreshCommand(new LaneIdEventArgs(e.LaneId));
        }

        private void _hwi_PitStopNextAction(object sender, TeamIdEventArgs e)
        {
            _race.PitStopNextAction(e.LaneId);
            _racePage.RacePitStopRefreshCommand(new LaneIdEventArgs(e.LaneId));
        }

        private void _hwi_PitStopPrevAction(object sender, TeamIdEventArgs e)
        {
            _race.PitStopPrevAction(e.LaneId);
            _racePage.RacePitStopRefreshCommand(new LaneIdEventArgs(e.LaneId));
        }

        private void _hwi_PitStopCancelAction(object sender, TeamIdEventArgs e)
        {
            _race.PitStopCancelAction(e.LaneId);
            _racePage.RacePitStopRefreshCommand(new LaneIdEventArgs(e.LaneId));
        }

        private void _hwi_HandSetStartClick(object sender, EventArgs e)
        {
            if(SendStartEventToRacePage && Race.RaceParams.EnablePauseWithGamePad)
              _racePage.StartButtonActionCommand();
        }


        private void hwi_HandSetLBPressed(object sender, TeamIdEventArgs e)
        {
            if (_race.Teams[e.LaneId].InCarPro)
            { 
                if (_lastLightSwitchTime.AddMilliseconds(500) <= DateTime.Now)
                {
                    _lastLightSwitchTime = DateTime.Now;
                    _race.Teams[e.LaneId].LightsOn = !_race.Teams[e.LaneId].LightsOn;
                    bool[] lights = new bool[] { false, false, false, false, false, false };
                    foreach (KeyValuePair<int, TeamInRace> entry in Race.Teams)
                        lights[entry.Key - 1] = entry.Value.LightsOn;
                    _hwi.SendCarLights(lights);
                }
            }
            else if (_lastLightSwitchTime.AddMilliseconds(100) <= DateTime.Now)
            {
                _lastLightSwitchTime = DateTime.Now;

                if (_race.RaceParams.EnablePowerAdjustement)
                {
                    if (_race.Teams[e.LaneId].CurrentPilot.MaxPowerPercent > 0)
                        _race.Teams[e.LaneId].CurrentPilot.MaxPowerPercent -= 1;
                    _racePage.RefreshOneTeamCommand(_race, e.LaneId);
                }
            }
        }

        private void hwi_HandSetRBPressed(object sender, TeamIdEventArgs e)
        {
            if (_race.Teams[e.LaneId].InCarPro)
            {
                if (_lastLightSwitchTime.AddMilliseconds(500) <= DateTime.Now)
                {
                    _lastLightSwitchTime = DateTime.Now;
                    {
                        _race.Teams[e.LaneId].LightsOn = !_race.Teams[e.LaneId].LightsOn;
                        bool[] lights = new bool[] { false, false, false, false, false, false };
                        foreach (KeyValuePair<int, TeamInRace> entry in Race.Teams)
                            lights[entry.Key - 1] = entry.Value.LightsOn;
                        _hwi.SendCarLights(lights);
                    }
                }
            }
            else if (_lastLightSwitchTime.AddMilliseconds(100) <= DateTime.Now)
            {
                _lastLightSwitchTime = DateTime.Now;

                if (_race.RaceParams.EnablePowerAdjustement)
                {
                    if (_race.Teams[e.LaneId].CurrentPilot.MaxPowerPercent < 100)
                        _race.Teams[e.LaneId].CurrentPilot.MaxPowerPercent += 1;
                    _racePage.RefreshOneTeamCommand(_race, e.LaneId);
                }
            }

        }

        void hwInterface_TimerPaused(object sender, EventArgs e)
        {
            if (_race.State == RaceState.Started)
            {
                _race.Pause();
                _startLights.YellowFlag();
            }
        }

        void hwInterface_TimerUnPaused(object sender, EventArgs e)
        {
            if (_race.State == RaceState.Paused)
            {
                _race.UnPause();
                _startLights.GreenFlag();
            }
        }

        void hwInterface_TimerStoped(object sender, EventArgs e)
        {
            _race.Finish();
            StopRainSound();
            _startLights.RedLight(5);
        }

        void hwInterface_TimerStarted(object sender, EventArgs e)
        {
            if (_race.State == RaceState.NotStarted)
                _race.Start();
            else if (_race.State == RaceState.Ended)
                _race.Start();
            else if (_race.State == RaceState.Paused)
                _race.UnPause();
            else if (_race.State == RaceState.Started)
                _race.PutGreenFlag();

        }

        void hwInterface_TimerReset(object sender, EventArgs e)
        {
        }


        void hwInterface_GreenFlagEvent(object sender, TeamIdEventArgs e)
        {
            _race.DoEndOfTrackCall(e.LaneId);
            PlaySoundAsync(SoundEnum.GreenFlag);
            // Si la course est une time Attack, on stop le timer 
            if (_race is TimeAttackRace || _race.RaceParams.DigitalParams.MaxPowerOnYellowFlag == 0)
            {
                UnPauseHwi();
                StartRaceTimerForUI();
            }
        }

        void hwInterface_TrackCallEvent(object sender, TeamIdEventArgs e)
        {
            _race.DoTrackCall(e.LaneId);

            if (_racePage != null)
                _racePage.TrackCallCommand(e);
            if(_secondRacePage != null)
               _secondRacePage.TrackCallCommand(e);


            // Si la course est une time Attack OU si la course est stopée pendant un YF , on stop le timer 
            if (_race is TimeAttackRace || _race.RaceParams.DigitalParams.MaxPowerOnYellowFlag == 0)
            {
                PauseHwi();
                StopRaceTimerForUI();
            }
            else
                PlaySoundAsync(SoundEnum.YellowFlag);

        }

        void hwInterface_LapEnded(object sender, LapEndedEventArgs e)
        {
            //BackgroundWorker worker = new BackgroundWorker();
            //worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            //worker.DoWork += worker_DoWork;
            //worker.RunWorkerAsync(e);
            DoEndOfLap(e.LaneId, e.PassTime);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            (sender as BackgroundWorker).Dispose();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            DoEndOfLap((e.Argument as LapEndedEventArgs).LaneId, (e.Argument as LapEndedEventArgs).PassTime);
        }

        private void DoEndOfLap(int laneId, TimeSpan passTime)
        {
            if (!_race.Teams.ContainsKey(laneId))
                return;

            if (_race.Teams[laneId].IsPacer)
                _race.Teams[laneId].Pacer.LapThrotlesInfosCurrentIdx = 0;

            // Gestion TimeAttack
            if (_race is TimeAttackRace)
            {
                _race.Teams[laneId].CalculTimeAttackTimeLeft();
            }

            _race.DoEndOfLap(laneId, passTime,true,false);
            if (_race.Teams[laneId].UseGamePadPlayerIndex.HasValue)
                (_hwi.Handsets.Get(_race.Teams[laneId].Id) as GlobalGamePadHandSet).WarningVibrationsInfos(_race.Teams[laneId].FuelPercent, _race.Teams[laneId].TiresWearPercent, _race.Teams[laneId].CarHealthPercent);

            if (_race is TimeAttackRace)
            {
                if (TimeSpan.Compare(_race.Teams[laneId].LastLapTime, _race.Teams[laneId].TimeAttackLapTarget) <= 0)
                    PlaySoundAsync(SoundEnum.TA_Positive);
                else
                    PlaySoundAsync(SoundEnum.TA_Negative);
            }
        }

        #endregion

        #region PIT SENSORS EVENTS

        private void PitSensors_CarExitPitLane(object sender, TeamIdEventArgs e)
        {
            //Race.TeamEnterPitLane(e.LaneId, _hwi.RaceElapsedTime);
            Race.TeamExitPitLane(e.LaneId, _hwi.RaceElapsedTime);
            _hwi.TeamIsInPitLane(e.LaneId, false);
            _racePage.RefreshOneTeamCommand(_race, e.LaneId);
        }

        private void PitSensors_CarEnterInPitLane(object sender, TeamIdEventArgs e)
        {
            

            //si on est en mode PP on ne sait pas faire la différence entre entrée et sortie.
            // donc un passage sur la ligne = on entre si on est pas déja entrée
            // sinon on sort
           // if (Race.RaceParams.DigitalParams.PitSmartSensorsParams.SensorProtocol == SensorProtocolEnum.PP && Race.Teams[e.LaneId].IsInPitLane)
           if (Race.Teams[e.LaneId].IsInPitLane)
           {
                    PitSensors_CarExitPitLane(sender,e);
            }
            else
            {
                Race.TeamEnterPitLane(e.LaneId, _hwi.RaceElapsedTime);
                PlaySoundAsync(SoundEnum.EnterPitlane);
                _hwi.TeamIsInPitLane(e.LaneId, true);
                _racePage.RefreshOneTeamCommand(_race, e.LaneId);
            }
        }

        public void ForcePitStopToBegin(int laneId)
        {
            _pitSensors.ForcePitIn(laneId);

            Race.Teams[laneId].EnterPitLane(_hwi.RaceElapsedTime);
            Race.Teams[laneId].PitIn();
            _hwi.TeamIsInPitLane(laneId, true);
            _racePage.RefreshOneTeamCommand(_race, laneId);

        }

        #endregion PIT SENSORS EVENTS

        #region RACE EVENTS

        private void Team_PilotChanged(object sender, EventArgs e)
        {
            TeamInRace team = sender as TeamInRace;
            if (team.UseGamePadPlayerIndex.HasValue)
                (_hwi.Handsets.Get(team.Id) as GlobalGamePadHandSet).SetDriverSettings(team.CurrentPilot.GamePadThrottleCurve, team.InCarPro ? team.CurrentPilot.GamePadInCarProBrakeCurve : team.CurrentPilot.GamePadBrakeCurve, team.InCarPro,team.CurrentPilot.VibrationLevel,team.CurrentPilot.VibrationTriggerLevel);
            else
                (_hwi.Handsets.Get(team.Id) as HandSet).SetThrotthleCurve(team.CurrentPilot.HandsetThrottleCurve);

        }

        private void TeamDriverCurvesChanged(object sender, EventArgs e)
        {
            TeamInRace team = sender as TeamInRace;
            if (team.UseGamePadPlayerIndex.HasValue)
                (_hwi.Handsets.Get(team.Id) as GlobalGamePadHandSet).SetDriverSettings(team.CurrentPilot.GamePadThrottleCurve, team.InCarPro ? team.CurrentPilot.GamePadInCarProBrakeCurve : team.CurrentPilot.GamePadBrakeCurve, team.InCarPro, team.CurrentPilot.VibrationLevel, team.CurrentPilot.VibrationTriggerLevel);
            else
                (_hwi.Handsets.Get(team.Id) as HandSet).SetThrotthleCurve(team.CurrentPilot.HandsetThrottleCurve);
        }

        private void _race_RaceUnPaused(object sender, EventArgs e)
        {
            UnPauseRace();
        }

        private void UnPauseRace()
        {
            StartRaceTimerForUI();
            PlaySoundAsync(SoundEnum.Go);
            if (_racePage != null)
                _racePage.RefreshAfterUnPauseCommand();
            if (_secondRacePage != null)
                _secondRacePage.RefreshAfterUnPauseCommand();
        }

        private void _race_RacePaused(object sender, EventArgs e)
        {
            StopRaceTimerForUI();
            if (_racePage != null)
                _racePage.RefreshAfterPauseCommand();
            if (_secondRacePage != null)
                _secondRacePage.RefreshAfterPauseCommand();
            PlaySoundAsync(SoundEnum.Warning);
        }

        void CurrentRace_DebugEvent(object sender, EventArgs e)
        {

        }

        void RacePage_LevelChangedEvent(object sender, EventArgs e)
        {
            this.PlaySoundAsync(SoundEnum.TA_ChangeLevel);
        }

        void Race_RaceStarted(object sender, EventArgs e)
        {
            if (_racePage != null)
                _racePage.RaceGreenFlagCommand();
            if (_secondRacePage != null)
                _secondRacePage.RaceGreenFlagCommand();

            PlaySoundAsync(SoundEnum.Go);
            CheckForRainSound();
        }


        void Race_TeamFinish(object sender, LaneIdEventArgs e)
        {
            if (_racePage != null)
                _racePage.RaceTeamFinishCommand(e);
            if (_secondRacePage != null)
                _secondRacePage.RaceTeamFinishCommand(e);

            PlaySoundAsync(SoundEnum.TA_ChangeLevel);
        }

        public void RaceRefresh(LaneIdEventArgs e)
        {
            if (_racePage != null)
                _racePage.RacePitStopRefreshCommand(e);
            if (_secondRacePage != null)
                _secondRacePage.RacePitStopRefreshCommand(e);
        }

        void Race_PitStopRefresh(object sender, LaneIdEventArgs e)
        {
            if (_racePage != null)
                _racePage.RacePitStopRefreshCommand(e);
            if (_secondRacePage != null)
                _secondRacePage.RacePitStopRefreshCommand(e);
        }

        void Race_PitStopEnded(object sender, LaneIdEventArgs e)
        {
            _hwi.StopPitStop(e.LaneId);

            if (_racePage != null)
                _racePage.RacePitStopEndedCommand(e);
            if (_secondRacePage != null)
                _secondRacePage.RacePitStopEndedCommand(e);
            //PlaySoundAsync(SoundEnum.Go);
        }

        void Race_PitStopBegin(object sender, LaneIdEventArgs e)
        {
            if (_racePage != null)
                _racePage.RacePitStopBeginCommand(e);
            if (_secondRacePage != null)
                _secondRacePage.RacePitStopBeginCommand(e);
            PlaySoundAsync(SoundEnum.PitIn);
        }

        void Race_IncidentEvent(object sender, LaneIdEventArgs e)
        {
            PlaySoundAsync(SoundEnum.Incident);

            if (_racePage != null)
                _racePage.RaceIncidentCommand(e);
            if (_secondRacePage != null)
                _secondRacePage.RaceIncidentCommand(e);

        }

        void CurrentRace_OutOfFuelEvent(object sender, LaneIdEventArgs e)
        {
            PlaySoundAsync(SoundEnum.Alert);

            if (_racePage != null)
                _racePage.CurrentRaceOutOfFuelCommand(e);
            if (_secondRacePage != null)
                _secondRacePage.CurrentRaceOutOfFuelCommand(e);
        }

        void CurrentRace_LowFuelEvent(object sender, LaneIdEventArgs e)
        {
            PlaySoundAsync(SoundEnum.Warning);

            if (_racePage != null)
                _racePage.CurrentRaceLowFuelCommand(e);
            if (_secondRacePage != null)
                _secondRacePage.CurrentRaceLowFuelCommand(e);
        }

        void CurrentRace_LapRecordEvent(object sender, LaneIdEventArgs e)
        {
            PlaySoundAsync(SoundEnum.LapRecord);

            if (_racePage != null)
                _racePage.CurrentRaceLapRecordCommand(e);
            if (_secondRacePage != null)
                _secondRacePage.CurrentRaceLapRecordCommand(e);
        }

        void CurrentRace_OutOfHealthEvent(object sender, LaneIdEventArgs e)
        {
            PlaySoundAsync(SoundEnum.Alert);

            if (_racePage != null)
                _racePage.CurrentRaceOutOfHealthCommand(e);
            if (_secondRacePage != null)
                _secondRacePage.CurrentRaceOutOfHealthCommand(e);
        }

        private void CurrentRace_OutOfTiresEvent(object sender, LaneIdEventArgs e)
        {
            PlaySoundAsync(SoundEnum.Alert);

            if (_racePage != null)
                _racePage.CurrentRaceOutOfTiresCommand(e);
            if (_secondRacePage != null)
                _secondRacePage.CurrentRaceOutOfTiresCommand(e);
        }

        private void CurrentRace_LowTiresEvent(object sender, LaneIdEventArgs e)
        {
            PlaySoundAsync(SoundEnum.Warning);

            if (_racePage != null)
                _racePage.CurrentRaceLowTiresCommand(e);
            if (_secondRacePage != null)
                _secondRacePage.CurrentRaceLowTiresCommand(e);
        }

        void CurrentRace_TeamEndRelay(object sender, LaneIdEventArgs e)
        {
            if (!_race.IsLastLap)
            {
                PlaySoundAsync(SoundEnum.EndRealy);
                if (_racePage != null)
                    _racePage.CurrentRaceTeamEndRelayCommand(e);
                if (_secondRacePage != null)
                    _secondRacePage.CurrentRaceTeamEndRelayCommand(e);
            }
        }

        void CurrentRace_LowHealthEvent(object sender, LaneIdEventArgs e)
        {
            PlaySoundAsync(SoundEnum.Warning);

            if (_racePage != null)
                _racePage.CurrentRaceOutOfFuelCommand(e);
            if (_secondRacePage != null)
                _secondRacePage.CurrentRaceOutOfFuelCommand(e);
        }

        void Race_YellowFlagEvent(object sender, EventArgs e)
        {
            PlaySoundAsync(SoundEnum.Warning);
            _startLights.YellowFlag();

            if (_racePage != null)
                _racePage.RaceYellowFlagCommand();
            if (_secondRacePage != null)
                _secondRacePage.RaceYellowFlagCommand();
        }

        void Race_GreenFlagEvent(object sender, EventArgs e)
        {
            _startLights.GreenFlag();

            PlaySoundAsync(SoundEnum.Go);
            if (_racePage != null)
                _racePage.RaceGreenFlagCommand();
            if (_secondRacePage != null)
                _secondRacePage.RaceGreenFlagCommand();
        }

        void Race_RaceFinished(object sender, EventArgs e)
        {
            StopRaceTimerForUI();

            PlaySoundAsync(SoundEnum.Finish);
            if (_racePage != null)
                _racePage.RaceFinishedCommand();
            if (_secondRacePage != null)
                _secondRacePage.RaceFinishedCommand();

            // Calcul des records
            _records.ComputeLapsOnRaceEnd(_race.Teams);
            StopRainSound();
        }

        void Race_LapEndedEvent(object sender, System.EventArgs e)
        {
            PlaySoundAsync(SoundEnum.PassSFLine);

            if (_racePage != null)
                _racePage.RaceLapEndedCommand();
            if (_secondRacePage != null)
                _secondRacePage.RaceLapEndedCommand();
        }

        #endregion RACE EVENTS

        #region MISE A JOUR UI DEPUIS EVENTS

        DateTime _lastCalculTime;

        private void RefreshTimeAttackRaceTime()
        {
            // modification du time de la course 
            _race.TimeAttackTickTime(new TimeSpan(0, 0, 0, 0, 100));
            // refresh des panels
            if (_racePage != null)
                _racePage.RefreshTimeAttackRaceTimeCommand();
            if (_secondRacePage != null)
                _secondRacePage.RefreshTimeAttackRaceTimeCommand();
        }

        private void RefreshConnectionState()
        {
            if (_racePage != null)
                _racePage.RefreshConnectionStateCommand();
        }

        private void _race_WeatherChanged(object sender, EventArgs e)
        {
            if (_racePage != null)
                _racePage.RefresWeatherCommand();
            if (_secondRacePage != null)
                _secondRacePage.RefresWeatherCommand();

            CheckForRainSound();
        }

        public void CheckForRainSound()
        {
            if (_race.WeatherScenario == null)
                return;

            if (_digitalParams.RainSound)
            {
                if (_race.WeatherScenario.CurrentWeather.Weather == WeatherEnum.NightRain1 || _race.WeatherScenario.CurrentWeather.Weather == WeatherEnum.SunnyRain1)
                    PlayRainSound(SoundEnum.LightRain);
                if (_race.WeatherScenario.CurrentWeather.Weather == WeatherEnum.NightRain2 || _race.WeatherScenario.CurrentWeather.Weather == WeatherEnum.SunnyRain2)
                    PlayRainSound(SoundEnum.MediumRain);
                if (_race.WeatherScenario.CurrentWeather.Weather == WeatherEnum.Raining)
                    PlayRainSound(SoundEnum.HardRain);
                else
                    StopRainSound();
            }
        }

        #endregion MISE A JOUR UI DEPUIS EVENTS

        #region GESTION DES SONS

        private void PlaySoundAsync(SoundEnum sound)
        {
            ESRMSoundPlayer.Instance.PlaySound(sound);
        }

        private void PlayRainSound(SoundEnum sound)
        {
            // on passe par la page pour le sound play car sinon le multithread bloque le son et il n'est plus possible de le stoper par la suite
            _racePage.PlayRainSoundCommand(sound);
        }

        private void StopRainSound()
        {
            _racePage.StopRainSoundCommand();
        }

        #endregion

        #region CALCUL DES CONSOMMATIONS

        private void RunCalculationConsumptionBackgroundWorker()
        {
            if (!_calculationConsumptionworker.IsBusy)
                _calculationConsumptionworker.RunWorkerAsync();
        }


        void CalculationConsumptionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CalculConsumption();
        }

        private void CalculConsumption()
        {
            foreach (KeyValuePair<int, TeamInRace> entry in Race.Teams)
            {
                entry.Value.CalculIntervalFuelConsumption();
                entry.Value.CalculIntervalTiresWear();
                entry.Value.CalculMaxPowerCoef();

                if (entry.Value.UseGamePadPlayerIndex.HasValue)
                    (_hwi.Handsets.Get(entry.Value.Id) as GlobalGamePadHandSet).WarningVibrationsInfos(entry.Value.FuelPercent, entry.Value.TiresWearPercent, entry.Value.CarHealthPercent);
            }

            _racePage.RefreshRaceBoardCommand();
            if(_secondRacePage != null)
                _secondRacePage.RefreshRaceBoardCommand();
        }
        #endregion

        #region GESTION DU TEMPS DE COURSE

        private void RaceDurationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!_raceTimerForUI.Enabled)
            {
                if (Race is TimeAttackRace)
                    _raceTimerForUI.Interval = 100;
                else
                    _raceTimerForUI.Interval = 1000;

                _raceTimerForUI.Start();
            }
        }

        public void StartRaceTimerForUI()
        {
            if(!_raceDurationWorker.IsBusy)
                _raceDurationWorker.RunWorkerAsync();
        }

        public void StopRaceTimerForUI()
        {
            _raceDurationWorker.CancelAsync();
            //_raceTimerForUI.Stop();
        }

        private void raceTimer_Tick(object sender, EventArgs e)
        {
            _timerTickForConnectionState++;

            if (_raceDurationWorker.CancellationPending)
                _raceTimerForUI.Stop();
            else 
            {
                //_raceDurationForUI = RaceDurationForUI.Add(new TimeSpan(0, 0, 0, 0, (int)_raceTimerForUI.Interval));
                _raceDurationForUI = _hwi.RaceElapsedTime;

                if (_racePage != null)
                {
                    _racePage.RefreshDurationCommand();
                    if (_timerTickForConnectionState >= 5)
                    {
                        _timerTickForConnectionState = 0;
                        RefreshConnectionState();
                    }
                }
                if (_secondRacePage != null)
                    _secondRacePage.RefreshDurationCommand();

                if (DateTime.Now >= _lastCalculTime.Add(new TimeSpan(0, 0, 3)) && !_calculationConsumptionworker.IsBusy)
                {
                    _lastCalculTime = DateTime.Now;
                    _calculationConsumptionworker.RunWorkerAsync();
                }
                // si la course est une Time Attack on informe l'UI quil faut mettre a jours les différents panel de temps
                if (_race is TimeAttackRace)
                    RefreshTimeAttackRaceTime();
            }
        }

        #endregion
    }


}
