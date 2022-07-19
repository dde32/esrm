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
    public partial class EndRacePage : BasePage
    {
        bool _isSecondaryView = false;

        TeamInRaceSortedList classement;

        public EndRacePage()
        {
            InitializeComponent();
        }

        public override void OnNavigatedTo(INavigationArgs args)
        {
            base.OnNavigatedTo(args);

            SetTeamsOnScreen();
        }

        protected override void btnMouseHover(object sender, EventArgs e)
        {
            base.btnMouseHover(sender, e);
        }

        protected override void btnMouseLeave(object sender, EventArgs e)
        {
            base.btnMouseLeave(sender, e);
        }




        public void InitSecondView(IESRMViewModel model)
        {
            _isSecondaryView = true; // la vue est une vue secondaire (affichage complémentaire), certaines fonctionnalités ne seront pas présentes
            btnEndurance.Visible = !_isSecondaryView;
            btnGP.Visible = !_isSecondaryView;
            btnRedo.Visible = !_isSecondaryView;
            btnStatsPilotes.Visible = !_isSecondaryView;

            this.BackgroundImage = global::ESRM.Win.Images.endracewp;
            appViewModel = model;
            SetTeamsOnScreen();

        }

        private void SetTeamsOnScreen()
        {
            if (AppViewModel.CurrentRace == null)
                return;

            raceGrid.BeginUpdate();
            ResizeGridRowHeight();
            classement = new TeamInRaceSortedList();
            classement.AddRange(AppViewModel.CurrentRace.Teams.Values);
            classement.SortByPosition();
            raceGrid.DataSource = classement;
            classicRaceView.RefreshData();
            raceGrid.EndUpdate();

            ResizeGridRowHeight();
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ResizeGridRowHeight();

        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            // on veut recommencer la session que l'on vient de faire : 
            // - naviguer sur la page de course en passant un paramètre pour relancer la même session.
            AppViewModel.CurrentRace.ResetRace(true, false);
            AppViewModel.ActivatePage("pageRace");

        }

        private void btnGP_Click(object sender, EventArgs e)
        {
            AppViewModel.InitRaceParameters(RaceType.GP);
            AppViewModel.ActivatePage("pageRaceParams");
        }

        private void btnEndurance_Click(object sender, EventArgs e)
        {
            AppViewModel.InitRaceParameters(RaceType.Endurance);
            AppViewModel.ActivatePage("pageRaceParams");

        }

        private void esrmButtonStatsPilotes_Click(object sender, EventArgs e)
        {
            List<PilotStatistics> stats = new List<PilotStatistics>();
            foreach (TeamInRace t in AppViewModel.CurrentRace.ClassedTeams)
            {
                foreach (KeyValuePair<Pilot, PilotStatistics> st in t.Statisitics.StatsByPilot)
                    stats.Add(st.Value);
            }

            StatsPilotsForm form = new StatsPilotsForm(stats, AppViewModel.CurrentRace.ClassedTeams, appViewModel.Records);
            form.ShowDialog();
        }

        #region  GRID VIEW

        private void classicRaceView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            TeamInRace team = (classicRaceView.GetRow(e.RowHandle) as TeamInRace);
            int teamId = team.Id;

            //FastestLap


            // affichage du nom de l'équipe et ID du handset
            if (e.RowHandle < classicRaceView.RowCount && 
                (e.Column == colPilote || e.Column == colLapCount || e.Column == colFuel || e.Column ==  colTires || e.Column ==  colPitStopCOunt 
                || e.Column == colTCCount || e.Column == colIncidents) )
            {

                e.Appearance.ForeColor = Color.FromArgb(team.Color);
            }
            else if ((e.Column == colBestLap) && e.RowHandle < classicRaceView.RowCount )
            {
                e.Appearance.ForeColor = Color.White;

                //if(team.Statisitics.FastestLap)
                //        e.Appearance. = Color.YellowGreen;
            }

        }


        public void ResizeGridRowHeight()
        {
            if (AppViewModel == null || AppViewModel.CurrentRace == null || AppViewModel.CurrentRace.ClassedTeams.Count == 0)
                return;

            if (classicRaceView != null) //&& classicRaceView.RowCount > 0)
            {
                classicRaceView.RowHeight = (this.Height - 80) / (6 * (AppViewModel.CurrentRace.ClassedTeams.Count >= 2 ? AppViewModel.CurrentRace.ClassedTeams.Count : 2));
                int maxRowHeight = (this.Height - 80) / (6 * (AppViewModel.CurrentRace.ClassedTeams.Count));
                if ((AppViewModel.CurrentRace.ClassedTeams.Count) < 6)
                    maxRowHeight = (this.Height - 80) / 24;

                float newSize = maxRowHeight / (float)1;
                Font newFont = Program.fontManager.GetCGFFont(newSize, FontStyle.Italic);
                if (AppViewModel.CurrentRace.RaceParams.PilotPerTeam > 1)
                {
                    newSize = (colPilote.RowCount * maxRowHeight) / (float)2.2;
                    newFont = Program.fontManager.GetCGFFont(newSize, FontStyle.Italic);
                    colPilote.AppearanceCell.Font = newFont;
                }
                else
                {
                    newSize = (colPilote.RowCount * maxRowHeight) / (float)2;
                    newFont = Program.fontManager.GetCGFFont(newSize, FontStyle.Italic);
                    colPilote.AppearanceCell.Font = newFont;
                }

                newSize = ((colLapCount.RowCount - 1) * maxRowHeight) / (float)1.6;
                newFont = Program.fontManager.GetCGFFont(newSize, FontStyle.Italic);
                colLapCount.AppearanceCell.Font = newFont;

                newSize = (maxRowHeight) / (float)1.8;
                //newFont = Program.fontManager.GetRadioStarFont(newSize, FontStyle.Italic);
                newFont = Program.fontManager.GetCGFFont(newSize, FontStyle.Italic);
                //newFont = Program.fontManager.GetEuroStyleFont(newSize, FontStyle.Bold | FontStyle.Italic);
                colFuel.AppearanceCell.Font = newFont;
                colTires.AppearanceCell.Font = newFont;
                colPitStopCOunt.AppearanceCell.Font = newFont;
                colTCCount.AppearanceCell.Font = newFont;
                colIncidents.AppearanceCell.Font = newFont;

                newSize = (2 * maxRowHeight) / (float)1.7;
                newFont = Program.fontManager.GetEuroStyleFont(newSize, FontStyle.Bold | FontStyle.Italic);
                //newFont = Program.fontManager.GetCGFFont(newSize, FontStyle.Bold | FontStyle.Italic);
                colAvgLap.AppearanceCell.Font = newFont;
                colBestLap.AppearanceCell.Font = newFont;
                colGap.AppearanceCell.Font = newFont;
            }

            raceGrid.DataSource = null;
            classicRaceView.RefreshData();
            raceGrid.DataSource = classement;
            classicRaceView.RefreshData();
        }


        #endregion GRID VIEW

    }
}
