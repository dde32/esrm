
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities.Weather
{
    public class WeatherParams
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool PassNight { get; set; }
        public int MaxTemperature { get; set; }
        public int MinTemperature { get; set; }
        public RainriskEnum RainRisk { get; set; }
        public WeatherEnum InitialWeather { get; set; }
        public int InitialTemperature { get; set; }
        public WeatherChangeFrequencyEnum EvolutionFrequency { get; set; } // Eventuellement on pourrait plutot mettre un coef qui pourrait varier en fonction de la saison
        public int MinEvolutionLapCount { get; set; }
        public int AverageLaptimeSeconds { get; set; }

        public WeatherParams()
        {
            MinEvolutionLapCount = 10;
            AverageLaptimeSeconds = 6;
        }


        public WeatherParams(int? maxTemperature, int? minTemperature, WeatherEnum initialWeather, int? initialTemperature,
                               WeatherChangeFrequencyEnum weatherEvolutionFrequency, RainriskEnum rainRisk,
                               TimeSpan startTime, TimeSpan endTime, bool PassNight, int minEvolutionLapCount, int averageLaptimeSeconds)
        {
            MaxTemperature = maxTemperature.HasValue ? maxTemperature.Value : WeatherConditionsConstants.SummerMaxTemp;
            MinTemperature = minTemperature.HasValue ? minTemperature.Value : WeatherConditionsConstants.WinterMinTemp;

            StartTime = startTime;
            EndTime = endTime;
            RainRisk = rainRisk;
            EvolutionFrequency = weatherEvolutionFrequency;
            MinEvolutionLapCount = minEvolutionLapCount;
            AverageLaptimeSeconds = averageLaptimeSeconds;
        }

        public void RandomInit()
        {
            InitialiseFirstWeather();
        }
        
        private void InitialiseFirstWeather()
        {
            Random _random = new Random();

            MinTemperature = _random.Next(5, 15);
            MaxTemperature = _random.Next(MinTemperature + 5, 36);
            RainRisk = (RainriskEnum) _random.Next(0, 3);
            InitialTemperature = _random.Next(MinTemperature, MaxTemperature + 1);

            if (RainRisk == RainriskEnum.High)
            {
                InitialWeather = (WeatherEnum)_random.Next(0, (int)WeatherEnum.Raining + 4);
                if (InitialWeather > WeatherEnum.Raining)
                    InitialWeather = WeatherEnum.Raining;
            }
            else if (RainRisk == RainriskEnum.Normal)
                InitialWeather = (WeatherEnum)_random.Next(0, (int)WeatherEnum.Raining + 1);
            else
            {
                InitialWeather = (WeatherEnum)_random.Next(0, (int)WeatherEnum.Raining + 4);
                if (InitialWeather > WeatherEnum.Raining)
                    InitialWeather = WeatherEnum.SunnyCloudy;
            }

            StartTime = new TimeSpan(_random.Next(12, 19),0,0);
            EndTime = StartTime.Add(new TimeSpan(2, 0, 0));
            PassNight = EndTime.Hours > 19;



    }
}

}
