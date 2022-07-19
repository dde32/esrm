using Android.App;
using Android.Widget;
using Android.OS;
//using ESRM.Entities.Dto;
using System.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System;
using Java.IO;
using System.Net.Http;
using System.Collections.Generic;
using ESRM.Entities.Dto;
using Android.Content;
using System.Threading;
using ESRM.Entities;
using Android.Graphics.Drawables;
using Android.Speech.Tts;
using System.Linq;
using Java.Util;
using Android.Views;

namespace ESRM.Mobile.Droid
{
    [Activity(Theme = "@style/Theme.NoTitle", NoHistory = true)]
    //[Activity(Label = "ESRM.Mobile.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class RaceDatasActivity : Activity
    {
        List<TeamDto> _teams;
        TeamRaceDriverDatasDto _driverDatas;
        TeamRaceDatasDto _raceDatas;


        private int _teamId = 1;

        private TextView _driver;
        //Race datas
        private TextView _bestLapText;
        private TextView _lapcountText;
        private TextView _lastLapText;
        private TextView _positionText;
        private TextView _gapText;
        private RadialProgress.RadialProgressView _fuelBar;
        private RadialProgress.RadialProgressView _tiresBar;
        private RadialProgress.RadialProgressView _healthBar;

        // Driver Datas
        private TextView _thCurve;
        private TextView _brakeCurve;
        private TextView _inCarPro;
        private TextView _driverMaxP;
        private TextView _healthPercentage;
        private TextView _tiresTypeText;
        private TextView _weatherTemperatures;
        private TextView _weatherForecastText;
        private TextView _mandatoryPS;
        private ImageView _weatherCurentImg;
        private ImageView _weatherNextImg;
        private ImageView _tiresTypeImg;
        private ImageView _stateImg;
        Spinner _spinner;
        // Create the delegate that invokes methods for the timer.
        TimerExampleState _timerState = new TimerExampleState();
        DateTime? _lastLowFuelSpoked;
        DateTime? _lastLowHealthSpoked;
        DateTime? _lastLowTiresSpoked;
        DateTime? _lastPositionSpoked;
        TextToSpeechImplementation _tts;

        string _second = " second ";
        bool _selecting;

        protected override void OnDestroy()
        {
            _tts.Dispose();
            base.OnDestroy();
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            int selectTeamId = Intent.GetIntExtra("TeamId",1);

            _tts = new TextToSpeechImplementation();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.RaceDatas);

            _driver = FindViewById<TextView>(Resource.Id.team);
            _bestLapText = FindViewById<TextView>(Resource.Id.bestlap);
            _lapcountText = FindViewById<TextView>(Resource.Id.lapcount);
            _lastLapText = FindViewById<TextView>(Resource.Id.lastlap);
            _positionText = FindViewById<TextView>(Resource.Id.position);
            _gapText = FindViewById<TextView>(Resource.Id.gap);
            _fuelBar = FindViewById<RadialProgress.RadialProgressView>(Resource.Id.fuelBar);
            _fuelBar.Value = 0;
            _healthBar = FindViewById<RadialProgress.RadialProgressView>(Resource.Id.healthBar);
            _healthBar.Value = 0;
            _tiresBar = FindViewById<RadialProgress.RadialProgressView>(Resource.Id.tiresBar);
            _tiresBar.Value = 0;

            _thCurve = FindViewById<TextView>(Resource.Id.thcurvetitle);
            _brakeCurve = FindViewById<TextView>(Resource.Id.brakecurvetitle);
            _inCarPro = FindViewById<TextView>(Resource.Id.incarpro);
            _driverMaxP = FindViewById<TextView>(Resource.Id.driverpower);
            _healthPercentage = FindViewById<TextView>(Resource.Id.healthpower);

            _tiresTypeText = FindViewById<TextView>(Resource.Id.tireTypeText);
            _weatherTemperatures = FindViewById<TextView>(Resource.Id.weatherText);
            _weatherForecastText = FindViewById<TextView>(Resource.Id.weatherForecastText);
            _weatherCurentImg = FindViewById<ImageView>(Resource.Id.weatherImg);
            _weatherNextImg = FindViewById<ImageView>(Resource.Id.weatherNextImg);
            _tiresTypeImg = FindViewById<ImageView>(Resource.Id.tireTypeImpg);
            _stateImg = FindViewById<ImageView>(Resource.Id.stateImage);
            _mandatoryPS = FindViewById<TextView>(Resource.Id.mandatoryPS);
            
            GetTeams();

            _spinner = FindViewById<Spinner>(Resource.Id.spinnerTeams);
            _spinner.Visibility = Android.Views.ViewStates.Invisible;

            _spinner.ItemSelected += Spinner_ItemSelected;
            _driver.Click += Driver_Click;

            ArrayAdapter spinnerArrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerDropDownItem); //, teamsName); //selected item will look like a spinner set from XML
            foreach (TeamDto t in _teams)
                spinnerArrayAdapter.Add(string.Format("{0} - {1}",t.TeamName, t.CurrentDriverName));
            _spinner.Adapter = spinnerArrayAdapter;


