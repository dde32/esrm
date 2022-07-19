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
    public partial class EndRace_PilotPanel : ScalableControl
    {

        #region PROPERTIES

        #endregion


        public EndRace_PilotPanel()
        {
            InitializeComponent();
        }

        public EndRace_PilotPanel(TeamInRace team)
        {
            //InitializeComponent();
            //lblPosition.BackColor = Color.FromArgb(100, Color.FromArgb(team.Color).R, Color.FromArgb(team.Color).G, Color.FromArgb(team.Color).B);
            //lblPosition.Text = team.Statisitics.Position.ToString();
            //lblBestLap.Text = team.BestLapForUI;
            //lblPitStops.Text = team.Statisitics.PitStopCount + "Pitstop";
            //lblTeam.Text = team.NameAndPilot;
            //if(team.Statisitics.FastestLap)
            //    lblBestLap.ForeColor = Color.YellowGreen;
            //if (team.Statisitics.Position == 1)
            //    lblTotalTime.Text = team.Race.RaceDuration.ToString(@"hh\:mm\:ss");
            //else
            //    lblTotalTime.Text = team.Statisitics.Gap;

            //lblAverage.Text = team.AverageLapForUI;
            //if (team.TimeAttackLevel > 0)
            //    lblTimeAttackResult.Text = string.Format("level : {0} {1} laps", team.TimeAttackLevel, team.LapCount);
            //else
            //    lblTimeAttackResult.Text = string.Empty;

            //lblIncidents.Text = string.Format("{0} {1}", team.Statisitics.IncidentCount, Textes.Incident);
            //lblTrackCall.Text = string.Format("{0} {1}", team.Statisitics.TrackCallCount, Textes.TrackCall);

        }



        #region BINDING

        protected virtual void ClearBindings()
        {
            foreach (Control ctrl in Controls)
            {
                ctrl.DataBindings.Clear();
                if (ctrl is Panel)
                {
                    foreach (Control ctrlChilds in ctrl.Controls)
                        ctrlChilds.DataBindings.Clear();

                }
            }
        }

        protected virtual void RefreshPanel()
        {
            foreach (Control ctrl in Controls)
            {
                foreach (Binding db in this.DataBindings)
                    db.ReadValue();

                if (ctrl is Panel)
                {
                    foreach (Binding db2 in ctrl.DataBindings)
                        db2.ReadValue();
                }
            }
        }

        protected override void DoBinding()
        {
            base.DoBinding();
 
        }

        #endregion





        #region MISE A L ECHELLE

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
        }

        #endregion


    }
}
