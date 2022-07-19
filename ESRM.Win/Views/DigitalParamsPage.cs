using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRM.Entities;
using System.Windows.Threading;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System.Threading;

namespace ESRM.Win.Views
{
    public partial class DigitalParamsPage : BasePage
    {
        public string TrackCallMethod
        {
            get
            {
                if (AppViewModel.DigitalParams.TrackCallMethod == TrackCallMethodEnum.BrakeAndZGaz)
                    return Textes.BrakeAndZeorGaz;
                else if (AppViewModel.DigitalParams.TrackCallMethod == TrackCallMethodEnum.LCAndBrake)
                    return Textes.LCAndBrake;
                else if (AppViewModel.DigitalParams.TrackCallMethod == TrackCallMethodEnum.LCAndBrakeAndZGaz)
                    return Textes.LCAndBrakeAndZGaz;
                else if (AppViewModel.DigitalParams.TrackCallMethod == TrackCallMethodEnum.None)
                    return Textes.Disabled;
                else return Textes.Disabled;
            }
        }

        public string PitInMethod
        {
            get
            {
                if (AppViewModel.DigitalParams.PitInMethod == PitInMethodEnum.Brake)
                    return Textes.Brake;
                else if (AppViewModel.DigitalParams.PitInMethod == PitInMethodEnum.LC)
                    return Textes.LC;
                else if (AppViewModel.DigitalParams.PitInMethod == PitInMethodEnum.LCAndBrake)
                    return Textes.LCAndBrake;
                else if (AppViewModel.DigitalParams.PitInMethod == PitInMethodEnum.None)
                    return Textes.Disabled;
                else return Textes.Disabled;
            }
        }
        public string BreakDownActionText
        {
            get
            {
                if (AppViewModel.DigitalParams.ActionOnBreakdowmn == BreakdownActionEnum.DoNothing)
                    return Textes.DoNothing;
                else if (AppViewModel.DigitalParams.ActionOnBreakdowmn == BreakdownActionEnum.EndLapWithPenalityPower)
                    return Textes.EndLapWithPenalityPower;
                else if (AppViewModel.DigitalParams.ActionOnBreakdowmn == BreakdownActionEnum.WaitForPitStop)
                    return Textes.WaitForPitStop;
                else if (AppViewModel.DigitalParams.ActionOnBreakdowmn == BreakdownActionEnum.Disquafied)
                    return Textes.Disqualify;
                else
                    return Textes.DoNothing;
            }
        }

        public string AddLapOnPitStopText
        {
            get
            {
                return AppViewModel.DigitalParams.AddLapOnPitStop.ToString();
            }
        }

        public double TrackCallPressDelay
        {
            get { return (double)AppViewModel.DigitalParams.TrackCallPressDelay / 1000; }
            set
            {
                double result = (value * 1000);
                AppViewModel.DigitalParams.TrackCallPressDelay = (int)result;
            }
        }

        public double PitInPressDelay
        {
            get { return (double) AppViewModel.DigitalParams.PitInPressDelay / 1000; }
            set
            {
                double result = (value * 1000);
                AppViewModel.DigitalParams.PitInPressDelay = (int)result;
            }
        }

        public string LicenceType
        {
            get { return Program.Licence.IsTrial ? Textes.TrialVersion : Textes.Standard; }
        }
        public Color PenalityOnTcColor
        {
            get { return AppViewModel.DigitalParams.PenalityOnTc ? Color.Green : Color.Red; }
        }
        public Color UsePitDetectionColor
        {
            get { return AppViewModel.DigitalParams.UsePitDetection ? Color.Green : Color.Red; }
        }

        public string UsePitDetectionText
        {
            get
            {
                if (!AppViewModel.DigitalParams.UsePitDetection)
                    return Textes.None;
                else if (AppViewModel.DigitalParams.PitSmartSensorsParams.SensorType == SensorProtocolEnum.PP)
                    return Textes.PitPro;
                else if (AppViewModel.DigitalParams.PitSmartSensorsParams.SensorType == SensorProtocolEnum.SS)
                    return Textes.SmartSensor;
                else
                    return Textes.None;

            }
        }

        public Color UseStartLightColor
        {
            get { return AppViewModel.DigitalParams.UseStartLight ? Color.Green : Color.Red; }
        }
        




