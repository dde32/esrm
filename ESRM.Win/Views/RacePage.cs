using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ESRM.Entities;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using ESRM.Win.Panels;
using System.Threading;
using System.IO;
using System.Collections.ObjectModel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraBars.Docking2010;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System.Linq;

namespace ESRM.Win.Views
{
    public delegate void PlaySoundDelegate(SoundEnum sound);
    public delegate void StopSoundDelegate();

    public partial class RacePage : BasePage, IRacePage
    {
        SecondRaceView _secondRacePageDialog;
        public bool IsSecondPage;
        bool _consignShowed = false;
        StartLightDlg _startLightDlg;

        #region PROPERTIES FOR UI

        public Image CurrentWeatherImage
        {
            get { return GetWeatherImage(RaceManager.Instance.Race.WeatherScenario.CurrentWeather.Weather); }
        }
        public Image ForecastWeatherImage
        {
            get { return GetWeatherImage(RaceManager.Instance.Race.WeatherScenario.NextWeather.Weather); }
        }
        public Image OptimalTireImage
        {
            get { return GetTireImage(RaceManager.Instance.Race.WeatherScenario.CurrentWeather.OptimalTireType); }
        }

        public string ForeCastProbabilityForUI
        {
            get { return string.Format("{0}{1}{2}%", RaceManager.Instance.Race.WeatherScenario.TimeBeforeNextEvolutionForUI, Environment.NewLine, RaceManager.Instance.Race.WeatherScenario.NextWeather.ForeCastProbability); }
        }
        public string TemperatureForUI
        {
            get { return string.Format("{0}°C", RaceManager.Instance.Race.WeatherScenario.CurrentWeather.Temperature); }
        }
        public string TrackTemperatureForUI
        {
            get { return string.Format("{0}°C", RaceManager.Instance.Race.WeatherScenario.CurrentWeather.TrackTemperature); }
        }


        private Image GetWeatherImage(WeatherEnum weather)
        {
            switch(weather)
            {
                case WeatherEnum.Covered:
                    return Images.Covered;
                case WeatherEnum.NightClear:
                    return Images.NightClear;
                case WeatherEnum.NightCloudy:
                    return Images.NightCloudy;
                case WeatherEnum.NightRain1:
                    return Images.NightRain1;
                case WeatherEnum.NightRain2:
                    return Images.NightRain2;
                case WeatherEnum.Raining:
                    return Images.Rain;
                case WeatherEnum.Sunny:
                    return Images.Sunny;
                case WeatherEnum.SunnyCloudy:
                    return Images.SunnyCloudy;
                case WeatherEnum.SunnyRain1:
                    return Images.SunnyRain1;
                case WeatherEnum.SunnyRain2:
                    return Images.SunnyRain2;
                case WeatherEnum.Thinning:
                    return Images.Thinning;
                default:
                    return Images.empty;
            }
        }

        private Image GetTireImage(TireType tire)
        {
            switch (tire)
            {
                case TireType.Hard:
                    return Images.Hard;
                case TireType.Medium:
                    return Images.Medium;
                case TireType.Soft:
                    return Images.Soft;
                case TireType.Intermediate:
                    return Images.Intermediate;
                case TireType.Wet:
                    return Images.Wet;
                default:
                    return Images.empty;
            }
        }
        

        #endregion


