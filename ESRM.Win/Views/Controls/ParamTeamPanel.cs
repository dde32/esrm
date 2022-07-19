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
using System.Diagnostics;
using ESRM.HWInterfaces;
using ESRM.GamePads;

namespace ESRM.Win.Panels
{
    public delegate void TeamIdChangedEventHandler(Object sender, TeamIdChangedEventArgs e);

    public partial class ParamTeamPanel : ESRMControl  //ScalablePanel  ESRMControl //ScalablePanel //ScalableControl
    {
        protected IESRMViewModel AppViewModel
        {
            get;
            set;
        }
        
        TeamInRace _team;
        int _pilotPerTeam;
        public event EventHandler Deleted;
        public event EventHandler Changed;
        MessageDialog messageSelectGamePad = new MessageDialog(Textes.Mess_PressStartOnTeamGamePad);

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

        #region PILOT 1
        public bool Pilot1Visible
        {
            get { return _pilotPerTeam > 1; }
        }

        public string Pilot1_Name
        {
            get { return _team.Pilot1.Name; }
            set { _team.Pilot1.Name = value; }
        }

        public Image Pilot1_Image
        {
            get 
            {
                if (_team.Pilot1.Image == null)
                    return null;
                else
                    return   ImageHelper.byteArrayToImage( _team.Pilot1.Image);
            }
            set { _team.Pilot1.Image = ImageHelper.ImageToByteArray(value); }
        }

        public string Pilot1_CurveTitle
        {
            get
            {
                if (_team.Pilot1 != null)
                {
                    if (_team.UseGamePadPlayerIndex.HasValue)
                    {
                        string thCurveTitle = _team.Pilot1.GamePadThrottleCurve != null ? _team.Pilot1.GamePadThrottleCurve.Title : Textes.Default;
                        string brakeCurveTitle = _team.Pilot1.GamePadBrakeCurve != null ? _team.Pilot1.GamePadBrakeCurve.Title : Textes.Default;
                        string incarProBrakeCurveTitle = _team.Pilot1.GamePadInCarProBrakeCurve != null ? _team.Pilot1.GamePadInCarProBrakeCurve.Title : Textes.Default;
                        return string.Format("{0}/{1}", thCurveTitle, _team.InCarPro ? incarProBrakeCurveTitle : brakeCurveTitle);
                    }
                    else
                        return _team.Pilot1.HandsetThrottleCurve != null ? _team.Pilot1.HandsetThrottleCurve.Title : Textes.Default;
                }
                else
                    return string.Empty;
            }
        }
        #endregion

        #region PILOT 2
        public bool Pilot2Visible
        {
            get { return _pilotPerTeam >= 2; }
        }

        public string Pilot2_Name
        {
            get { return  _team.Pilot2 != null ? _team.Pilot2.Name : string.Empty; }
            set { _team.Pilot2.Name = value; }
        }

        public Image Pilot2_Image
        {
            get
            {
                if (_team.Pilot2 == null || _team.Pilot2.Image == null)
                    return null;
                else
                    return ImageHelper.byteArrayToImage(_team.Pilot2.Image);
            }
            set { _team.Pilot2.Image = ImageHelper.ImageToByteArray(value); }
        }


        public string Pilot2_CurveTitle
        {
            get
            {
                if (_team.Pilot2 != null)
                {
                    if (_team.UseGamePadPlayerIndex.HasValue)
                    {
                        string thCurveTitle = _team.Pilot2.GamePadThrottleCurve != null ? _team.Pilot2.GamePadThrottleCurve.Title : Textes.Default;
                        string brakeCurveTitle = _team.Pilot2.GamePadBrakeCurve != null ? _team.Pilot2.GamePadBrakeCurve.Title : Textes.Default;
                        string incarProBrakeCurveTitle = _team.Pilot2.GamePadInCarProBrakeCurve != null ? _team.Pilot2.GamePadInCarProBrakeCurve.Title : Textes.Default;
                        return string.Format("{0}/{1}", thCurveTitle, _team.InCarPro ? incarProBrakeCurveTitle : brakeCurveTitle);
                    }
                    else
                        return _team.Pilot2.HandsetThrottleCurve != null ? _team.Pilot2.HandsetThrottleCurve.Title : Textes.Default;
                }
                else
                    return string.Empty;
            }
        }


        #endregion

        #region PILOT3

        public bool Pilot3Visible
        {
            get { return _pilotPerTeam == 3; }
        }

        public string Pilot3_Name
        {
            get { return _team.Pilot3 != null ? _team.Pilot3.Name : string.Empty; }
            set { _team.Pilot3.Name = value; }
        }

        public Image Pilot3_Image
        {
            get
            {
                if (_team.Pilot3 == null || _team.Pilot3.Image == null)
                    return null;
                else
                    return ImageHelper.byteArrayToImage(_team.Pilot3.Image);
            }
            set { _team.Pilot3.Image = ImageHelper.ImageToByteArray(value); }
        }