        public DigitalParamsPage()
        {
            InitializeComponent();

            btnTest.Visible = true;

            btnTiresConfig.Text = Textes.Tires;
            btnGlobalParams.Text = Textes.General;

            Font btnFont = Program.fontManager.GetRadioStarFont(btnGlobalParams.Font.Size, FontStyle.Italic);
            btnTiresConfig.Font = btnFont;
            btnGlobalParams.Font = btnFont;
            btnSounds.Font = btnFont;
            btnAdvancedParams.Font = btnFont;

#if DEBUG
            btnTest.Visible = true;
#endif
        }

        public override void OnNavigatedTo(INavigationArgs args)
        {
            base.OnNavigatedTo(args);

            BindDatas();

            panelTires.SetParams(appViewModel);
            advancedParams.SetParams(appViewModel);
            soundsParams1.SetParams(appViewModel);

            ChangeConnexionButtonColor();
            ChangePitSmartSensorsConnexionButtonColor();
            ChangeSLConnexionButtonColor();
        }

        public override void OnNavigatedFrom(INavigationArgs args)
        {
            advancedParams.ApplyChangesOnGlobalDatas();
            base.OnNavigatedFrom(args);
        }
        private void BindDatas()
        {
            ScalablePanel.ClearBindings(this);

            //btnLicence.DataBindings.Add("SubText", this, "LicenceType");
            btnPitStopMethod.DataBindings.Add("SubText", this, "PitInMethod");
            btnTCMethod.DataBindings.Add("SubText", this, "TrackCallMethod");


            btnAutoGreenFlag.DataBindings.Add("SubText", AppViewModel.DigitalParams, "AutoGreenFlag");
            btnMaxDamages.DataBindings.Add("SubText", AppViewModel.DigitalParams, "DamagesPercentMax");
            btnMaxPenalityPower.DataBindings.Add("SubText", AppViewModel.DigitalParams, "MaxPowerOnPenality");
            btnMaxPitPower.DataBindings.Add("SubText", AppViewModel.DigitalParams, "MaxPowerInPit");
            btnMaxYFPower.DataBindings.Add("SubText", AppViewModel.DigitalParams, "MaxPowerOnYellowFlag");
            btnMinorDamages.DataBindings.Add("SubText", AppViewModel.DigitalParams, "DamagesPercentMin");
            btnNormalDamages.DataBindings.Add("SubText", AppViewModel.DigitalParams, "DamagesPercentNormal");
            btnTCDamages.DataBindings.Add("SubText", AppViewModel.DigitalParams, "DamagesPercentOnTrackCall");

            btnBreakdownAction.DataBindings.Add("SubText", this, "BreakDownActionText");
            btnAddLapOnPitStop.DataBindings.Add("SubText", this, "AddLapOnPitStopText");
            btnPenalityOnTC.DataBindings.Add("ForeColor", this, "PenalityOnTcColor");

            btnZeroGaz.DataBindings.Add("SubText", AppViewModel.DigitalParams, "SeuilZeroGaz");
            edtPitPressDelay.DataBindings.Add("Value", this, "PitInPressDelay");
            edtTCPressDelay.DataBindings.Add("Value", this, "TrackCallPressDelay");
            btnUsePitDetection.DataBindings.Add("ForeColor", this, "UsePitDetectionColor");
            // btnUsePitDetection.DataBindings.Add("SubText", this, "UsePitDetectionText");

            btnUsePitDetection.SubText = UsePitDetectionText;

            edtSensorsCount.DataBindings.Add("Value", AppViewModel.DigitalParams.PitSmartSensorsParams, "SensorsCount");
            cbxComPortsForPits.DataBindings.Add("Visible", AppViewModel.DigitalParams, "UsePitDetection");
            btnConnectPitSS.DataBindings.Add("Visible", AppViewModel.DigitalParams, "UsePitDetection");
            lblSensorsCount.DataBindings.Add("Visible", AppViewModel.DigitalParams, "UsePitDetection");
            edtSensorsCount.DataBindings.Add("Visible", AppViewModel.DigitalParams, "UsePitDetection");


            btnUseStartLight.DataBindings.Add("ForeColor", this, "UseStartLightColor");
            cbxComPortsForSL.DataBindings.Add("Visible", AppViewModel.DigitalParams, "UseStartLight");
            btnConnectSL.DataBindings.Add("Visible", AppViewModel.DigitalParams, "UseStartLight");

            cbxComPorts.Items.Clear();
            cbxComPortsForPits.Items.Clear();
            cbxComPortsForSL.Items.Clear();

            if (appViewModel.DigitalParams.OpenedComPort == null || appViewModel.DigitalParams.OpenedComPort.Count == 0)
                Program.GetComPorts();

            if (appViewModel.DigitalParams.OpenedComPort != null)
            {
                cbxComPorts.Items.Add(string.Empty);
                cbxComPortsForSL.Items.Add(string.Empty);
                foreach (string s in appViewModel.DigitalParams.OpenedComPort)
                {
                    cbxComPorts.Items.Add(s);
                    cbxComPortsForSL.Items.Add(s);
                }

                cbxComPorts.SelectedItem = appViewModel.DigitalParams.ComPort;
                cbxComPortsForSL.SelectedItem = appViewModel.DigitalParams.StartLightComPort;
            }


            if (appViewModel.DigitalParams.PitSmartSensorsParams != null)
            {
                cbxComPortsForPits.Items.Add(string.Empty);

                foreach (string s in appViewModel.DigitalParams.PitSmartSensorsParams.OpenedComPort)
                    cbxComPortsForPits.Items.Add(s);

                cbxComPortsForPits.SelectedItem = appViewModel.DigitalParams.PitSmartSensorsParams.ComPort;
            }
        }


