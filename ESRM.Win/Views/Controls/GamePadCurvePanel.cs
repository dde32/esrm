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
using ESRM.GamePads;
using System.Threading;

namespace ESRM.Win
{

    public partial class GamePadCurvePanel : ScalableControl, IDisposable
    {

        GamePadThrottleCurve _initialCurve;
        GamePadThrottleCurve _currentCurve;
        List<string> _favoriteCurves;
        GlobalGamePadHandSet _gamePad;
        bool _brakeCurves;
        bool _icp;

        System.Timers.Timer _calibrationTimer;
        TimeSpan? _calibrationBeginTime;
        float? _minTriggerValue;
        float? _maxTriggerValue;
        int _blinkCount;
        int _currentIdx = 0;
        BackgroundWorker _gpWorker;

        protected IESRMViewModel AppViewModel
        {
            get;
            set;
        }

        public GamePadThrottleCurve CurrentCurve
        {
            get { return _currentCurve; }
        }
        public GamePadThrottleCurve InitialCurve
        {
            get { return _initialCurve; }
        }
        
        public GamePadCurvePanel()
        {
            InitializeComponent();
            gridView1.CellValueChanged += GridView1_CellValueChanged;
            SetGridAndChartDataSource();

            _gpWorker = new BackgroundWorker();
            _gpWorker.WorkerSupportsCancellation = true;
            _gpWorker.WorkerReportsProgress = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                if (_gpWorker != null)
                {
                    _gpWorker.CancelAsync();
                    Thread.Sleep(50);
                    _gpWorker.Dispose();
                    _gpWorker = null;
                }

            }
            base.Dispose(disposing);
        }

        public void InitPanel(GlobalGamePadHandSet gamePad,IESRMViewModel appViewModel, GamePadThrottleCurve currentCurve,bool ICP, bool brakeCurves,List<string> favoriteCurves,Color curveColor)
        {
            _icp = ICP;
            _brakeCurves = brakeCurves;
            _gamePad = gamePad;
            AppViewModel = appViewModel;
            _currentCurve = currentCurve;
            _favoriteCurves = favoriteCurves;
            chartControl1.Series[0].View.Color = curveColor;

            if (_currentCurve == null )
            {
                if(!brakeCurves)
                    _currentCurve = new GamePadThrottleCurve();
                else
                    _currentCurve = new GamePadThrottleCurve(0,12);
            }

            if (_currentCurve.Values == null || _currentCurve.Values.Count == 0 || _currentCurve.MaxResultValue == _currentCurve.MinResultValue)
                _currentCurve.InitDefaultValues(brakeCurves && !_icp);

            _currentCurve.BeginUpdate();
            _initialCurve = _currentCurve;

            FillThCurvesComboBox();

            if(!string.IsNullOrEmpty(_currentCurve.Title))
            {
                if (cbxThCurves.Items.Contains(_currentCurve))
                    cbxThCurves.SelectedItem = _currentCurve;
            }

            SetGridAndChartDataSource();             
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
                foreach (BaseThrottleCurve curve in AppViewModel.GamePadThrottleCurves)
                {
                    cbxThCurves.Items.Add(curve);
                }
            }
            else
            {
                if (_icp)
                {
                    foreach (BaseThrottleCurve curve in AppViewModel.GamePadICPBrakesCurves)
                    {
                        cbxThCurves.Items.Add(curve);
                    }
                }
                else
                {
                    foreach (BaseThrottleCurve curve in AppViewModel.GamePadBrakeCurves)
                    {
                        cbxThCurves.Items.Add(curve);
                    }
                }
            }

