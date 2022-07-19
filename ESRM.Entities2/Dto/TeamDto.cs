using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ESRM.Entities.Dto
{

    public class EsrmServer
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public EsrmServer()
        {

        }

        public EsrmServer(string json)
        {
            dynamic results = JsonConvert.DeserializeObject<dynamic>(json);
            Name = results.Name;
            Url = results.Url;
        }
    }

    public class TeamDto
    {
        public string TeamName { get; set; }
        public string Driver1Name { get; set; }
        public string Driver2Name { get; set; }
        public string Driver3Name { get; set; }
        public int TeamColor { get; set; }
        public int LaneId { get; set; }
        public int GamePadIndex { get; set; }
        public string CurrentDriverName { get; set; }
        public bool InCarPro { get; set; }



        public TeamDto()
        {
        }

        public TeamDto(string json)
        {
            dynamic results = JsonConvert.DeserializeObject<dynamic>(json);
            TeamName = results.TeamName;
            Driver1Name = results.Driver1Name;
            Driver2Name = results.Driver2Name;
            Driver3Name = results.Driver3Name;
            TeamColor = results.TeamColor;
            LaneId = results.LaneId;
            GamePadIndex = results.GamePadIndex;
            CurrentDriverName = results.CurrentDriverName;
            //InCarPro = results.InCarPro;
        }

        public static List<TeamDto> ToList(string json)
        {
            List<TeamDto> items = JsonConvert.DeserializeObject<List<TeamDto>>(json) ;
            return items;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1} Id = {2}", TeamName, Driver1Name, LaneId);
        }
    }
}
