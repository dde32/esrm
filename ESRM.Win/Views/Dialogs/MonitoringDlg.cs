using ESRM.Entities;
using ESRM.Win.Panels;
using ESRM.Win.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;

namespace ESRM.Win
{
    public partial class MonitoringDlg : Form
    {
        RaceManager _raceManager;
        IESRMViewModel _appViewModel;


        public MonitoringDlg(RaceManager raceHelper, IESRMViewModel appViewModel)
        {
            InitializeComponent();

            _raceManager = raceHelper;
            //_raceHelper.Race.GreenFlagEvent += Race_GreenFlagEvent;
            //_raceHelper.Race.IncidentEvent += Race_IncidentEvent;
            //_raceHelper.Race.RaceFinished += Race_RaceFinished;
            //_raceHelper.Race.RaceStarted += Race_RaceStarted;
            //_raceHelper.Race.RaceUnPaused += Race_RaceUnPaused;
            //_raceHelper.Race.YellowFlagEvent += Race_YellowFlagEvent;
            //_raceHelper.Race.LapEndedEvent += Race_LapEndedEvent;

            _appViewModel = appViewModel;

            foreach (KeyValuePair<int, TeamInRace> entry in raceHelper.Race.Teams)
            {
                MonitoringTeamPanel pteam = new MonitoringTeamPanel(_raceManager);
                pteam.SetTeam(entry.Value);
                TeamsPanel.Controls.Add(pteam);

            }

        }



        private void Race_LapEndedEvent(object sender, EventArgs e)
        {
        }

        //private void Race_YellowFlagEvent(object sender, EventArgs e)
        //{
        //    pbFlag.EditValue = Images.YellowFlag;
        //}

        //private void Race_RaceUnPaused(object sender, EventArgs e)
        //{
        //    pbFlag.EditValue = Images.GreenFlag;
        //}

        //private void Race_RaceStarted(object sender, EventArgs e)
        //{
        //    pbFlag.EditValue = Images.GreenFlag;
        //}

        //private void Race_RaceFinished(object sender, EventArgs e)
        //{
        //    pbFlag.EditValue = Images.RedFlag;
        //}

        //private void Race_IncidentEvent(object sender, LaneIdEventArgs e)
        //{
        //}

        private void Race_GreenFlagEvent(object sender, EventArgs e)
        {
            pbFlag.EditValue = Images.GreenFlag;
        }



        private void btnStartPause_Click(object sender, EventArgs e)
        {
            if (_raceManager.Race.State == RaceState.Ended || _raceManager.Race.State == RaceState.NotStarted)
                _raceManager.StartTimer();
            else if (_raceManager.Race.State == RaceState.Paused)
                _raceManager.UnPauseHwi();
            else if (_raceManager.Race.State == RaceState.Started)
                _raceManager.PauseHwi();
        }

        private void btnSTOP_Click(object sender, EventArgs e)
        {
            _raceManager.StoptHwi();
        }

        private void btnYellowFlag_Click(object sender, EventArgs e)
        {
            _raceManager.ForceYellowFlag();
        }

        private void btnGreenFlag_Click(object sender, EventArgs e)
        {
            _raceManager.ForceGreenFlag();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReaffectGamePads_Click(object sender, EventArgs e)
        {
            _raceManager.ReaffectGamePadsToTeams();
        }
    }

 
}
