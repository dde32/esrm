using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRM.Entities;
using System.Windows.Threading;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using ESRM.Win.Panels;
using ESRM.GamePads;
using System.Threading;

namespace ESRM.Win.Views
{
    public partial class DriverAndCarSelectionPage : BasePage
    {
        DriverAndCarSelectionPanel panel1;
        DriverAndCarSelectionPanel panel2;
        DriverAndCarSelectionPanel panel3;
        DriverAndCarSelectionPanel panel4;
        DriverAndCarSelectionPanel panel5;
        DriverAndCarSelectionPanel panel6;
        List<DriverAndCarSelectionPanel> _panels;

        GlobalGamePadHandSet _gp1;
        GlobalGamePadHandSet _gp2;
        GlobalGamePadHandSet _gp3;
        GlobalGamePadHandSet _gp4;
        GlobalGamePadHandSet _gp5;
        GlobalGamePadHandSet _gp6;
        List<GlobalGamePadHandSet> _gamePads;

        BackgroundWorker _gpWorker;

        public DriverAndCarSelectionPage()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                _gpWorker.CancelAsync();
                _gpWorker.Dispose();
                _gpWorker = null;

                if (_gp1 != null)
                {
                    _gp1.Dispose();
                    _gp1 = null;
                }
                if (_gp2 != null)
                {
                    _gp2.Dispose();
                    _gp2 = null;
                }
                if (_gp3 != null)
                {
                    _gp3.Dispose();
                    _gp3 = null;
                }
                if (_gp4 != null)
                {
                    _gp4.Dispose();
                    _gp4 = null;
                }
                if (_gp5 != null)
                {
                    _gp5.Dispose();
                    _gp5 = null;
                }
                if (_gp6 != null)
                {
                    _gp6.Dispose();
                    _gp6 = null;
                }          
            }
            base.Dispose(disposing);
        }

        public override void OnNavigatedTo(INavigationArgs args)
        {
            base.OnNavigatedTo(args);

            if (this.ParentForm != null && this.ParentForm is MainForm)
                (this.ParentForm as MainForm).SetTitle(AppViewModel.CurrentRaceParameters.RaceType.ToString());

            InitPage();

            ResizePanels();
        }

        public void InitPage(IESRMViewModel model)
        {
            base.appViewModel = model;

            if (_gp1 == null) //already init
                InitPage();
            else
                SetNotReadyPage();
        }


        private void SetNotReadyPage()
        {
            foreach (DriverAndCarSelectionPanel pane in _panels)
            {
                pane.NotReadyCommand();
            }
        }
        private void ResetPage()
        {
            foreach (DriverAndCarSelectionPanel pane in _panels)
            {
                pane.Reset();
            }
        }

        private void InitPage()
        {
            if (_gp1 == null)
            {
                _gp1 = GamePadFactory.GetGamePad(EsrmPlayerIndex.One);
                _gp2 = GamePadFactory.GetGamePad(EsrmPlayerIndex.Two);
                _gp3 = GamePadFactory.GetGamePad(EsrmPlayerIndex.Three);
                _gp4 = GamePadFactory.GetGamePad(EsrmPlayerIndex.Four);
                _gp5 = GamePadFactory.GetGamePad(EsrmPlayerIndex.Five);
                _gp6 = GamePadFactory.GetGamePad(EsrmPlayerIndex.Six);
                _gamePads = new List<GlobalGamePadHandSet>();
                _gamePads.Add(_gp1);
                _gamePads.Add(_gp2);
                _gamePads.Add(_gp3);
                _gamePads.Add(_gp4);
                _gamePads.Add(_gp5);
                _gamePads.Add(_gp6);

                int laneId = 1;
                foreach (GlobalGamePadHandSet gp in _gamePads)
                {
                    gp.LaneId = laneId;
                    laneId++;

                    gp.Left += Gp_Left;
                    gp.Right += Gp_Right;
                    gp.Up += Gp_Up;
                    gp.Down += Gp_Down;
                    gp.ButtonAPressed += Gp_ButtonAPressed;
                    gp.ButtonBPressed += Gp_ButtonBPressed;
                }
            }
            if (panel1 == null)
            {

                panel1 = new DriverAndCarSelectionPanel(this, AppViewModel.Pilots, AppViewModel.Cars, 1, AppViewModel.CurrentRaceParameters.PilotPerTeam);
                panel1.Dock = DockStyle.Left;
                panel2 = new DriverAndCarSelectionPanel(this, AppViewModel.Pilots, AppViewModel.Cars, 2, AppViewModel.CurrentRaceParameters.PilotPerTeam);
                panel2.Dock = DockStyle.Left;
                panel3 = new DriverAndCarSelectionPanel(this, AppViewModel.Pilots, AppViewModel.Cars, 3, AppViewModel.CurrentRaceParameters.PilotPerTeam);
                panel3.Dock = DockStyle.Left;
                panel4 = new DriverAndCarSelectionPanel(this, AppViewModel.Pilots, AppViewModel.Cars, 4, AppViewModel.CurrentRaceParameters.PilotPerTeam);
                panel4.Dock = DockStyle.Left;
                panel5 = new DriverAndCarSelectionPanel(this, AppViewModel.Pilots, AppViewModel.Cars, 5, AppViewModel.CurrentRaceParameters.PilotPerTeam);
                panel5.Dock = DockStyle.Left;
                panel6 = new DriverAndCarSelectionPanel(this, AppViewModel.Pilots, AppViewModel.Cars, 6, AppViewModel.CurrentRaceParameters.PilotPerTeam);
                panel6.Dock = DockStyle.Left;
                _panels = new List<DriverAndCarSelectionPanel>();

                _panels.Add(panel1);
                _panels.Add(panel2);
                _panels.Add(panel3);
                _panels.Add(panel4);
                _panels.Add(panel5);
                _panels.Add(panel6);
                this.panelTeam.Controls.Add(panel6);
                this.panelTeam.Controls.Add(panel5);
                this.panelTeam.Controls.Add(panel4);
                this.panelTeam.Controls.Add(panel3);
                this.panelTeam.Controls.Add(panel2);
                this.panelTeam.Controls.Add(panel1);


            }
            else
                SetNotReadyPage();

            int teamId = 1;
            foreach (DriverAndCarSelectionPanel panel in _panels)
            {
                if (AppViewModel.CurrentRaceParameters.Teams.ContainsKey(teamId))
                    panel.SetInitialValues(AppViewModel.CurrentRaceParameters.Teams[teamId]);
                teamId++;
            }

            if (_gpWorker == null)
            {

                _gpWorker = new BackgroundWorker();
                if (_gpWorker.IsBusy)
                {
                    _gpWorker.CancelAsync();
                    _gpWorker.DoWork -= Worker_DoWork;
                }
                else
                {
                    _gpWorker.DoWork += Worker_DoWork;
                    _gpWorker.RunWorkerAsync();
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ResizePanels();
        }

        private void ResizePanels()
        {
            if (_panels == null)
                return;

            int width = this.Width;
            int panelWidth = width / _panels.Count;
            foreach (DriverAndCarSelectionPanel panel in _panels)
            {
                panel.Size = new Size(panelWidth, this.panelTeam.Height);

            }
        }

        public void CheckIfAllTeamsAreReady()
        {
            bool isReady = panel1.IsReady && panel2.IsReady && panel3.IsReady && panel4.IsReady && panel5.IsReady && panel6.IsReady;
            bool atLeastOneTeamActivated = panel1.Activated || panel2.Activated || panel3.Activated || panel4.Activated || panel5.Activated || panel6.Activated;

            if (isReady && atLeastOneTeamActivated)
            {
                AppViewModel.CurrentRaceParameters.Teams.Clear();

                foreach (DriverAndCarSelectionPanel panel in _panels)
                {
                    TeamInRace team = panel.GetTeam();
                    if (team != null)
                    {
                        AppViewModel.CurrentRaceParameters.Teams.Add(team.Id, team);
                    }
                }

                if (AppViewModel.CurrentRaceParameters.Teams.Count > 0)
                {
                    AppViewModel.CreateRaceFromParameters();

                    AppViewModel.ActivatePage("pageRace");
                }
            }
        }




        #region GESTION DES GAMEPADS

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckButtonStateLoop();
        }



        private void CheckButtonStateLoop()
        {
            while (true)
            {
                Thread.Sleep(100);
                try
                {
                    _gp1.CheckStates();
                    _gp2.CheckStates();
                    _gp3.CheckStates();
                    _gp4.CheckStates();
                    _gp5.CheckStates();
                    _gp6.CheckStates();
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            ResetPage();
        }


        private void Gp_ButtonBPressed(object sender, EventArgs e)
        {
            int panelId = (sender as GlobalGamePadHandSet).LaneId - 1;
            _panels[panelId].NotReadyCommand();
        }

        private void Gp_ButtonAPressed(object sender, EventArgs e)
        {
            int panelId = (sender as GlobalGamePadHandSet).LaneId - 1;
            _panels[panelId].ReadyCommand();
        }

        private void Gp_Down(object sender, EventArgs e)
        {
            int panelId = (sender as GlobalGamePadHandSet).LaneId - 1;
            _panels[panelId].DownPanelCommand();
        }

        private void Gp_Up(object sender, EventArgs e)
        {
            int panelId = (sender as GlobalGamePadHandSet).LaneId - 1;
            _panels[panelId].UpPanelCommand();
        }

        private void Gp_Right(object sender, EventArgs e)
        {
            int panelId = (sender as GlobalGamePadHandSet).LaneId - 1;
            _panels[panelId].NextValueCommand();
        }

        private void Gp_Left(object sender, EventArgs e)
        {
            int panelId = (sender as GlobalGamePadHandSet).LaneId - 1;
            _panels[panelId].PreviousValueCommand();
        }
        #endregion GESTION DES GAMEPADS

    }
}