            string currentLanguagage = Locale.Default.GetDisplayLanguage(Locale.Default);

            if (currentLanguagage == Locale.French.DisplayLanguage)
                _second = " seconde ";

            SelectTeam(selectTeamId);

            // Timer pour la récupération des données, toutes les secondes
            TimerCallback timerDelegate = new TimerCallback(CheckStatus);
            System.Threading.Timer timer = new System.Threading.Timer(timerDelegate, _timerState, 1000, 1000);

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.mainmenu, menu);
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.select_server:
                    //do something
                    return true;
                case Resource.Id.settings:
                    //do something
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        void CheckStatus(Object state)
        {
            TimerExampleState s = (TimerExampleState)state;
            s.counter++;
            if (s.counter == 5)
            {
                s.counter = 0;
                RunOnUiThread(() => RefreshTemRaceDriverDatas());
                RunOnUiThread(() => RefreshTeamRaceDatas());
            }
            else
            {
                RunOnUiThread(() => RefreshTeamRaceDatas());
            }
        }

        private void Driver_Click(object sender, EventArgs e)
        {
            _selecting = true;
            _spinner.PerformClick();
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if(_selecting)
                SelectTeam(e.Position + 1);
        }


        private void GetTeams()
        {
            _teams = EsrmProxy.GetTeams();
           // _teamList.
        }

        private void SelectTeam(int id)
        {
            _teamId = id;
            GetTeamInvariantDatas();
            RefreshTeamRaceDatas();
            RefreshTemRaceDriverDatas();
        }
        
        private void GetTeamInvariantDatas()
        {
            TeamDto team = EsrmProxy.GetTeam(_teamId);

            Android.Graphics.Color teamColor = new Android.Graphics.Color(team.TeamColor);

            if (teamColor.ToArgb() == 0)
                teamColor = Android.Graphics.Color.White;

            _positionText.SetTextColor(teamColor);
            _lastLapText.SetTextColor(teamColor);
            _lapcountText.SetTextColor(teamColor);
            //_positionText.SetTextColor(teamColor);
            _fuelBar.ProgressColor = teamColor;
            _healthBar.ProgressColor = teamColor;
            _tiresBar.ProgressColor = teamColor;
            _driver.SetTextColor(teamColor);

            _tiresBar.RefreshDrawableState();
            _tiresBar.RequestLayout();
            _fuelBar.RefreshDrawableState();
            _fuelBar.RequestLayout();
            _healthBar.RefreshDrawableState();
            _healthBar.RequestLayout();
        }


        #region REFRESH UI



        private void RefreshTeamRaceDatas()
        {
            _raceDatas = EsrmProxy.GetTeamRaceDatas(_teamId);
            _bestLapText.Text = _raceDatas.BestLap;
            _positionText.Text = "P" + _raceDatas.Position.ToString();
            _lapcountText.Text = _raceDatas.LapCount;

            DoInformationSpeach(_raceDatas);

            _gapText.Text = _raceDatas.Gap;

            _fuelBar.Value = _raceDatas.FuelPercent;
            _healthBar.Value = _raceDatas.HealthPercent;
            _tiresBar.Value = _raceDatas.TiresPercent;

            _stateImg.SetImageResource(GetStateImageId((TeamState)_raceDatas.State));
        }

        private void DoInformationSpeach(TeamRaceDatasDto raceDatas)
        {
            if (_lastLapText.Text != raceDatas.LastLap)
            {
                _lastLapText.Text = raceDatas.LastLap;
                SpeakLastLapTime(raceDatas.LastLap);
            }
            if (raceDatas.LowFuel)
                SpeakLowFuel();
            if (raceDatas.LowHealth)
                SpeakLowHealth();
            if (raceDatas.LowTires)
                SpeakLowTires();
        }

        private void RefreshTemRaceDriverDatas()
        {
            _driverDatas = EsrmProxy.GetTeamRaceDriverDatas(_teamId);

            _thCurve.Text = _driverDatas.ThrottleCurve;
            _brakeCurve.Text = _driverDatas.BrakeCurve;
            _driverMaxP.Text = _driverDatas.DriverMaxPower;
            _healthPercentage.Text = _driverDatas.HealthPowerPercent;
            _tiresTypeText.Text = _driverDatas.CurrentTireTypeText;
            _weatherTemperatures.Text = _driverDatas.Temperature;
            _weatherForecastText.Text = _driverDatas.Probability;
            _driver.Text = _driverDatas.DriverName;
            _mandatoryPS.Text = _driverDatas.MandatoryPS;
            _inCarPro.SetTextColor(_driverDatas.InCarPro ? Android.Graphics.Color.YellowGreen : Android.Graphics.Color.Red);

            _tiresTypeImg.SetImageResource(GetTireImageId((TireType)_driverDatas.CurrentTireType));
            _weatherCurentImg.SetImageResource(GetWeatherImageId((WeatherEnum)_driverDatas.CurrentWeather));
            _weatherNextImg.SetImageResource(GetWeatherImageId((WeatherEnum)_driverDatas.NextWeather));
        }

        private int GetStateImageId(TeamState state)
        {
            switch(state)
            {
                case TeamState.Disqualified:
                    return Resource.Drawable.red_light;
                case TeamState.Finished:
                    return Resource.Drawable.Finish;
                case TeamState.EndOfRelay:
                    return Resource.Drawable.PitStop;
                case TeamState.Normal:
                    return Resource.Drawable.empty;
                case TeamState.PitIn:
                    return Resource.Drawable.repair;
                case TeamState.RunningPenality:
                    return Resource.Drawable.yellowFlag;
                case TeamState.TCRunning:
                    return Resource.Drawable.yellowFlag;
                default:
                    return Resource.Drawable.empty;
            }
        }

        private int GetTireImageId(TireType tireType)
        {
            switch (tireType)
            {
                case TireType.Hard:
                    return Resource.Drawable.Hard;
                case TireType.Intermediate:
                    return Resource.Drawable.Intermediate;
                case TireType.Medium:
                    return Resource.Drawable.Medium;
                case TireType.Soft:
                    return Resource.Drawable.Soft;
                case TireType.Wet:
                    return Resource.Drawable.Wet;
                default:
                    return Resource.Drawable.Medium;
            }
        }

        private int GetWeatherImageId(WeatherEnum tireType)
        {
            switch (tireType)
            {
                case WeatherEnum.Covered:
                    return Resource.Drawable.covered;
                case WeatherEnum.NightClear:
                    return Resource.Drawable.NightClear;
                case WeatherEnum.NightCloudy:
                    return Resource.Drawable.NightClear;
                case WeatherEnum.NightRain1:
                    return Resource.Drawable.NightRain1;
                case WeatherEnum.NightRain2:
                    return Resource.Drawable.NightRain1;
                case WeatherEnum.Raining:
                    return Resource.Drawable.rain;
                case WeatherEnum.Sunny:
                    return Resource.Drawable.sunny;
                case WeatherEnum.SunnyCloudy:
                    return Resource.Drawable.SunnyCloudy1;
                case WeatherEnum.SunnyRain1:
                    return Resource.Drawable.SunnyAndRainRisk1;
                case WeatherEnum.SunnyRain2:
                    return Resource.Drawable.SunnyAndRainRisk2;
                case WeatherEnum.Thinning:
                    return Resource.Drawable.thinning;
                case WeatherEnum.Unknown:
                    return Resource.Drawable.sunny;
                default:
                    return Resource.Drawable.sunny;
            }
        }
        #endregion


        #region TEXT TO SPEECH

        string XlapsRemaining = string.Format("$X {0} {1}",laps remaining"
        private void SpeakLastLapTime(string lapTime)
        {
            if (!_tts.IsSpeaking)
            {
                string toSay = lapTime.Replace("'", ", ").TrimStart('0');
                if (!string.IsNullOrEmpty(toSay))
                {
                    // ici on a traité le temps au tour.
                    toSay = toSay.Substring(0, toSay.Length - 1);

                    // maintenant si on est dans les derniers tours d'un GP 
                    // on va aussi donner le nombre de tours restant 
                    _raceDatas.LapCount




                    //string toSay = lapTime.Trim('0');
                    _tts.Speak(toSay);
                }
            }
        }


        private void SpeakLowFuel()
        {
            if (!_tts.IsSpeaking && (!_lastLowFuelSpoked.HasValue || DateTime.Now > _lastLowFuelSpoked.Value.AddSeconds(10)))
            {
                string toSay = "Low fuel";
                _tts.Speak(toSay);
                _lastLowFuelSpoked = DateTime.Now;
            }
        }

        private void SpeakLowHealth()
        {
            if (!_tts.IsSpeaking && (!_lastLowHealthSpoked.HasValue || DateTime.Now > _lastLowHealthSpoked.Value.AddSeconds(10)))
            {
                string toSay = "Low health";
                _tts.Speak(toSay);
                _lastLowHealthSpoked = DateTime.Now;
            }
        }
        private void SpeakLowTires()
        {
            if (!_tts.IsSpeaking && (!_lastLowTiresSpoked.HasValue || DateTime.Now > _lastLowTiresSpoked.Value.AddSeconds(10)))
            {
                string toSay = "Low tires";
                _tts.Speak(toSay);
                _lastLowTiresSpoked = DateTime.Now;
            }
        }

        #endregion TEXT TO SPEECH
    }

    class TimerExampleState
    {
        public int counter = 0;
        public System.Threading.Timer tmr;
    }
}

