using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRM.Entities;
using ESRM.Win.Views;
using System.Threading;

namespace ESRM.Win.Panels
{
    public partial class MonitoringTeamPanel1 : ESRMControl //ScalableControl //ScalablePanel //ScalableControl
    {
        protected IESRMViewModel AppViewModel
        {
            get;
            set;
        }
       
        TeamInRace _team;
        int _pilotPerTeam;

        #region PROPERTIES

        public TeamInRace Team
        {
            get { return _team; }
        }

        public string TeamName
        {
            get
            {
                if (_pilotPerTeam == 1)
                    return _team.CurrentPilotName;
                else
                    return _team.Name;
            }
        }

        public Color TeamColor
        {
            get { return _team != null ? Color.FromArgb(_team.Color) : Color.Orange; }
        }

        public int TeamPosition
        {
            get { return _team != null ? _team.Statisitics.InitialPosition : 1; }
        }

        public string IsPacer
        {
            get { return _team.IsPacer ? Textes.Yes : Textes.No; }
        }

        public bool ShowBrakeLimitation 
        {
            get { return !_team.IsPacer; }
        }

        public Color PacerOnOrOffColor
        {
            get { return _team.IsPacer ? Color.Green : Color.Red; }
        }
        

        #endregion


        public MonitoringTeamPanel1(TeamInRace team, int pilotPerTeam, IESRMViewModel appModel)
        {
            InitializeComponent();
            _pilotPerTeam = pilotPerTeam;
            _team = team;
            DoBinding();
            AppViewModel = appModel;
        }
    
        
        private TeamState GetTeamState()
        {
            return _team.State;
        }

        public override void Refresh()
        {
            base.Refresh();
            DoBinding();
        }
        
        #region BINDING

        protected override void DoBinding()
        {
            if (lblTeamId.DataBindings.Count > 0)
            {
                foreach (Control c in Controls)
                    c.DataBindings.Clear();
            }

            base.DoBinding();

            lblTeamId.DataBindings.Add("Text", _team, "Id");
            lblTeamPos.DataBindings.Add("Text", _team.Statisitics, "InitialPosition");
            lblTeam.DataBindings.Add("Text", this, "TeamName");
            edtPacerVMax.DataBindings.Add("EditValue", _team, "PacerPower");
            edtVMax.DataBindings.Add("EditValue", _team.CurrentPilot, "MaxPowerPercent");
            edtBrake.DataBindings.Add("EditValue", _team.CurrentPilot, "BrakeLimitation");
            lblPacerOnOrOff.DataBindings.Add("Text", this, "IsPacer");
            lblPacerOnOrOff.DataBindings.Add("ForeColor", this, "PacerOnOrOffColor");

            panelTitle.DataBindings.Add("BackColor", this, "TeamColor");
         }

        #endregion


        private void edtVMax_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void edtBrake_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void edtPacerVMax_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lblPacerOnOrOff_Click(object sender, EventArgs e)
        {

        }

        private void btnApplyPenality_Click(object sender, EventArgs e)
        {

        }

        private void btnStopPenality_Click(object sender, EventArgs e)
        {

        }
    }
}