        public RacePage()
        {
            InitializeComponent();
            //RaceManager.Instance = new RaceManager();
            //panelTests.Visible = true;
            CreateStartLightPanelIfNeeded();

#if DEBUG
            panelTests.Visible = true;
#endif

        }




        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);

        }

        // arrivé sur la page, on initialise le panel des équipes
        public override void OnNavigatedTo(INavigationArgs args)
        {
            base.OnNavigatedTo(args);
            if (!DesignMode)
            {
                if (RaceManager.Instance.Race != null)
                {
                    RaceManager.Instance.ResetRace();
                }
                InitUI();
            }
        }

        // on quitte la page, on stoppe la course.
        public override void OnNavigatedFrom(INavigationArgs args)
        {
            labelLapsCount.Text = "-";
            labelRaceTime.Text = "-";
            if (RaceManager.Instance.Race.IsRunning)
                StopRace_Click(null, null);

            AppViewModel.Records.ComputeLapsOnRaceEnd(RaceManager.Instance.Race.Teams);
        }


        public void ShowButtonPanel(bool visible)
        {
            panelButtons.Visible = Visible;
#if DEBUG
            panelTests.Visible = visible;
#endif
        }
        public void ShowHeaderPanel(bool visible)
        {
            headerPanel.Visible = visible;
        }





        //public void SetRaceHelper(RaceManager raceHelper)
        //{
        //    RaceManager.Instance = raceHelper;
        //}

        public void InitSecondView(IESRMViewModel appViewModelParam)
        {

            appViewModel = appViewModelParam;
            lblRaceInformation.Text = AppViewModel.CurrentRace.GetTitle();

            // affichage du chrono de la course
            labelLapsCount.Text = "-";
            labelRaceTime.Text = "-";
            labelRaceTime.ForeColor = Color.White;
            pbStart.Image = Images.Play;

            if (RaceManager.Instance.Race.State == RaceState.Started)
                pbFlag.EditValue = Images.GreenFlag;

            InitWeatherInfosPanel();

            ResizeGridRowHeight();
            List<TeamInRace> teams = new List<TeamInRace>();
            teams.AddRange(AppViewModel.CurrentRace.Teams.Values);
            raceGrid.DataSource = teams;
            classicRaceView.RefreshData();
        }



        // initialisation de l'UI, abonnement aux évents de l'interface matériel 
        protected void InitUI()
        {
            if (!DesignMode)
            {
                try
                {
                    if (this.ParentForm != null && this.ParentForm is MainForm)
                        (this.ParentForm as MainForm).SetTitle(AppViewModel.CurrentRace.GetTitle());
                    lblRaceInformation.Text = AppViewModel.CurrentRace.GetTitle();

                    //racePanel.Visible = (AppViewModel.CurrentRace is TimeAttackRace);

                    RaceManager.Instance.InitHelper(Program.hwInterface, Program.pitSensors, Program._startLight, Program._carIdProgrammer, this, _secondRacePageDialog != null ? _secondRacePageDialog.RacePage : null, AppViewModel.DigitalParams, AppViewModel.SoundSettings, AppViewModel.CurrentRace, AppViewModel.Records, true);

                    // affichage du chrono de la course
                    labelLapsCount.Text = "-";
                    labelRaceTime.Text = "-";
                    labelRaceTime.ForeColor = Color.White;
                    pbStart.Image = Images.Play;
                    pbFlag.Image = Images.RedFlag;

                    InitWeatherInfosPanel();

                    raceGrid.DataSource = null;
                    ResizeGridRowHeight();
                    raceGrid.DataSource = AppViewModel.CurrentRace.Teams.Values;
                    classicRaceView.RefreshData();


                    if (_secondRacePageDialog != null)
                    {
                        _secondRacePageDialog.SwitchView(true);
                        _secondRacePageDialog.InitUI(AppViewModel);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void InitWeatherInfosPanel()
        {
            pbOptimalTires.Visible = RaceManager.Instance.Race.RaceParams.UseWeatherConditions && RaceManager.Instance.Race.RaceParams.ShowOptimalTiresType;
            pbWeather.DataBindings.Clear();
            pbNextWeather.DataBindings.Clear();
            lblForecast.DataBindings.Clear();
            lblTemp.DataBindings.Clear();
            lblTrackTemperature.DataBindings.Clear();
            pbOptimalTires.DataBindings.Clear();

            pbWeather.Visible = RaceManager.Instance.Race.RaceParams.UseWeatherConditions;
            pbNextWeather.Visible = RaceManager.Instance.Race.RaceParams.UseWeatherConditions;
            lblForecast.Visible = RaceManager.Instance.Race.RaceParams.UseWeatherConditions;
            lblTemp.Visible = RaceManager.Instance.Race.RaceParams.UseWeatherConditions;
            lblTrackTemperature.Visible = RaceManager.Instance.Race.RaceParams.UseWeatherConditions;
            if (RaceManager.Instance.Race.WeatherScenario != null)
            {
                pbWeather.DataBindings.Add(new Binding("Image", this, "CurrentWeatherImage"));
                pbNextWeather.DataBindings.Add(new Binding("Image", this, "ForecastWeatherImage"));
                pbOptimalTires.DataBindings.Add(new Binding("Image", this, "OptimalTireImage"));
                lblForecast.DataBindings.Add(new Binding("Text", this, "ForeCastProbabilityForUI"));
                lblTemp.DataBindings.Add(new Binding("Text", this, "TemperatureForUI"));
                lblTrackTemperature.DataBindings.Add(new Binding("Text", this, "TrackTemperatureForUI"));
            }
        }


        #region UI COMMANDS

        //private void btnGreenFlag_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnYF_Click(object sender, EventArgs e)
        //{
        //    _raceHelper.ForceYellowFlag();
        //}

        private void StartRace_Click(object sender, System.EventArgs e)
        {
            StartButtonAction();
        }

        private void StartButtonAction()
        {
            //if (!_startLightDlg.IsHandleCreated)
            //    _startLightDlg = new StartLightDlg();

            // si la course n'est pas encore démarrée on peut la démarer
            if (AppViewModel.CurrentRace.State == RaceState.NotStarted || (AppViewModel.CurrentRace.State == RaceState.Started && AppViewModel.CurrentRace.YellowFlag))
            {
                if (!AppViewModel.CurrentRace.CanStart())
                    MessageBox.Show(Textes.MessageCantStartRace);
                else
                {
                   // _startLightDlg.Show();
                    Start();
                }
            }
            else if (AppViewModel.CurrentRace.State == RaceState.Paused)
                UnPause();
            else if (AppViewModel.CurrentRace.State == RaceState.Started)
                Pause();
            else if (AppViewModel.CurrentRace.State == RaceState.Ended) // on veut faire un restart
                Start();
        }

        private void StopRace_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Textes.MessConfirmStopRace, "ESRM", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Stop();
        }

        private void Start()
        {
            labelRaceTime.ForeColor = Color.White;
            pbStart.Image = Images.Pause;
            pbFlag.EditValue = Images.GreenFlag;
            btnGreenFlag.Enabled = false;
            btnGreenFlag.Text = Textes.YellowFlag;

            if (AppViewModel.CurrentRace.State == RaceState.NotStarted)
            {
                pbFlag.EditValue = Images.RedFlag;
               RaceManager.Instance.StartTimer();
            }
            //else
            //    labelRaceTime.Text = RaceManager.Instance.RaceDurationForUI.ToString("c");
        }

        #region START LIGHT
        private void CreateStartLightPanelIfNeeded()
        {
            if (_startLightDlg == null || !_startLightDlg.IsHandleCreated)
                _startLightDlg = new StartLightDlg();
        }

        private void ShowStartLight()
        {
            CreateStartLightPanelIfNeeded();

            if(!_startLightDlg.Visible)
                _startLightDlg.Show(this);
        }

        private void CloseStartLight()
        {
            _startLightDlg.Close();
        }

        private void ShowWarningLights()
        {
            CreateStartLightPanelIfNeeded();

            if(_startLightDlg.Visible == false)
                _startLightDlg.Show(this);
            _startLightDlg.WarningLights();
        }

        private void StopWarningLights()
        {
            CreateStartLightPanelIfNeeded();

            _startLightDlg.StopWarningLights();
        }

        private void StartLight_ShowRedLight(int value)
        {
            CreateStartLightPanelIfNeeded();
            if (!_startLightDlg.Visible)
                ShowStartLight();

            _startLightDlg.ShowRedLight(value);
        }
        private void StartLight_ShowGreenLight()
        {
            CreateStartLightPanelIfNeeded();

            _startLightDlg.AllGreen();
        }

        private void StartLight_NoLight()
        {
            if (_startLightDlg != null && _startLightDlg.Visible)
            {
                _startLightDlg.Hide();
                _startLightDlg.HideAllRedLights();
            }
        }

        #endregion START LIGHT


        private void Pause()
        {
            RaceManager.Instance.PauseHwi();
        }

        public void RefreshAfterPauseCommand()
        {
            this.BeginInvoke(new StandardCallBack(RefreshAfterPause));
        }

        private void RefreshAfterPause()
        {
            pbStart.Image = Images.Play;
            pbFlag.EditValue = Images.YellowFlag;
            btnGreenFlag.Enabled = false;
            ShowWarningLights();
        }



        private void UnPause()
        {
            RaceManager.Instance.UnPauseHwi();
        }

        public void RefreshAfterUnPauseCommand()
        {
            this.BeginInvoke(new StandardCallBack(RefreshAfterUnPause));
        }

        public void RefreshAfterUnPause()
        {
            pbStart.Image = Images.Pause;
            pbFlag.EditValue = Images.GreenFlag;
            btnGreenFlag.Enabled = true;
            StopWarningLights();
        }

        private void Stop()
        {
            CloseStartLight();
            RaceManager.Instance.StoptHwi();
        }



        #endregion COMMANDS


        #region RACE HELPER COMMANDS

        public void RefresWeatherCommand()
        {
            this.BeginInvoke(new RefreshWithoutArgs(RefresWeather));
        }

        public void ResfreshStartLightCommand()
        {
           this.BeginInvoke(new RefreshStartCountdown(RefreshStarterCountdown), 0);           
        }

        public void ResfreshStarterCommand(int? count)
        {
            if(count.HasValue)
                this.BeginInvoke(new RefreshStartCountdown(RefreshStarterCountdown), count);
            else
                this.BeginInvoke(new RefreshWithoutArgs(RefreshDuration));
        }

        public void RaceTeamFinishCommand(LaneIdEventArgs e)
        {
            this.BeginInvoke(new RefreshOneTeamCallback(RefreshOneTeamImagesByPosition), new object[] { e.LaneId});
        }

        public void RacePitStopRefreshCommand(LaneIdEventArgs e)
        {
            // mettre a jour le TeamPanel correspondant (refresh
            this.BeginInvoke(new RefreshOneTeamCallback(RefreshTeamForPitStopByPosition), new object[] { e.LaneId });
            
        }

        public void RacePitStopEndedCommand(LaneIdEventArgs e)
        {
            // mettre a jour le TeamPanel correspondant (refresh
            this.BeginInvoke(new RefreshOneTeamCallback(RefreshOneTeamForPitStopEndByPosition), new object[] { e.LaneId });
        }

        public void RacePitStopBeginCommand(LaneIdEventArgs e)
        {
            // mettre a jour le TeamPanel correspondant (refresh
            this.BeginInvoke(new RefreshOneTeamCallback(RefreshTeamForPitStopByPosition), new object[] { e.LaneId });
        }

        public void RaceIncidentCommand(LaneIdEventArgs e)
        {
            // mettre a jour le TeamPanel correspondant (refresh
            this.BeginInvoke(new RefreshOneTeamCallback(RefreshTeamForPitStopByPosition), new object[] { e.LaneId });

        }

        public void CurrentRaceOutOfFuelCommand(LaneIdEventArgs e)
        {
        }

        public void CurrentRaceLowFuelCommand(LaneIdEventArgs e)
        {
        }

        public void CurrentRaceLapRecordCommand(LaneIdEventArgs e)
        {
        }

        public void CurrentRaceOutOfHealthCommand(LaneIdEventArgs e)
        {
        }

        public void CurrentRaceOutOfTiresCommand(LaneIdEventArgs e)
        {
        }

        public void CurrentRaceLowTiresCommand(LaneIdEventArgs e)
        {
        }

        public void CurrentRaceTeamEndRelayCommand(LaneIdEventArgs e)
        {
            // TODO
            // Ici il faut voir comment faire pour que l'on affiche la nécessité pour une team de changer de pilote (fin de relais).
            // On peut éventuellement afficher un pictogramme

            this.BeginInvoke(new RefreshOneTeamCallback(RefreshTeamForEndOfRelay), new object[] { e.LaneId });
        }


        public void CurrentRaceLowHealthCommand(LaneIdEventArgs e)
        {
        }

        public void StartButtonActionCommand()
        {
            if(this.AppViewModel.CurrentPage != null && this.AppViewModel.CurrentPage.GetType() == this.GetType())
                this.BeginInvoke(new StandardCallBack(StartButtonAction));
        }

        public void RaceStartedCommand()
        {
            this.BeginInvoke(new StandardCallBack(RefreshOnGreenFlag));
        }

        public void RaceYellowFlagCommand()
        {
            this.BeginInvoke(new StandardCallBack(RefreshOnYellowFlag));
        }

        public void RaceGreenFlagCommand()
        {
            this.BeginInvoke(new StandardCallBack(RefreshOnGreenFlag));
        }

        public void RaceFinishedCommand()
        {
            this.BeginInvoke(new StandardCallBack(RefreshOnRaceFinished));
        }

        public void RaceLapEndedCommand()
        {
            this.BeginInvoke(new RefreshAllTeamsWithRace(RefreshAllPage), new object[] { AppViewModel.CurrentRace });
        }
        
        public void RefreshDurationCommand()
        {
            this.BeginInvoke(new StandardCallBack(RefreshDuration));
        }

        public void RefreshTimeAttackRaceTimeCommand()
        {
            this.BeginInvoke(new StandardCallBack(RefreshRaceTime));
        }

        public void RefreshConnectionStateCommand()
        {
            this.BeginInvoke(new StandardCallBack(RefreshConnectionState));
        }

        public void TrackCallCommand(TeamIdEventArgs e)
        {
            this.BeginInvoke(new StandardCallBack(RefreshTeamsForTrackCall));
        }

        public void ResizeTeamsListCommand()
        {
            this.BeginInvoke(new StandardCallBack(RefreshGridAfterTeamAdded));
        }

        #endregion RACE HELPER COMMANDS

        #region MISE A JOUR UI 

        private void RefresWeather()
        {
            if (pbWeather.DataBindings.Count > 0)
            {
                pbWeather.DataBindings["Image"].ReadValue();
                pbNextWeather.DataBindings["Image"].ReadValue();
                lblForecast.DataBindings["Text"].ReadValue();
                lblTemp.DataBindings["Text"].ReadValue();
                lblTrackTemperature.DataBindings["Text"].ReadValue();
                pbOptimalTires.DataBindings["Image"].ReadValue();
            }
        }

        private void RefreshStarterCountdown(int? count)
        {
            if (count.HasValue && count == 0)
            {
                ShowStartLight();
            }
            else if (count.HasValue && count > 0)
            {
                //labelRaceTime.Text = count.ToString();
                StartLight_ShowRedLight(count.Value);
            }
            else
            {
                RefreshDuration();
            }
        }

        private void RefreshDuration()
        {
            try
            {
                if (RaceManager.Instance.Race.SafetyCar)
                {
                    ShowWarningLights();
                    if (RaceManager.Instance.Race.EndSafetyCarInThisLap)
                        _startLightDlg.SafetyCarInThisLap();
                }
                else if (_startLightDlg.Visible)
                    StopWarningLights();


                if (RaceManager.Instance.Race.RaceParams.ShowTimeDuration || RaceManager.Instance.Race is Qualification)
                {
                    TimeSpan t = (RaceManager.Instance.Race is Qualification) ? RaceManager.Instance.Race.RaceParams.QualificationTime : RaceManager.Instance.Race.RaceParams.TimeLimit.Value - RaceManager.Instance.RaceDurationForUI;
                    if (t.TotalSeconds > 0)
                        labelRaceTime.Text = t.ToString(@"hh\:mm\:ss");
                    else
                        labelRaceTime.Text = Textes.RaceFinished;
                }
                else
                    labelRaceTime.Text = RaceManager.Instance.RaceDurationForUI.ToString(@"hh\:mm\:ss");

                if (lblForecast.DataBindings.Count > 0)
                    lblForecast.DataBindings["Text"].ReadValue();
            }
            catch(Exception ex)
            {

            }
        }


        private void RefreshOnYellowFlag()
        {
            pbFlag.EditValue = Images.YellowFlag;
            pbStart.Image = Images.Play;
        }

        private void RefreshOnGreenFlag()
        {
            pbFlag.EditValue = Images.GreenFlag;
            pbStart.Image= Images.Pause;
            classicRaceView.RefreshData();
            StartLight_NoLight();
        }

        protected virtual  void RefreshOnRaceFinished()
        {
            pbFlag.EditValue = Images.RedFlag;

            // Passer le chrono en rouge et changer le label Chrono par "Terminé !"
            labelRaceTime.ForeColor = Color.Orange;
            labelRaceTime.Text = Textes.RaceFinished;
            labelLapsCount.Text = string.Empty;
            pbStart.Image = Images.Play;

            // si la course est en mode multi car on affiche une DLG pour donner le vaiqueur
            if (RaceManager.Instance.Race.RaceParams.MultiCarTeams)
            {
                var first = RaceManager.Instance.Race.ClassementByColors.First();
                FinishDlg finishDlg = new FinishDlg(first.Key, first.Value);
                finishDlg.StartPosition = FormStartPosition.CenterScreen;
                finishDlg.ShowDialog();
            }

            AppViewModel.ActivatePage("pageEndRace");
            if(_secondRacePageDialog != null)
              _secondRacePageDialog.SwitchView(false);

            classicRaceView.RefreshData();
        }

        private void RefreshAllPage(Race race)
        {
            if (race.IsFirstLap)
                labelLapsCount.Text = Textes.FirstLap;
            else if (race.IsLastLap)
                labelLapsCount.Text = Textes.LastLap;
            else if (race.IsRunning)
                labelLapsCount.Text = string.Format("{0} {1}", Textes.Lap, race.CurrentLap);

            //if (racePanel.Visible)
            //    racePanel.OrderPanels();
            //else
               classicRaceView.RefreshData();
        }

        private void RefreshTeamsForTrackCall()
        {
            //if (racePanel.Visible)
            //    racePanel.RefreshTeamsForTrackCall();
            //else
                classicRaceView.RefreshData();
        }

        public void RefreshOneTeamCommand(Race datas, int teamId)
        {
            if (teamId >= 0)
            {
                //if (racePanel.Visible)
                //    racePanel.RefreshTeam(teamId);
                //else
                    classicRaceView.RefreshData();
            }
        }

        public void RefreshRaceBoardCommand()
        {
            classicRaceView.RefreshData();
        }


        private void RefreshOneTeamImagesByPosition(int teamId)
        {
            if (teamId >= 0)
            {
                //if (racePanel.Visible)
                //    racePanel.RefreshTeamImages(AppViewModel.CurrentRace.Teams[teamId].Statisitics.Position);
                //else
                    classicRaceView.RefreshData();
            }

            // Clipboard.SetText(AppViewModel.CurrentRace._log);
        }

        private void RefreshTeamForPitStopByPosition(int teamId)
        {
            if (teamId >= 0)
            {
                //if (racePanel.Visible)
                //    racePanel.RefreshTeamForPitStopByPosition(AppViewModel.CurrentRace.Teams[teamId].Statisitics.Position);
                //else
                    classicRaceView.RefreshData();
            }
        }

        private void RefreshOneTeamForPitStopEndByPosition(int teamId)
        {
            if (teamId >= 0)
            {
                //if (racePanel.Visible)
                //    racePanel.RefreshTeamForPitStopEndByPosition(AppViewModel.CurrentRace.Teams[teamId].Statisitics.Position);
                //else
                    classicRaceView.RefreshData();
            }
        }

        private void RefreshTeamForEndOfRelay(int teamId)
        {
            if (teamId >= 0)
            {
                //if (racePanel.Visible)
                //    racePanel.RefreshTeamForEndOfRelay(AppViewModel.CurrentRace.Teams[teamId].Statisitics.Position);
                //else
                    classicRaceView.RefreshData();
            }
        }

        private void RefreshRaceTime()
        {
            //// refresh des panels
            //    racePanel.RefreshTeamsTimeAttackCountdown();
        }

        #endregion MISE A JOUR UI DEPUIS EVENTS

        #region TESTING



        private void simpleButton1_Click(object sender, System.EventArgs e)
        {
            //_raceHelper.Race.Teams[1].LapThrotlesInfos = new List<HandSetThrotthleInfo>();
            //for (int i = 0; i < 200; i++)
            //{
            //    _raceHelper.Race.Teams[1].LapThrotlesInfos.Add(new HandSetThrotthleInfo(20));
            //    _raceHelper.Race.Teams[1].TotalLapThrottle += 20;
            //}

            //            _raceHelper.Race.Teams[1].CarHealthPercent -= 20;

            RaceManager.Instance.Race.Teams[1]._totalLapThrottle = 2000;
            RaceManager.Instance.Race.Teams[1].InitTankAndTiresPotentiel(10,10);
            RaceManager.Instance.Race.Teams[1].TotalThrotlleForFueUnit = 2000;

            Program.hwInterface.OnLapEndedTestTimer(1);
        }

        private void simpleButton2_Click(object sender, System.EventArgs e)
        {
            Program.hwInterface.OnLapEndedTestTimer(2);
        }

        private void simpleButton3_Click(object sender, System.EventArgs e)
        {
            Program.hwInterface.OnLapEndedTestTimer(3);
        }

        private void simpleButton4_Click(object sender, System.EventArgs e)
        {
            Program.hwInterface.OnLapEndedTestTimer(4);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            RaceManager.Instance.ForcePitStopToBegin(1);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            //_raceHelper.Race.Teams[0].PitOut(appViewModel.DigitalParams.AddLapOnPitStop);
            //RacePitStopRefreshCommand(new LaneIdEventArgs(1));

            AppViewModel.CurrentRace.AddNewTeamInRace(6);

            RefreshGridAfterTeamAdded();

        }


        #endregion TESTING




        protected override void OnSizeChanged(EventArgs e)
        {
            //if (racePanel != null)
            //{
            //    racePanel.SuspendLayout();
            //}
            this.SuspendLayout();

            base.OnSizeChanged(e);

            //if (racePanel != null)
            //    racePanel.ResumeLayout();

            this.ResumeLayout();
            ResizeGridRowHeight();
        }


        private void btnMonitoring_Click(object sender, EventArgs e)
        {
            ShowMonitoringDialog();
        }

        public void ShowMonitoringDialog()
        {
                MonitoringDlg _monitoringDlg;
                _monitoringDlg = new MonitoringDlg(RaceManager.Instance, appViewModel);
                _monitoringDlg.Show();
        }

        private void btnDuplicateView_Click(object sender, EventArgs e)
        {
            ShowSecondRaceView();
        }

        public void ShowSecondRaceView()
        {
            if (_secondRacePageDialog != null && _secondRacePageDialog.Visible == false)
            {
                _secondRacePageDialog.Close();
                _secondRacePageDialog.Dispose();
                _secondRacePageDialog = null;
                _secondRacePageDialog = new SecondRaceView(RaceManager.Instance);
            }
            else if (_secondRacePageDialog == null)
                _secondRacePageDialog = new SecondRaceView(RaceManager.Instance);

            _secondRacePageDialog.FormClosed -= SecondRacePageDialog_FormClosed;
            _secondRacePageDialog.FormClosed += SecondRacePageDialog_FormClosed;

            RaceManager.Instance.SetSecondRacePage(_secondRacePageDialog.RacePage);
            _secondRacePageDialog.Show();
            _secondRacePageDialog.InitUI(AppViewModel);
        }

        private void SecondRacePageDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            RaceManager.Instance.SetSecondRacePage(null);
            _secondRacePageDialog = null;
        }



        // Reconnexion à la PB en cas de perte de connexion ou d'arrêt de la PB.
        // il faut se reconnecter mais également reprende la course ou elle en était
        public void ResetConnexion()
        {
            //Pause();
            // On relance la connexion a la PB. Attention la reconnexion a pour effet de casser le lien avec le racehelper et donc la course.
            Program.ResetHardwareConnexion(appViewModel.DigitalParams);
            Thread.Sleep(100);
            // remise en cohérence du lien entre PB et racehelper
            RaceManager.Instance.InitHelper(Program.hwInterface, Program.pitSensors, Program._startLight, Program._carIdProgrammer, this, _secondRacePageDialog != null ? _secondRacePageDialog.RacePage : null, AppViewModel.DigitalParams, AppViewModel.SoundSettings, AppViewModel.CurrentRace, AppViewModel.Records,false);
            Thread.Sleep(100);
            RefreshConnectionState();
            if (RaceManager.Instance.Race.IsRunning)
                Program.hwInterface.StartCommand();
            ////UnPause();
        }

        private void RefreshConnectionState()
        {
            if (this.ParentForm != null && this.ParentForm is MainForm)
                (this.ParentForm as MainForm).ChangeConnexionButtonColor();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            panelTests.Visible = false;
        }


        private void labelRaceTime_Paint(object sender, PaintEventArgs e)
        {
           
            if (!_consignShowed && this.appViewModel.DigitalParams.ShowRaceStartConsign && (appViewModel.CurrentRaceParameters.UseWeatherConditions || this.appViewModel.CurrentRaceParameters.PilotPerTeam > 1))
            {
                _consignShowed = true;
                BeforeStartRaceDlg dlg = new BeforeStartRaceDlg(this.appViewModel);
                dlg.ShowDialog();
            }
        }

        #region  GRID VIEW

        private void InitGridImageColumns()
        {
            int TiresImageListSize = (int)(colCurrentTires.Width - 15);
            if (TiresImageListSize > (int)(2.7 * classicRaceView.RowHeight))
                TiresImageListSize = (int)(2.7 * classicRaceView.RowHeight);

            if (TiresImageListSize < 256)
            {
                //if (TiresImageListSize > colCurrentTires.Width - 15)
                //    TiresImageList.ImageSize = new Size((int)(colCurrentTires.Width - 15), (int)(colCurrentTires.Width - 15));
                //else
                TiresImageList.ImageSize = new Size(TiresImageListSize, TiresImageListSize);
            }
            else
            {
                if (256 > colCurrentTires.Width - 15)
                    TiresImageList.ImageSize = new Size((int)(colCurrentTires.Width - 15), (int)(colCurrentTires.Width - 15));
                else
                    TiresImageList.ImageSize = new Size(256, 256);
            }

            TiresImageList.Images.Clear();
            TiresImageList.Images.Add(Images.Hard);
            TiresImageList.Images.Add(Images.Medium);
            TiresImageList.Images.Add(Images.Soft);
            TiresImageList.Images.Add(Images.Intermediate);
            TiresImageList.Images.Add(Images.Wet);
            TiresImageList.Images.Add(Images.empty);

            // Initialisation de la liste des images d'état
            stateImageList.ImageSize = new Size(TiresImageList.ImageSize.Width, TiresImageList.ImageSize.Height);
            stateImageList.Images.Clear();
            stateImageList.Images.Add(Images.TeamFinish);
            stateImageList.Images.Add(Images.PitStop);
            stateImageList.Images.Add(Images.GreenFlag);
            stateImageList.Images.Add(Images.YellowFlag);
            stateImageList.Images.Add(Images.EndOfRelay);
            stateImageList.Images.Add(Images.BrakeIncident);
            stateImageList.Images.Add(Images.EngineIncident);
            stateImageList.Images.Add(Images.SuspensionIncident);
            stateImageList.Images.Add(Images.TiresIncident);
            stateImageList.Images.Add(Images.Alert);
            stateImageList.Images.Add(Images.Warning);
            stateImageList.Images.Add(Images.empty);

            // WeatherImage List
            WeatherImageList.Images.Clear();
            WeatherImageList.Images.Add(Images.Sunny);
            WeatherImageList.Images.Add(Images.SunnyCloudy);
            WeatherImageList.Images.Add(Images.Thinning);
            WeatherImageList.Images.Add(Images.Covered);
            WeatherImageList.Images.Add(Images.SunnyRain1);
            WeatherImageList.Images.Add(Images.SunnyRain2);
            WeatherImageList.Images.Add(Images.Rain);
            WeatherImageList.Images.Add(Images.NightClear);
            WeatherImageList.Images.Add(Images.NightCloudy);
            WeatherImageList.Images.Add(Images.NightRain1);
            WeatherImageList.Images.Add(Images.NightRain2);



            repositoryItemImageStates.LargeImages = stateImageList;
            repositoryItemImageStates.Items.Clear();
            ImageComboBoxItem vItem1 = new ImageComboBoxItem() { ImageIndex = (int)StateImageEnum.Finish, Value = (int)StateImageEnum.Finish };
            repositoryItemImageStates.Items.Add(vItem1);
            ImageComboBoxItem vItem2 = new ImageComboBoxItem() { ImageIndex = (int)StateImageEnum.PitStop, Value = (int)StateImageEnum.PitStop };
            repositoryItemImageStates.Items.Add(vItem2);
            ImageComboBoxItem vItem3 = new ImageComboBoxItem() { ImageIndex = (int)StateImageEnum.GreenFlag, Value = (int)StateImageEnum.GreenFlag };
            repositoryItemImageStates.Items.Add(vItem3);
            ImageComboBoxItem vItem4 = new ImageComboBoxItem() { ImageIndex = (int)StateImageEnum.YellowFlag, Value = (int)StateImageEnum.YellowFlag };
            repositoryItemImageStates.Items.Add(vItem4);
            ImageComboBoxItem vItem5 = new ImageComboBoxItem() { ImageIndex = (int)StateImageEnum.EndOfRelay, Value = (int)StateImageEnum.EndOfRelay };
            repositoryItemImageStates.Items.Add(vItem5);
            ImageComboBoxItem vItem6 = new ImageComboBoxItem() { ImageIndex = (int)StateImageEnum.BrakesIncident, Value = (int)StateImageEnum.BrakesIncident };
            repositoryItemImageStates.Items.Add(vItem6);
            ImageComboBoxItem vItem7 = new ImageComboBoxItem() { ImageIndex = (int)StateImageEnum.EngineIncident, Value = (int)StateImageEnum.EngineIncident };
            repositoryItemImageStates.Items.Add(vItem7);
            ImageComboBoxItem vItem8 = new ImageComboBoxItem() { ImageIndex = (int)StateImageEnum.SuspensionIncident, Value = (int)StateImageEnum.SuspensionIncident };
            repositoryItemImageStates.Items.Add(vItem8);
            ImageComboBoxItem vItem9 = new ImageComboBoxItem() { ImageIndex = (int)StateImageEnum.TiresIncident, Value = (int)StateImageEnum.TiresIncident };
            repositoryItemImageStates.Items.Add(vItem9);
            ImageComboBoxItem vItem10 = new ImageComboBoxItem() { ImageIndex = (int)StateImageEnum.Alert, Value = (int)StateImageEnum.Alert };
            repositoryItemImageStates.Items.Add(vItem10);
            ImageComboBoxItem vItem11 = new ImageComboBoxItem() { ImageIndex = (int)StateImageEnum.Warning, Value = (int)StateImageEnum.Warning };
            repositoryItemImageStates.Items.Add(vItem11);
            ImageComboBoxItem vItem12 = new ImageComboBoxItem() { ImageIndex = (int)StateImageEnum.Empty, Value = (int)StateImageEnum.Empty };
            repositoryItemImageStates.Items.Add(vItem12);

            repositoryItemImagePitStop.LargeImages = TiresImageList;
            repositoryItemImagePitStop.Items.Clear();
            ImageComboBoxItem vItemPS1 = new ImageComboBoxItem() { ImageIndex = 5, Value = 99 };
            repositoryItemImagePitStop.Items.Add(vItemPS1);
            ImageComboBoxItem vItemPS2 = new ImageComboBoxItem() { ImageIndex = 0, Value = (int)TireType.Hard };
            repositoryItemImagePitStop.Items.Add(vItemPS2);
            ImageComboBoxItem vItemPS3 = new ImageComboBoxItem() { ImageIndex = 1, Value = (int)TireType.Medium };
            repositoryItemImagePitStop.Items.Add(vItemPS3);
            ImageComboBoxItem vItemPS4 = new ImageComboBoxItem() { ImageIndex = 2, Value = (int)TireType.Soft };
            repositoryItemImagePitStop.Items.Add(vItemPS4);
            ImageComboBoxItem vItemPS5 = new ImageComboBoxItem() { ImageIndex = 3, Value = (int)TireType.Intermediate };
            repositoryItemImagePitStop.Items.Add(vItemPS5);
            ImageComboBoxItem vItemPS6 = new ImageComboBoxItem() { ImageIndex = 4, Value = (int)TireType.Wet };
            repositoryItemImagePitStop.Items.Add(vItemPS6);


            if (!RaceManager.Instance.Race.RaceParams.ShowPilots && RaceManager.Instance.Race.RaceParams.ShowCars)
            {
                colImagePilote.Visible = true;
                colImagePilote.FieldName = "CarImage";
                colImageCar.Visible = false;
            }
            else
            {
                colImagePilote.FieldName = "TeamImage";
                colImagePilote.Visible = RaceManager.Instance.Race.RaceParams.ShowPilots;
                colImageCar.Visible = RaceManager.Instance.Race.RaceParams.ShowCars;
            }

            if(RaceManager.Instance.Race is RallyCrossRace)
                this.colMandatoryLeft.FieldName = "JokerLapLeft";
            else
                this.colMandatoryLeft.FieldName = "MandatoryPSLeft";


            colCurrentTires.Visible = RaceManager.Instance.Race.RaceParams.UseWeatherConditions;
            colHealth.Visible = RaceManager.Instance.Race.RaceParams.Damages != DamagesEnum.None;
            colFuel.Visible = RaceManager.Instance.Race.RaceParams.FuelImpact;
            colTires.Visible = RaceManager.Instance.Race.RaceParams.TiresImpact != TiresImpactEnum.None;

            colBestLap.RowCount = 3;
            colTires.RowCount = 1;
            colHealth.RowCount = 1;
            colFuel.RowCount = 1;

            this.colHealth.RowIndex = 0;
            this.colFuel.RowIndex = 1;
            this.colTires.RowIndex = 2;
            colBestLap.RowIndex = 3;

            if (!colTires.Visible)
                colFuel.RowCount++;
            if (!colHealth.Visible)
                colFuel.RowCount++;
            if (!colFuel.Visible)
                colTires.RowCount++;

            if (!colTires.Visible && !colFuel.Visible && !colHealth.Visible)
                colBestLap.RowCount += 3;

            raceGrid.Invalidate();
            raceGrid.Refresh();
            
        }

        private void classicRaceView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            TeamInRace team = (classicRaceView.GetRow(e.RowHandle) as TeamInRace);
            int teamId = team.Id;

            // affichage du nom de l'équipe et ID du handset
            if ((e.Column == colId || e.Column == colPilote || e.Column == colLapCount) && e.RowHandle < classicRaceView.RowCount)
            {
                if (RaceManager.Instance.Race.Teams.ContainsKey(teamId))
                    e.Appearance.ForeColor = Color.FromArgb(team.Color);
            }
            else if ((e.Column == colLastLap) && e.RowHandle < classicRaceView.RowCount)
            {
                if (RaceManager.Instance.Race.Teams.ContainsKey(teamId))
                    e.Appearance.ForeColor = Color.FromArgb(team.Color);
            }
            else if ((e.Column == colImagePilote) && RaceManager.Instance.Race.RaceParams.DigitalParams.UsePitDetection)
            {
                (e.Column.ColumnEdit as RepositoryItemPictureEdit).Caption.Text = team.IsInPitLaneText;
            }
            else if (e.Column == colCurrentTires)
            {
                (e.Column.ColumnEdit as RepositoryItemPictureEdit).Caption.Text = team.CurrentTiresFirstLetter;
            }

            bool intPit = team.State == TeamState.PitIn;
            // couleur de fond du ROW
            if(team.IsInPitLane)
                e.Appearance.BackColor = Color.FromArgb(80, 19, 80, 100);

            if (intPit)
            {
                e.Appearance.BackColor = Color.FromArgb(80, 19, 80, 100);

                if (e.Column == colPitStopAction || e.Column == colLastLap)
                    e.Appearance.ForeColor = team.PitStop_CurrentActionColor;
                else if(e.Column == colPitStopSelectionImage)
                    (e.Column.ColumnEdit as RepositoryItemPictureEdit).Caption.Text = team.PitStop_CurrentSelectionTitle;
            }
            else if (team.OutOfFuel || team.OutOfTires || team.OutOfHealth)
                e.Appearance.BackColor = Color.FromArgb(50, 215, 9, 9);
            else if (team.LowFuel || team.LowHealth || team.LowTires)
                e.Appearance.BackColor = Color.FromArgb(50, 215, 191, 9);

            if (!intPit && e.Column == colPitStopSelectionImage)
            {
                (e.Column.ColumnEdit as RepositoryItemPictureEdit).Caption.Text = string.Empty;
            }

            // COULEUR DES PROGRESS BAR
            if (e.Column == colTires || e.Column == colHealth || e.Column == colFuel)
            {
                (e.Column.ColumnEdit as RepositoryItemProgressBar).StartColor = ControlPaint.Dark(Color.FromArgb(team.Color));
                (e.Column.ColumnEdit as RepositoryItemProgressBar).EndColor = Color.FromArgb(team.Color);
                (e.Column.ColumnEdit as RepositoryItemProgressBar).Appearance.Options.UseForeColor = false;
                (e.Column.ColumnEdit as RepositoryItemProgressBar).Appearance.Options.UseForeColor2 = false;
                colTires.AppearanceCell.Options.UseForeColor = true;
                e.Appearance.ForeColor = ControlPaint.LightLight(Color.FromArgb(team.Color));
            }

        }

        public void RefreshGridAfterTeamAdded()
        {
            ResizeGridRowHeight();
        }

        private void ResizeGridRowHeight()
        {
            if (AppViewModel == null || AppViewModel.CurrentRace == null)
                return;

            if (classicRaceView != null ) //&& classicRaceView.RowCount > 0)
            {
                classicRaceView.RowHeight = (this.raceGrid.Height - 20) / (6 * (RaceManager.Instance.Race.Teams.Count >= 2 ? RaceManager.Instance.Race.Teams.Count : 2));
                int maxRowHeight = (this.Height - 30) / (6 * (RaceManager.Instance.Race.Teams.Count));
                if ((RaceManager.Instance.Race.Teams.Count) < 4)
                    maxRowHeight = (this.Height - 30) / 24;

                float newSize = maxRowHeight / (float)1;
                Font newFont = Program.fontManager.GetCGFFont(newSize, FontStyle.Italic);
                if (appViewModel.CurrentRaceParameters.PilotPerTeam > 1)
                {
                    newSize = (colPilote.RowCount * maxRowHeight) / (float)2.5;
                    newFont = Program.fontManager.GetCGFFont(newSize, FontStyle.Italic);
                    colPilote.AppearanceCell.Font = newFont;
                }
                else
                {
                    newSize = (colPilote.RowCount * maxRowHeight) / (float)2;
                    newFont = Program.fontManager.GetCGFFont(newSize, FontStyle.Italic);
                    colPilote.AppearanceCell.Font = newFont;
                }

                if(RaceManager.Instance.Race.RaceParams.ShowPilots || RaceManager.Instance.Race.RaceParams.ShowCars)
                     newSize = ((colLapCount.RowCount-1) * maxRowHeight) / (float)1.8;
                else
                    newSize = ((colLapCount.RowCount - 1) * maxRowHeight) / (float)1.2;

                newFont = Program.fontManager.GetCGFFont(newSize, FontStyle.Italic);
                colLapCount.AppearanceCell.Font = newFont;

                newSize = (colGap.RowCount * maxRowHeight) / (float)2.4;
                newFont = Program.fontManager.GetEuroStyleFont(newSize, FontStyle.Bold | FontStyle.Italic);
                colGap.AppearanceCell.Font = newFont;

                newSize = (2 * maxRowHeight) / (float)1.5;
                newFont = Program.fontManager.GetEuroStyleFont(newSize, FontStyle.Bold | FontStyle.Italic);
                colLastLap.AppearanceCell.Font = newFont;

                newSize = (2 * maxRowHeight) / (float)1.8;
                newFont = Program.fontManager.GetEuroStyleFont(newSize, FontStyle.Italic);
                colPitStopSelectionTitle.AppearanceCell.Font = newFont;


                newSize = (3 * maxRowHeight) / (float)1.7;
                newFont = Program.fontManager.GetEuroStyleFont(newSize, FontStyle.Bold | FontStyle.Italic);
                colBestLap.AppearanceCell.Font = newFont;

                newSize = maxRowHeight / (float)2.5;
                newFont = Program.fontManager.GetEuroStyleFont(newSize, FontStyle.Bold | FontStyle.Italic);
                repositoryItemProgressBarCar.Appearance.Font = newFont;
                colHealth.AppearanceCell.Font = newFont;
                repositoryItemProgressBarFuel.Appearance.Font = newFont;
                colFuel.AppearanceCell.Font = newFont;
                repositoryItemProgressBarTires.Appearance.Font = newFont;
                colTires.AppearanceCell.Font = newFont;
                colCurrentCurves.AppearanceCell.Font = newFont;

                newSize = maxRowHeight / (float)1.5;
                newFont = Program.fontManager.GetEuroStyleFont(newSize, FontStyle.Bold | FontStyle.Italic);
                this.repositoryItemPicturePilot.Caption.Appearance.Font = newFont;
                this.repositoryItemPicturePilot.Caption.Appearance.BackColor = Color.Transparent;
                this.repositoryItemPicturePitStopSelection.Caption.Appearance.Font = newFont;
                this.repositoryItemPicturePitStopSelection.Caption.Appearance.BackColor = Color.Transparent;

                newSize = ((colMandatoryLeft.RowCount - 1) * maxRowHeight) / (float)2.6;
                newFont = Program.fontManager.GetCGFFont(newSize, FontStyle.Italic);
                //newFont = Program.fontManager.GetEuroStyleFont(newSize, FontStyle.Regular);
                this.colMandatoryLeft.AppearanceCell.Font = newFont;

            }

            InitGridImageColumns();

            //raceGrid.DataSource = null;
            classicRaceView.RefreshData();
            //raceGrid.DataSource = AppViewModel.CurrentRace.Teams.Values;
            //classicRaceView.RefreshData();
        }


        private void repositoryItemProgressBarFuel_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            e.DisplayText = string.Format("{0} {1}",Textes.FuelShort,e.Value);
        }

        private void repositoryItemProgressBarCar_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            e.DisplayText = string.Format("{0} {1}", Textes.CarHealth, e.Value);
        }

        private void repositoryItemProgressBarTires_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            e.DisplayText = string.Format("{0} {1}", Textes.Tires, e.Value);
        }

        private void classicRaceView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == colImageFuel)
                e.Value = Images.gas;
            else if (e.Column == colImageHealth)
                e.Value = Images.heart;
            else if (e.Column == colImageTires)
                e.Value = Images.carwheel;

            // gestion de l'image lors de pitStop.
            // Si on est en action changement de pneu, on navigue dans les différents Type de pneus
            // SI on est en action changement de pilote, on affiche les images des pilotes
            // Sinon on affiche rien du tout
            else if (e.Column == colPitStopSelectionImage)
            {
                TeamInRace team = e.Row as TeamInRace;
                if (team.PitStopRunning && team.PitStop_CurrentAction == PitStopActionEnum.SelectTires)
                {
                    e.Value = TiresImageList.Images[team.PitStop_TireTypeShowed];
                }
                else if (team.PitStopRunning && team.PitStop_CurrentAction == PitStopActionEnum.SelectPilot)
                {
                    e.Value = team.PitStop_NextPilot.Image;
                }
                else
                {
                    e.Value = Images.empty;
                }
            }
            else if (e.Column == colCurrentTires)
            {
                TeamInRace team = e.Row as TeamInRace;
                e.Value = TiresImageList.Images[team.CurrentTires];
            }


        }

        #endregion GRID VIEW


        #region GESTION DES SONS


        public void PlayRainSoundCommand(SoundEnum sound)
        {
            this.BeginInvoke(new PlaySoundDelegate(PlayRainSound), sound);
        }

        public void StopRainSoundCommand()
        {
            this.BeginInvoke(new StopSoundDelegate(StopRainSound));
        }

        private void PlayRainSound(SoundEnum sound)
        {
            ESRMSoundPlayer.Instance.PlayRainSound(sound, this.Handle);
        }
        private void StopRainSound()
        {
            ESRMSoundPlayer.Instance.StopRainSound(this.Handle);
        }



        private const int MM_MCINOTIFY = 0x03b9;
        private const int MCI_NOTIFY_SUCCESS = 0x01;
        private const int MCI_NOTIFY_SUPERSEDED = 0x02;
        private const int MCI_NOTIFY_ABORTED = 0x04;
        private const int MCI_NOTIFY_FAILURE = 0x08;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == MM_MCINOTIFY)
            {
                switch (m.WParam.ToInt32())
                {
                    case MCI_NOTIFY_SUCCESS:
                        // success handling
                        RaceManager.Instance.CheckForRainSound();
                        break;
                    case MCI_NOTIFY_SUPERSEDED:
                        // superseded handling
                        break;
                    case MCI_NOTIFY_ABORTED:
                        // abort handling
                        break;
                    case MCI_NOTIFY_FAILURE:
                        // failure! handling
                        break;
                    default:
                        // haha
                        break;
                }
            }
            base.WndProc(ref m);
        }






        #endregion

        private void RacePage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                StartButtonAction();
            }
        }

        private void raceGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                StartButtonAction();
            }
        }
    }
}

