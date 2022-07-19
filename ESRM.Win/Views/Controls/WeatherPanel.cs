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
using ESRM.Entities.Weather;

namespace ESRM.Win.Panels
{
    public partial class WeatherPanel: ScalableControl
    {
        protected IESRMViewModel _appViewModel;

        #region

        public Image WeatherImage
        {
            get { return GetWeatherImage(_appViewModel.CurrentRaceParameters.WeatherParams.InitialWeather); }
        }

        public Color ColorShowOptimalTiresType
        {
            get
            {
                if (_appViewModel.CurrentRaceParameters != null && _appViewModel.CurrentRaceParameters.ShowOptimalTiresType)
                    return Color.Green;
                else
                    return Color.Red;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, _appViewModel.CurrentRaceParameters.WeatherParams.StartTime.Hours, _appViewModel.CurrentRaceParameters.WeatherParams.StartTime.Minutes, _appViewModel.CurrentRaceParameters.WeatherParams.StartTime.Seconds);
            }
            set
            {
                _appViewModel.CurrentRaceParameters.WeatherParams.StartTime = new TimeSpan(value.Hour, value.Minute, 0);
                _appViewModel.CurrentRaceParameters.WeatherParams.PassNight = _appViewModel.CurrentRaceParameters.WeatherParams.EndTime.Hours > 19 || _appViewModel.CurrentRaceParameters.WeatherParams.EndTime <= _appViewModel.CurrentRaceParameters.WeatherParams.StartTime;

            }
        }

