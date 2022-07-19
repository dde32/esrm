using ESRM.Entities.Weather;
using System;
using System.Collections.Generic;

namespace ESRM.Entities
{
    public class WeatherScenario
    {
        Random _random;
        private int _currentWeatherIndex;
        //private bool _isFirstLapPassed;
        private double _timeRatio;
        List<WeatherConditions> _weatherConditions;

        WeatherParams _weatherParams;
        protected TimeSpan Time { get; set; }
        protected bool _isNight { get; set; }

        //public TimeSpan? RaceDuration { get; set; }
        //protected int? LapCount { get; set; }
        protected TimeSpan? TimeBeforeNextEvolution { get; set; }

        //private DateTime LastTimeWeatherChange { get; set; }

        public event EventHandler WeatherChanged;


        public WeatherConditions CurrentWeather
        {
            get { return this._weatherConditions[_currentWeatherIndex]; }
        }

        public WeatherConditions NextWeather
        {
            get
            {
                if (_currentWeatherIndex < _weatherConditions.Count -1)
                    return this._weatherConditions[_currentWeatherIndex + 1];
                else
                    return CurrentWeather;
            }
        }

        public string TimeBeforeNextEvolutionForUI
        {
            get
            {
                if (!TimeBeforeNextEvolution.HasValue)
                {
                    return string.Format("{0}L.",NextWeather.LapEvolutionDelay);
                }

                if (TimeBeforeNextEvolution.Value.Minutes < 1)
                {
                    if (TimeBeforeNextEvolution.Value.TotalSeconds < 30)
                        return "< 30s.";
                    else
                        return "< 1min";
                }
                else
                    return TimeBeforeNextEvolution.HasValue ? string.Format("{0}m.", (int)TimeBeforeNextEvolution.Value.Minutes) : string.Empty;
            }
        }



        public WeatherScenario(WeatherParams weatherParams, RaceParameters raceParams)
        {
            if (!raceParams.LapCount.HasValue && !raceParams.TimeLimit.HasValue)
                return;

            _weatherParams = weatherParams;

            _isNight = false;
            //_isFirstLapPassed = false;
            _currentWeatherIndex = 0;
            _random = new Random();
            _weatherConditions = new List<WeatherConditions>();
            Time = weatherParams.StartTime;


            // création du premier Weather
            InitialiseFirstWeather(_weatherParams.InitialWeather, _weatherParams.InitialTemperature);

            // GESTION DES CHANGEMENTS DE METEO
            int evolutionInterval = raceParams.TireLifeTime;
            evolutionInterval = evolutionInterval * ((int)_weatherParams.EvolutionFrequency + 1);

            if (evolutionInterval == 0)
                return;
            int MaxLapCount = 0;

            // on a la fréquence d'évolution et la durée de la course, on peut calculer le nombre de weather à générer
            if (raceParams.LapCount.HasValue) // Course GP
            {
                MaxLapCount = raceParams.LapCount.Value;
                if (evolutionInterval > (raceParams.LapCount.Value - _weatherParams.MinEvolutionLapCount))
                    evolutionInterval = raceParams.LapCount.Value - _weatherParams.MinEvolutionLapCount;
            }
            else // TIME LIMIT
            {
                evolutionInterval = evolutionInterval * ((int)_weatherParams.EvolutionFrequency + 1);
                int AverageRaceLapCount = (int) raceParams.TimeLimit.Value.TotalSeconds / _weatherParams.AverageLaptimeSeconds;

                if (evolutionInterval > (AverageRaceLapCount - _weatherParams.MinEvolutionLapCount))
                    evolutionInterval = AverageRaceLapCount - _weatherParams.MinEvolutionLapCount;

                MaxLapCount = AverageRaceLapCount;
            }

            int lapnumber = 0;
            while (lapnumber < MaxLapCount)
            {
                int next = _random.Next(lapnumber + (int)(_weatherParams.MinEvolutionLapCount / 2), lapnumber + evolutionInterval + (int)(_weatherParams.MinEvolutionLapCount / 2));
                lapnumber = lapnumber + evolutionInterval + (int)(_weatherParams.MinEvolutionLapCount / 2);

                InitialiseNewWeather(_weatherConditions[_weatherConditions.Count - 1], next);
            }

            if (NextWeather.ForeCastAbsoluteTime.HasValue)
                TimeBeforeNextEvolution = new TimeSpan(0, 0, 0, (int)NextWeather.ForeCastAbsoluteTime.Value.TotalSeconds, 0);

            //string result = this.ToString();

            // pour la gestion du passage en mode nuit, il faut connaitre le ratio entre une seconde de temps passé
            // et une vraie seconde
            double approxRaceTime = MaxLapCount * raceParams.WeatherParams.AverageLaptimeSeconds;
            TimeSpan raceDuration = raceParams.WeatherParams.EndTime - raceParams.WeatherParams.StartTime;
            _timeRatio = raceDuration.TotalSeconds / approxRaceTime;

            // calcul du temps avant changement de météo en fonction du temps approximatif au tour
            foreach (WeatherConditions w in _weatherConditions)
                w.ForeCastAbsoluteTime = new TimeSpan(0, 0, (int)(w.LapEvolutionDelay * raceParams.WeatherParams.AverageLaptimeSeconds));
        }

