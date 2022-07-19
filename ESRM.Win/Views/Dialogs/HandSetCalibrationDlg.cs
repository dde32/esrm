using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using ESRM.Entities;
using ESRM.Win.Panels;

namespace ESRM.Win
{

    public partial class HandSetCalibrationDlg : Form
    {
        protected IESRMViewModel AppViewModel
        {
            get;
            set;
        }

        public HandsetThrottleCurve InitialThrottleCurve
        {
            get { return ThrottleCurvePanel.InitialCurve; }
        }
        public HandsetThrottleCurve CurrentThrottleCurve
        {
            get { return ThrottleCurvePanel.CurrentCurve; }
        }

        public HandSetCalibrationDlg()
        {
            InitializeComponent();
        }
        
        public HandSetCalibrationDlg(int laneId,IESRMViewModel appViewModel, HandsetThrottleCurve currentThrottleCurve)
        {
            InitializeComponent();
            AppViewModel = appViewModel;
            ThrottleCurvePanel.InitPanel(laneId,appViewModel, currentThrottleCurve);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

 
        private void btnOk_Click(object sender, EventArgs e)
        {
            AppViewModel.SaveCurves();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CurrentThrottleCurve.CancelUpdate();
            Close();
        }
    }
}
