using ESRM.Entities;
using ESRM.HWInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ESRM.Win.Views
{
    public partial class DlgPacerLapInfos : Form
    {
        public List<HandSetThrotthleInfo> _thInfos_Original;
        public List<HandSetThrotthleInfo> _thInfos_Updated;
        public List<HandSetThrotthleInfo> _thInfos_FirstLap;

        RaceManager raceHelper;
        RaceParameters parameters;
        PracticeRace race;
        bool _testingPacer = false;

        TeamInRace _team;
        DigitalParamsBase _dgParams;

        public DlgPacerLapInfos(TeamInRace team, DigitalParamsBase dgParams )
        {
            _team = team;
            _dgParams = dgParams;

            InitializeComponent();

            _thInfos_Original = new List<HandSetThrotthleInfo>();
            _thInfos_Updated = new List<HandSetThrotthleInfo>();
            _thInfos_FirstLap = new List<HandSetThrotthleInfo>();
            _thInfos_Original.AddRange(team.Pacer.LapThrotlesInfos_Initial);

            lblCountInfos.Text = string.Format("{0} valeurs", _thInfos_Original.Count);
            gridControlOriginalsInfos.DataSource = _thInfos_Original;
            gridControlUpdatedInfos.DataSource = _thInfos_Updated;
            gridControlFistLapInfos.DataSource = _thInfos_FirstLap;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if(raceHelper != null)
            {
                raceHelper.Dispose();
                raceHelper = null;
            }

            base.Dispose(disposing);
        }

        private void btnExportXLS_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                gridControlOriginalsInfos.ExportToXlsx(d.FileName);
                ProcessStartInfo p = new ProcessStartInfo(d.FileName);
                Process.Start(p);
            }
        }

        private void btnClearBegin_Click(object sender, EventArgs e)
        {
            _thInfos_Updated.Clear();
            _thInfos_Updated.AddRange(_thInfos_Original);

            Pacer.ClearBeginOfLap(_thInfos_Updated,Convert.ToInt32(edtMinValue.Text));
            gridControlUpdatedInfos.DataSource = _thInfos_Updated;
            gridControlUpdatedInfos.Refresh();
        }

        private void btnClearEnd_Click(object sender, EventArgs e)
        {
            Pacer.ClearEndOfLap(_thInfos_Updated,Convert.ToInt32(edtMinValue.Text));
            gridControlUpdatedInfos.DataSource = _thInfos_Updated;
            gridControlUpdatedInfos.Refresh();
        }

        private void btnStartMaxLast_Click(object sender, EventArgs e)
        {
            edtStartPower.Text = Pacer.CalculStartPowerFromLastMaxTh(_thInfos_Original, Convert.ToInt32(edtLastCountTh.Text)).ToString();
        }

        private void btnStartAvgLast_Click(object sender, EventArgs e)
        {
           edtStartPower.Text = Pacer.CalculStartPowerFromLastAverageTh(_thInfos_Original, Convert.ToInt32(edtLastCountTh.Text)).ToString();

        }

        private void btnGenerateFirstLapInfos_Click(object sender, EventArgs e)
        {
            if (_thInfos_Updated.Count == 0)
                _thInfos_Updated.AddRange(_thInfos_Original);

            _thInfos_FirstLap = Pacer.TestLissageLapThrottleInfos(_thInfos_Updated,_team.Pacer.StartPower.Value);
            gridControlFistLapInfos.DataSource = _thInfos_FirstLap;
            gridControlFistLapInfos.RefreshDataSource();
        }

        private void ValidateInfosForPacer()
        {
            _team.Pacer.IsRecordingLapThrothlesInfo = false;
            if (_thInfos_Updated.Count == 0)
                _thInfos_Updated.AddRange(_thInfos_Original);

            // si la start Power n'est pas encore calculée, on force le calcul
            if(string.IsNullOrEmpty(edtStartPower.Text))
                edtStartPower.Text = Pacer.CalculStartPowerFromLastMaxTh(_thInfos_Original, Convert.ToInt32(edtLastCountTh.Text)).ToString();

            try
            {
                int startPower = Convert.ToInt32(edtStartPower.Text);
                if (startPower > 0)
                    _team.Pacer.StartPower = startPower;

                _team.Pacer.LapThrotlesInfos_Initial = _thInfos_Updated;

                if (_thInfos_FirstLap.Count > 0)
                    _team.Pacer.LapThrotlesInfos_FirstLap = _thInfos_FirstLap;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        #region TEST DU PACER
        private void btnTestPacer_Click(object sender, EventArgs e)
        {
            if (!_testingPacer)
            {
                ValidateInfosForPacer();
                InitTestRace();
                btnTestPacer.Text = "Stop Test";
            }
            else
            {
                btnTestPacer.Text = "Test Pacer";
                raceHelper.StoptHwi();
            }
            _testingPacer = !_testingPacer;
        }



        private void InitTestRace()
        {
            DisposeTestRace();

            _team.PassedFirstTime = false;
            _team.Reset(false,false, 63);

            _team.Pacer.LapThrotlesInfosCurrentIdx = 0;

            if (Program.hwInterface is SSDInterface)
            {
                if (raceHelper == null)
                {
                    raceHelper = RaceManager.Instance;
                    parameters = DefaultDatas.GetDefaultRaceParameters(RaceType.Practice, null, _dgParams);
                    race = new PracticeRace(parameters);
                    race.Teams.Clear();
                    _team.Race = race;
                    for (int i = 0; i < 6; i++)
                    {
                        if (i + 1 == _team.Id)
                            race.Teams.AddTeam(_team);
                        else
                            race.Teams.AddTeam(DefaultDatas.GetDefaultTeamInRace(i + 1, 1));
                    }
                    raceHelper.InitHelper(Program.hwInterface, Program.pitSensors, Program._startLight, Program._carIdProgrammer, null, null, _dgParams,null, race,null,true);
                   }
                //else
                //    raceHelper.Race.ResetRace(false, false);

                raceHelper.StartTimer();
            }
        }

        private void DisposeTestRace()
        {
            if (raceHelper != null)
            {
                raceHelper.StoptHwi();
                raceHelper.Dispose();
                raceHelper = null;
            }
        }

        private void btnTestYF_Click(object sender, EventArgs e)
        {
            int boostPower = Convert.ToInt32(edtStartPower.Text);
            int ThCountBeforeBoost= Convert.ToInt32(edtLastCountTh.Text);
            _team.Pacer.TestBoostPacer(boostPower, ThCountBeforeBoost);

            raceHelper.ForceYellowFlag();
        }

        private void btnTestGF_Click(object sender, EventArgs e)
        {
            raceHelper.ForceGreenFlag();
        }

        #endregion TEST DU PACER


        private void btnOK_Click(object sender, EventArgs e)
        {
            ValidateInfosForPacer();
            DisposeTestRace();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DisposeTestRace();
            base.OnClosing(e);
        }


    }
}
