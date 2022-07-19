using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRM.Entities;
using DevExpress.XtraEditors;
using ESRM.Win.Views;
using System.Collections.ObjectModel;

namespace ESRM.Win.Panels
{
    public partial class RaceColumnPanel : PanelControl
    {
        TeamInRaceSortedList _teams;
        List<TimeAttackTeamPanelColumn> _teampsPanels;

        public RaceColumnPanel()
        {
            InitializeComponent();
            this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            _teampsPanels = new List<TimeAttackTeamPanelColumn>();
        }


        public void SetTeams(List<TeamInRace> teams,RaceManager raceHelper)
        {
            _teams = new TeamInRaceSortedList();
            _teams.AddRange(teams);

            _teampsPanels.Clear();
            foreach (Control ctrl in this.Controls)
                    ctrl.Dispose();

            this.Controls.Clear();

            //           foreach (TeamInRace t in _teams)
            for (int i = _teams.Count - 1; i >= 0; i--)
                {
                TimeAttackTeamPanelColumn panel = new TimeAttackTeamPanelColumn(raceHelper);
                panel.SetTeam(_teams[i]);
                panel.Dock = DockStyle.Left;
                this.Controls.Add(panel);
                _teampsPanels.Add(panel);
            }
            ScaleContent();
        }

        public void ScaleContent()
        {
            if (_teampsPanels.Count == 0)
                return;

            int nbCols = _teampsPanels.Count > 4 ? _teampsPanels.Count : 4 ;
            int nbLines = 1;

            int pWidth = (int)(this.Size.Width / nbCols) ;
            int pHeight = (int)(this.Size.Height / nbLines) ;

            foreach (TimeAttackTeamPanelColumn t in _teampsPanels)
            {
                float fscalew = (float)((float)pWidth / (float)t.Size.Width);
                float fscaleh = (float)((float)pHeight / (float)t.Size.Height);

                t.Scale(new SizeF(fscalew, fscaleh));
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ScaleContent();
        }




        public void RefreshTeamsForTrackCall()
        {
            foreach (TimeAttackTeamPanelColumn t in _teampsPanels)
            {
                t.RefreshForTrackCall();
            }
        }



        public void RefreshTeamImages(int teamId)
        {
            int idx = _teampsPanels.FindIndex(t => t.Id == teamId);
            if (idx > -1 && _teampsPanels.Count > idx)
                _teampsPanels[idx].RefreshTeamImages();
        }

        public void RefreshTeam(int teamId)
        {
            int idx = _teampsPanels.FindIndex(t => t.Id == teamId);
            if (idx > -1 && _teampsPanels.Count > idx)
                _teampsPanels[idx].RefreshOnPitStop();
        }

        public void RefreshTeamForPitStopByPosition(int position)
        {
            int idx = _teampsPanels.FindIndex(t => t.Position == position);
            if (idx > -1 && _teampsPanels.Count > idx)
                _teampsPanels[idx].RefreshOnPitStop();
        }

        public void RefreshTeamForPitStopEndByPosition(int position)
        {
            int idx = _teampsPanels.FindIndex(t => t.Position == position);
            if (idx > -1 && _teampsPanels.Count > idx)
                _teampsPanels[idx].RefreshOnPitStopEnd();
        }

        public void RefreshTeamForEndOfRelay(int position)
        {
            int idx = _teampsPanels.FindIndex(t => t.Position == position);
            if (idx > -1 && _teampsPanels.Count > idx)
                _teampsPanels[idx].RefreshTeamForEndOfRelay();
        }     

        public void RefreshTeamsTimeAttackCountdown()
        {
            foreach (TimeAttackTeamPanelColumn t in _teampsPanels)
            {
                t.RefreshTimeAttackCountdown();
            }
        }
        public void RefreshTeamsForTimeAttack()
        {
            foreach (TimeAttackTeamPanelColumn t in _teampsPanels)
            {
                t.RefreshForTimeAttack();
            }
        }

        public void OrderPanels()
        {
            foreach (TimeAttackTeamPanelColumn t in _teampsPanels)
            {
                t.DeepRefresh();
            }
        }

        public void Reset()
        {
            if (_teams == null)
                return;

            for (int i = 0; i < _teams.Count; i++)
            {
                _teampsPanels[i].DeepRefresh();
            }
        }
    }
}
