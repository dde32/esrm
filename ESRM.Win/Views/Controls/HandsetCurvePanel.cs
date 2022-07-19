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
using DevExpress.XtraCharts;
using ESRM.HWInterfaces.Scalextric;

namespace ESRM.Win
{

    public partial class HandsetCurvePanel : ScalableControl 
    {

        HandsetThrottleCurve _initialCurve;
        HandsetThrottleCurve _currentCurve;
        int _laneId;
        bool _brakeCurves = false;

        System.Timers.Timer _calibrationTimer;
        TimeSpan? _calibrationBeginTime;
        float? _minTriggerValue;
        float? _maxTriggerValue;
        int _blinkCount;

        protected IESRMViewModel AppViewModel
        {
            get;
            set;
        }

        public HandsetThrottleCurve CurrentCurve
        {
            get { return _currentCurve; }
        }
        public HandsetThrottleCurve InitialCurve
        {
            get { return _initialCurve; }
        }
        
        public HandsetCurvePanel()
        {
            InitializeComponent();
            gridView1.CellValueChanged += GridView1_CellValueChanged;
            SetGridAndChartDataSource();
        }

        public void InitPanel(int laneId,IESRMViewModel appViewModel, HandsetThrottleCurve currentCurve)
        {
            _laneId = laneId;
            AppViewModel = appViewModel;
            _currentCurve = currentCurve;

            if (_currentCurve == null )
                _currentCurve = new HandsetThrottleCurve();

            if (_currentCurve.Values == null || _currentCurve.Values.Count == 0 || _currentCurve.MaxResultValue == _currentCurve.MinResultValue)
                _currentCurve.InitDefaultValues(false);

            _currentCurve.BeginUpdate();
            _initialCurve = _currentCurve;

            FillThCurvesComboBox();

            SetGridAndChartDataSource();             
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                //_gamePad.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FillThCurvesComboBox()
        {
            cbxThCurves.Items.Clear();
            cbxThCurves.SelectedItem = null;
            cbxThCurves.SelectedText = null;
            cbxThCurves.Text = string.Empty;
            cbxThCurves.Invalidate();
            cbxThCurves.Refresh();

            if (!_brakeCurves)
            {
                foreach (BaseThrottleCurve curve in AppViewModel.HandsetThrottleCurves)
                {
                    cbxThCurves.Items.Add(curve);
                }
            }
            //else
            //{
            //    foreach (BaseTriggerCurve curve in AppViewModel.GamePadBrakeCurves)
            //    {
            //        cbxThCurves.Items.Add(curve);
            //    }
            //}

        }


        private void SetGridAndChartDataSource()
        {
            if (_currentCurve != null)
                gridControl1.DataSource = _currentCurve.Values;
            else
                gridControl1.DataSource = null;

            gridControl1.RefreshDataSource();

            SetChartDataSource();
        }

        private void SetChartDataSource()
        {
            if (_currentCurve != null)
            {
                List<TriggerValue> _tmp = new List<TriggerValue>();
                foreach (TriggerValue t in _currentCurve.Values)
                    _tmp.Add(new TriggerValue(t.Value, t.ResultValue));
                chartControl1.DataSource = _tmp;

                chartControl1.Series[0].ArgumentDataMember = "Value";
                chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "ResultValue" });
            }
            else
                chartControl1.DataSource = null;
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle == 0)
                _currentCurve.MinResultValue = (int)e.Value;
            else if (gridView1.FocusedRowHandle == _currentCurve.Values.Count - 1)
                _currentCurve.MaxResultValue = (int)e.Value;


            // linéarisation vers la fin de la courbe
            int start = gridView1.FocusedRowHandle;
            int end = _currentCurve.Values.Count - 1;
            var startValue = gridView1.GetRowCellValue(start, Result);
            var endValue = gridView1.GetRowCellValue(end, Result);


            string linearizeMessage = string.Format(Textes.MessageLinearize, startValue, endValue);

