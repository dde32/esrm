using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities.Dto
{
    public class TeamRaceDatasDto
    {
        public string LapCount { get; set; }
        public int Position { get; set; }
        public string BestLap { get; set; }
        public string LastLap { get; set; }
        public int FuelPercent { get; set; }
        public int TiresPercent { get; set; }
        public int HealthPercent { get; set; }
        public bool LowFuel { get; set; }
        public bool LowHealth{ get; set; }
        public bool LowTires { get; set; }
        public string Gap { get; set; }
        public string CurrentPowerPercentage { get; set; }
        public int State { get; set; }


        public TeamRaceDatasDto()
        {
        }

        public TeamRaceDatasDto(string json)
        {
            dynamic result = JsonConvert.DeserializeObject<dynamic>(json);

            this.LapCount = result.LapCount;
            this.Position = result.Position;
            this.BestLap = result.BestLap;
            this.LastLap = result.LastLap;
            this.FuelPercent = result.FuelPercent;
            this.TiresPercent = result.TiresPercent;
            this.HealthPercent = result.HealthPercent;
            this.LowFuel = result.LowFuel;
            this.LowHealth = result.LowHealth;
            this.LowTires = result.LowTires;
            this.Gap = result.Gap;
            CurrentPowerPercentage = result.CurrentPowerPercentage;
            State = result.State;
        }
    }

    public class TeamRaceDriverDatasDto
    {
        public string DriverName { get; set; }
        public string DriverMaxPower { get; set; }
        public string HealthPowerPercent { get; set; }
        public string ThrottleCurve { get; set; }
        public string BrakeCurve { get; set; }
        public string CurrentTireTypeText { get; set; }
        public int CurrentTireType { get; set; }
        public int CurrentWeather { get; set; }
        public int NextWeather { get; set; }
        public string Temperature { get; set; }
        public string Probability { get; set; }
        public string MandatoryPS { get; set; }
        public bool InCarPro { get; set; }
        public int? RaceLapCount { get; set; }
        public TimeSpan? RaceDuration { get; set; }

        public TeamRaceDriverDatasDto()
        {
        }

        public TeamRaceDriverDatasDto(string json)
        {
            dynamic result = JsonConvert.DeserializeObject<dynamic>(json);

            this.DriverName = result.DriverName;
            this.DriverMaxPower = result.DriverMaxPower;
            this.ThrottleCurve = result.ThrottleCurve;
            this.BrakeCurve = result.BrakeCurve;
            this.CurrentTireType = result.CurrentTireType;
            this.Temperature = result.Temperature;
            this.Probability = result.Probability;
            this.CurrentWeather = result.CurrentWeather;
            this.NextWeather = result.NextWeather;
            this.HealthPowerPercent = result.HealthPowerPercent;
            this.CurrentTireTypeText = result.CurrentTireTypeText;
            this.MandatoryPS = result.MandatoryPS;
            InCarPro = result.InCarPro;
            RaceLapCount = result.RaceLapCount;
            RaceDuration = result.RaceDuration;
        }
    }

}