        private void ChangeConnexionButtonColor()
        {
            if (!Program.hwInterface.IsConnected())
            {
                lblConnection.ForeColor = Color.Red;
                btnTestConnexion.ForeColor = Color.Red;
            }
            else
            {
                lblConnection.ForeColor = Color.Green;
                btnTestConnexion.ForeColor = Color.Green;
            }
        }

        private void ChangePitSmartSensorsConnexionButtonColor()
        {
            if (!Program.pitSensors.IsConnected)
            {
                btnConnectPitSS.ForeColor = Color.Red;
                btnConnectPitSS.Text = "Connect";
            }
            else
            {
                btnConnectPitSS.ForeColor = Color.Green;
                btnConnectPitSS.Text = "Disconnect";
            }
        }

        

        private void btnTCMethod_Click(object sender, EventArgs e)
        {
            AppViewModel.DigitalParams.TrackCallMethod += 1;
            if(AppViewModel.DigitalParams.TrackCallMethod > TrackCallMethodEnum.None)
                AppViewModel.DigitalParams.TrackCallMethod = 0;
            btnTCMethod.DataBindings["SubText"].ReadValue();
        }

        private void btnPitStopMethod_Click(object sender, EventArgs e)
        {
            AppViewModel.DigitalParams.PitInMethod += 1;
            if (AppViewModel.DigitalParams.PitInMethod >  PitInMethodEnum.None)
                AppViewModel.DigitalParams.PitInMethod = 0;

            btnPitStopMethod.DataBindings["SubText"].ReadValue();
        }

        private void btnAutoGreenFlag_Click(object sender, EventArgs e)
        {
            AppViewModel.DigitalParams.AutoGreenFlag = !AppViewModel.DigitalParams.AutoGreenFlag;
            btnAutoGreenFlag.DataBindings["SubText"].ReadValue();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cbxComPorts.SelectedItem != null)
                appViewModel.DigitalParams.ComPort = cbxComPorts.SelectedItem.ToString();
            //else
            //    appViewModel.DigitalParams.ComPort = string.Empty;

            if (cbxComPortsForPits.SelectedItem != null)
                appViewModel.DigitalParams.PitSmartSensorsParams.ComPort = cbxComPortsForPits.SelectedItem.ToString();
            //else
            //    appViewModel.DigitalParams.PitSmartSensorsParams.ComPort = string.Empty;

            AppViewModel.SaveDigitalParams();
            appViewModel.SaveTiresParams();
            appViewModel.SaveSoundSettings();
            AppViewModel.ActivatePage("pageMainMenu");
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            AppViewModel.ActivatePage("pageSSDTest");


        }

