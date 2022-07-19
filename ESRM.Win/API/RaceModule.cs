using ESRM.Entities;
using ESRM.Entities.Dto;
using ESRM.Win.Views;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESRM.Win
{
    // https://www.codeproject.com/articles/694907/lift-your-petticoats-with-nancy
    //https://github.com/NancyFx/Nancy/wiki/Defining-routes
    //http://volkanpaksoy.com/archive/2015/11/11/building-a-simple-http-server-with-nancy/

    public class RaceModule : NancyModule
    {

        public RaceModule() : base("race")
        {
            GetRaceSetting();
            RaceStart();
        }

        public void GetRaceSetting() 
        {
            Get["/settings"] = parameters =>
            {
                try
                {
                    RaceParameters result = RaceManager.Instance.Race.RaceParams;

                    return Response.AsJson(result);
                }
                catch (Exception ex)
                {
                    return null;
                }
            };
        }
        public void RaceStart()
        {
            Post["/start"] = _ =>
            {
                var team = this.Bind<TeamDto>();
                RaceManager.Instance.StartTimer();
                return team.TeamName;
                return HttpStatusCode.OK;
            };
        }
    }
}