        public DateTime EndTime
        {
            get
            {
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, _appViewModel.CurrentRaceParameters.WeatherParams.EndTime.Hours, _appViewModel.CurrentRaceParameters.WeatherParams.EndTime.Minutes, _appViewModel.CurrentRaceParameters.WeatherParams.StartTime.Seconds);
            }
            set
            {
                _appViewModel.CurrentRaceParameters.WeatherParams.EndTime = new TimeSpan(value.Hour, value.Minute, 0);
                _appViewModel.CurrentRaceParameters.WeatherParams.PassNight = _appViewModel.CurrentRaceParameters.WeatherParams.EndTime.Hours > 19 || _appViewModel.CurrentRaceParameters.WeatherParams.EndTime <= _appViewModel.CurrentRaceParameters.WeatherParams.StartTime;
            }
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
            }

            base.Dispose(disposing);
        }

        public WeatherPanel()
        {
            InitializeComponent();
            _originalSize = Size;
        }

        public void SetDatas(IESRMViewModel appViewModel)
        {
            _appViewModel = appViewModel;
            if (_appViewModel.CurrentRaceParameters.WeatherParams == null)
                _appViewModel.CurrentRaceParameters.WeatherParams = new WeatherParams();

            if(_appViewModel.CurrentRaceParameters.WeatherParams.MinTemperature == 0)
                _appViewModel.CurrentRaceParameters.WeatherParams.RandomInit();
            DoBinding();


        }

        #region BINDING



        protected override void DoBinding()
        {
            base.DoBinding();

            btnEvolFrequency.DataBindings.Clear();
            btnRainRisk.DataBindings.Clear();
            btnShowOptimalTiresType.DataBindings.Clear();
            lblMaxTemp.DataBindings.Clear();
            lblMinTemp.DataBindings.Clear();
            pbWeather.DataBindings.Clear();
            edtTemp.DataBindings.Clear();
            dtStartTime.DataBindings.Clear();
            dtEndTme.DataBindings.Clear();
            lblEvoleInterval.DataBindings.Clear();
            lblAvgLapTime.DataBindings.Clear();
            chkBxRainSound.DataBindings.Clear();

            
            btnEvolFrequency.DataBindings.Add("SubText", _appViewModel.CurrentRaceParameters.WeatherParams, "EvolutionFrequency");
            btnRainRisk.DataBindings.Add("SubText", _appViewModel.CurrentRaceParameters.WeatherParams, "RainRisk");

            btnShowOptimalTiresType.DataBindings.Add("Enabled", _appViewModel.CurrentRaceParameters, "UseWeatherConditions");
            btnShowOptimalTiresType.DataBindings.Add("SubText", _appViewModel.CurrentRaceParameters, "ShowOptimalTiresType");
            btnShowOptimalTiresType.DataBindings.Add("SubTextForeColor", this, "ColorShowOptimalTiresType");

            lblMaxTemp.DataBindings.Add("Text", _appViewModel.CurrentRaceParameters.WeatherParams, "MaxTemperature");
            lblMinTemp.DataBindings.Add("Text", _appViewModel.CurrentRaceParameters.WeatherParams, "MinTemperature");

            pbWeather.DataBindings.Add("Image", this, "WeatherImage");
            edtTemp.DataBindings.Add("Value", _appViewModel.CurrentRaceParameters.WeatherParams, "InitialTemperature");

            dtStartTime.DataBindings.Add("Value", this, "StartTime");
            dtEndTme.DataBindings.Add("Value", this, "EndTime");
            //btnPassNight.DataBindings.Add("ForeColor", this, "PassNightColor");

            lblAvgLapTime.DataBindings.Add("Text", _appViewModel.CurrentRaceParameters.WeatherParams, "AverageLaptimeSeconds");
            lblEvoleInterval.DataBindings.Add("Text", _appViewModel.CurrentRaceParameters.WeatherParams, "MinEvolutionLapCount");
            chkBxRainSound.DataBindings.Add("Checked", _appViewModel.DigitalParams, "RainSound");
        }

        public override void DeepRefresh()
        {
            base.DeepRefresh();
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


        #endregion

        private void btnRandomWeather_Click(object sender, EventArgs e)
        {
            _appViewModel.CurrentRaceParameters.WeatherParams.RandomInit();
            DeepRefresh();
        }

        private void btnDownMinTemp_Click(object sender, EventArgs e)
        {
            if (_appViewModel.CurrentRaceParameters.WeatherParams.MinTemperature <= 5)
                _appViewModel.CurrentRaceParameters.WeatherParams.MinTemperature = 5;
            else
                _appViewModel.CurrentRaceParameters.WeatherParams.MinTemperature--;
            DeepRefresh();
        }

        private void btnUpMinTemp_Click(object sender, EventArgs e)
        {
            if (_appViewModel.CurrentRaceParameters.WeatherParams.MinTemperature >= 20)
                _appViewModel.CurrentRaceParameters.WeatherParams.MinTemperature = 20;
            else
                _appViewModel.CurrentRaceParameters.WeatherParams.MinTemperature++;
            DeepRefresh();
        }

        private void btnDownMaxTemp_Click(object sender, EventArgs e)
        {
            if (_appViewModel.CurrentRaceParameters.WeatherParams.MaxTemperature <= 10)
                _appViewModel.CurrentRaceParameters.WeatherParams.MaxTemperature = 10;
            else
                _appViewModel.CurrentRaceParameters.WeatherParams.MaxTemperature--;
            DeepRefresh();
        }

        private void btnMaxTemp_Click(object sender, EventArgs e)
        {
            if (_appViewModel.CurrentRaceParameters.WeatherParams.MaxTemperature >= 35)
                _appViewModel.CurrentRaceParameters.WeatherParams.MaxTemperature = 35;
            else
                _appViewModel.CurrentRaceParameters.WeatherParams.MaxTemperature++;
            DeepRefresh();
        }

        private void btnNextWeather_Click(object sender, EventArgs e)
        {
            _appViewModel.CurrentRaceParameters.WeatherParams.InitialWeather++;

            if (_appViewModel.CurrentRaceParameters.WeatherParams.InitialWeather > WeatherEnum.Raining)
                _appViewModel.CurrentRaceParameters.WeatherParams.InitialWeather = WeatherEnum.Sunny;

            pbWeather.DataBindings["Image"].ReadValue();
            DeepRefresh();
        }

        private void btnRainRisk_Click(object sender, EventArgs e)
        {
            _appViewModel.CurrentRaceParameters.WeatherParams.RainRisk++;

            if (_appViewModel.CurrentRaceParameters.WeatherParams.RainRisk> RainriskEnum.High)
                _appViewModel.CurrentRaceParameters.WeatherParams.RainRisk = RainriskEnum.Low;
            DeepRefresh();
        }

        private void btnEvolFrequency_Click(object sender, EventArgs e)
        {
            _appViewModel.CurrentRaceParameters.WeatherParams.EvolutionFrequency++;

            if (_appViewModel.CurrentRaceParameters.WeatherParams.EvolutionFrequency > WeatherChangeFrequencyEnum.Slow)
                _appViewModel.CurrentRaceParameters.WeatherParams.EvolutionFrequency = WeatherChangeFrequencyEnum.Quick;

            DeepRefresh();
        }

        private void btnPassNight_Click(object sender, EventArgs e)
        {
        }

        private void btnDownLapTime_Click(object sender, EventArgs e)
        {
            if (_appViewModel.CurrentRaceParameters.WeatherParams.AverageLaptimeSeconds <= 1)
                _appViewModel.CurrentRaceParameters.WeatherParams.AverageLaptimeSeconds = 1;
            else
                _appViewModel.CurrentRaceParameters.WeatherParams.AverageLaptimeSeconds--;

            DeepRefresh();
        }

        private void btnUpLapTime_Click(object sender, EventArgs e)
        {
            _appViewModel.CurrentRaceParameters.WeatherParams.AverageLaptimeSeconds ++;
            DeepRefresh();
        }

        private void btnDownEvolveInterval_Click(object sender, EventArgs e)
        {
            if (_appViewModel.CurrentRaceParameters.WeatherParams.MinEvolutionLapCount <= 1)
                _appViewModel.CurrentRaceParameters.WeatherParams.MinEvolutionLapCount = 1;
            else
                _appViewModel.CurrentRaceParameters.WeatherParams.MinEvolutionLapCount--;

            DeepRefresh();
        }

        private void btnUpEvolveInterval_Click(object sender, EventArgs e)
        {
            _appViewModel.CurrentRaceParameters.WeatherParams.MinEvolutionLapCount ++;

            DeepRefresh();
        }

        private void btnShowOptimalTiresType_Click(object sender, EventArgs e)
        {
            if (_appViewModel != null)
            {
                _appViewModel.CurrentRaceParameters.ShowOptimalTiresType = !_appViewModel.CurrentRaceParameters.ShowOptimalTiresType;
                DeepRefresh();
            }
        }


        private Image GetWeatherImage(WeatherEnum weather)
        {
            switch (weather)
            {
                case WeatherEnum.Covered:
                    return Images.Covered;
                case WeatherEnum.NightClear:
                    return Images.NightClear;
                case WeatherEnum.NightCloudy:
                    return Images.NightCloudy;
                case WeatherEnum.NightRain1:
                    return Images.NightRain1;
                case WeatherEnum.NightRain2:
                    return Images.NightRain2;
                case WeatherEnum.Raining:
                    return Images.Rain;
                case WeatherEnum.Sunny:
                    return Images.Sunny;
                case WeatherEnum.SunnyCloudy:
                    return Images.SunnyCloudy;
                case WeatherEnum.SunnyRain1:
                    return Images.SunnyRain1;
                case WeatherEnum.SunnyRain2:
                    return Images.SunnyRain2;
                case WeatherEnum.Thinning:
                    return Images.Thinning;
                default:
                    return Images.empty;
            }
        }

    }
}
