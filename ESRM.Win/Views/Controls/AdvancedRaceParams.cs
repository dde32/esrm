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

namespace ESRM.Win.Panels
{
    public partial class AdvancedRaceParams : ScalableControl
    {
        IESRMViewModel _appViewModel;
        public IESRMViewModel AppViewModel
        {
            get { return _appViewModel; }
        }

        public Color ColorManualRefuel
        {
            get
            {
                if (AppViewModel.CurrentRaceParameters != null && AppViewModel.CurrentRaceParameters.ManualRefuel)
                    return Color.Green;
                else
                    return Color.Red;
            }
        }

        public Color ColorRollingStart
        {
            get
            {
                if (AppViewModel.CurrentRaceParameters != null && AppViewModel.CurrentRaceParameters.RollingStartLapCount > 0)
                    return Color.Green;
                else
                    return Color.Red;
            }
        }

        public Color ColorJokerLaps
        {
            get
            {
                if (AppViewModel.CurrentRaceParameters != null && AppViewModel.CurrentRaceParameters.JokerLapCount > 0)
                    return Color.Green;
                else
                    return Color.Red;
            }
        }

        public Color ColorDeSlotAutoDetect
        {
            get
            {
                if (AppViewModel.CurrentRaceParameters != null && AppViewModel.CurrentRaceParameters.DeSlotAutoDetectDelay > 0)
                    return Color.Green;
                else
                    return Color.Red;
            }
        }
        public bool EnableJokerLap
        {
            get
            {
                return AppViewModel.CurrentRaceParameters.RaceType == RaceType.RallyCross;
            }
        }



        public string EndRaceTypeForUI
        {
            get
            {
                if (AppViewModel.CurrentRaceParameters.EndRaceType == Entities.EndRaceType.Standard)
                    return Textes.EndRaceType_Standard;
                else if (AppViewModel.CurrentRaceParameters.EndRaceType == Entities.EndRaceType.FirstFinish)
                    return Textes.EndRaceType_FirstFinish;
                else
                    return Textes.EndRaceType_AllFinish;
            }
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

        public AdvancedRaceParams()
        {
            InitializeComponent();
        }

        public void SetDatas(IESRMViewModel appViewModel)
        {
           _appViewModel = appViewModel;
            if (_appViewModel.CurrentRaceParameters.RepairSpeed == 0)
                _appViewModel.CurrentRaceParameters.RepairSpeed = 15;
            if (_appViewModel.CurrentRaceParameters.RefuelSpeed == 0)
                _appViewModel.CurrentRaceParameters.RefuelSpeed = 20;

            DoBinding();
        }


        #region BINDING

        protected override void DoBinding()
        {
            base.DoBinding();
            foreach (Control c in this.Controls)
                c.DataBindings.Clear();

            btnJokerLapCount.SubText = string.Empty;
            btnEndRace.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "EndRaceTypeForUI");
            btnJokerLapCount.DataBindings.Add("Enabled", this, "EnableJokerLap");
            
            btnAutoRefuel.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "ManualRefuel");
            btnAutoRefuel.DataBindings.Add("SubTextForeColor", this, "ColorManualRefuel");

            btnRollingStart.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "RollingStartLapCount");
            btnRollingStart.DataBindings.Add("SubTextForeColor", this, "ColorRollingStart");

            //btnDeslotAutoDetect.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "DeSlotAutoDetect");
            //btnDeslotAutoDetect.DataBindings.Add("SubTextForeColor", this, "ColorDeSlotAutoDetect");

