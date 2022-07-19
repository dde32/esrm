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
using DevExpress.XtraEditors;
using System.Threading;

namespace ESRM.Win.Panels
{
    public partial class AdvancedDigitalParams : ScalableControl
    {
        IESRMViewModel _appViewModel;
        public IESRMViewModel AppViewModel
        {
            get { return _appViewModel; }
        }

        public string RumblesOnHighAcceleration
        {
            get { return _appViewModel.DigitalParams.RumblesOnHighAcceleration ? Textes.Enabled : Textes.Disabled; }
        }
        public string RumblesOnStrongBraking
        {
            get { return _appViewModel.DigitalParams.RumblesOnStrongBraking ? Textes.Enabled : Textes.Disabled; }
        }
        public Color RumblesOnHighAccelerationColor
        {
            get { return _appViewModel.DigitalParams.RumblesOnHighAcceleration ? Color.YellowGreen : Color.Red; }
        }
        public Color RumblesOnStrongBrakingColor
        {
            get { return _appViewModel.DigitalParams.RumblesOnStrongBraking ? Color.YellowGreen : Color.Red; }
        }
        public Color UseCarIdProgrammerColor
        {
            get { return AppViewModel.DigitalParams.UseCarIdProgrammer ? Color.Green : Color.Red; }
        }


        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        public AdvancedDigitalParams()
        {
            InitializeComponent();
        }

        public void SetParams(IESRMViewModel appViewModel)
        {
           _appViewModel = appViewModel;
            DoBinding();
        }


        #region BINDING

        protected override void DoBinding()
        {
            base.DoBinding();

            btnLowFuelLevel.DataBindings.Add("SubText", _appViewModel.DigitalParams, "LowFuelLevel");
            btnLowHealthLevel.DataBindings.Add("SubText", _appViewModel.DigitalParams, "LowHealthLevel");
            btnLowTiresLevel.DataBindings.Add("SubText", _appViewModel.DigitalParams, "LowTiresLevel");
            btnMaxAccelerationDelta.DataBindings.Add("SubText", _appViewModel.DigitalParams, "MaxAccelerationDelta");
            btnMaxBrakeIntervals.DataBindings.Add("SubText", _appViewModel.DigitalParams, "MaxBrakeIntervals");
            btnTimeBetweenData.DataBindings.Add("SubText", _appViewModel.DigitalParams, "TimeBetweenData");
            btnHighSpeedRumbles.DataBindings.Add("SubText", this, "RumblesOnHighAcceleration");
            btnVibrationsStrongBrakes.DataBindings.Add("SubText", this, "RumblesOnStrongBraking");
            btnHighSpeedRumbles.DataBindings.Add("SubTextForeColor", this, "RumblesOnHighAccelerationColor");
            btnVibrationsStrongBrakes.DataBindings.Add("SubTextForeColor", this, "RumblesOnStrongBrakingColor");

            btnUseCarIdProgrammer.DataBindings.Add("ForeColor", this, "UseCarIdProgrammerColor");
            cbxCarIdProgrammerComPorts.DataBindings.Add("Visible", AppViewModel.DigitalParams, "UseCarIdProgrammer");
            btnTestCarIdProgrammerConnexion.DataBindings.Add("Visible", AppViewModel.DigitalParams, "UseCarIdProgrammer");


            cbxCarIdProgrammerComPorts.Items.Clear();

            if (_appViewModel.DigitalParams.OpenedComPort == null || _appViewModel.DigitalParams.OpenedComPort.Count == 0)
                Program.GetComPorts();

            if (_appViewModel.DigitalParams.OpenedComPort != null)
            {
                cbxCarIdProgrammerComPorts.Items.Add(string.Empty);
                foreach (string s in _appViewModel.DigitalParams.OpenedComPort)
                {
                    cbxCarIdProgrammerComPorts.Items.Add(s);
                }

                cbxCarIdProgrammerComPorts.SelectedItem = _appViewModel.DigitalParams.CarIdProgrammerComPort;
            }
        }

        public void ApplyChangesOnGlobalDatas()
        {
            GlobalDatas.INTERVALBETWEENTWOSIGNALS = _appViewModel.DigitalParams.TimeBetweenData;
            GlobalDatas.LOWFUELLEVEL = _appViewModel.DigitalParams.LowFuelLevel;
            GlobalDatas.LOWHEALTHLEVEL = _appViewModel.DigitalParams.LowHealthLevel;
            GlobalDatas.LOWTIRESLEVEL = _appViewModel.DigitalParams.LowTiresLevel;
            GlobalDatas.MAXACCELERATIONDELTA = _appViewModel.DigitalParams.MaxAccelerationDelta;
            GlobalDatas.MAXBRAKEINTERVAL = _appViewModel.DigitalParams.MaxBrakeIntervals;
        }

        #endregion

        private void btnHighSpeedRumbles_Click(object sender, EventArgs e)
        {
            _appViewModel.DigitalParams.RumblesOnHighAcceleration = !_appViewModel.DigitalParams.RumblesOnHighAcceleration;
            btnHighSpeedRumbles.DataBindings[0].ReadValue();
            btnHighSpeedRumbles.DataBindings[1].ReadValue();
        }

        private void btnVibrationsStrongBrakes_Click(object sender, EventArgs e)
        {
            _appViewModel.DigitalParams.RumblesOnStrongBraking = !_appViewModel.DigitalParams.RumblesOnStrongBraking;
            btnVibrationsStrongBrakes.DataBindings[0].ReadValue();
            btnVibrationsStrongBrakes.DataBindings[1].ReadValue();
        }

        private void btnTestConnexion_Click(object sender, EventArgs e)
        {
            if (Program._carIdProgrammer.IsConnected)
            {
                Program._carIdProgrammer.CloseConnexion();
                ChangeConnexionButtonColor();
            }
            else
            {
                if (!string.IsNullOrEmpty(cbxCarIdProgrammerComPorts.Text))
                {
                    AppViewModel.DigitalParams.CarIdProgrammerComPort = cbxCarIdProgrammerComPorts.Text;
                    Program.IniCarIdProgrammerConnexionThread(AppViewModel.DigitalParams);
                }


                Cursor = Cursors.WaitCursor;
                Thread.Sleep(1000);
                ChangeConnexionButtonColor();
                AppViewModel.SaveDigitalParams();
                Cursor = Cursors.Default;
            }

        }

        private void ChangeConnexionButtonColor()
        {
            if (!Program._carIdProgrammer.IsConnected)
            {
                btnTestCarIdProgrammerConnexion.ForeColor = Color.Red;
            }
            else
            {
                btnTestCarIdProgrammerConnexion.ForeColor = Color.Green;
            }
        }

        private void btnUseCarIdProgrammer_Click(object sender, EventArgs e)
        {
            AppViewModel.DigitalParams.UseCarIdProgrammer = !AppViewModel.DigitalParams.UseCarIdProgrammer;
            btnUseCarIdProgrammer.DataBindings["ForeColor"].ReadValue();
            cbxCarIdProgrammerComPorts.DataBindings["Visible"].ReadValue();
            btnTestCarIdProgrammerConnexion.DataBindings["Visible"].ReadValue();

            ChangeConnexionButtonColor();
       }
    }
}

