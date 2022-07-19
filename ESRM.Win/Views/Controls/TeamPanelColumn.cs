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

namespace ESRM.Win.Panels
{
    public partial class TeamPanelColumn : ScalableControl, IComparable
    {
        TeamInRace _team;
        RaceManager _raceHelper;
        bool _showMonitoringInfos;

        public bool ShowMonitoringInfos
        {
            get { return _showMonitoringInfos; }
            set {
                _showMonitoringInfos = value ;
                panelControlParametresPilotes.DataBindings["Visible"].ReadValue();
            }
        }


        #region PROPERTIES


        public bool ModeTimeAttack
        {
            get { return _team.ModeTimeAttack; }
        }

        public bool ModeNormal
        {
            get { return !ModeTimeAttack; }
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
                    return Color.White;
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
        public int Position { get { return _team != null ? _team.Statisitics.Position : 0; } }
        public int Id { get { return _team != null ? _team.Id : 0; } }
        public double CarHealthPercent { get { return _team != null ?_team.CarHealthPercent : 0; } }
        public double FuelPercent { get { return _team != null ? _team.FuelPercent : 0; } }
        public double TiresWearPercent { get { return _team != null ? _team.Car.Tires.Health : 0; } }
        public bool FastestLap { get { return _team != null ?_team.Statisitics.FastestLap : false; } }

        public bool ShowCar { get { return _team != null ? _team.Race.RaceParams.ShowCars : false; } }
        public bool ShowPilot { get { return _team != null ? _team.Race.RaceParams.ShowPilots : false; } }
        public bool ShowFuel { get { return _team != null ? _team.Race.RaceParams.FuelImpact : false; } }
        public bool ShowTires { get { return _team != null ? _team.Race.RaceParams.TiresImpact != TiresImpactEnum.None : false; } }
        public bool ShowHealth { get { return _team != null ? _team.Race.RaceParams.Damages != DamagesEnum.None : false; } }
        public bool ShowStatePanel { get { return ShowHealth || ShowFuel || ShowTires; } }

        public Image StateImage
        {
            get
            {
                // Priorité a la fin de course
                if (_team.State == TeamState.Finished)
                    return Images.TeamFinish;
                // si la course est en cours, priorité ensuite a ce qu'il se passe en cas d'arret au stands
                else if (_team.State == TeamState.PitIn)
                {
                    if (_team.FuelPercent < 100 || _team.CarHealthPercent < 100)
                        return Images.PitStop;
                    else
                        return Images.GreenFlag;
                }
                // si on a une pénalité (limite la puissance pendant un tour) on affiche un drapeaux
                else if (_team.State == TeamState.RunningPenality)
                    return Images.YellowFlag;
                else if (_team.EndOfRelay)
                    return Images.EndOfRelay;
                // si on a été victime d'un incident pendant le tour on affiche le picto correspondant
                else if (_team.IncidentInThisLap.HasValue)
                {
                    switch (_team.IncidentInThisLap.Value)
                    {
                        case DamageTypeEnum.Brake:
                            return Images.BrakeIncident;
                        case DamageTypeEnum.Engine:
                            return Images.EngineIncident;
                        case DamageTypeEnum.Suspension:
                            return Images.SuspensionIncident;
                        case DamageTypeEnum.Tires:
                            return Images.TiresIncident;
                        default:
                            return Images.empty;
                    }
                }
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

                if (_team.Car.Number > 0)
                {
                    if (!_team.IsMultiPilot)
                        return string.Format("#{0} {1}", _team.Car.Number, _team.CurrentPilotName);
                    else
                        return string.Format("#{0} {1}", _team.Car.Number, _team.NameAndPilot);
                }
                else
                {
                    if (!_team.IsMultiPilot)
                        return _team.CurrentPilotName;
                    else
                        return _team.NameAndPilot;

                }
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
            get { return _team != null ? Color.FromArgb(_team.Color) : Color.White; }
        }
        public Color ForeTeamColor
        {
            get { return _team != null  ? GetForegroundColor(_team.Color) : Color.White ; }
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

        public Image CarImage
        {
            get
            {
                if (_team == null || _team.Car.Image == null)
                    return Images.empty;
                else
                    return ImageHelper.byteArrayToImage(_team.Car.Image);
            }
        }

        public Color IsPacerForeColor
            {
            get {
                return  _team.IsPacer ? Color.Green : Color.Red;
            }
        }
        //Color _lastBorderColor;
        //public Color ContextBackColor
        //{
        //    get 
        //    {
        //        if(_team == null)
        //            return Color.FromArgb(150, 0, 0, 0);

        //        if (this._team.LowFuel || this._team.LowHealth || this._team.LowTires || this._team.State == TeamState.RunningPenality)
        //            return Color.FromArgb(200, 245, 135, 32);
        //        else if (this._team.OutOfFuel || this._team.OutOfHealth || this._team.OutOfTires)
        //            return Color.FromArgb(200, 255, 0, 0);
        //        else
        //            return Color.FromArgb(150, 0, 0, 0);
        //    }
        //}


        #endregion

        #region TOOLS
        Color ContrastColor(Color color)
        {
            int d = 0;

            // Counting the perceptive luminance - human eye favors green color... 
            double a = 1 - (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;

            if (a < 0.5)
                d = 0; // bright colors - black font
            else
                d = 255; // dark colors - white font

            return Color.FromArgb(d, d, d);
        }

        public static string GetForegroundColor(string colorCode)
    {
      var c = System.Drawing.ColorTranslator.FromHtml(colorCode);
       return Brightness(c) < 130 ? "#FFFFFF" : "#000000";
    }

        public static Color GetForegroundColor(int colorCode)
        {
            var c = Color.FromArgb(colorCode);
            return Brightness(c) < 130 ? Color.White : Color.Black;
        }

        private static int Brightness(Color c)
    {
      return (int)Math.Sqrt(
         c.R* c.R * .241 +
         c.G* c.G* .691 +
         c.B* c.B* .068);
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
                _raceHelper = null;
            }

            base.Dispose(disposing);
        }

        public TeamPanelColumn()
        {
            InitializeComponent();
        }

        public TeamPanelColumn(RaceManager raceHelper)
        {
            InitializeComponent();

            _originalSize = Size;
            _raceHelper = raceHelper;
            btnPacer.UseMouseHoverColor = false;
            btnPenality.UseMouseHoverColor = false;
            btnStopPenality.UseMouseHoverColor = false;
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
            pbCarState.DataBindings["EditValue"].ReadValue();
        }

        public void RefreshOnPitStop()
        {
            Invalidate();
            lblNbPitStops.DataBindings["Text"].ReadValue();
            if (!(_team.Race is TimeAttackRace))
            {
                prgBarCar.DataBindings["EditValue"].ReadValue();
                prgBarFuel.DataBindings["EditValue"].ReadValue();
                prgBarTires.DataBindings["EditValue"].ReadValue();
            }
            pbCarState.DataBindings["EditValue"].ReadValue();
            DeepRefresh();
        }

        public void RefreshOnPitStopEnd()
        {
            lblMaxP.DataBindings["Text"].ReadValue();
            lblTeam.DataBindings["Text"].ReadValue();
            pbTeamImage.DataBindings["EditValue"].ReadValue();

            lblNbPitStops.DataBindings["Text"].ReadValue();
            pbCarState.DataBindings["EditValue"].ReadValue();
            ResetBorders();
        }

        
        public void RefreshTeamForEndOfRelay()
        {
            // ICI IL FAUT AFFICHER UNE INFO POUR PREVENIR DE LA FIN DU RELAIS
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
            pbCarState.DataBindings["EditValue"].ReadValue();

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

            panelControlParametresPilotes.DataBindings.Add("Visible", this, "ShowMonitoringInfos");

            if (_team.Race.RaceParams.ApplyColorOnAllTeamPanel)
            {
                panelTeamHeader.DataBindings.Add("BackColor", this, "TeamColor");
                panelTeamColor.DataBindings.Add("BackColor", this, "TeamColor");
                lblTeam.DataBindings.Add("ForeColor", this, "ForeTeamColor");
                lblLaneId.DataBindings.Add("ForeColor", this, "ForeTeamColor");
            }
            else
            {
                panelTeamColor.DataBindings.Add("BackColor", this, "TeamColor");
                lblTeam.DataBindings.Add("ForeColor", this, "TeamColor");
                lblLaneId.DataBindings.Add("ForeColor", this, "TeamColor");
            }

            lblTeam.DataBindings.Add("Text", this, "TeamAndPilotName");
            lblLaneId.DataBindings.Add("Text", this, "Id");
            pbTeamImage.DataBindings.Add("EditValue", this, "TeamImage");
            pictureEditCar.DataBindings.Add("EditValue", this, "CarImage");
            lblNbPitStops.DataBindings.Add("Text", this, "PitStopInfos");
            pbCarState.DataBindings.Add("EditValue", this, "StateImage");
            lblBestLap.DataBindings.Add("Text", this, "BestLapForUI");
            lblTeamBestLap.DataBindings.Add("Text", this, "TeamBestLapForUI");
            lblBrakeLimitation.DataBindings.Add("Text", _team.CurrentPilot, "BrakeLimitation");

            labelHealth.DataBindings.Add("Visible", this, "ShowHealth");
            labelFuel.DataBindings.Add("Visible", this, "ShowFuel");
            labelTires.DataBindings.Add("Visible", this, "ShowTires");
            prgBarCar.DataBindings.Add("Visible", this, "ShowHealth");
            prgBarFuel.DataBindings.Add("Visible", this, "ShowFuel");
            prgBarTires.DataBindings.Add("Visible", this, "ShowTires");

            panelCar.DataBindings.Add("Visible", this, "ShowCar");
            panelControl_PilotImage.DataBindings.Add("Visible", this, "ShowPilot");
            panelStateBars.DataBindings.Add("Visible", this, "ShowStatePanel");

            btnPacer.DataBindings.Add("ForeColor", this, "IsPacerForeColor");

            if (this._team.IsMultiPilot)
                lblTeamBestLap.DataBindings.Add("ForeColor", this, "BestLapColor");
            else
                lblBestLap.DataBindings.Add("ForeColor", this, "BestLapColor");

            lblGap.DataBindings.Add("Text", this, "Gap");
            lblLaps.DataBindings.Add("Text", this, "LapCountForUI");
            lblLaps.DataBindings.Add("ForeColor", this, "LapCountForUIColor");
            
            lblLastLap.DataBindings.Add("Text", this, "LastLapForUI");
            lblPosition.DataBindings.Add("Text", this, "Position");
            if (!(_team.Race is TimeAttackRace))
            {
                prgBarCar.DataBindings.Add("EditValue", this, "CarHealthPercent");
                prgBarFuel.DataBindings.Add("EditValue", this, "FuelPercent");
                prgBarTires.DataBindings.Add("EditValue", this, "TiresWearPercent");

            }

            panelTimeAttack.Visible = ModeTimeAttack;
            panelStateBars.Visible = ModeNormal && ShowStatePanel;

            // Time Attack
            lblTimeAttackBonusMalus.DataBindings.Add("Text", _team, "TimeAttackBonusMalusForUI");
            lblTimeAttackBonusMalus.DataBindings.Add("ForeColor", this , "TimeAttackBonusColor");
            lblTimeAttackCounter.DataBindings.Add("Text", _team, "TimeAttackTimeLeftForUI");
            lblTimeAttackLevel.DataBindings.Add("Text", _team, "TimeAttackLevel");
            lblTA_Target.DataBindings.Add("Text", _team, "TimeAttackLapTargetForUI");

            if(_team.IsPacer)
                lblMaxP.DataBindings.Add("Text", _team, "PacerPower");
            else
                lblMaxP.DataBindings.Add("Text", _team.CurrentPilot, "MaxPowerPercent");

        }

        public override void DeepRefresh()
        {
            pbCarState.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            base.DeepRefresh();
            //lblMaxP.DataBindings.Clear();
            //lblMaxP.DataBindings.Add("Text", _team.CurrentPilot, "MaxPowerPercent");
            pbCarState.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
        }


        public void ResetBorders()
        {
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
            if (_team.IsPacer &&  _team.Pacer.PacerPowerPercent > 0)
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
            ////          if (_lastBorderColor != ContextBackColor)
            //{
            //    ControlPaint.DrawBorder(e.Graphics, ClientRectangle, ContextBackColor, 10, ButtonBorderStyle.Solid, ContextBackColor, 10, ButtonBorderStyle.Solid, ContextBackColor, 10, ButtonBorderStyle.Solid, ContextBackColor, 10, ButtonBorderStyle.Solid);
            //    _lastBorderColor = ContextBackColor;
            //}
        }
        protected override void ScaleCore(float dx, float dy)
        {
            base.ScaleCore(dx, dy);
        }

        Size _originalSize;
        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            if (float.IsInfinity(factor.Height) || float.IsInfinity(factor.Width))
                return;

            //this.SuspendLayout();

            base.ScaleControl(factor, specified);

            if (!_lastRatio.HasValue || _lastRatio.Value == 0)
                _lastRatio = 1;

            // float ratio = factor.Height > factor.Width ? factor.Height : factor.Width;
            float ratio = Math.Max(factor.Width, factor.Height * 0.9f);

            if (factor.Height > 1.8 * factor.Width || factor.Width > 1.8 * factor.Height)
                ratio = ratio * (float)0.7;


            //panelTeamHeader.Size = new Size((int)(panelTeamHeader.Size.Width * factor.Width), (int)(panelTeamHeader.Size.Height * factor.Height));
            //panelControl_Position.Size = new Size((int)(panelControl_Position.Size.Width * factor.Width), (int)(panelControl_Position.Size.Height * factor.Height));
            //panelControl_LapsInfos.Size = new Size((int)(panelControl_LapsInfos.Size.Width * factor.Width), (int)(panelControl_LapsInfos.Size.Height * factor.Height));
            //panelControlMaxPower.Size = new Size((int)(panelControlMaxPower.Size.Width * factor.Width), (int)(panelControlMaxPower.Size.Height * factor.Height));
            //panelControl_PilotImage.Size = new Size((int)(panelControl_PilotImage.Size.Width * factor.Width), (int)(panelControl_PilotImage.Size.Height * factor.Height));


            //foreach (Control ctrl in panelTeamHeader.Controls)
            //    DeepScaleControl(ctrl, ratio, _lastRatio.Value, specified, factor);
            //foreach (Control ctrl in panelControl_Position.Controls)
            //    DeepScaleControl(ctrl, ratio, _lastRatio.Value, specified, factor);
            //foreach (Control ctrl in panelControl_LapsInfos.Controls)
            //    DeepScaleControl(ctrl, ratio, _lastRatio.Value, specified, factor);
            //foreach (Control ctrl in panelControlMaxPower.Controls)
            //    DeepScaleControl(ctrl, ratio, _lastRatio.Value, specified, factor);
            //foreach (Control ctrl in panelControl_PilotImage.Controls)
            //    DeepScaleControl(ctrl, ratio, _lastRatio.Value, specified, factor);


            foreach (Control ctrl in Controls)
                DeepScaleControl(ctrl, ratio, _lastRatio.Value, specified, factor);

            _lastRatio = ratio;

            //this.ResumeLayout();




        }

        protected override void OnSizeChanged(EventArgs e)
        {
            //if (_originalSize.Height > 0 && _originalSize.Width > 0 && !_scaling)
            //{
            //    SizeF factor = new SizeF(Size.Width / _originalSize.Width, (float)((float)Size.Height / (float)_originalSize.Height));
            //    ScaleControl(factor, BoundsSpecified.All);
            //}

            base.OnSizeChanged(e);
        }

        public void SuspendAllLayout()
        {
            this.panelTeamHeader.SuspendLayout();
            this.panelTeam.SuspendLayout();
            this.panelName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTeamImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgBarCar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgBarFuel.Properties)).BeginInit();
            this.panelTimeAttack.SuspendLayout();
            this.panelTA_Level.SuspendLayout();
            this.panelTA_Time.SuspendLayout();
            this.panelStateBars.SuspendLayout();
            this.SuspendLayout();
        }