            if (MessageBox.Show(linearizeMessage, "ESRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(!_brakeCurves)
                    _currentCurve.SmoothCurve(start, end, (int)startValue, (int)endValue);
                else
                    _currentCurve.SmoothCurveForBrakes(start, end, (int)startValue, (int)endValue);
            }

            if (start > 0)
            {
                // linéarisation vers le début de la courbe
                start = 0;
                end = gridView1.FocusedRowHandle;
                startValue = gridView1.GetRowCellValue(start, Result);
                endValue = gridView1.GetRowCellValue(end, Result);
                linearizeMessage = string.Format(Textes.MessageLinearize, startValue, endValue);
                if (MessageBox.Show(linearizeMessage, "ESRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!_brakeCurves)
                        _currentCurve.SmoothCurve(start, end, (int)startValue, (int)endValue);
                    else
                        _currentCurve.SmoothCurveForBrakes(start, end, (int)startValue, (int)endValue);
                }
            }
            SetGridAndChartDataSource();
        }

        private void cbxThCurves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_currentCurve != null)
                _currentCurve.CancelUpdate();

            if (cbxThCurves.SelectedItem != null)
            {
                _currentCurve = cbxThCurves.SelectedItem as HandsetThrottleCurve;
                _currentCurve.BeginUpdate();
                SetGridAndChartDataSource();
            }
        }

        private void btnRAZ_Click(object sender, EventArgs e)
        {
            _currentCurve.InitDefaultValues(_brakeCurves);
            SetGridAndChartDataSource();
        }

        private void btnSmooth_Click(object sender, EventArgs e)
        {
            int[] selection = gridView1.GetSelectedRows();

            if (selection.Length > 1)
            {
                var startValue = gridView1.GetRowCellValue(selection[0], Result);
                var endValue = gridView1.GetRowCellValue(selection[selection.Length - 1], Result);

                _currentCurve.SmoothCurve(selection[0], selection[selection.Length - 1], (int)startValue, (int)endValue);

                SetGridAndChartDataSource();
            }
        }

        public void CancelEdition()
        {
            _currentCurve.CancelUpdate();
            SetGridAndChartDataSource();
        }

        #region CRUD

        private void btnSaveThCurve_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentCurve.Title))
                btnSaveThCurveAs_Click(sender, e);
            else
            {
                AppViewModel.SaveCurves();
                _currentCurve.BeginUpdate();
            }

        }

        private void btnSaveThCurveAs_Click(object sender, EventArgs e)
        {
            TextBoxDlg dlg = new TextBoxDlg("new curve");
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                HandsetThrottleCurve newCurve = new HandsetThrottleCurve(_currentCurve);
                _currentCurve.CancelUpdate();
                newCurve.Title = dlg.EditValue;

                AppViewModel.HandsetThrottleCurves.Add(newCurve);

                AppViewModel.SaveCurves();
                _currentCurve = newCurve;
                _currentCurve.BeginUpdate();
                FillThCurvesComboBox();
            }
        }

        private void btnNewCurve_Click(object sender, EventArgs e)
        {
            HandsetThrottleCurve newCurve = new HandsetThrottleCurve();
            newCurve.InitDefaultValues(false);
            newCurve.Title = "new curve";
            AppViewModel.HandsetThrottleCurves.Add(newCurve);
            _currentCurve = newCurve;
            _currentCurve.BeginUpdate();
            FillThCurvesComboBox();
        }

        private void btnDeleteThCurve_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(Textes.MessageConfirmDelete, "ESRM",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                AppViewModel.HandsetThrottleCurves.Remove(_currentCurve);

                AppViewModel.SaveCurves();
                FillThCurvesComboBox();
                cbxThCurves.SelectedItem = null;
                _currentCurve = null;

                SetGridAndChartDataSource();
            }
        }

        #endregion CRUD

        #region CALIBRATION  HandSet
        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            // calibration
            // on fait un check pendant 4 secondes.
            // on cacth les valeurs du trigger toutes les 50 ms
            // a la fin, on cherche le min et le max.
            // le min servira de point de départ de la courbe
            // le max servira de fin.
            // si le handset n'a pas encore de courbe, alors on en crée une linéaire avec min et max modifié

            if (_calibrationTimer == null)
            {
                _calibrationTimer = new System.Timers.Timer();
                _calibrationTimer.Interval = 50;
                _calibrationTimer.Elapsed += _calibrationTimer_Elapsed;
                _calibrationTimer.Enabled = true;
                _calibrationTimer.Start();
            }
            else
            {
                _calibrationTimer.Stop();
                _calibrationTimer.Enabled = true;
                _calibrationTimer.Start();
            }

            _calibrationBeginTime = null;
            _minTriggerValue = null;
            _maxTriggerValue = null;
            lblCalibrationMessage.Visible = true;
            Program.hwInterface.DataReceived += HwInterface_DataReceived;

        }

        private void HwInterface_DataReceived(object sender, PBReceiveDataEventArgs e)
        {
            PB6RecievedPacket rPacket = e.DataPacket as PB6RecievedPacket;

            int power = 0;
            switch (_laneId)
            {
                case 1:
                    power = rPacket.DrivePacket1.Power;
                    break;
                case 2:
                    power = rPacket.DrivePacket2.Power;
                    break;
                case 3:
                    power = rPacket.DrivePacket3.Power;
                    break;
                case 4:
                    power = rPacket.DrivePacket4.Power;
                    break;
                case 5:
                    power = rPacket.DrivePacket5.Power;
                    break;
                case 6:
                    power = rPacket.DrivePacket6.Power;
                    break;
            }


            if (!_maxTriggerValue.HasValue || power > _maxTriggerValue)
                _maxTriggerValue = power;
            else if (!_minTriggerValue.HasValue || power < _minTriggerValue)
                _minTriggerValue = power;
        }

        private void _calibrationTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_maxTriggerValue.HasValue && _maxTriggerValue > 0 && !_calibrationBeginTime.HasValue)
                _calibrationBeginTime = DateTime.Now.TimeOfDay;

            _blinkCount++;
            if (!_calibrationBeginTime.HasValue || DateTime.Now.TimeOfDay < _calibrationBeginTime.Value.Add(new TimeSpan(0, 0, 4)))
            {
                if (_blinkCount == 4)
                {
                    _blinkCount = 0;
                    if (lblCalibrationMessage.ForeColor == Color.YellowGreen)
                        lblCalibrationMessage.ForeColor = Color.White;
                    else
                        lblCalibrationMessage.ForeColor = Color.YellowGreen;
                }
            }
            else
                EndCalibration();
        }

        private void EndCalibration()
        {
            Program.hwInterface.DataReceived -= HwInterface_DataReceived;
            _blinkCount = 0;

            lblCalibrationMessage.ForeColor = Color.YellowGreen;
            _calibrationTimer.Stop();
            _calibrationTimer.Enabled = false;

            _currentCurve.MinTriggerValue = (int)_minTriggerValue;
            _currentCurve.MaxTriggerValue = (int)_maxTriggerValue;
            _currentCurve.InitDefaultValues((int)_minTriggerValue, (int)_maxTriggerValue,0,63);

            InitialCurve.MinTriggerValue = (int)_minTriggerValue;
            InitialCurve.MaxTriggerValue = (int)_maxTriggerValue;
            InitialCurve.InitDefaultValues((int)_minTriggerValue, (int)_maxTriggerValue, 0, 63);

            SetGridAndChartDataSource();
            //lblCalibrationMessage.Visible = false;

        }


        #endregion CALIBRATION 


        private void chartControl1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ChartHitInfo hi = chartControl1.CalcHitInfo(e.X, e.Y);
            
            var hitInfo = chartControl1.CalcHitInfo(chartControl1.PointToClient(MousePosition));
            if (hitInfo.InSeriesPoint)
            {
                double value = hitInfo.SeriesPoint.Values[0];
                double argument = hitInfo.SeriesPoint.NumericalArgument;
                //MessageBox.Show(string.Format("Argument: {0}, Vlaue: {1}", argument, value));
                int index = chartControl1.Series[0].Points.FindIndex(p => p.ArgumentX.NumericalArgument == argument);

                gridView1.ClearSelection();
                gridView1.SelectRow(index);
                gridView1.FocusedRowHandle = index;

            }



        }


    }
}