            //cbxThCurves.SelectedItem = _currentCurve;
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
            }
            else
                chartControl1.DataSource = null;

            chartControl1.Series[0].ArgumentDataMember = "Value";
            chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "ResultValue" });
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
            if(_currentCurve != null)
                 _currentCurve.CancelUpdate();
            if (cbxThCurves.SelectedItem != null)
            {
                _currentCurve = cbxThCurves.SelectedItem as GamePadThrottleCurve;
                _currentCurve.BeginUpdate();
                SetGridAndChartDataSource();

                toggleSwitch1.EditValue = _favoriteCurves.Contains(_currentCurve.Title);
            }
        }

        private void btnRAZ_Click(object sender, EventArgs e)
        {
            _currentCurve.InitDefaultValues(_brakeCurves && !_icp);
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
                GamePadThrottleCurve newCurve = new GamePadThrottleCurve(_currentCurve);
                _currentCurve.CancelUpdate();
                newCurve.Title = dlg.EditValue;
                if (!_brakeCurves)
                    AppViewModel.GamePadThrottleCurves.Add(newCurve);
                else
                {
                    if(_icp)
                        AppViewModel.GamePadICPBrakesCurves.Add(newCurve);
                    else
                    AppViewModel.GamePadBrakeCurves.Add(newCurve);
                }

                AppViewModel.SaveCurves();
                _currentCurve = newCurve;
                _currentCurve.BeginUpdate();
                FillThCurvesComboBox();

                if (cbxThCurves.Items.Contains(_currentCurve))
                    cbxThCurves.SelectedItem = _currentCurve;

                SetGridAndChartDataSource();
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            TextBoxDlg dlg = new TextBoxDlg("new curve");
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                GamePadThrottleCurve newCurve = new GamePadThrottleCurve();
                newCurve.InitDefaultValues(_brakeCurves && !_icp);
                newCurve.Title = dlg.EditValue;
                if (!_brakeCurves)
                    AppViewModel.GamePadThrottleCurves.Add(newCurve);
                else
                {
                    if(_icp)
                        AppViewModel.GamePadICPBrakesCurves.Add(newCurve);
                    else
                        AppViewModel.GamePadBrakeCurves.Add(newCurve);
                }
                _currentCurve = newCurve;
                _currentCurve.BeginUpdate();
                FillThCurvesComboBox();

                if (cbxThCurves.Items.Contains(_currentCurve))
                    cbxThCurves.SelectedItem = _currentCurve;

                SetGridAndChartDataSource();
            }
        }

        private void btnDeleteThCurve_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(Textes.MessageConfirmDelete, "ESRM",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (!_brakeCurves)
                    AppViewModel.GamePadThrottleCurves.Remove(_currentCurve);
                else
                {
                    if(_icp)
                        AppViewModel.GamePadICPBrakesCurves.Remove(_currentCurve);
                    else
                        AppViewModel.GamePadBrakeCurves.Remove(_currentCurve);
                }

                AppViewModel.SaveCurves();
                FillThCurvesComboBox();
                cbxThCurves.SelectedItem = null;
                _currentCurve = null;

                SetGridAndChartDataSource();
            }
        }

        #endregion CRUD

        #region CALIBRATION  GAMEPAD
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
        }

        private void _calibrationTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(_maxTriggerValue.HasValue && _maxTriggerValue > 0 && !_calibrationBeginTime.HasValue)
                _calibrationBeginTime = DateTime.Now.TimeOfDay;

            _blinkCount++;
            if (!_calibrationBeginTime.HasValue || DateTime.Now.TimeOfDay < _calibrationBeginTime.Value.Add(new TimeSpan(0, 0, 4)) )
            {
                _gamePad.CheckStates();
                if (!_maxTriggerValue.HasValue || _gamePad.RightTriggerValue > _maxTriggerValue)
                    _maxTriggerValue = (float)_gamePad.RightTriggerValue;
                else if (!_minTriggerValue.HasValue || _gamePad.RightTriggerValue < _minTriggerValue)
                    _minTriggerValue = (float)_gamePad.RightTriggerValue;

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
            lblCalibrationMessage.ForeColor = Color.YellowGreen;
            _calibrationTimer.Stop();
            _calibrationTimer.Enabled = false;
            lblCalibrationMessage.Visible = false;
            _blinkCount = 0;

            _currentCurve.MinTriggerValue = (int)_minTriggerValue;
            _currentCurve.MaxTriggerValue = (int)_maxTriggerValue;
            _currentCurve.InitDefaultValues(false);

            InitialCurve.MinTriggerValue = (int)_minTriggerValue;
            InitialCurve.MaxTriggerValue = (int)_maxTriggerValue;
            InitialCurve.InitDefaultValues(false);

            SetGridAndChartDataSource();
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

        private void edtContinuousBrakeCount_TextChanged(object sender, EventArgs e)
        {
            //_currentCurve.ContinuousBrakeCount = Convert.ToInt32(edtContinuousBrakeCount.Text);
        }


        #region MODIFICATION DE LA COURBE AVEC BOUTONS OU GAMEPAD


        private void btnChangeWithPad_Click(object sender, EventArgs e)
        {
            btnCenterCurve_Click(null, null);

            if (_gpWorker.IsBusy)
            {
                _gpWorker.CancelAsync();
                _gpWorker.DoWork -= Worker_DoWork;
                _gpWorker.ProgressChanged -= gpWorker_ProgressChanged;
            }
            else
            {
                _gpWorker.DoWork += Worker_DoWork;
                _gpWorker.RunWorkerAsync();
                _gpWorker.ProgressChanged += gpWorker_ProgressChanged;
            }
        }

        private void gpWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SmoothCurveAfterDpadModification();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckButtonStateLoop();
        }



        private void CheckButtonStateLoop()
        {
            while (true)
            {
                Thread.Sleep(30);
                try
                {
                    _gamePad.CheckStates();
                    if (_gamePad.LeftThumbstickX > 0.5)
                    {
                        RightCurve();
                        _gpWorker.ReportProgress(1);
                    }
                    else if (_gamePad.LeftThumbstickX < -0.5)
                    {
                        LeftCurve();
                        _gpWorker.ReportProgress(100);
                    }
                    if (_gamePad.LeftThumbstickY > 0.5)
                    {
                        UpCurve();
                        _gpWorker.ReportProgress(100);
                    }
                    else if (_gamePad.LeftThumbstickY < -0.5)
                    {
                        DownCurve();
                        _gpWorker.ReportProgress(100);
                    }

                }
                catch (Exception ex)
                {
                }
            }
        }

        private void RightCurve()
        {
            _currentIdx++;

            if (_currentIdx > _currentCurve.Values.Count - 1)
                _currentIdx = _currentCurve.Values.Count - 1;

            _currentCurve.Values[_currentIdx].ResultValue = _currentCurve.Values[_currentIdx - 1].ResultValue;

        }

        private void LeftCurve()
        {
            _currentIdx--;
            if (_currentIdx < 0)
                _currentIdx = 0;

            _currentCurve.Values[_currentIdx].ResultValue = _currentCurve.Values[_currentIdx + 1].ResultValue;
        }

        private void DownCurve()
        {
            _currentCurve.Values[_currentIdx].ResultValue--;
            if(_currentCurve.Values[_currentIdx].ResultValue < 0)
                _currentCurve.Values[_currentIdx].ResultValue = 0;
        }
        private void UpCurve()
        {
            _currentCurve.Values[_currentIdx].ResultValue++;
            if (_currentCurve.Values[_currentIdx].ResultValue > (int)_currentCurve.MaxResultValue)
                _currentCurve.Values[_currentIdx].ResultValue = (int)_currentCurve.MaxResultValue;
        }


        private void SmoothCurveAfterDpadModification()
        {
            if (_currentIdx < _currentCurve.Values.Count / 2)
            {
                _currentCurve.SmoothCurve(0, _currentIdx, _currentCurve.Values[0].ResultValue, _currentCurve.Values[_currentIdx].ResultValue);
                _currentCurve.SmoothCurve(_currentIdx, _currentCurve.Values.Count - 1, _currentCurve.Values[_currentIdx].ResultValue, _currentCurve.Values[_currentCurve.Values.Count - 1].ResultValue);
            }
            else
            {
                _currentCurve.SmoothCurve(_currentIdx, _currentCurve.Values.Count - 1, _currentCurve.Values[_currentIdx].ResultValue, _currentCurve.Values[_currentCurve.Values.Count - 1].ResultValue);
                _currentCurve.SmoothCurve(0, _currentIdx, _currentCurve.Values[0].ResultValue, _currentCurve.Values[_currentIdx].ResultValue);
            }

            SetGridAndChartDataSource();
        }
        private void btnCenterCurve_Click(object sender, EventArgs e)
        {
            _currentIdx = _currentCurve.Values.Count / 2;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            RightCurve();
            SmoothCurveAfterDpadModification();
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            LeftCurve();
            SmoothCurveAfterDpadModification();
        }


        private void btnDownCurve_Click(object sender, EventArgs e)
        {
            DownCurve();
            SmoothCurveAfterDpadModification();
        }



        private void btnUpCurve_Click(object sender, EventArgs e)
        {
            UpCurve();
            SmoothCurveAfterDpadModification();
        }

        #endregion

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn && !_favoriteCurves.Contains(_currentCurve.Title))
            {
                AddCurrentCurveToFavorites();
            }
            else if (!toggleSwitch1.IsOn && _favoriteCurves.Contains(_currentCurve.Title))
                _favoriteCurves.RemoveAll(c => c ==_currentCurve.Title);
        }

        public void AddCurrentCurveToFavorites()
        {
            if (string.IsNullOrEmpty(_currentCurve.Title))
                btnSaveThCurveAs_Click(null, null);
            if(!_favoriteCurves.Contains(_currentCurve.Title))
                _favoriteCurves.Add(_currentCurve.Title);

        }
    }
}

