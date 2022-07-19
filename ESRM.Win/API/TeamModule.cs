using ESRM.Entities;
using ESRM.Entities.Dto;
using ESRM.Win.Views;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESRM.Win
{
    // https://www.codeproject.com/articles/694907/lift-your-petticoats-with-nancy
    //https://github.com/NancyFx/Nancy/wiki/Defining-routes


    public class TeamModule : NancyModule
    {

        public TeamModule() : base("/teams")
        {
            // All the teams in the current race
            Get["/list"] = parameters =>
            {
                try
                {
                    List<TeamDto> result = RaceManager.Instance.Race.Teams.Values.ToTeamDtos();

                    return Response.AsJson(result);
                }
                catch(Exception ex)
                {
                    return null;
                }
            };


            // get team information by lane id
            Get["/team/{laneId:int}"] = parameters =>
            {
                try
                {
                    int laneId = parameters["laneId"];
                    TeamDto result = RaceManager.Instance.Race.Teams[laneId].ToTeamDto();

                    return Response.AsJson(result);
                }
                catch (Exception ex)
                {
                    return null;
                }
            };


            // Get race datas for one team by lane id
            Get["/racedatas/{laneId:int}"] = parameters =>
            {
                try
                {
                    int laneId = parameters["laneId"];
                    TeamRaceDatasDto result = RaceManager.Instance.Race.Teams[laneId].ToTeamRaceDatasDto();

                    return Response.AsJson(result);
                }
                catch (Exception ex)
                {
                    return null;
                }
            };

            Get["/racedriverdatas/{laneId:int}"] = parameters =>
            {
                try
                {
                    int laneId = parameters["laneId"];
                    TeamRaceDriverDatasDto result = RaceManager.Instance.Race.Teams[laneId].ToTeamRaceDriverDatasDto();

                    return Response.AsJson(result);
                }
                catch (Exception ex)
                {
                    return null;
                }
            };

            // Set somme settings for team by id
            // IncarPro
            // TH Curve
            // Brake Curve
            // current driver (selected from the 3 drivers)
            // Tires type



            // PitStop Action
            // only if car is in pitlane
            //

        }
    }
}
