using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESRM.Entities.Dto
{
    public static partial class TeamConverter
    {

        public static TeamDto ToTeamDto(this TeamInRace source)
        {
            return source.ToTeamDtoWithRelated(0);
        }

        public static TeamDto ToTeamDtoWithRelated(this TeamInRace source, int level)
        {
            if (source == null)
                return null;

            var target = new TeamDto();

            // Properties
            target.TeamName = source.Name;
            target.Driver1Name = source.Pilot1.Name;
            target.Driver2Name = source.Pilot2 != null ? source.Pilot2.Name : string.Empty;
            target.Driver3Name = source.Pilot3 != null ? source.Pilot3.Name : string.Empty;
            target.TeamColor = source.Color;
            target.LaneId = source.Id;
            target.CurrentDriverName = source.CurrentPilotName;
            target.GamePadIndex = source.UseGamePadPlayerIndex.HasValue ? (int)source.UseGamePadPlayerIndex.Value : 0;

            // Navigation Properties
            if (level > 0)
            {

            }

            return target;
        }

        public static List<TeamDto> ToTeamDtos(this IEnumerable<TeamInRace> source)
        {
            if (source == null)
                return null;

            var target = source
              .Select(src => src.ToTeamDto())
              .ToList();

            return target;
        }
    }



    public static partial class TeamRaceDatasConverter
    {

        public static TeamRaceDatasDto ToTeamRaceDatasDto(this TeamInRace source)
        {
            return source.ToTeamRaceDatasDtoWithRelated(0);
        }

        public static TeamRaceDatasDto ToTeamRaceDatasDtoWithRelated(this TeamInRace source, int level)
        {
            if (source == null)
                return null;

            var target = new TeamRaceDatasDto();

            // Properties
            target.Position = source.Position;
            target.BestLap = source.BestLapForUI;
            target.LastLap = source.LastLapForUI;
            target.FuelPercent = (int)source.FuelPercent;
            target.TiresPercent = (int)source.TiresWearPercent;
            target.HealthPercent = (int)source.CarHealthPercent;
            target.LowFuel = source.LowFuel;
            target.LowHealth = source.LowHealth;
            target.LowTires = source.LowTires;
            target.Gap = source.Gap;
            target.LapCount = source.LapCountForMobileUI;
            target.CurrentPowerPercentage = source.MaxPowerPercent;
            target.State = (int)source.State ;
            if (source.Race.YellowFlag)
                target.State = (int)StateImageEnum.YellowFlag;

                // Navigation Properties
                if (level > 0)
            {

            }

            return target;
        }

        public static List<TeamRaceDatasDto> ToTeamRaceDatasDtos(this IEnumerable<TeamInRace> source)
        {
            if (source == null)
                return null;

            var target = source
              .Select(src => src.ToTeamRaceDatasDto())
              .ToList();

            return target;
        }
    }

    public static partial class TeamRaceDriverDatasConverter
    {

        public static TeamRaceDriverDatasDto ToTeamRaceDriverDatasDto(this TeamInRace source)
        {
            return source.ToTeamRaceDriverDatasDtoWithRelated(0);
        }

        public static TeamRaceDriverDatasDto ToTeamRaceDriverDatasDtoWithRelated(this TeamInRace source, int level)
        {
            if (source == null)
                return null;

            var target = new TeamRaceDriverDatasDto();

            // Properties
            target.DriverName = source.CurrentPilot.Name;
            target.BrakeCurve = source.CurrentBrakeCurveTitlle;
            target.ThrottleCurve = source.CurrentThrottleCurveTitlle;
            target.MandatoryPS = source.MandatoryPSLeft;
            target.InCarPro= source.InCarPro;

            target.CurrentTireType = source.CurrentTires;
            target.CurrentWeather = source.Race.RaceParams.UseWeatherConditions ? (int)source.Race.WeatherScenario.CurrentWeather.Weather : 0;
            target.DriverMaxPower = source.CurrentPilot.MaxPowerPercent.ToString();
            target.NextWeather = source.Race.RaceParams.UseWeatherConditions ? (int)source.Race.WeatherScenario.NextWeather.Weather : 0;
            target.Probability = source.Race.RaceParams.UseWeatherConditions ? source.Race.ForeCastProbabilityForUI : string.Empty;
            target.Temperature = source.Race.RaceParams.UseWeatherConditions ? source.Race.GlobalTrackTemperatureForUI : string.Empty;

            target.HealthPowerPercent = source.MaxPowerPercent;
            target.CurrentTireTypeText = source.CurrentTiresTitle;

            // Navigation Properties
            if (level > 0)
            {

            }

            return target;
        }

        public static List<TeamRaceDriverDatasDto> ToTeamRaceDriverDatasDtos(this IEnumerable<TeamInRace> source)
        {
            if (source == null)
                return null;

            var target = source
              .Select(src => src.ToTeamRaceDriverDatasDto())
              .ToList();

            return target;
        }
    }

}
