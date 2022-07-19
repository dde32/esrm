using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using ESRM.Entities;
using ESRM.Win.Panels;
using ESRM.Win.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ESRM.Win
{
    public partial class RPTeamsPage : BasePage
    {
        SmallParamTeamPanel _currentTeamPanel;

        public RPTeamsPage()
        {
            InitializeComponent();
            paramTeamPanel1.Changed += paramTeamPanel1_Changed;
        }

        void paramTeamPanel1_Changed(object sender, EventArgs e)
        {
            _currentTeamPanel.Invalidate();
            
            _currentTeamPanel.Refresh();
        }


        public override void OnNavigatedTo(INavigationArgs args)
        {
            base.OnNavigatedTo(args);
            AppViewModel.CurrentRaceParameters.EnsureTeamsHavePilot();
            BindDatas();

            if (teamsPanel.Controls.Count > 0)
                SelectTeam(teamsPanel.Controls[teamsPanel.Controls.Count-1] as SmallParamTeamPanel);
        }

        public override void OnNavigatedFrom(INavigationArgs args)
        {
            paramTeamPanel1.ClearEvents();
            foreach (KeyValuePair<int, TeamInRace> entry in AppViewModel.CurrentRaceParameters.Teams)
            {
                int driverIdx = appViewModel.Pilots.FindIndex(d => d.Name == entry.Value.Pilot1.Name);
                if (driverIdx > -1)
                    appViewModel.Pilots[driverIdx] = entry.Value.Pilot1;

                if (entry.Value.Pilot2 != null)
                {
                    driverIdx = appViewModel.Pilots.FindIndex(d => d.Name == entry.Value.Pilot2.Name);
                    if (driverIdx > -1)
                        appViewModel.Pilots[driverIdx] = entry.Value.Pilot2;
                }
                if (entry.Value.Pilot3 != null)
                {
                    driverIdx = appViewModel.Pilots.FindIndex(d => d.Name == entry.Value.Pilot3.Name);
                    if (driverIdx > -1)
                        appViewModel.Pilots[driverIdx] = entry.Value.Pilot3;
                }
            }

            appViewModel.SavePilots();
            base.OnNavigatedFrom(args);
        }

        private void BindDatas()
        {
            foreach (SmallParamTeamPanel p in teamsPanel.Controls)
            {
                p.Deleted -= Panel_Deleted;
                p.IdChanged -= TeamIdChanged;
                p.PosChanged -= TeamPosChanged;
            }
            teamsPanel.Controls.Clear();

            foreach (KeyValuePair<int, TeamInRace> entry in AppViewModel.CurrentRaceParameters.Teams)
            {
                entry.Value.Id = entry.Key;
                AddPanelForTeam(entry.Value);

            }
     }



        void Panel_Deleted(object sender, EventArgs e)
        {
            teamsPanel.SuspendLayout();
            AppViewModel.CurrentRaceParameters.Teams.Remove((sender as SmallParamTeamPanel).Team.Id);
            teamsPanel.Controls.Remove(sender as Control);


            teamsPanel.ResumeLayout();
        }

        void TeamIdChanged(object sender, TeamIdChangedEventArgs e)
        {
            AppViewModel.CurrentRaceParameters.Teams.ChangeLaneId(e.OldLaneId,e.NewLaneId);
            BindDatas();

            //teamsPanel.SuspendLayout();

            //int idxPannel = teamsPanel.Controls.Count - 1;
            //foreach (KeyValuePair<int, TeamInRace> entry in AppViewModel.CurrentRaceParameters.Teams)
            //{
            //    (teamsPanel.Controls[idxPannel] as SmallParamTeamPanelMonoPilot).SetTeam(entry.Value, AppViewModel.CurrentRaceParameters.PilotPerTeam, AppViewModel);
            //    idxPannel--;
            //}
            //teamsPanel.ResumeLayout();

            //int idxPanelToSelect = teamsPanel.Controls.Count - e.NewLaneId;
            //SelectTeam(teamsPanel.Controls[idxPanelToSelect] as SmallParamTeamPanelMonoPilot);
        }

        void TeamPosChanged(object sender, TeamIdChangedEventArgs e)
        {

        }


        private void AddPanelForTeam(TeamInRace newTeam)
        {
            if ((Program.Licence.TeamLimit.HasValue && teamsPanel.Controls.Count < Program.Licence.TeamLimit.Value) || !Program.Licence.TeamLimit.HasValue)
            {
                //           teamsPanel.SuspendLayout();
                newTeam.Statisitics.InitialPosition = teamsPanel.Controls.Count+1;
                SmallParamTeamPanel p = new SmallParamTeamPanel();
                p.SetTeam(newTeam, AppViewModel.CurrentRaceParameters.PilotPerTeam, AppViewModel);
                teamsPanel.Controls.Add(p);
                p.Dock = DockStyle.Top;
                teamsPanel.Refresh();
                p.Deleted += Panel_Deleted;
                p.IdChanged += TeamIdChanged;
                p.PosChanged += TeamPosChanged;
                p.Selected += p_Selected;

                teamsPanel.Size = new Size(teamsPanel.Width, (p.Height * teamsPanel.Controls.Count) + 50);
            }
        }

        void p_Selected(object sender, EventArgs e)
        {
            SelectTeam(sender as SmallParamTeamPanel);
        }

        private void SelectTeam(SmallParamTeamPanel teamPanel)
        {
            paramTeamPanel1.ClearEvents();

            if (_currentTeamPanel != null)
                _currentTeamPanel.BorderStyle = BorderStyle.None;
            _currentTeamPanel = teamPanel;
            _currentTeamPanel.BorderStyle = BorderStyle.Fixed3D;
            
            paramTeamPanel1.SetTeam(_currentTeamPanel.Team, AppViewModel.CurrentRaceParameters.PilotPerTeam, AppViewModel);

        }

        protected override void ScaleCore(float dx, float dy)
        {
            base.ScaleCore(dx, dy);
        }

        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            if ((Program.Licence.TeamLimit.HasValue && teamsPanel.Controls.Count < Program.Licence.TeamLimit.Value) || !Program.Licence.TeamLimit.HasValue)
            {
                TeamInRace newTeam = DefaultDatas.GetDefaultTeamInRace(AppViewModel.CurrentRaceParameters.Teams.Count + 1, AppViewModel.CurrentRaceParameters.PilotPerTeam);
                if (newTeam.Id == 1)
                    newTeam.Color = Color.FromArgb(49, 133, 155).ToArgb(); // bleu
                else if (newTeam.Id == 2)
                    newTeam.Color = Color.FromArgb(118, 146, 60).ToArgb(); // vert
                else if (newTeam.Id == 3)
                    newTeam.Color = Color.FromArgb(149, 55, 52).ToArgb(); //rouge
                else if (newTeam.Id == 4)
                    newTeam.Color = Color.FromArgb(95, 75, 122).ToArgb(); // mauve
                else if (newTeam.Id == 5)
                    newTeam.Color = Color.FromArgb(255, 255, 255).ToArgb(); // blanc
                else if (newTeam.Id == 6)
                    newTeam.Color = Color.FromArgb(227, 108, 9).ToArgb(); // orange

                AppViewModel.CurrentRaceParameters.Teams.AddTeam(newTeam);
                AddPanelForTeam(newTeam);
            }
        }

        private void RPTeamsPage_SizeChanged(object sender, EventArgs e)
        {
           // ScaleContent();
        }

        private void btnSearchGamePads_Click(object sender, EventArgs e)
        {
            string message = Program.GetGamePadConnections();
            MessageBox.Show(message);
        }

        private void teamsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