        private void InitialiseFirstWeather(WeatherEnum initialWeather, int? initialTemperature)
        {
            int temp = initialTemperature.HasValue ? initialTemperature.Value : _random.Next(_weatherParams.MinTemperature, _weatherParams.MaxTemperature +1);
            int forecastProbability = 100; // le premier weather est forcément fiable à 100% _random.Next(25, 100); 

            if (initialWeather == WeatherEnum.Unknown)
            {
                if (_weatherParams.RainRisk == RainriskEnum.High)
                {
                    initialWeather = (WeatherEnum)_random.Next(0,(int)WeatherEnum.Raining + 4);
                    if (initialWeather > WeatherEnum.Raining)
                        initialWeather = WeatherEnum.Raining;
                }
                else if (_weatherParams.RainRisk == RainriskEnum.Normal)
                    initialWeather = (WeatherEnum)_random.Next(0, (int)WeatherEnum.Raining+1);
                else
                {
                    initialWeather = (WeatherEnum)_random.Next(0, (int)WeatherEnum.Raining + 4);
                    if (initialWeather > WeatherEnum.Raining)
                        initialWeather = WeatherEnum.SunnyCloudy;
                }
            }

            WeatherConditions NextWeatherConditions = new WeatherConditions(this, (WeatherEnum)initialWeather, temp, forecastProbability);
            NextWeatherConditions.CalculTrackTemperature();
            NextWeatherConditions.Major = true;

            _weatherConditions.Add(NextWeatherConditions);
        }

        private void InitialiseNewWeather(WeatherConditions previousWeather,int interval)
        {
            WeatherEnum newWeatherType = previousWeather.Weather;
            int newTemp = previousWeather.Temperature;
            int newForecastProbability = 100;


            // choix alétoire du prochain type de météo
            int idxForNewWeather = _random.Next(0, 101);

            int currentProba = 0;
            int PrecProba = 0;
            for (int i = 0; i <= (int)WeatherEnum.Raining; i++)
            {
                PrecProba = currentProba;

                currentProba += WeatherConditionsConstants.EvolutionProbabilities[(int)previousWeather.Weather, i];

                if (idxForNewWeather >= PrecProba && idxForNewWeather < currentProba)
                {
                    newWeatherType = (WeatherEnum)i;
                    break;
                }
            }

            // calcul de la température
            // ici on va calculer la nouvelle temperature 
            // pour déterminer l'intervalle de température mini et maxi il faudrait commencer par déterminer l'heure réelle
            // attention on peut également passe en mode nuit auquel cas la température peut baisser plus fortement
            if (previousWeather.Weather == newWeatherType)
            {
                newTemp = _random.Next(previousWeather.Temperature - 3 > _weatherParams.MinTemperature ? previousWeather.Temperature - 3 : _weatherParams.MinTemperature, previousWeather.Temperature + 3);
            }
            else
            {
                newForecastProbability = _random.Next(30, 101);

                if (previousWeather.IsWorst((WeatherEnum)newWeatherType))
                    newTemp = _random.Next(previousWeather.Temperature - 5 > _weatherParams.MinTemperature ?  previousWeather.Temperature - 5 : _weatherParams.MinTemperature, previousWeather.Temperature);
                else
                    newTemp = _random.Next(previousWeather.Temperature, previousWeather.Temperature + 5 < _weatherParams.MaxTemperature ?  previousWeather.Temperature + 5 : _weatherParams.MaxTemperature +1);
            }


            WeatherConditions NextWeatherConditions = new WeatherConditions(this, (WeatherEnum)newWeatherType, newTemp, newForecastProbability);
            NextWeatherConditions.CalculTrackTemperature();
            NextWeatherConditions.Major = true;

            NextWeatherConditions.LapEvolutionDelay = interval;

            _weatherConditions.Add(NextWeatherConditions);
        }

        private void FirstLapEnded(TimeSpan firstLapTime)
        {
            //_isFirstLapPassed = true;

            //foreach(WeatherConditions w in _weatherConditions)
            //{
            //    w.ForeCastAbsoluteTime = new TimeSpan(0,0,0,0, (int) (w.LapEvolutionDelay * firstLapTime.TotalMilliseconds));
            //}

            //if (NextWeather.ForeCastAbsoluteTime.HasValue)
            //    TimeBeforeNextEvolution = new TimeSpan(0, 0, 0, (int)NextWeather.ForeCastAbsoluteTime.Value.TotalSeconds, 0);
            //OnWeatherChanged();
        }


