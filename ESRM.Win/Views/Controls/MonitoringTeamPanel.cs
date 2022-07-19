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
using ESRM.GamePads;
using System.Threading;

namespace ESRM.Win.Panels
{
    public partial class MonitoringTeamPanel : ScalableControl
    {
        TeamInRace _team;
        RaceManager _raceManager;
        MessageDialog messageSelectGamePad = new MessageDialog(Textes.Mess_PressStartOnTeamGamePad);


        #region PROPERTIES

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

        public int Position { get { return _team != null ? _team.Statisitics.Position : 0; } }
        public int Id { get { return _team != null ? _team.Id : 0; } }

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

        public Color IsPacerForeColor
            {
            get {
                return  _team.IsPacer ? Color.Green : Color.Red;
            }
        }

        public string LapTarget
        {
            get
            {
                if (_team.IsPacer && _team.Pacer.LapTarget.TotalMilliseconds > 0)
                    return string.Format("{0}'{1}", _team.Pacer.LapTarget.Seconds.ToString("D2"), _team.Pacer.LapTarget.Milliseconds.ToString("D3"));
                else
                    return string.Empty;
            }
        }


        public Color UseGamePadColor
        {
            get { return _team != null && _team.UseGamePadPlayerIndex.HasValue ? Color.Green : Color.Red; }
        }
        public Color InCarProColor
        {
            get { return _team != null && _team.InCarPro ? Color.Green : Color.Red; }
        }

        public string UseGamePadPlayerIndex
        {
            get { return _team != null && _team.UseGamePadPlayerIndex.HasValue ? _team.UseGamePadPlayerIndex.Value.ToString() : Textes.No; }
        }

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
                _raceManager = null;
            }

