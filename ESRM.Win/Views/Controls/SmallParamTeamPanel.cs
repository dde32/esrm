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
    public partial class SmallParamTeamPanel : ESRMControl //ScalableControl //ScalablePanel //ScalableControl
    {
        protected IESRMViewModel AppViewModel
        {
            get;
            set;
        }
       
        TeamInRace _team;
        int _pilotPerTeam;
        public event EventHandler Deleted;
        public event EventHandler Selected;
        public event TeamIdChangedEventHandler IdChanged;
        public event TeamIdChangedEventHandler PosChanged;

        #region PROPERTIES

        public TeamInRace Team
        {
            get { return _team; }
        }

        public string TeamName
        {
            get
            {
              return _team.Name;
            }
        }

        #region PILOT 1
        //public bool Pilot1Visible
        //{
        //    get { return _pilotPerTeam > 1; }
        //}

        public string PilotsNames
        {
            get
            {
                string result = _team.Pilot1.Name;
                if (_team.Pilot2 != null)
                    result += string.Format("; {0}", _team.Pilot2.Name);

                if (_team.Pilot3 != null)
                    result += string.Format("; {0}", _team.Pilot3.Name);

                return result;
            }
           // set { _team.Pilot1.Name = value; }
        }

        //public Image Pilot1_Image
        //{
        //    get 
        //    {
        //        if (_team.Pilot1.Image == null)
        //            return null;
        //        else
        //            return   ImageHelper.byteArrayToImage( _team.Pilot1.Image);
        //    }
        //    set { _team.Pilot1.Image = ImageHelper.ImageToByteArray(value); }
        //}

        #endregion

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

        #endregion


        public SmallParamTeamPanel()
        {
            InitializeComponent();
        }

        public void SetTeam(TeamInRace team,int pilotPerTeam,IESRMViewModel appModel)
        {
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
            if(_team.Statisitics != null)
               lblTeamPos.DataBindings.Add("Text", this, "TeamPosition");
            lblTeam.DataBindings.Add("Text", this, "TeamName");
            lblPilot1.DataBindings.Add("Text", this, "PilotsNames");
            panelTitle.DataBindings.Add("BackColor", this, "TeamColor");
        }

        #endregion


        private void lblTeam_Click(object sender, EventArgs e)
        {
            if (Selected != null)
                Selected(this, EventArgs.Empty);

        }

 
        private void btnUpId_Click(object sender, EventArgs e)
        {
            int oldId = _team.Id;

            _team.Id += 1;
            //if (_team.Id > AppViewModel.CurrentRaceParameters.Teams.Count)
            //    _team.Id = 1;
            lblTeamId.DataBindings["Text"].ReadValue();

            if (IdChanged != null)
                IdChanged(this, new TeamIdChangedEventArgs(oldId, _team.Id));

        }

        private void btnDownId_Click(object sender, EventArgs e)
        {
            int oldId = _team.Id;

            _team.Id -= 1;
            if (_team.Id < 1)
                _team.Id = 1;
            lblTeamId.DataBindings["Text"].ReadValue();

            if (IdChanged != null)
                IdChanged(this, new TeamIdChangedEventArgs(oldId, _team.Id));
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (Deleted != null)
                Deleted(this, EventArgs.Empty);
        }

        private void SmallParamTeamPanel_Click(object sender, EventArgs e)
        {
            if (Selected != null)
                Selected(this, EventArgs.Empty);

        }

        private void panelTeamParams_Click(object sender, EventArgs e)
        {
            if (Selected != null)
                Selected(this, EventArgs.Empty);

        }

        private void panelP1Name_Click(object sender, EventArgs e)
        {
            if (Selected != null)
                Selected(this, EventArgs.Empty);

        }

        private void panelP2Name_Click(object sender, EventArgs e)
        {
            if (Selected != null)
                Selected(this, EventArgs.Empty);

        }

        private void panelP3Name_Click(object sender, EventArgs e)
        {
            if (Selected != null)
                Selected(this, EventArgs.Empty);

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (Selected != null)
                Selected(this, EventArgs.Empty);

        }

        private void btnPosPlus_Click(object sender, EventArgs e)
        {

            int oldPos = _team.Statisitics.InitialPosition;

            _team.Statisitics.InitialPosition += 1;
            if (_team.Statisitics.InitialPosition > AppViewModel.CurrentRaceParameters.Teams.Count)
                _team.Statisitics.InitialPosition = 1;
            lblTeamPos.DataBindings["Text"].ReadValue();

            if (PosChanged != null)
                PosChanged(this, new TeamIdChangedEventArgs(oldPos, _team.Statisitics.InitialPosition));



        }

        private void btnPosMoins_Click(object sender, EventArgs e)
        {
            int oldPos = _team.Statisitics.InitialPosition;

            _team.Statisitics.InitialPosition -= 1;
            if (_team.Statisitics.InitialPosition < 1)
                _team.Statisitics.InitialPosition = 1;
            lblTeamPos.DataBindings["Text"].ReadValue();

            if (PosChanged != null)
                PosChanged(this, new TeamIdChangedEventArgs(oldPos, _team.Statisitics.InitialPosition));
        }
    }
}
