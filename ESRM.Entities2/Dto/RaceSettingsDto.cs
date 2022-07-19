using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities.Dto
{
    public class RaceSettingsDto
    {
        public string RaceType { get; set; }
        public string Duration { get; set; }

        public RaceSettingsDto()
        {
        }
    }


    //public static partial class TeamConverter
    //{

    //    public static TeamDto ToTeamDto(this TeamInRace source)
    //    {
    //        return source.ToTeamDtoWithRelated(0);
    //    }

    //    public static TeamDto ToTeamDtoWithRelated(this TeamInRace source, int level)
    //    {
    //        if (source == null)
    //            return null;

    //        var target = new TeamDto();

    //        // Properties
    //        target.TeamName = source.Name;
    //        target.Driver1Name = source.Pilot1.Name;
    //        target.Driver2Name = source.Pilot2 != null ? source.Pilot2.Name : string.Empty;
    //        target.Driver3Name = source.Pilot3 != null ? source.Pilot3.Name : string.Empty;
    //        target.TeamColor = source.Color;
    //        target.LaneId = source.Id;
    //        target.CurrentDriverName = source.CurrentPilotName;
    //        target.GamePadIndex = source.UseGamePadPlayerIndex.HasValue ? (int)source.UseGamePadPlayerIndex.Value : 0;

    //        // Navigation Properties
    //        if (level > 0)
    //        {

    //        }

    //        return target;
    //    }

    //    public static List<TeamDto> ToTeamDtos(this IEnumerable<TeamInRace> source)
    //    {
    //        if (source == null)
    //            return null;

    //        var target = source
    //          .Select(src => src.ToTeamDto())
    //          .ToList();

    //        return target;
    //    }
    //}


}