        public void EvolveWeather(TimeSpan passedTime)
        {
            //if (!_isFirstLapPassed)
            //    FirstLapEnded(passedTime);

            TimeBeforeNextEvolution = NextWeather.ForeCastAbsoluteTime - passedTime;
            // on va voir s'il est temps de passer au weather suivant
            // si c'est le cas on fait un random pour voir s'il se déclenche ou pas (en fonction du % de proba).
            // s'il ne se déclenche pas on va essayer de trouver le weather de remplacement.
            // il peut s'agir d'un weather pire ou carrément d'un non changement de temps (?)
            // pour que l'heure de déclenchement ne soit pas trop précise on va faire un evole de temps réel
            // plutot que sur le temps de course
            if (passedTime >= this.NextWeather.ForeCastAbsoluteTime && _currentWeatherIndex < _weatherConditions.Count - 1)
            {
               int proba = _random.Next(0, 101);
                if(proba <= NextWeather.ForeCastProbability)
                {
                    this._currentWeatherIndex++;

                    if (NextWeather.ForeCastAbsoluteTime.HasValue)
                        TimeBeforeNextEvolution = NextWeather.ForeCastAbsoluteTime.Value - passedTime;
                }
                else
                {
                    int deltaProba = 100 - NextWeather.ForeCastProbability;
                    deltaProba = deltaProba / 4;
                    WeatherEnum newWeather = NextWeather.Weather;

                    // si la proba n'a pas été atteinte, on a plusieurs  options. 
                    // on trouve un autre weather pour le remplacer
                    if (NextWeather.Weather > WeatherEnum.Raining)
                    {
                        if (proba <= NextWeather.ForeCastProbability + deltaProba)
                            newWeather = newWeather >= WeatherEnum.NightCloudy ? newWeather - 1 : newWeather + 1;
                        else if (proba <= NextWeather.ForeCastProbability + (2 * deltaProba))
                            newWeather = newWeather >= WeatherEnum.NightRain1 ? newWeather - 2 : newWeather + 2;
                        else if (proba <= NextWeather.ForeCastProbability + (3 * deltaProba))
                            newWeather = newWeather <= WeatherEnum.NightRain2 ? newWeather + 1 : newWeather - 1;
                        else // on garde le weather actuel
                            newWeather = CurrentWeather.Weather;
                    }
                    else
                    {
                        if (proba <= NextWeather.ForeCastProbability + deltaProba)
                            newWeather = newWeather >= WeatherEnum.SunnyCloudy ? newWeather - 1 : newWeather + 1;
                        else if (proba <= NextWeather.ForeCastProbability + (2 * deltaProba))
                            newWeather = newWeather >= WeatherEnum.Thinning ? newWeather - 2 : newWeather + 2;
                        else if (proba <= NextWeather.ForeCastProbability + (3 * deltaProba))
                            newWeather = newWeather <= WeatherEnum.SunnyRain2 ? newWeather + 1 : newWeather - 1;
                        else // on garde le weather actuel
                            newWeather = CurrentWeather.Weather;
                    }

                    NextWeather.Weather = newWeather;
                    NextWeather.CalculTrackTemperature();
                    if (NextWeather.ForeCastAbsoluteTime.HasValue)
                        TimeBeforeNextEvolution = NextWeather.ForeCastAbsoluteTime.Value - passedTime;
                }
                OnWeatherChanged();
            }

            // une fois que le temps avance, on fait le ratio entre temps passé et le temps de course sur une échelle 1/1 pour faire évoluer l'heure et eventuellement passe en mode nuit.
            if (_weatherParams.PassNight)
            {
                double totalSeconds = passedTime.TotalSeconds * _timeRatio;
                Time = _weatherParams.StartTime.Add(new TimeSpan(0, 0, (int)totalSeconds));

                if (Time.Hours < 19 && Time.Hours > 8)
                    SwitchNight(false);
                else
                    SwitchNight(true);
            }

        }

        private void SwitchNight(bool setNight)
        {
            CurrentWeather.SwitchNight(setNight);
            NextWeather.SwitchNight(setNight);
            OnWeatherChanged();
        }

        protected void OnWeatherChanged()
        {
            if (WeatherChanged != null)
                WeatherChanged(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            string result = string.Empty;

            foreach(WeatherConditions w in _weatherConditions)
            {
                result += w.ToString() + Environment.NewLine;
            }


            return result;
        }
    }





}