        public string Pilot3_CurveTitle
        {
            get
            {
                if (_team.Pilot3 != null)
                {
                    if (_team.UseGamePadPlayerIndex.HasValue)
                    {
                        string thCurveTitle = _team.Pilot3.GamePadThrottleCurve != null ? _team.Pilot3.GamePadThrottleCurve.Title : Textes.Default;
                        string brakeCurveTitle = _team.Pilot3.GamePadBrakeCurve != null ? _team.Pilot3.GamePadBrakeCurve.Title : Textes.Default;
                        string incarProBrakeCurveTitle = _team.Pilot3.GamePadInCarProBrakeCurve != null ? _team.Pilot3.GamePadInCarProBrakeCurve.Title : Textes.Default;
                        return string.Format("{0}/{1}", thCurveTitle, _team.InCarPro ? incarProBrakeCurveTitle : brakeCurveTitle);
                    }
                    else
                        return _team.Pilot3.HandsetThrottleCurve != null ? _team.Pilot3.HandsetThrottleCurve.Title : Textes.Default;
                }
                else
                    return string.Empty;
            }
        }
        #endregion




        public bool ShowCurveBtn
        {
            get { return _team != null && _team.UseGamePadPlayerIndex.HasValue ? true :false; }
        }

        public Color TeamColor
        {
            get { return _team != null ? Color.FromArgb(_team.Color) : Color.Orange; }
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

        public int TeamPosition
        {
            get { return _team != null ? _team.Statisitics.Position : 1; }
        }

        public string IsPacer
        {
            get { return _team.IsPacer ? Textes.Yes : Textes.No; }
        }

        public bool ShowBrakeLimitation 
        {
            get { return !_team.IsPacer && !_team.UseGamePadPlayerIndex.HasValue; }
        }

        #endregion


        public ParamTeamPanel()
        {
            InitializeComponent();

            btnUseGamePad.UseMouseHoverColor = false;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            panelTitle.SuspendLayout();
            panelTitle.BackColor = this.TeamColor;
            panelP1Name.BackColor = this.TeamColor;
            panelP2Name.BackColor = this.TeamColor;
            panelP3Name.BackColor = this.TeamColor;
            panelTitle.ResumeLayout();
            btnPacerPower.Invalidate();
            btnPacerPower.PerformAutoScale();
            btnPacerPower.PerformLayout();

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
       
        #region BINDING

        protected override void DoBinding()
        {
           // if (lblPosition.DataBindings.Count > 0)
           // {
           //     foreach (Control c in Controls)
           //         c.clear.Clear();
           // }

           //{

            base.DoBinding();


            lblPosition.DataBindings.Add("Text", _team, "Id");
            lblTeam.DataBindings.Add("Text", this, "TeamName");
            pbCar.DataBindings.Add("EditValue", _team.Car, "Image");
            lblCar.DataBindings.Add("Text", _team.Car, "DescriptionForUI");
            btnInCarPro.DataBindings.Add("ForeColor", this, "InCarProColor");

            // lblPilot1.DataBindings.Add("Visible", this, "Pilot1Visible");
            lblPilot1.DataBindings.Add("Text", this, "Pilot1_Name");
            pbPilot1.DataBindings.Add("EditValue", this, "Pilot1_Image");

            lblPilot2.DataBindings.Add("Visible", this, "Pilot2Visible");
            panelP2.DataBindings.Add("Visible", this, "Pilot2Visible");
            lblPilot2.DataBindings.Add("Text", this, "Pilot2_Name");
            pbPilot2.DataBindings.Add("EditValue", this, "Pilot2_Image");

            lblPilot3.DataBindings.Add("Visible", this, "Pilot3Visible");
            lblPilot3.DataBindings.Add("Text", this, "Pilot3_Name");
            pbPilot3.DataBindings.Add("EditValue", this, "Pilot3_Image");
            panelP3.DataBindings.Add("Visible", this, "Pilot3Visible");

            panelTitle.DataBindings.Add("BackColor", this, "TeamColor");
            panelP1Name.DataBindings.Add("BackColor", this, "TeamColor");
            panelP2Name.DataBindings.Add("BackColor", this, "TeamColor");
            panelP3Name.DataBindings.Add("BackColor", this, "TeamColor");

            if (!Pilot2Visible && !Pilot3Visible)
                    pbPilot1.Dock = DockStyle.Fill;
                else
                    pbPilot1.Dock = DockStyle.None;

            btnPacer.DataBindings.Add("SubText", this, "IsPacer");
            btnPacerPower.DataBindings.Add("Visible", _team, "IsPacer");
            btnPacerPower.DataBindings.Add("SubText", _team, "PacerPower");
            btnRecordPacerLap.DataBindings.Add("Visible", _team, "IsPacer");
            btnViewPacerLap.DataBindings.Add("Visible", _team, "IsPacer");

            //btnP1TriggerCurves.DataBindings.Add("Visible", this, "ShowCurveBtn");
            btnP1TriggerCurves.DataBindings.Add("SubText", this, "Pilot1_CurveTitle");

            chkBxDynBrakeP1.DataBindings.Add("Enabled", this, "ShowBrakeLimitation");

            btnMaxPowerP1.DataBindings.Add("SubText", _team.Pilot1, "MaxPowerPercent");
            btnFuelHandicapP1.DataBindings.Add("SubText", _team.Pilot1, "FuelHandicapForUI");
            btnDamagesHandicapP1.DataBindings.Add("SubText", _team.Pilot1, "DamagesHandicapForUI");
            btnBrakeParamP1.DataBindings.Add("SubText", _team.Pilot1, "BrakeLimitation");
            btnBrakeParamP1.DataBindings.Add("Enabled", this, "ShowBrakeLimitation");
            chkBxDynBrakeP1.DataBindings.Add("Checked", _team.Pilot1, "UseDynamicBrake");
            btnUseGamePad.DataBindings.Add("ForeColor", this, "UseGamePadColor");
            btnUseGamePad.DataBindings.Add("SubText", this, "UseGamePadPlayerIndex");

             if (Pilot2Visible)
            {
                btnP2TriggerCurves.DataBindings.Add("SubText", this, "Pilot2_CurveTitle");
                chkBxDynBrakeP2.DataBindings.Add("Enabled", this, "ShowBrakeLimitation");
                //btnP2TriggerCurves.DataBindings.Add("Visible", this, "ShowCurveBtn");
                btnMaxPowerP2.DataBindings.Add("SubText", _team.Pilot2, "MaxPowerPercent");
                btnFuelHandicapP2.DataBindings.Add("SubText", _team.Pilot2, "FuelHandicapForUI");
                btnDamagesHandicapP2.DataBindings.Add("SubText", _team.Pilot2, "DamagesHandicapForUI");
                btnBrakeParamP2.DataBindings.Add("SubText", _team.Pilot2, "BrakeLimitation");
                btnBrakeParamP2.DataBindings.Add("Enabled", this, "ShowBrakeLimitation");
                chkBxDynBrakeP2.DataBindings.Add("Checked", _team.Pilot2, "UseDynamicBrake");
            }
            if (Pilot3Visible)
            {
                btnP3TriggerCurves.DataBindings.Add("SubText", this, "Pilot3_CurveTitle");
                //btnP3TriggerCurves.DataBindings.Add("Visible", this, "ShowCurveBtn");
                chkBxDynBrakeP3.DataBindings.Add("Enabled", this, "ShowBrakeLimitation");
                btnMaxPowerP3.DataBindings.Add("SubText", _team.Pilot3, "MaxPowerPercent");
                btnFuelHandicapP3.DataBindings.Add("SubText", _team.Pilot3, "FuelHandicapForUI");
                btnDamagesHandicapP3.DataBindings.Add("SubText", _team.Pilot3, "DamagesHandicapForUI");
                btnBrakeParamP3.DataBindings.Add("SubText", _team.Pilot3, "BrakeLimitation");
                btnBrakeParamP3.DataBindings.Add("Enabled", this, "ShowBrakeLimitation");
                chkBxDynBrakeP3.DataBindings.Add("Checked", _team.Pilot3, "UseDynamicBrake");
            }
            //btnSelectPilot1.DataBindings.Add("Visible", this, "Pilot2Visible");
            //btnSelectPilot2.DataBindings.Add("Visible", this, "Pilot1Visible");
            //btnSelectPilot3.DataBindings.Add("Visible", this, "Pilot3Visible");
        }

        #endregion

        private void OnChanged()
        {
            DoBinding();

            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }

        private void lblTeam_Click(object sender, EventArgs e)
        {
            // si l'équipe a au moins deux pilotes, on donne un nom a la team, sinon c'est directement la sélection du pilote
            //if (Pilot2Visible)
            {
                using (TextBoxDlg dlg = new TextBoxDlg(lblTeam.Text))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        if (Pilot2Visible)
                            _team.SetName(dlg.EditValue);
                        else
                            _team.Pilot1.Name = dlg.EditValue;
                        lblTeam.Text = dlg.EditValue;
                        OnChanged();
                    }
                }
            }
            //else
            //    SelectPilot1();

        }

