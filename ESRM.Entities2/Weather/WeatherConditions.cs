using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{
    public class WeatherConditions
    {
        private WeatherScenario _weatherScenario;
        private bool _isNight;

        public WeatherEnum Weather { get; set; }
        public int Temperature { get; set; }
        public int TrackTemperature { get; internal set; }
        public int ForeCastProbability { get; set; } // pourcentage    
        public TimeSpan? ForeCastAbsoluteTime { get; set; } // pourcentage    
        public bool Major { get; set; }
        public int LapEvolutionDelay { get; set; }

        public WeatherConditions(WeatherScenario weatherScenario, WeatherEnum weather, int temperature, int forecastProbability)
        {
            _weatherScenario = weatherScenario;
            Weather = weather;
            Temperature = temperature;
            ForeCastProbability = forecastProbability;
            LapEvolutionDelay = 0;
        }

        public void Initialise()
        {

            // quelle température
            CalculTrackTemperature();
        }


        public bool IsWorst(WeatherEnum otherWeather)
        {
            if (this.Weather == otherWeather)
                return false;
            else if (this.Weather < otherWeather && this.Weather < WeatherEnum.NightClear && otherWeather < WeatherEnum.NightClear)
                return true;
            else //temporaire, il faut terminer
                return false;

            //if (this.Weather >= WeatherEnum.NightClear)
            //{
            //    return otherWeather.Weather > WeatherEnum.NightClear && <
            //}
            //NightClear = 7,
            //NightCloudy = 8,
            //NightRain1 = 9,
            //NightRain2 = 10,
        }

        public void CalculTrackTemperature()
        {
            if (Weather == WeatherEnum.Sunny)
            {
                TrackTemperature = Temperature + 15;
            }
            else
            {
                TrackTemperature = Temperature + 10 - (int)Weather;
            }
        }


        public void SwitchNight(bool setNight)
        {
            if (_isNight != setNight)
            {
                if (!_isNight) // on est pas encore en mode nuit, on y passe
                {
                    _isNight = setNight;

                    switch (Weather)
                    {
                        case WeatherEnum.Sunny:
                            Weather = WeatherEnum.NightClear;
                            break;
                        case WeatherEnum.SunnyCloudy:
                            Weather = WeatherEnum.NightCloudy;
                            break;
                        case WeatherEnum.Thinning:
                            Weather = WeatherEnum.NightClear;
                            break;
                        case WeatherEnum.Covered:
                            Weather = WeatherEnum.NightCloudy;
                            break;
                        case WeatherEnum.SunnyRain1:
                            Weather = WeatherEnum.NightRain1;
                            break;
                        case WeatherEnum.SunnyRain2:
                            Weather = WeatherEnum.NightRain2;
                            break;
                        case WeatherEnum.Raining:
                            Weather = WeatherEnum.NightRain2;
                            break;
                    }
                    Temperature -= 5;
                    CalculTrackTemperature();
                }
                else // on est pas enmode nuit, on passe en jour
                {
                    _isNight = setNight;

                    switch (Weather)
                    {
                        case WeatherEnum.NightClear:
                            Weather = WeatherEnum.Sunny;
                            break;
                        case WeatherEnum.NightCloudy:
                            Weather = WeatherEnum.SunnyCloudy;
                            break;
                        case WeatherEnum.NightRain1:
                            Weather = WeatherEnum.SunnyRain1;
                            break;
                        case WeatherEnum.NightRain2:
                            Weather = WeatherEnum.SunnyRain2;
                            break;
                    }
                    Temperature += 5;
                    CalculTrackTemperature();
                }
            }
        }



        #region CALCULATED  PROPERTIES
        public bool WetConditions
        {
            get
            {
                return Weather == WeatherEnum.Raining;
            }
        }


        public bool DampConditions
        {
            get
            {
                return
                 Weather == WeatherEnum.NightRain1 ||
                 Weather == WeatherEnum.NightRain2 ||
                 Weather == WeatherEnum.SunnyRain1 ||
                 Weather == WeatherEnum.SunnyRain2;
            }
        }

        public TireType OptimalTireType
        {
            get
            {
                if (DampConditions)
                    return TireType.Intermediate;
                else if (WetConditions)
                    return TireType.Wet;
                else
                {
                    if (TrackTemperature < 20)
                        return TireType.Soft;
                    else if (TrackTemperature >= 20 && TrackTemperature < 35)
                        return TireType.Medium;
                    else
                        return TireType.Hard;
                }
            }
        }

        #endregion CALCULATED  PROPERTIES


        public override string ToString()
        {
            string result = string.Empty;

            if (ForeCastAbsoluteTime.HasValue)
                result = string.Format("{0} - PROBA : {1}% -  Temp :{2} - TrackTemp = {3} - Intervalle = {4}", this.Weather, ForeCastProbability, Temperature, TrackTemperature, ForeCastAbsoluteTime.Value.TotalSeconds);
            else
                result = string.Format("{0} - PROBA : {1}% -  Temp :{2} - TrackTemp = {3} - Intervalle = {4}", this.Weather, ForeCastProbability, Temperature, TrackTemperature, LapEvolutionDelay);

            return result;
        }
    }

}
