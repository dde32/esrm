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

namespace ESRM.Win.Views
{
    public partial class TimeAttackRaceParamsPage : BasePage
    {
        public string LapTarget
        {
            get
            {
               string result =  string.Format("{0}:{1}", AppViewModel.CurrentRaceParameters.TimeAttackLapTarget.Seconds.ToString("D2"), AppViewModel.CurrentRaceParameters.TimeAttackLapTarget.Milliseconds.ToString("D3"));
               return result;
            }
            set
            {
                string[] results = value.Split(':');
                AppViewModel.CurrentRaceParameters.TimeAttackLapTarget = new TimeSpan(0,0,0,Convert.ToInt32(results[0]),Convert.ToInt32(results[1]));

            }
        }

        public string StartBonus
        {
            get
            {
                string result = string.Format("{0}:{1}", AppViewModel.CurrentRaceParameters.TimeAttackStartBonus.Seconds.ToString("D2"), AppViewModel.CurrentRaceParameters.TimeAttackStartBonus.Milliseconds.ToString("D3"));
                return result;
            }
            set
            {
                string[] results = value.Split(':');
                AppViewModel.CurrentRaceParameters.TimeAttackStartBonus = new TimeSpan(0, 0, 0, Convert.ToInt32(results[0]), Convert.ToInt32(results[1]));

            }
        }

        

        public TimeAttackRaceParamsPage()
        {
            InitializeComponent();
        }

        public override void OnNavigatedTo(INavigationArgs args)
        {
            base.OnNavigatedTo(args);
            //if (AppViewModel.CurrentRace == null)
            //    AppViewModel.CurrentRace = DefaultDatas.GetDefaultRaceFromParameters(AppViewModel.CurrentRaceParameters);
            BindDatas();
        }

        private void BindDatas()
        {
            foreach (Control c in panelPrincipal.Controls)
                c.DataBindings.Clear();

            edtLapTarget.DataBindings.Add("Text", this, "LapTarget");
            edtBonus.DataBindings.Add("Text", this, "StartBonus");
            
            btnPilotPerTeams.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "PilotPerTeam");
            btnTeams.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "TeamsCount");
            btnTrack.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "TrackName");
        }

        private void btnTrackSelect_Click(object sender, EventArgs e)
        {
            
            AppViewModel.ActivatePage("pageTracks");
        }

        private void btnTeams_Click(object sender, EventArgs e)
        {
            AppViewModel.ActivatePage("RPTeamsPage");
        }

        private void btnGoRacing_Click(object sender, EventArgs e)
        {
            AppViewModel.CreateRaceFromParameters();
            // on applique les restrictions de la licence
            if (Program.Licence.LapCountLimit.HasValue)
                AppViewModel.CurrentRaceParameters.LapCount = Program.Licence.LapCountLimit;
            if (Program.Licence.TeamLimit.HasValue)
                AppViewModel.CurrentRaceParameters.MaxTeamsCount = Program.Licence.TeamLimit.Value;
            if (Program.Licence.TeamLimit.HasValue)
                AppViewModel.CurrentRaceParameters.TimeLimit = Program.Licence.TimeLimit;
            if (Program.Licence.TimeAttackLevelLimit.HasValue)
                AppViewModel.CurrentRaceParameters.TimeAttackLevelLimit = Program.Licence.TimeAttackLevelLimit;


            AppViewModel.ActivatePage("pageRace");
        }

        private void btnTargetMoins_Click(object sender, EventArgs e)
        {
            AppViewModel.CurrentRaceParameters.TimeAttackLapTarget = AppViewModel.CurrentRaceParameters.TimeAttackLapTarget.Subtract(new TimeSpan(0, 0, 0, 0, 10));
            edtLapTarget.DataBindings["Text"].ReadValue();
        }        

        private void btnTargetPlus_Click(object sender, EventArgs e)
        {
            AppViewModel.CurrentRaceParameters.TimeAttackLapTarget = AppViewModel.CurrentRaceParameters.TimeAttackLapTarget.Add(new TimeSpan(0, 0, 0, 0, 10));
            edtLapTarget.DataBindings["Text"].ReadValue();
        }

        private void btnPilotPerTeams_Click(object sender, EventArgs e)
        {
            //if (AppViewModel != null)
            //{
            //    AppViewModel.CurrentRaceParameters.PilotPerTeam = AppViewModel.CurrentRaceParameters.PilotPerTeam + 1;
            //    if (AppViewModel.CurrentRaceParameters.PilotPerTeam > 3)
            //        AppViewModel.CurrentRaceParameters.PilotPerTeam = 1;

            //    btnPilotPerTeams.DataBindings["SubText"].ReadValue();
            //}
        }

        private void btnBonusMoins_Click(object sender, EventArgs e)
        {
            AppViewModel.CurrentRaceParameters.TimeAttackStartBonus = AppViewModel.CurrentRaceParameters.TimeAttackStartBonus.Subtract(new TimeSpan(0, 0, 0, 0, 500));
            edtBonus.DataBindings["Text"].ReadValue();

        }

        private void btnBonusPlus_Click(object sender, EventArgs e)
        {
            AppViewModel.CurrentRaceParameters.TimeAttackStartBonus = AppViewModel.CurrentRaceParameters.TimeAttackStartBonus.Add(new TimeSpan(0, 0, 0, 0, 500));
            edtBonus.DataBindings["Text"].ReadValue();

        }
    }
}
