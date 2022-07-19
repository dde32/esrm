using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRM.Entities;

namespace ESRM.Win.Panels
{
    public partial class RacePanel : System.Windows.Forms.FlowLayoutPanel
    {
        TeamInRaceSortedList _teams;
        List<TeamPanel> _teampsPanels;

        public RacePanel()
        {
            InitializeComponent();
            _teampsPanels = new List<TeamPanel>();
        }


        public void SetTeams(List<TeamInRace> teams,int pilotPerTeam)
        {
            _teams = new TeamInRaceSortedList();
            _teams.AddRange(teams);

            _teampsPanels.Clear();
            foreach (Control ctrl in this.Controls)
                    ctrl.Dispose();

            this.Controls.Clear();

            foreach (TeamInRace t in _teams)
            {
                TeamPanel panel = new TeamPanel(pilotPerTeam);
                panel.SetTeam(t);
                this.Controls.Add(panel);
                _teampsPanels.Add(panel);
                ScaleContent();
            }
        }

        public void ScaleContent()
        {
            if (_teampsPanels.Count == 0)
                return;
            int nbCols = 0;
            if (_teams.Count > 9)
                nbCols = (int)_teams.Count / 2;
            else
                nbCols = (int)(_teams.Count / 2);
            if (nbCols < 2)
                nbCols = 2;

            int pWidth = (int)(this.Size.Width / nbCols) -5;
            int nbLines = (int)_teams.Count / nbCols;
            if (((double)_teams.Count / (double)nbCols) > nbLines)
                nbLines++;
            int pHeight = (int)(this.Size.Height / nbLines)-5;

            foreach(TeamPanel t in _teampsPanels)
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
            foreach (TeamPanel t in _teampsPanels)
            {
                t.RefreshForTrackCall();
            }
        }



        public void RefreshTeamImages(int teamId)
        {
            int idx = _teams.FindIndex(t => t.Id == teamId);
            if (_teampsPanels.Count > idx)
                _teampsPanels[idx].RefreshTeamImages();
        }

        public void RefreshTeamForPitStop(int teamId)
        {
            int idx = _teams.FindIndex(t => t.Id == teamId);
            if (_teampsPanels.Count > idx)
                _teampsPanels[idx].RefreshOnPitStop();
        }

        public void RefreshTeamForPitStopByPosition(int position)
        {
            if (_teampsPanels.Count > position - 1)
                _teampsPanels[position - 1].RefreshOnPitStop();
        }

        public void RefreshTeamForPitStopEndByPosition(int position)
        {
            if( _teampsPanels.Count > position - 1)
                 _teampsPanels[position - 1].RefreshOnPitStopEnd();
        }

        public void RefreshTeamsTimeAttackCountdown()
        {
            foreach (TeamPanel t in _teampsPanels)
            {
                t.RefreshTimeAttackCountdown();
            }
        }
        public void RefreshTeamsForTimeAttack()
        {
            foreach (TeamPanel t in _teampsPanels)
            {
                t.RefreshForTimeAttack();
            }
        }

        public void OrderPanels()
        {
            _teams.SortByPosition();

            for (int i = 0; i < _teams.Count; i++)
            {
                _teampsPanels[i].SetTeam(_teams[i]);
            }
        }

        public void Reset()
        {
            for (int i = 0; i < _teams.Count; i++)
            {
                _teampsPanels[i].ResetBorders();
            }
        }
    }
}