        private void lblPilot1_Click(object sender, EventArgs e)
        {
           SelectPilot1();
        }

        private void lblPilot2_Click(object sender, EventArgs e)
        {
            SelectPilot2();

        }

        private void lblPilot3_Click(object sender, EventArgs e)
        {
            SelectPilot3();

        }

        private void pbPilot1_Click(object sender, EventArgs e)
        {
            SelectPilot1();
        }

        private void pbPilot2_Click(object sender, EventArgs e)
        {
            SelectPilot2();
        }

        private void pbPilot3_Click(object sender, EventArgs e)
        {
            SelectPilot3();
        }

        private void SelectPilot1()
        {
            using (SelectPilotDlg dlg = new SelectPilotDlg(AppViewModel))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _team.Pilot1 = dlg.Pilot;
                    if (_team.Pilot1.Color != 0 && _team.Pilot1.Color != Color.Transparent.ToArgb())
                    {
                        _team.Color = _team.Pilot1.Color;
                        panelTitle.BackColor = Color.FromArgb(_team.Color);
                        panelP1Name.BackColor = Color.FromArgb(_team.Color);
                        panelP2Name.BackColor = Color.FromArgb(_team.Color);
                        panelP3Name.BackColor = Color.FromArgb(_team.Color);
                    }

                    //AffectCarParamsToPilot1();
                    lblPilot1.DataBindings["Text"].ReadValue();
                    lblTeam.DataBindings["Text"].ReadValue();
                    pbPilot1.DataBindings["EditValue"].ReadValue();
                    OnChanged();
                }
            }
        }

        private void SelectPilot2()
        {
            using (SelectPilotDlg dlg = new SelectPilotDlg(AppViewModel))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _team.Pilot2 = dlg.Pilot;
                    //AffectCarParamsToPilot2();
                    lblPilot2.DataBindings["Text"].ReadValue();
                    pbPilot2.DataBindings["EditValue"].ReadValue();
                    OnChanged();
                }
            }
        }

        private void SelectPilot3()
        {
            using (SelectPilotDlg dlg = new SelectPilotDlg(AppViewModel))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _team.Pilot3 = dlg.Pilot;
                    //AffectCarParamsToPilot3();
                    lblPilot3.DataBindings["Text"].ReadValue();
                    pbPilot3.DataBindings["EditValue"].ReadValue();
                    OnChanged();
                }
            }
        }



        private void btnMaxPower_Click(object sender, EventArgs e)
        {
            if(_team.Pilot1.MaxPowerPercent  >= 70)
                _team.Pilot1.MaxPowerPercent += 2;
            else
                _team.Pilot1.MaxPowerPercent += 5;

            if (_team.Pilot1.MaxPowerPercent > 100)
                _team.Pilot1.MaxPowerPercent = 30;

            btnMaxPowerP1.DataBindings["SubText"].ReadValue();
            OnChanged();
        }

        private void btnMaxPowerP2_Click(object sender, EventArgs e)
        {
            if (_team.Pilot2.MaxPowerPercent >= 70)
                _team.Pilot2.MaxPowerPercent += 2;
            else
                _team.Pilot2.MaxPowerPercent += 5;

            if (_team.Pilot2.MaxPowerPercent > 100)
                _team.Pilot2.MaxPowerPercent = 30;

            btnMaxPowerP2.DataBindings["SubText"].ReadValue();
            OnChanged();
        }

        private void btnMaxPowerP3_Click(object sender, EventArgs e)
        {
            if (_team.Pilot3.MaxPowerPercent >= 70)
                _team.Pilot3.MaxPowerPercent += 2;
            else
                _team.Pilot3.MaxPowerPercent += 5;

            if (_team.Pilot3.MaxPowerPercent > 100)
                _team.Pilot3.MaxPowerPercent = 30;

            btnMaxPowerP3.DataBindings["SubText"].ReadValue();
            OnChanged();
        }

        private void btnFuelHandicap_Click(object sender, EventArgs e)
        {
            _team.Pilot1.FuelHandicap += 0.05;
            if (_team.Pilot1.FuelHandicap > 0.5)
                _team.Pilot1.FuelHandicap = 0;
            btnFuelHandicapP1.DataBindings["SubText"].ReadValue();
            OnChanged();
        }

        private void btnDamagesHandicap_Click(object sender, EventArgs e)
        {
            _team.Pilot1.DamagesHandicap += 0.05;
            if (_team.Pilot1.DamagesHandicap > 0.50)
                _team.Pilot1.DamagesHandicap = 0;
            btnDamagesHandicapP1.DataBindings["SubText"].ReadValue();
            OnChanged();
        }

        private void btnBrakeParam_Click(object sender, EventArgs e)
        {
            _team.Pilot1.BrakeLimitation += 1;
            if (_team.Pilot1.BrakeLimitation > 6)
                _team.Pilot1.BrakeLimitation = 0;
            btnBrakeParamP1.DataBindings["SubText"].ReadValue();
            OnChanged();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (Deleted != null)
                Deleted(this, EventArgs.Empty);
        }

        private void btnPacer_Click(object sender, EventArgs e)
        {
            _team.IsPacer = !_team.IsPacer;

            btnPacer.DataBindings["SubText"].ReadValue();
            if(btnRecordPacerLap.DataBindings["SubText"] != null)
             btnRecordPacerLap.DataBindings["SubText"].ReadValue();
            btnRecordPacerLap.DataBindings["Visible"].ReadValue();
            btnPacerPower.DataBindings["Visible"].ReadValue();
            btnBrakeParamP1.DataBindings["Enabled"].ReadValue();

            if (_team.IsPacer)
            {
                _team.CurrentPilot.BrakeLimitation = 0;
                _team.Pacer.PacerPowerPercent = 30;
            }
            else
            {
                btnRecordPacerLap.SubText = "";
            }

            btnBrakeParamP1.DataBindings["SubText"].ReadValue();
            OnChanged();
        }


        private void lblColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _team.Color = colorDialog.Color.ToArgb();
                panelTitle.BackColor = colorDialog.Color;
                panelP1Name.BackColor = colorDialog.Color;
                panelP2Name.BackColor = colorDialog.Color;
                panelP3Name.BackColor = colorDialog.Color;               
            }
            OnChanged();
        }

        #region GESTION DU TOUR POUR PACER VARIABLE
        public delegate void RefreshLapTimeCallback(string laptime);


        private void btnRecordPacerLap_Click(object sender, EventArgs e)
        {
            _team.Pacer.SetPacerPowerThrottle(AppViewModel.DigitalParams.PowerBaseMaxThrottleValue);

            if (Program.hwInterface is SSDInterface)
            {

                if (Team.Pacer.IsRecordingLapThrothlesInfo)
                {
                    Program.hwInterface.ResetCommand();
                    Thread.Sleep(5);
                    Team.Pacer.IsRecordingLapThrothlesInfo = false;
                    btnRecordPacerLap.SubText = "Stopped";
                    Team.Reset(false, false, AppViewModel.DigitalParams.PowerBaseMaxThrottleValue);
                    ClearEvents();
                }
                else
                {
                    Team.Reset(false, false, AppViewModel.DigitalParams.PowerBaseMaxThrottleValue);
                    ClearEvents();

                    Team.Pacer.IsRecordingLapThrothlesInfo = true;
                    btnRecordPacerLap.SubText = "Recording";
                    Team.IniRecordingPacerLap();
                    Program.hwInterface.SetCallBackGetCarThrottleValueFromRace(GetThrottleForCar);
                    (Program.hwInterface as SSDInterface).HandSetThrottleInfosRecorded += ParamTeamPanel_HandSetThrottleInfosRecorded; 
                  Program.hwInterface.StartCommand();
                }

            }
        }
        private void btnViewPacerLap_Click(object sender, EventArgs e)
        {
            _team.Pacer.SetPacerPowerThrottle(AppViewModel.DigitalParams.PowerBaseMaxThrottleValue);

            if (Team.Pacer.LapThrotlesInfos_Initial == null || Team.Pacer.LapThrotlesInfos_Initial.Count == 0)
                return;

            Program.hwInterface.ResetCommand();
            Thread.Sleep(50);
            ClearEvents();

            DlgPacerLapInfos dlg = new DlgPacerLapInfos(Team,AppViewModel.DigitalParams);
            dlg.ShowDialog();
        }


        public void ClearEvents()
        {
            if(Team != null && Team.IsPacer)
                Team.Pacer.IsRecordingLapThrothlesInfo = false;
            (Program.hwInterface as SSDInterface).HandSetThrottleInfosRecorded -= ParamTeamPanel_HandSetThrottleInfosRecorded;
            Program.hwInterface.SetCallBackGetCarThrottleValueFromRace(null);
            Program.hwInterface.StopCommand();
        }


        void ParamTeamPanel_HandSetThrottleInfosRecorded(object sender, ThrottleInfosRecordedEventArgs e)
        {
            if (e.LaneId == this.Team.Id && Team.IsPacer)
            {
                Team.Pacer.LapThrotlesInfos_Initial.Clear();
                Team.Pacer.LapThrotlesInfos_Initial.AddRange(Team.LapThrotlesInfos);
                Team.LapThrotlesInfos.Clear();
                Team.AddLap(e.PassTime,false,false);
                Team.Pacer.LapTarget = Team.LastLapTime;

//#if TRACE
//                Trace.Write("******************************************************** PACER VALUES***************************************************");
//                foreach (int t in e.ThrotthleValues)
//                        Trace.Write(string.Format(" Id = {0}  T = {1}"));
//#endif

                this.BeginInvoke(new RefreshLapTimeCallback(RefreshLapTime), new object[] { Team.LastLapForUI });
            }
        }

        // gestion du Max Power par rapport a la voiture / pilote etc.bool
        public void GetThrottleForCar(int carId, int throtlleValue, float handsetBrakingForce,bool checkAutoTC, bool gamePadUsed, out int resultThrottle, out CantBrakeEnum canBrake,out bool highAcceleration, out bool strongBraking, out float brakeAdhesionLoss, out float accelerationAdhesionLoss)
        {
            brakeAdhesionLoss = 0;
            accelerationAdhesionLoss = 0;
            highAcceleration = false;
            strongBraking = false;

            if (carId == Team.Id)
                Team.GetThrottleValue(throtlleValue, handsetBrakingForce > 0, out resultThrottle, out canBrake, checkAutoTC);
            else
            {
                resultThrottle = throtlleValue;
                canBrake = (resultThrottle == 0 && Team.CurrentPilot.UseDynamicBrake) || handsetBrakingForce > 0 ? CantBrakeEnum.CanBrake : CantBrakeEnum.NoBrakeWanted;
            }
        }


        #endregion

        private void RefreshLapTime(string lapTime)
        {
            btnRecordPacerLap.SubText = lapTime;
            OnChanged();
        }



        private void btnSetId_Click(object sender, EventArgs e)
        {
            if (Program._carIdProgrammer != null && Program._carIdProgrammer.IsConnected)
                Program._carIdProgrammer.ProgramCar(_team.Id);
            else
                Program.hwInterface.SetCurrentCarIdCommand(_team.Id);


            MessageBox.Show("Done");
        }


        private void btnSelectCar_Click(object sender, EventArgs e)
        {
            using (SelectCarDlg dlg = new SelectCarDlg(AppViewModel))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _team.Car = dlg.Car;
                    pbCar.DataBindings["EditValue"].ReadValue();
                    lblCar.DataBindings["Text"].ReadValue();

                    if (_team.Car.Color != 0 && _team.Car.Color != Color.Transparent.ToArgb())
                    {
                        _team.Color = _team.Car.Color;
                        _team.InCarPro = _team.Car.InCarPro;
                        panelTitle.BackColor = Color.FromArgb(_team.Color);
                        panelP1Name.BackColor = Color.FromArgb(_team.Color);
                        panelP2Name.BackColor = Color.FromArgb(_team.Color);
                        panelP3Name.BackColor = Color.FromArgb(_team.Color);
                    }

                    //AffectCarParamsToPilot1();
                    //AffectCarParamsToPilot2();
                    //AffectCarParamsToPilot3();

                    OnChanged();
                }
            }
        }

        private void AffectCarParamsToPilot3()
        {
            if (_team.Pilot3 != null)
            {
                _team.Pilot3.MaxPowerPercent = _team.Car.MaxPowerPercent;
                _team.Pilot3.BrakeLimitation = _team.Car.BrakeLimitation;
                _team.Pilot3.FuelHandicap = _team.Car.FuelHandicap;
                _team.Pilot3.DamagesHandicap = _team.Car.DamagesHandicap;
            }
        }

        private void AffectCarParamsToPilot2()
        {
            if (_team.Pilot2 != null)
            {
                _team.Pilot2.MaxPowerPercent = _team.Car.MaxPowerPercent;
                _team.Pilot2.BrakeLimitation = _team.Car.BrakeLimitation;
                _team.Pilot2.FuelHandicap = _team.Car.FuelHandicap;
                _team.Pilot2.DamagesHandicap = _team.Car.DamagesHandicap;
            }
        }

        private void AffectCarParamsToPilot1()
        {
            _team.Pilot1.MaxPowerPercent = _team.Car.MaxPowerPercent;
            _team.Pilot1.BrakeLimitation = _team.Car.BrakeLimitation;
            _team.Pilot1.FuelHandicap = _team.Car.FuelHandicap;
            _team.Pilot1.DamagesHandicap = _team.Car.DamagesHandicap;
        }

        private void btnPacerPower_Click(object sender, EventArgs e)
        {
            btnPacerPower.DataBindings["SubText"].WriteValue();
        }

        private void btnUseGamePad_Click(object sender, EventArgs e)
        {
            if (_team.UseGamePadPlayerIndex.HasValue && _team.UseGamePadPlayerIndex.Value == EsrmPlayerIndex.Six)
                _team.UseGamePadPlayerIndex = null;
            else if (_team.UseGamePadPlayerIndex.HasValue)
                _team.UseGamePadPlayerIndex++;
            else
            {
                _team.UseGamePadPlayerIndex = (EsrmPlayerIndex)_team.Id - 1;
                //_team.UseGamePadPlayerIndex = EsrmPlayerIndex.One;
            }

            RefreshGamePadInfos();
        }

        private void RefreshGamePadInfos()
        {
            btnUseGamePad.DataBindings["ForeColor"].ReadValue();
            btnUseGamePad.DataBindings["SubText"].ReadValue();

            //btnP1TriggerCurves.DataBindings["Visible"].ReadValue();
            btnP1TriggerCurves.DataBindings["SubText"].ReadValue();
            btnBrakeParamP1.DataBindings["Enabled"].ReadValue();
            chkBxDynBrakeP1.DataBindings["Enabled"].ReadValue();
            if (Pilot2Visible)
            {
                //btnP2TriggerCurves.DataBindings["Visible"].ReadValue();
                btnP2TriggerCurves.DataBindings["SubText"].ReadValue();
                btnBrakeParamP2.DataBindings["Enabled"].ReadValue();
                chkBxDynBrakeP2.DataBindings["Enabled"].ReadValue();
            }
            if (Pilot3Visible)
            {
                //btnP3TriggerCurves.DataBindings["Visible"].ReadValue();
                btnP3TriggerCurves.DataBindings["SubText"].ReadValue();
                btnBrakeParamP3.DataBindings["Enabled"].ReadValue();
                chkBxDynBrakeP3.DataBindings["Enabled"].ReadValue();
            }
        }

        private void btnP1TriggerCurves_Click(object sender, EventArgs e)
        {
            if (_team.UseGamePadPlayerIndex.HasValue)
            {
                CalibrationDialog dlg = null;
                dlg = new CalibrationDialog(_team.UseGamePadPlayerIndex.Value, AppViewModel, _team.InCarPro, _team.Pilot1,Color.FromArgb(_team.Color));

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _team.Pilot1.GamePadThrottleCurve = dlg.CurrentThrottleCurve;
                    if(_team.InCarPro)
                        _team.Pilot1.GamePadInCarProBrakeCurve = dlg.CurrentBrakeCurve;
                    else
                        _team.Pilot1.GamePadBrakeCurve = dlg.CurrentBrakeCurve;

                    btnP1TriggerCurves.DataBindings["SubText"].ReadValue();
                }
                else
                {
                    _team.Pilot1.GamePadThrottleCurve = dlg.InitialThrottleCurve;
                    _team.Pilot1.GamePadBrakeCurve = dlg.InitialBrakeCurve;
                    btnP1TriggerCurves.DataBindings["SubText"].ReadValue();
                }
            }
            else
            {
                HandSetCalibrationDlg dlg = null;
                dlg = new HandSetCalibrationDlg(_team.Id, AppViewModel, _team.Pilot1.HandsetThrottleCurve);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _team.Pilot1.HandsetThrottleCurve = dlg.CurrentThrottleCurve;
                    btnP1TriggerCurves.DataBindings["SubText"].ReadValue();
                }
                else
                {
                    _team.Pilot1.HandsetThrottleCurve = dlg.InitialThrottleCurve;
                    btnP1TriggerCurves.DataBindings["SubText"].ReadValue();
                }
            }
        }

        private void btnP2TriggerCurves_Click(object sender, EventArgs e)
        {
            if (_team.UseGamePadPlayerIndex.HasValue)
            {
                CalibrationDialog dlg = null;
                dlg = new CalibrationDialog(_team.UseGamePadPlayerIndex.Value, AppViewModel, _team.InCarPro, _team.Pilot2, Color.FromArgb(_team.Color));

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _team.Pilot2.GamePadThrottleCurve = dlg.CurrentThrottleCurve;
                    if (_team.InCarPro)
                        _team.Pilot2.GamePadInCarProBrakeCurve = dlg.CurrentBrakeCurve;
                    else
                        _team.Pilot2.GamePadBrakeCurve = dlg.CurrentBrakeCurve;
                    btnP2TriggerCurves.DataBindings["SubText"].ReadValue();
                }
                else
                {
                    _team.Pilot2.GamePadThrottleCurve = dlg.InitialThrottleCurve;
                    _team.Pilot2.GamePadBrakeCurve = dlg.InitialBrakeCurve;
                    btnP2TriggerCurves.DataBindings["SubText"].ReadValue();
                }
            }
            else
            {
                HandSetCalibrationDlg dlg = null;
                dlg = new HandSetCalibrationDlg(_team.Id, AppViewModel, _team.Pilot2.HandsetThrottleCurve);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _team.Pilot2.HandsetThrottleCurve = dlg.CurrentThrottleCurve;
                    btnP2TriggerCurves.DataBindings["SubText"].ReadValue();
                }
                else
                {
                    _team.Pilot2.HandsetThrottleCurve = dlg.InitialThrottleCurve;
                    btnP2TriggerCurves.DataBindings["SubText"].ReadValue();
                }
            }
        }

        private void btnP3TriggerCurves_Click(object sender, EventArgs e)
        {
            if (_team.UseGamePadPlayerIndex.HasValue)
            {
                CalibrationDialog dlg = null;
                dlg = new CalibrationDialog(_team.UseGamePadPlayerIndex.Value, AppViewModel, _team.InCarPro, _team.Pilot3, Color.FromArgb(_team.Color));

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _team.Pilot3.GamePadThrottleCurve = dlg.CurrentThrottleCurve;
                    if (_team.InCarPro)
                        _team.Pilot3.GamePadInCarProBrakeCurve = dlg.CurrentBrakeCurve;
                    else
                        _team.Pilot3.GamePadBrakeCurve = dlg.CurrentBrakeCurve;
                    btnP3TriggerCurves.DataBindings["SubText"].ReadValue();
                }
                else
                {
                    _team.Pilot3.GamePadThrottleCurve = dlg.InitialThrottleCurve;
                    _team.Pilot3.GamePadBrakeCurve = dlg.InitialBrakeCurve;
                    btnP3TriggerCurves.DataBindings["SubText"].ReadValue();
                }
            }
            else
            {
                HandSetCalibrationDlg dlg = null;
                dlg = new HandSetCalibrationDlg(_team.Id, AppViewModel, _team.Pilot3.HandsetThrottleCurve);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _team.Pilot3.HandsetThrottleCurve = dlg.CurrentThrottleCurve;
                    btnP3TriggerCurves.DataBindings["SubText"].ReadValue();
                }
                else
                {
                    _team.Pilot3.HandsetThrottleCurve = dlg.InitialThrottleCurve;
                    btnP3TriggerCurves.DataBindings["SubText"].ReadValue();
                }
            }
        }

        private void chkBxDynBrakeP1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxDynBrakeP1.DataBindings["Checked"] != null)
                chkBxDynBrakeP1.DataBindings["Checked"].WriteValue();
            if (Pilot2Visible && chkBxDynBrakeP2.DataBindings["Checked"] != null)
                chkBxDynBrakeP2.DataBindings["Checked"].WriteValue();
            if (Pilot3Visible && chkBxDynBrakeP3.DataBindings["Checked"] != null)
                chkBxDynBrakeP3.DataBindings["Checked"].WriteValue();
        }

        private void btnFuelHandicapP2_Click(object sender, EventArgs e)
        {
            _team.Pilot2.FuelHandicap += 0.05;
            if (_team.Pilot2.FuelHandicap > 0.5)
                _team.Pilot2.FuelHandicap = 0;
            btnFuelHandicapP2.DataBindings["SubText"].ReadValue();
            OnChanged();
        }

        private void btnDamagesHandicapP2_Click(object sender, EventArgs e)
        {
            _team.Pilot2.DamagesHandicap += 0.05;
            if (_team.Pilot2.DamagesHandicap > 0.50)
                _team.Pilot2.DamagesHandicap = 0;
            btnDamagesHandicapP2.DataBindings["SubText"].ReadValue();
            OnChanged();
        }
        private void btnFuelHandicapP3_Click(object sender, EventArgs e)
        {
            _team.Pilot3.FuelHandicap += 0.05;
            if (_team.Pilot3.FuelHandicap > 0.5)
                _team.Pilot3.FuelHandicap = 0;
            btnFuelHandicapP3.DataBindings["SubText"].ReadValue();
            OnChanged();

        }

        private void btnDamagesHandicapP3_Click(object sender, EventArgs e)
        {
            _team.Pilot3.DamagesHandicap += 0.05;
            if (_team.Pilot3.DamagesHandicap > 0.50)
                _team.Pilot3.DamagesHandicap = 0;
            btnDamagesHandicapP3.DataBindings["SubText"].ReadValue();
            OnChanged();
        }

        private void btnBrakeParamP2_Click(object sender, EventArgs e)
        {
            _team.Pilot2.BrakeLimitation += 1;
            if (_team.Pilot2.BrakeLimitation > 6)
                _team.Pilot2.BrakeLimitation = 0;
            btnBrakeParamP2.DataBindings["SubText"].ReadValue();
            OnChanged();
        }

        private void btnBrakeParamP3_Click(object sender, EventArgs e)
        {
            _team.Pilot3.BrakeLimitation += 1;
            if (_team.Pilot3.BrakeLimitation > 6)
                _team.Pilot3.BrakeLimitation = 0;
            btnBrakeParamP3.DataBindings["SubText"].ReadValue();
            OnChanged();
        }

        private void btnRasCar_Click(object sender, EventArgs e)
        {
            _team.Car = new Car(TireType.Medium);
            OnChanged();
        }

        private void btnInCarPro_Click(object sender, EventArgs e)
        {
            _team.InCarPro = !_team.InCarPro;
            btnInCarPro.DataBindings["ForeColor"].ReadValue();

        }


        GlobalGamePadHandSet gp1 ;
        GlobalGamePadHandSet gp2;
        GlobalGamePadHandSet gp3;
        GlobalGamePadHandSet gp4;
        GlobalGamePadHandSet gp5;
        GlobalGamePadHandSet gp6;
        BackgroundWorker waitingForGpWorker;
        bool continuesearch = true;

        private void btnAffectGPFromTh_Click(object sender, EventArgs e)
        {
            continuesearch = true;
            Cursor.Current = Cursors.WaitCursor;

            if (waitingForGpWorker != null && waitingForGpWorker.IsBusy)
                waitingForGpWorker.CancelAsync();

            messageSelectGamePad = new MessageDialog(Textes.Mess_PressStartOnTeamGamePad);
            messageSelectGamePad.FormClosed += MessageSelectGamePad_FormClosed;
            messageSelectGamePad.Show();
            // instancier les gamepads
            waitingForGpWorker = new BackgroundWorker();
            waitingForGpWorker.WorkerSupportsCancellation = true;

            waitingForGpWorker.DoWork += Worker_DoWork;
            waitingForGpWorker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            waitingForGpWorker.RunWorkerAsync();

            // attendre un start event sur un GP
        }

        private void MessageSelectGamePad_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (waitingForGpWorker != null && waitingForGpWorker.IsBusy)
                waitingForGpWorker.CancelAsync();

            CanGPEvents() ;
            messageSelectGamePad.FormClosed -= MessageSelectGamePad_FormClosed;
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
            this.Team.UseGamePadPlayerIndex = EsrmPlayerIndex.Six;
            gp6.HighSpeedVibrations();
           this.BeginInvoke(new StandardCallBack(RefreshGamePadInfos));
        }

        private void Gp5_StartEvent(object sender, EventArgs e)
        {
            waitingForGpWorker.CancelAsync();
            continuesearch = false;
            this.Team.UseGamePadPlayerIndex = EsrmPlayerIndex.Five;
            gp5.HighSpeedVibrations();

            this.BeginInvoke(new StandardCallBack(RefreshGamePadInfos));
        }

        private void Gp4_StartEvent(object sender, EventArgs e)
        {
            waitingForGpWorker.CancelAsync();
            continuesearch = false;
            this.Team.UseGamePadPlayerIndex = EsrmPlayerIndex.Four;
            gp4.HighSpeedVibrations();
            this.BeginInvoke(new StandardCallBack(RefreshGamePadInfos));
        }

        private void Gp3_StartEvent(object sender, EventArgs e)
        {
            waitingForGpWorker.CancelAsync();
            continuesearch = false;
            this.Team.UseGamePadPlayerIndex = EsrmPlayerIndex.Three;
            gp3.HighSpeedVibrations();
            this.BeginInvoke(new StandardCallBack(RefreshGamePadInfos));
        }

        private void Gp2_StartEvent(object sender, EventArgs e)
        {
            waitingForGpWorker.CancelAsync();
            continuesearch = false;
            this.Team.UseGamePadPlayerIndex = EsrmPlayerIndex.Two;
            gp2.HighSpeedVibrations();
            this.BeginInvoke(new StandardCallBack(RefreshGamePadInfos));
        }

        private void Gp1_StartEvent(object sender, EventArgs e)
        {
            waitingForGpWorker.CancelAsync();
            continuesearch = false;
            this.Team.UseGamePadPlayerIndex = EsrmPlayerIndex.One;
            gp1.HighSpeedVibrations();
            this.BeginInvoke(new StandardCallBack(RefreshGamePadInfos));
        }
    }
}
