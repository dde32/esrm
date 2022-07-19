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
    public partial class TeamPanel : ScalableControl, IComparable
    {
        TeamInRace _team;

        #region PROPERTIES

        public bool ModeTimeAttack
        {
            get { return _team.Race is TimeAttackRace; }
        }

        public bool ModeNormal
        {
            get { return !ModeTimeAttack; }
        }

        public int PilotPerTeam
        {
            get;
            set;
        }



        public Color TimeAttackBonusColor
        {
            get
            {
                if (_team == null)
                    return Color.White;

                if (_team.TimeAttackBonusMalus.TotalMilliseconds > 0)
                    return Color.GreenYellow;
                else
                    return Color.Tomato;
            }
        }

        public Color LapCountForUIColor
        {
            get
            {
                if (_team.State == TeamState.Disqualified)
                    return Color.Red;
                else
                    return Color.LightSkyBlue;
            }
        }

        public Color BestLapColor 
        { 
            get 
            {
                if (_team == null)
                    return Color.Yellow;

                if (_team.Statisitics.FastestLap)
                    return Color.GreenYellow;
                else
                    return Color.Yellow;
            } 
        }

        public string BestLapForUI { get { return _team != null ? _team.BestLapForUI : string.Empty; } }
        public string TeamBestLapForUI { get { return _team != null  && _team.IsMultiPilot ? _team.TeamBestLapForUI : string.Empty; } }
        public string Gap { get { return _team != null ? _team.Statisitics.Gap : string.Empty; } }
        public string LapCountForUI { get { return _team != null ? _team.LapCountForUI : string.Empty; } }
        public string LastLapForUI { get { return _team != null ? _team.LastLapForUI : string.Empty; } }
        public int Position { get { return _team != null ?_team.Statisitics.Position : 0; } }
        public double CarHealthPercent { get { return _team != null ?_team.CarHealthPercent : 0; } }
        public double FuelPercent { get { return _team != null ? _team.FuelPercent : 0; } }
        public double TiresWearPercent { get { return _team != null ? _team.Car.Tires.Health : 0; } }
        public bool FastestLap { get { return _team != null ?_team.Statisitics.FastestLap : false; } }


        public Image StateImage
        {
            get
            {
                if (_team.State == TeamState.Finished)
                    return Images.TeamFinish;
                else if (_team.State == TeamState.PitIn)
                {
                    if (_team.FuelPercent < 100 || _team.CarHealthPercent < 100)
                        return Images.PitStop;
                    else
                        return Images.GreenFlag;
                }
                else if (_team.State == TeamState.RunningPenality)
                    return Images.YellowFlag;
                else if (_team.IncidentInThisLap.HasValue)
                        return Images.YellowFlag;
                else if (_team.OutOfHealth || _team.OutOfTires || _team.OutOfFuel)
                    return Images.Alert;
                else if (_team.LowFuel || _team.LowHealth || _team.LowTires)
                    return Images.Warning;
                else
                    return Images.empty;
            }
        }

        public string TeamAndPilotName
        {
            get 
            {
                if (_team == null)
                    return string.Empty;

                if (PilotPerTeam == 1)
                return string.Format("#{0} {1}",_team.Car.Number, _team.CurrentPilotName);
                else
                    return string.Format("#{0} {1}", _team.Car.Number, _team.NameAndPilot);
            }
        }

        public string PitStopInfos
        {
            get
            {
                if (_team.EndOfRelayPenality)
                    return Textes.EndOfRelayPenality;
                else if (_team.EndOfRelay)
                    return Textes.EndOfRelay;
                else
                      return _team != null ? string.Format("{0} Pitstop", _team.Statisitics.PitStopCount) : string.Empty;
            }

        }

        public Color TeamColor
        {
            get { return _team != null ? Color.FromArgb(_team.Color) : Color.Wheat; }
        }

        public int TeamPosition
        {
            get { return _team != null ? _team.Statisitics.Position : 1; }
        }

        public Image TeamImage
        {      
            get 
            {
                if (_team == null || _team.CurrentPilot.Image == null)
                    return Images.empty;
                else
                    return ImageHelper.byteArrayToImage(_team.CurrentPilot.Image);
            }
        }

        Color _lastBorderColor;
        public Color ContextBackColor
        {
            get 
            {
                if(_team == null)
                    return Color.FromArgb(150, 0, 0, 0);

                if (this._team.LowFuel || this._team.LowHealth || this._team.LowTires || this._team.State == TeamState.RunningPenality)
                    return Color.FromArgb(200, 245, 135, 32);
                else if (this._team.OutOfFuel || this._team.OutOfHealth || this._team.OutOfTires)
                    return Color.FromArgb(200, 255, 0, 0);
                else
                    return Color.FromArgb(150, 0, 0, 0);
            }
        }


        #endregion

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();

                _team = null;
            }

            base.Dispose(disposing);
        }

        public TeamPanel(int pilotPerTeam)
        {
            PilotPerTeam = pilotPerTeam;
            _lastBorderColor = Color.FromArgb(150, 0, 0, 0);

            InitializeComponent();
        }

        public void SetTeam(TeamInRace team)
        {
            this.SuspendLayout();
            //ResetBorders();
            _team = team;
            if (lblTeam.DataBindings.Count > 0)
            {
                DeepRefresh();
            }
            else
                DoBinding();
            this.ResumeLayout();
        }

        #region METHODES DE REFRESH

        public void RefreshTeamImages()
        {
            pbCarState.DataBindings["Image"].ReadValue();
        }

        public void RefreshOnPitStop()
        {
            lblNbPitStops.DataBindings["Text"].ReadValue();
            if (!(_team.Race is TimeAttackRace))
            {
                prgBarCar.DataBindings["EditValue"].ReadValue();
                prgBarFuel.DataBindings["EditValue"].ReadValue();
                prgBarTires.DataBindings["EditValue"].ReadValue();
            }
            pbCarState.DataBindings["Image"].ReadValue();
        }

        public void RefreshOnPitStopEnd()
        {
            lblMaxP.DataBindings["Text"].ReadValue();
            lblTeam.DataBindings["Text"].ReadValue();
            pbTeamImage.DataBindings["Image"].ReadValue();

            lblNbPitStops.DataBindings["Text"].ReadValue();
            pbCarState.DataBindings["Image"].ReadValue();
            ResetBorders();
        }


        public void RefreshTimeAttackCountdown()
        {
            lblTimeAttackCounter.DataBindings["Text"].ReadValue();
        }


        public void RefreshForTimeAttack()
        {
            lblTimeAttackBonusMalus.DataBindings["Text"].ReadValue();
            lblTimeAttackBonusMalus.DataBindings["Color"].ReadValue();
            lblTimeAttackCounter.DataBindings["Text"].ReadValue();
            lblTimeAttackLevel.DataBindings["Text"].ReadValue();
        }

        public void RefreshForTrackCall()
        {
            pbCarState.DataBindings["Image"].ReadValue();

            if (!(_team.Race is TimeAttackRace))
            {
                prgBarCar.DataBindings["EditValue"].ReadValue();
                prgBarFuel.DataBindings["EditValue"].ReadValue();
                prgBarTires.DataBindings["EditValue"].ReadValue();
            }
        }

        #endregion

        #region BINDING



        protected override void DoBinding()
        {
            base.DoBinding();


            lblTeam.DataBindings.Add("Text", this, "TeamAndPilotName");
            lblPosition.DataBindings.Add("ForeColor", this, "TeamColor");
            pbTeamImage.DataBindings.Add("Image", this, "TeamImage");
            lblNbPitStops.DataBindings.Add("Text", this, "PitStopInfos");
            pbCarState.DataBindings.Add("Image", this, "StateImage");
            lblBestLap.DataBindings.Add("Text", this, "BestLapForUI");
            lblTeamBestLap.DataBindings.Add("Text", this, "TeamBestLapForUI");

            if (this._team.IsMultiPilot)
                lblTeamBestLap.DataBindings.Add("ForeColor", this, "BestLapColor");
            else
                lblBestLap.DataBindings.Add("ForeColor", this, "BestLapColor");

            lblGap.DataBindings.Add("Text", this, "Gap");
            lblLaps.DataBindings.Add("Text", this, "LapCountForUI");
            lblLaps.DataBindings.Add("ForeColor", this, "LapCountForUIColor");
            
            lblLastLap.DataBindings.Add("Text", this, "LastLapForUI");
            lblPosition.DataBindings.Add("Text", this, "Position");
            panelTeamColor.DataBindings.Add("BackColor", this, "TeamColor");
            if (!(_team.Race is TimeAttackRace))
            {
                prgBarCar.DataBindings.Add("EditValue", this, "CarHealthPercent");
                prgBarFuel.DataBindings.Add("EditValue", this, "FuelPercent");
                prgBarTires.DataBindings.Add("EditValue", this, "TiresWearPercent");

            }
            // Time Attack
            lblTimeAttackBonusMalus.DataBindings.Add("Text", _team, "TimeAttackBonusMalusForUI");
            lblTimeAttackBonusMalus.DataBindings.Add("ForeColor", this , "TimeAttackBonusColor");
            lblTimeAttackCounter.DataBindings.Add("Text", _team, "TimeAttackTimeLeftForUI");
            lblTimeAttackLevel.DataBindings.Add("Text", _team, "TimeAttackLevel");
            lblTA_Target.DataBindings.Add("Text", _team, "TimeAttackLapTargetForUI");

            //btnPowerMaxPlus.DataBindings.Add("Visible", _team, "IsPacer");
            //btnPowerMaxMoins.DataBindings.Add("Visible", _team, "IsPacer");
            if(_team.IsPacer)
                lblMaxP.DataBindings.Add("Text", _team, "PacerPower");
            else
                lblMaxP.DataBindings.Add("Text", _team.CurrentPilot, "MaxPowerPercent");

            panelTimeAttack.Visible = ModeTimeAttack;
            panelParams.Visible = ModeNormal;
        }

        public override void DeepRefresh()
        {
            if (_lastBorderColor != ContextBackColor)
                Invalidate();

            base.DeepRefresh();
            lblMaxP.DataBindings.Clear();
            lblMaxP.DataBindings.Add("Text", _team.CurrentPilot, "MaxPowerPercent");
        }


        public void ResetBorders()
        {
            _lastBorderColor = Color.FromArgb(150, 0, 0, 0);
            Invalidate();
        }
        #endregion





        #region GESTION DU MAX POWER

        private void btnPowerMaxPlus_Click(object sender, EventArgs e)
        {
            if ( _team.IsPacer && _team.Pacer.PacerPowerPercent < 100)
                _team.Pacer.PacerPowerPercent += 1;
            else if (!_team.IsPacer && _team.CurrentPilot.MaxPowerPercent < 100)
                _team.CurrentPilot.MaxPowerPercent++;
            lblMaxP.DataBindings["Text"].ReadValue();
        }

        private void btnPowerMaxMoins_Click(object sender, EventArgs e)
        {
            if (_team.IsPacer &&  _team.Pacer.PacerPowerPercent >0)
                _team.Pacer.PacerPowerPercent -= 1;
            else if (!_team.IsPacer && _team.CurrentPilot.MaxPowerPercent > 0)
                _team.CurrentPilot.MaxPowerPercent--;

                lblMaxP.DataBindings["Text"].ReadValue();
        }
        #endregion


        #region PAINTING ET SCALE

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //          if (_lastBorderColor != ContextBackColor)
            {
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, ContextBackColor, 10, ButtonBorderStyle.Solid, ContextBackColor, 10, ButtonBorderStyle.Solid, ContextBackColor, 10, ButtonBorderStyle.Solid, ContextBackColor, 10, ButtonBorderStyle.Solid);
                _lastBorderColor = ContextBackColor;
            }
        }
        protected override void ScaleCore(float dx, float dy)
        {
            SuspendAllLayout();
            base.ScaleCore(dx, dy);
            ResumeAllLayout();
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            SuspendAllLayout();
            base.ScaleControl(factor, specified);
            ResumeAllLayout();
        }

        public void SuspendAllLayout()
        {
            this.panelTeamHeader.SuspendLayout();
            this.panelTeam.SuspendLayout();
            this.panelName.SuspendLayout();
            this.panelLapCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTeamImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgBarCar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgBarFuel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarState.Properties)).BeginInit();
            this.panelTimeAttack.SuspendLayout();
            this.panelTA_Level.SuspendLayout();
            this.panelTA_Time.SuspendLayout();
            this.panelParams.SuspendLayout();
            this.SuspendLayout();
        }

        public void ResumeAllLayout()
        {
            this.panelTeamHeader.ResumeLayout(false);
            this.panelTeam.ResumeLayout(false);
            this.panelName.ResumeLayout(false);
            this.panelLapCount.ResumeLayout(false);
            this.panelLapCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTeamImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgBarCar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgBarFuel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarState.Properties)).EndInit();
            this.panelTimeAttack.ResumeLayout(false);
            this.panelTA_Level.ResumeLayout(false);
            this.panelTA_Time.ResumeLayout(false);
            this.panelParams.ResumeLayout(false);
            this.panelParams.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion



        public int CompareTo(object y)
        {
            if (y is TeamPanel)
            {
                return _team.CompareTo((y as TeamPanel)._team);
            }
            else
                return 0;
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