            base.Dispose(disposing);
        }

        public MonitoringTeamPanel(RaceManager raceHelper)
        {
            InitializeComponent();

            _originalSize = Size;
            _raceManager = raceHelper;
            btnPacer.UseMouseHoverColor = false;
            btnPenality.UseMouseHoverColor = false;
            btnStopPenality.UseMouseHoverColor = false;
            btnShowMore_Click(null, null);
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
            lblCarMaxPower.Text = _team.Car.MaxPowerPercent.ToString();
        }

        #region METHODES DE REFRESH


        public void RefreshTeamInfos()
        {
        }

        #endregion

        #region BINDING



        protected override void DoBinding()
        {
            base.DoBinding();

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
            lblBrakeLimitation.DataBindings.Add("Text", _team.CurrentPilot, "BrakeLimitation");
            btnPacer.DataBindings.Add("ForeColor", this, "IsPacerForeColor");

            lblPacerLapTime.DataBindings.Add("Text", this, "LapTarget");
            chkBxDynamicBraking.DataBindings.Add("Checked", _team.CurrentPilot, "UseDynamicBrake");

            zoomTriggerVibrationLevel.DataBindings.Add("Value", _team.CurrentPilot, "VibrationTriggerLevel");
            zoomVibratoinLevel.DataBindings.Add("Value", _team.CurrentPilot, "VibrationLevel");

            if (_team.IsPacer)
                lblMaxP.DataBindings.Add("Text", _team, "PacerPower");
            else
                lblMaxP.DataBindings.Add("Text", _team.CurrentPilot, "MaxPowerPercent");

            btnUseGamePad.DataBindings.Add("ForeColor", this, "UseGamePadColor");
            btnUseGamePad.DataBindings.Add("SubText", this, "UseGamePadPlayerIndex");
            btnInCarPro.DataBindings.Add("ForeColor", this, "InCarProColor");
        }

        public override void DeepRefresh()
        {
            base.DeepRefresh();
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

            if (_team.Pacer != null)
                _team.Pacer.SetPacerPowerThrottle(63);

        }

        private void btnPowerMaxMoins_Click(object sender, EventArgs e)
        {
            if (_team.IsPacer &&  _team.Pacer.PacerPowerPercent > 0)
                _team.Pacer.PacerPowerPercent -= 1;
            else if (!_team.IsPacer && _team.CurrentPilot.MaxPowerPercent > 0)
                _team.CurrentPilot.MaxPowerPercent--;

                lblMaxP.DataBindings["Text"].ReadValue();
            if(_team.Pacer != null)
                 _team.Pacer.SetPacerPowerThrottle(63);
        }
        #endregion


        #region PAINTING ET SCALE

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
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


            foreach (Control ctrl in Controls)
                DeepScaleControl(ctrl, ratio, _lastRatio.Value, specified, factor);

            _lastRatio = ratio;
        }



        public void SuspendAllLayout()
        {
            this.panelTeamHeader.SuspendLayout();
            this.panelTeam.SuspendLayout();
            this.panelName.SuspendLayout();
            this.SuspendLayout();
        }

        public void ResumeAllLayout()
        {
            this.panelTeamHeader.ResumeLayout(false);
            this.panelTeam.ResumeLayout(false);
            this.panelName.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion


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
            {
                lblMaxP.DataBindings.Add("Text", _team, "PacerPower");
                _team.Pacer.LapTarget = new TimeSpan(0,0,10);
                _team.Pacer.PacerPowerPercent = 30;
            }
            else
                lblMaxP.DataBindings.Add("Text", _team.CurrentPilot, "MaxPowerPercent");

        }

        private void btnPenality_Click(object sender, EventArgs e)
        {
            _raceManager.ApplyPenality(_team.Id);           
        }

        private void btnStopPenality_Click(object sender, EventArgs e)
        {
            _raceManager.StopPenality(_team.Id);
        }

        private void btnSetId_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Textes.MessageConfirmProgCarId, "ESRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _raceManager.AffectID(this._team.Id);
            }
        }

        private void lblTeam_Click(object sender, EventArgs e)
        {
            {
                using (TextBoxDlg dlg = new TextBoxDlg(lblTeam.Text))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        _team.SetName(dlg.EditValue);
                        _team.Pilot1.Name = dlg.EditValue;
                        lblTeam.Text = dlg.EditValue;
                    }
                }
            }
        }

        private void btnPitStopStart_Click(object sender, EventArgs e)
        {
            //_team.PitIn();
            //_raceHelper.pi
            //_raceHelper.RaceRefresh(new LaneIdEventArgs(_team.Id));
            _raceManager.ForcePitStopToBegin(_team.Id);
        }

        private void btnPitStopSelect_Click(object sender, EventArgs e)
        {
            _team.PitStopNextAction();
            _raceManager.RaceRefresh(new LaneIdEventArgs(_team.Id));
        }

        private void btnPitStopValidate_Click(object sender, EventArgs e)
        {
            _team.PitStopValidateAction();
            _raceManager.RaceRefresh(new LaneIdEventArgs(_team.Id));
        }

        private void btnLapTimeMoins_Click(object sender, EventArgs e)
        {
            if(_team.IsPacer)
            {
                _team.Pacer.LapTarget = _team.Pacer.LapTarget.Subtract(new TimeSpan(0, 0, 0, 0, 250));
                lblPacerLapTime.DataBindings["Text"].ReadValue();
         }
        }

        private void btnLapTimePlus_Click(object sender, EventArgs e)
        {
            if (_team.IsPacer)
            {
                if (_team.Pacer.LapTarget.TotalSeconds < 3)
                    _team.Pacer.LapTarget += new TimeSpan(0, 0, 5);
                else
                    _team.Pacer.LapTarget =  _team.Pacer.LapTarget.Add(new TimeSpan(0, 0, 0, 0, 250));
                lblPacerLapTime.DataBindings["Text"].ReadValue();
            }
        }

        private void btnRAZTargetLapTime_Click(object sender, EventArgs e)
        {
            if (_team.IsPacer)
            {
                _team.Pacer.LapTarget += new TimeSpan(0, 0, 0);

                lblPacerLapTime.DataBindings["Text"].ReadValue();
            }

        }

        private void btnShowMore_Click(object sender, EventArgs e)
        {
            panelMore.Visible = !panelMore.Visible;
            if (panelMore.Visible)
            {
                btnShowMore.ForeColor = Color.Red;
                this.Size = new Size(this.Size.Width, 600);
            }
            else
            {
                this.Size = new Size(this.Size.Width, 350);
                btnShowMore.ForeColor = Color.YellowGreen;
            }
        }


        private void btnUseGamePad_Click(object sender, EventArgs e)
        {
           messageSelectGamePad = new MessageDialog(Textes.Mess_PressStartOnTeamGamePad);

            messageSelectGamePad.Show();
            messageSelectGamePad.FormClosed += MessageSelectGamePad_FormClosed;

            //if (MessageBox.Show(Textes.Mess_PressStartOnTeamGamePad, "ESRM", MessageBoxButtons.OKCancel) == DialogResult.OK)
            _raceManager.SendStartEventToRacePage = false;
            AffectGamePad();

        }

        private void MessageSelectGamePad_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (waitingForGpWorker != null && waitingForGpWorker.IsBusy)
                waitingForGpWorker.CancelAsync();

            CanGPEvents();
            messageSelectGamePad.FormClosed -= MessageSelectGamePad_FormClosed;
        }

        private void btnInCarPro_Click(object sender, EventArgs e)
        {
            _team.InCarPro = !_team.InCarPro;
            btnInCarPro.DataBindings["ForeColor"].ReadValue();
        }

        private void zoomVibratoinLevel_EditValueChanged(object sender, EventArgs e)
        {
            _team.CurrentPilot.VibrationLevel = zoomVibratoinLevel.Value;
            _raceManager.UpdateTeamGamePadSettings(_team.Id);
        }

        private void zoomTriggerVibrationLevel_EditValueChanged(object sender, EventArgs e)
        {
            _team.CurrentPilot.VibrationTriggerLevel = zoomTriggerVibrationLevel.Value;
            _raceManager.UpdateTeamGamePadSettings(_team.Id);
        }

        #region GESTION AFFECTATION GAMEPAD

        GlobalGamePadHandSet gp1;
        GlobalGamePadHandSet gp2;
        GlobalGamePadHandSet gp3;
        GlobalGamePadHandSet gp4;
        GlobalGamePadHandSet gp5;
        GlobalGamePadHandSet gp6;
        BackgroundWorker waitingForGpWorker;
        bool continuesearch = true;

        private void AffectGamePad()
        {
            continuesearch = true;
            Cursor.Current = Cursors.WaitCursor;

            if (waitingForGpWorker != null && waitingForGpWorker.IsBusy)
                waitingForGpWorker.CancelAsync();

            // instancier les gamepads
            waitingForGpWorker = new BackgroundWorker();
            waitingForGpWorker.WorkerSupportsCancellation = true;

            waitingForGpWorker.DoWork += Worker_DoWork;
            waitingForGpWorker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            waitingForGpWorker.RunWorkerAsync();

            // attendre un start event sur un GP
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CanGPEvents();
            messageSelectGamePad.Close();
        }

        private void CanGPEvents()
        {
            gp1.StartEvent -= Gp1_StartEvent;
            gp2.StartEvent -= Gp2_StartEvent;
            gp3.StartEvent -= Gp3_StartEvent;
            gp4.StartEvent -= Gp4_StartEvent;
            gp5.StartEvent -= Gp5_StartEvent;
            gp6.StartEvent -= Gp6_StartEvent;
            Cursor.Current = Cursors.Default;
            _raceManager.SendStartEventToRacePage = true;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckButtonStateLoop();
        }

        private void CheckButtonStateLoop()
        {
            gp1 = GamePadFactory.GetGamePad(EsrmPlayerIndex.One);
            gp2 = GamePadFactory.GetGamePad(EsrmPlayerIndex.Two);
            gp3 = GamePadFactory.GetGamePad(EsrmPlayerIndex.Three);
            gp4 = GamePadFactory.GetGamePad(EsrmPlayerIndex.Four);
            gp5 = GamePadFactory.GetGamePad(EsrmPlayerIndex.Five);
            gp6 = GamePadFactory.GetGamePad(EsrmPlayerIndex.Six);
            gp1.StartEvent += Gp1_StartEvent;
            gp2.StartEvent += Gp2_StartEvent;
            gp3.StartEvent += Gp3_StartEvent;
            gp4.StartEvent += Gp4_StartEvent;
            gp5.StartEvent += Gp5_StartEvent;
            gp6.StartEvent += Gp6_StartEvent;

            while (continuesearch)
            {
                Thread.Sleep(50);
                try
                {
                    gp1.CheckStates();
                    gp2.CheckStates();
                    gp3.CheckStates();
                    gp4.CheckStates();
                    gp5.CheckStates();
                    gp6.CheckStates();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void Gp6_StartEvent(object sender, EventArgs e)
        {
            waitingForGpWorker.CancelAsync();
            continuesearch = false;
            this._team.UseGamePadPlayerIndex = EsrmPlayerIndex.Six;
            gp6.HighSpeedVibrations();
            this.BeginInvoke(new StandardCallBack(RefreshGamePadInfos));
        }

        private void Gp5_StartEvent(object sender, EventArgs e)
        {
            waitingForGpWorker.CancelAsync();
            continuesearch = false;
            this._team.UseGamePadPlayerIndex = EsrmPlayerIndex.Five;
            gp5.HighSpeedVibrations();

            this.BeginInvoke(new StandardCallBack(RefreshGamePadInfos));
        }

        private void Gp4_StartEvent(object sender, EventArgs e)
        {
            waitingForGpWorker.CancelAsync();
            continuesearch = false;
            this._team.UseGamePadPlayerIndex = EsrmPlayerIndex.Four;
            gp4.HighSpeedVibrations();
            this.BeginInvoke(new StandardCallBack(RefreshGamePadInfos));
        }

        private void Gp3_StartEvent(object sender, EventArgs e)
        {
            waitingForGpWorker.CancelAsync();
            continuesearch = false;
            this._team.UseGamePadPlayerIndex = EsrmPlayerIndex.Three;
            gp3.HighSpeedVibrations();
            this.BeginInvoke(new StandardCallBack(RefreshGamePadInfos));
        }

        private void Gp2_StartEvent(object sender, EventArgs e)
        {
            waitingForGpWorker.CancelAsync();
            continuesearch = false;
            this._team.UseGamePadPlayerIndex = EsrmPlayerIndex.Two;
            gp2.HighSpeedVibrations();
            this.BeginInvoke(new StandardCallBack(RefreshGamePadInfos));
        }

        private void Gp1_StartEvent(object sender, EventArgs e)
        {
            waitingForGpWorker.CancelAsync();
            continuesearch = false;
            this._team.UseGamePadPlayerIndex = EsrmPlayerIndex.One;
            gp1.HighSpeedVibrations();
            this.BeginInvoke(new StandardCallBack(RefreshGamePadInfos));
        }

        private void RefreshGamePadInfos()
        {
            btnUseGamePad.DataBindings["ForeColor"].ReadValue();
            btnUseGamePad.DataBindings["SubText"].ReadValue();
            _raceManager.UpdateTeamGamePadSettings(_team.Id);
        }

        #endregion
    }
}