        public void ResumeAllLayout()
        {
            this.panelTeamHeader.ResumeLayout(false);
            this.panelTeam.ResumeLayout(false);
            this.panelName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTeamImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgBarCar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgBarFuel.Properties)).EndInit();
            this.panelTimeAttack.ResumeLayout(false);
            this.panelTA_Level.ResumeLayout(false);
            this.panelTA_Time.ResumeLayout(false);
            this.panelStateBars.ResumeLayout(false);
            this.panelStateBars.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion



        public int CompareTo(object y)
        {
            if (y is TeamPanel)
            {
                return _team.CompareTo((y as TeamPanelColumn)._team);
            }
            else
                return 0;
        }

        private void btnDownBrake_Click(object sender, EventArgs e)
        {
            _team.CurrentPilot.BrakeLimitation--;
            if (_team.CurrentPilot.BrakeLimitation < 0) 
            _team.CurrentPilot.BrakeLimitation = 0;
            lblBrakeLimitation.DataBindings["Text"].ReadValue();

        }

        private void btnUpBrake_Click(object sender, EventArgs e)
        {
            _team.CurrentPilot.BrakeLimitation++;
            if (_team.CurrentPilot.BrakeLimitation > 6) 
            _team.CurrentPilot.BrakeLimitation = 6;
            lblBrakeLimitation.DataBindings["Text"].ReadValue();
        }

        private void btnPacer_Click(object sender, EventArgs e)
        {
            _team.IsPacer = !this._team.IsPacer;
            btnPacer.DataBindings["ForeColor"].ReadValue();
            lblMaxP.DataBindings.Clear();
            if (_team.IsPacer)
                lblMaxP.DataBindings.Add("Text", _team, "PacerPower");
            else
                lblMaxP.DataBindings.Add("Text", _team.CurrentPilot, "MaxPowerPercent");

        }

        private void btnPenality_Click(object sender, EventArgs e)
        {
            _raceHelper.ApplyPenality(_team.Id);           
        }

        private void btnStopPenality_Click(object sender, EventArgs e)
        {
            _raceHelper.StopPenality(_team.Id);
        }
    }
}