        private void btnLicence_Click(object sender, EventArgs e)
        {
            using (LicenceDlg dlg = new LicenceDlg(Program.licenceId))
            {
                dlg.ShowDialog();
            }
        }

        private void btnAddLapOnPitStop_Click(object sender, EventArgs e)
        {
            int tmp = (int)AppViewModel.DigitalParams.AddLapOnPitStop + 1;
            if (tmp > (int)AddlapOnPitStopEnum.ExitPitLane)
                tmp = 0;
            AppViewModel.DigitalParams.AddLapOnPitStop = (AddlapOnPitStopEnum)tmp;
            btnAddLapOnPitStop.DataBindings["SubText"].ReadValue();
        }

        private void btnBreakdownAction_Click(object sender, EventArgs e)
        {
            if (AppViewModel.DigitalParams.ActionOnBreakdowmn < BreakdownActionEnum.WaitForPitStop)
                AppViewModel.DigitalParams.ActionOnBreakdowmn = (BreakdownActionEnum)((int)AppViewModel.DigitalParams.ActionOnBreakdowmn + 1);
            else
                AppViewModel.DigitalParams.ActionOnBreakdowmn = BreakdownActionEnum.DoNothing;

            btnBreakdownAction.DataBindings["SubText"].ReadValue();
        }

        private void btnTestConnexion_Click(object sender, EventArgs e)
        {
            if (cbxComPorts.SelectedItem != null && !string.IsNullOrEmpty(cbxComPorts.SelectedText))
            {
                if (Program.hwInterface.IsConnected())
                    MessageBox.Show("PB Is Already connected");
                else
                {
                    AppViewModel.DigitalParams.ComPort = cbxComPorts.SelectedItem.ToString();
                    Program.InitHardwareConnexionThread(AppViewModel.DigitalParams, false);
                    Thread.Sleep(200);
                }
            }
            else
            {
                AppViewModel.DigitalParams.CarIdProgrammerComPort = string.Empty;
                Program.hwInterface.CloseConnexionCommand();
            }
            ChangeConnexionButtonColor();
            AppViewModel.SaveDigitalParams();
        }

        private void btnGlobalParams_Click(object sender, EventArgs e)
        {
            btnGlobalParams.ForeColor = Color.YellowGreen;
            btnTiresConfig.ForeColor = Color.DimGray;
            btnAdvancedParams.ForeColor = Color.DimGray;

            panelTires.Visible = false;
            panelGeneral.Visible = true;
            advancedParams.Visible = false;

            btnSounds.ForeColor = Color.DimGray;
            soundsParams1.Visible = false;
        }

        private void btnbrakeParams_Click(object sender, EventArgs e)
        {
            btnGlobalParams.ForeColor = Color.DimGray;
            btnTiresConfig.ForeColor = Color.YellowGreen;
            btnAdvancedParams.ForeColor = Color.DimGray;

            panelGeneral.Visible = false;
            panelTires.Visible = true;
            advancedParams.Visible = false;

            btnSounds.ForeColor = Color.DimGray;
            soundsParams1.Visible = false;
        }

        private void btnAdvancedParams_Click(object sender, EventArgs e)
        {
            btnGlobalParams.ForeColor = Color.DimGray;
            btnTiresConfig.ForeColor = Color.DimGray;
            btnAdvancedParams.ForeColor = Color.YellowGreen;
            panelGeneral.Visible = false;
            panelTires.Visible = false;
            advancedParams.Visible = true;

            btnSounds.ForeColor = Color.DimGray;
            soundsParams1.Visible = false;

        }

        private void btnSounds_Click(object sender, EventArgs e)
        {
            btnGlobalParams.ForeColor = Color.DimGray;
            panelGeneral.Visible = false;
            btnTiresConfig.ForeColor = Color.DimGray;
            panelTires.Visible = false;
            btnAdvancedParams.ForeColor = Color.DimGray;
            advancedParams.Visible = false;
            btnSounds.ForeColor = Color.YellowGreen;
            soundsParams1.Visible = true;

        }



        private void btnPenalityOnTC_Click(object sender, EventArgs e)
        {
            AppViewModel.DigitalParams.PenalityOnTc = !AppViewModel.DigitalParams.PenalityOnTc;
            btnPenalityOnTC.DataBindings["ForeColor"].ReadValue();
        }