            btnFuelSpeed.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "RefuelSpeed");
            btnMandatoryPitStops.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "MandatoryPitStopCount");
            btnMaxRepair.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "MaxRepairPercent");
            btnMinLapTime.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "MinLapTimeSeconds");
            btnRepairSpeed.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "RepairSpeed");
            btnDeslotAutoDetect2.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "DeSlotAutoDetectDelay");
            btnDeslotAutoDetect2.DataBindings.Add("SubTextForeColor", this, "ColorDeSlotAutoDetect");

            btnEnablePowerAdjustemen.DataBindings.Add("BoolValue", AppViewModel.CurrentRaceParameters, "EnablePowerAdjustement");
            btnMultiCarTeams.DataBindings.Add("BoolValue", AppViewModel.CurrentRaceParameters, "MultiCarTeams");
            btnOneByOneRace.DataBindings.Add("BoolValue", AppViewModel.CurrentRaceParameters, "OneByOneRace");
            btnMaxPower.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "CarsMaxPower");
            btnEnablePauseByPilot.DataBindings.Add("BoolValue", AppViewModel.CurrentRaceParameters, "EnablePauseWithGamePad");
            

            if (AppViewModel.CurrentRaceParameters.RaceType == RaceType.RallyCross)
            {
                btnJokerLapCount.Enabled = true;
                btnJokerLapCount.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "JokerLapCount");
                btnJokerLapCount.DataBindings.Add("SubTextForeColor", this, "ColorJokerLaps");
            }
            else
                btnJokerLapCount.Enabled = false;

        }


        #endregion

        private void btnEndRace_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                AppViewModel.CurrentRaceParameters.EndRaceType = AppViewModel.CurrentRaceParameters.EndRaceType + 1;
                if (AppViewModel.CurrentRaceParameters.EndRaceType > EndRaceType.AllMustFinish)
                    AppViewModel.CurrentRaceParameters.EndRaceType = EndRaceType.Standard;

                btnEndRace.DataBindings["SubText"].ReadValue();
            }

        }

        private void btnAutoRefuel_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                AppViewModel.CurrentRaceParameters.ManualRefuel = !AppViewModel.CurrentRaceParameters.ManualRefuel;
                btnAutoRefuel.DataBindings["SubText"].ReadValue();
                btnAutoRefuel.DataBindings["SubTextForeColor"].ReadValue();
            }
        }

        private void btnRollingStart_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                AppViewModel.CurrentRaceParameters.RollingStartLapCount = AppViewModel.CurrentRaceParameters.RollingStartLapCount + 1;
                if (AppViewModel.CurrentRaceParameters.RollingStartLapCount > 3)
                    AppViewModel.CurrentRaceParameters.RollingStartLapCount = 0;

                btnRollingStart.DataBindings["SubText"].ReadValue();
                btnRollingStart.DataBindings["SubTextForeColor"].ReadValue();
            }
        }

        private void btnOneByOneRace_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                AppViewModel.CurrentRaceParameters.OneByOneRace = !AppViewModel.CurrentRaceParameters.OneByOneRace;
                btnOneByOneRace.DataBindings["BoolValue"].ReadValue();
            }
        }

        private void btnEnablePowerAdjustemen_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                AppViewModel.CurrentRaceParameters.EnablePowerAdjustement = !AppViewModel.CurrentRaceParameters.EnablePowerAdjustement;
                btnEnablePowerAdjustemen.DataBindings["BoolValue"].ReadValue();
            }
        }

        private void btnMultiCarTeams_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                AppViewModel.CurrentRaceParameters.MultiCarTeams = !AppViewModel.CurrentRaceParameters.MultiCarTeams;
                btnMultiCarTeams.DataBindings["BoolValue"].ReadValue();
            }
        }

        private void btnEnablePauseByPilot_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                AppViewModel.CurrentRaceParameters.EnablePauseWithGamePad = !AppViewModel.CurrentRaceParameters.EnablePauseWithGamePad;
                btnEnablePauseByPilot.DataBindings["BoolValue"].ReadValue();
            }
        }

        //private void btnDeslotAutoDetect_Click(object sender, EventArgs e)
        //{
        //    if (AppViewModel != null)
        //    {
        //        AppViewModel.CurrentRaceParameters.DeSlotAutoDetect = !AppViewModel.CurrentRaceParameters.DeSlotAutoDetect;

        //        btnDeslotAutoDetect.DataBindings["SubText"].ReadValue();
        //        btnDeslotAutoDetect.DataBindings["SubTextForeColor"].ReadValue();
        //    }
        //}
    }
}
