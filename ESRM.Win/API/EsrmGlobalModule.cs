using ESRM.Entities.Dto;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESRM.Win.API
{
    public class EsrmGlobalModule : NancyModule
    {

        public EsrmGlobalModule() : base("esrm")
        {

            Get["/servername"] = parameters =>
            {
                try
                {
                    EsrmServer serverDto = new EsrmServer();
                    serverDto.Name =  "ESRM Version" + Application.ProductVersion;

                    return Response.AsJson(serverDto);
                }
                catch (Exception ex)
                {
                    return null;
                }
            };
        }
    }
}
