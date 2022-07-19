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
using ESRM.GamePads;

namespace ESRM.Win
{

    public partial class CalibrationDialog : Form
    {
        GlobalGamePadHandSet _gamePad;

        protected IESRMViewModel AppViewModel
        {
            get;
            set;
        }

        public GamePadThrottleCurve InitialThrottleCurve
        {
            get { return ThrottleCurvePanel.InitialCurve; }
        }
        public GamePadThrottleCurve CurrentThrottleCurve
        {
            get { return ThrottleCurvePanel.CurrentCurve; }
        }
        public GamePadThrottleCurve CurrentBrakeCurve
        {
            get { return BrakeCurvePanel.CurrentCurve; }
        }

        public GamePadThrottleCurve InitialBrakeCurve
        {
            get { return BrakeCurvePanel.InitialCurve; }
        }

        public CalibrationDialog()
        {
            InitializeComponent();
        }
        
        public CalibrationDialog(EsrmPlayerIndex gamePadPlayerIndex,IESRMViewModel appViewModel,bool inCarPro,Pilot driver,Color curveColor)
        {
            InitializeComponent();

            _gamePad = GamePadFactory.GetGamePad((EsrmPlayerIndex)gamePadPlayerIndex);
            AppViewModel = appViewModel;

            ThrottleCurvePanel.InitPanel(_gamePad, appViewModel, driver.GamePadThrottleCurve, false, false, driver.FavoriteGamePadThrottleCurveTitles,curveColor);
            BrakeCurvePanel.InitPanel(_gamePad, appViewModel, inCarPro ? driver.GamePadInCarProBrakeCurve : driver.GamePadBrakeCurve, inCarPro, true, inCarPro ? driver.FavoriteGamePadInCarProBrakeCurveTitles : driver.FavoriteGamePadBrakeCurvesTitles, curveColor);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();

                ThrottleCurvePanel.Dispose();
                BrakeCurvePanel.Dispose();

                _gamePad.Dispose();
            }
            base.Dispose(disposing);
        }

 
        private void btnOk_Click(object sender, EventArgs e)
        {
            ThrottleCurvePanel.AddCurrentCurveToFavorites();
            BrakeCurvePanel.AddCurrentCurveToFavorites();

            AppViewModel.SaveCurves();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CurrentThrottleCurve.CancelUpdate();
            CurrentBrakeCurve.CancelUpdate();
            Close();
        }

        private void btnAccelParams_Click(object sender, EventArgs e)
        {
            btnAccelParams.ForeColor = Color.YellowGreen;
            btnbrakeParams.ForeColor = Color.DimGray;
            ThrottleCurvePanel.Visible = true;
            ThrottleCurvePanel.Enabled = true;
            BrakeCurvePanel.Visible = false;
            BrakeCurvePanel.Enabled = false;
        }

        private void btnbrakeParams_Click(object sender, EventArgs e)
        {
            btnbrakeParams.ForeColor = Color.YellowGreen;
            btnAccelParams.ForeColor = Color.DimGray;
            ThrottleCurvePanel.Visible = false;
            ThrottleCurvePanel.Enabled = false;
            BrakeCurvePanel.Visible = true;
            BrakeCurvePanel.Enabled = true;
        }
    }
}