        private void btnConnectPitSS_Click(object sender, EventArgs e)
        {
            if (Program.pitSensors.IsConnected)
            {
                Program.pitSensors.CloseConnexion();
                ChangePitSmartSensorsConnexionButtonColor();
            }
            else
            {
                if (!string.IsNullOrEmpty(cbxComPortsForPits.Text))
                {
                    // AppViewModel.DigitalParams.PitSmartSensorsParams.ComPort = cbxComPortsForPits.SelectedItem.ToString();
                    AppViewModel.DigitalParams.PitSmartSensorsParams.ComPort = cbxComPortsForPits.Text;
                    Program.IniSensorsConnexionThread(AppViewModel.DigitalParams);
                }
                Cursor = Cursors.WaitCursor;
                Thread.Sleep(3000);
                ChangePitSmartSensorsConnexionButtonColor();
                AppViewModel.SaveDigitalParams();
                Cursor = Cursors.Default;
            }
        }

        private void btnUsePitDetection_Click(object sender, EventArgs e)
        {
            if (AppViewModel.DigitalParams.PitSmartSensorsParams.SensorType == SensorProtocolEnum.None)
            {
                AppViewModel.DigitalParams.PitSmartSensorsParams.SensorType = SensorProtocolEnum.PP;
                AppViewModel.DigitalParams.UsePitDetection = true;
            }
            else if (AppViewModel.DigitalParams.PitSmartSensorsParams.SensorType == SensorProtocolEnum.PP)
            {
                AppViewModel.DigitalParams.PitSmartSensorsParams.SensorType = SensorProtocolEnum.SS;
                AppViewModel.DigitalParams.UsePitDetection = true;
            }
            else if (AppViewModel.DigitalParams.PitSmartSensorsParams.SensorType == SensorProtocolEnum.SS)
            { 
                AppViewModel.DigitalParams.PitSmartSensorsParams.SensorType = SensorProtocolEnum.None;
                AppViewModel.DigitalParams.UsePitDetection = false;
            }


            btnUsePitDetection.SubText = UsePitDetectionText;

            btnUsePitDetection.DataBindings["ForeColor"].ReadValue();
            cbxComPortsForPits.DataBindings["Visible"].ReadValue();
            btnConnectPitSS.DataBindings["Visible"].ReadValue();
            lblSensorsCount.DataBindings["Visible"].ReadValue();
            edtSensorsCount.DataBindings["Visible"].ReadValue();
        }


        private void btnUseStartLight_Click(object sender, EventArgs e)
        {
            AppViewModel.DigitalParams.UseStartLight = !AppViewModel.DigitalParams.UseStartLight;

            btnUseStartLight.DataBindings["ForeColor"].ReadValue();
            cbxComPortsForSL.DataBindings["Visible"].ReadValue();
            btnConnectSL.DataBindings["Visible"].ReadValue();

        }
        private void btnConnectSL_Click(object sender, EventArgs e)
        {
            if (Program._startLight.IsConnected)
            {
                Program._startLight.CloseConnexion();
                ChangeSLConnexionButtonColor();
            }
            else
            {
                if (!string.IsNullOrEmpty(cbxComPortsForSL.Text))
                {
                    // AppViewModel.DigitalParams.PitSmartSensorsParams.ComPort = cbxComPortsForPits.SelectedItem.ToString();
                    AppViewModel.DigitalParams.StartLightComPort = cbxComPortsForSL.Text;
                    Program.IniStartLightConnexionThread(AppViewModel.DigitalParams);
                }
                Cursor = Cursors.WaitCursor;
                Thread.Sleep(1000);
                ChangeSLConnexionButtonColor();
                AppViewModel.SaveDigitalParams();
                Cursor = Cursors.Default;
            }
        }


        private void ChangeSLConnexionButtonColor()
        {
            if (!Program._startLight.IsConnected)
            {
                btnConnectSL.ForeColor = Color.Red;
                btnConnectSL.Text = "Connect";
            }
            else
            {
                btnConnectSL.ForeColor = Color.Green;
                btnConnectSL.Text = "Disconnect";
            }
        }
    }
}
