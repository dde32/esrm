using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using System.Json;
using ESRM.Entities.Dto;
using System.Net;
using System.IO;
using Java.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Diagnostics;

namespace ESRM.Mobile.Droid
{

    public class EsrmProxy
    {
        public static string ESRM_SERVER_IP_OR_HOST;
        //public static string ESRM_SERVER_URL = "http://PCFAMILLY:666/";
        public static string ESRM_SERVER_URL = "http://PORTABLEDD:666/";

        public static List<EsrmServer> ServerList;

        #region Proxy method

        public static async Task<List<TeamDto>> GetTeamsAsync()
        {
            string url = ESRM_SERVER_URL + "teams/list";

            JsonValue jsonDoc = await GetDatasAsync(url);
            List<TeamDto> teams = TeamDto.ToList(jsonDoc.ToString());

            return teams;
        }

        public static List<TeamDto> GetTeams()
        {
            string url = ESRM_SERVER_URL + "teams/list";

            JsonValue jsonDoc = GetDatas(url);
            List<TeamDto> teams = TeamDto.ToList(jsonDoc.ToString());

            return teams;
        }

        public static async Task<TeamDto> GetTeamAsync(int id)
        {
            string url = ESRM_SERVER_URL + "teams/team/" + id.ToString();

            JsonValue jsonDoc = await GetDatasAsync(url);
            TeamDto team = new TeamDto(jsonDoc.ToString());

            return team;
        }

        public static TeamDto GetTeam(int id)
        {
            string url = ESRM_SERVER_URL + "teams/team/" + id.ToString();

            JsonValue jsonDoc = GetDatas(url);
            TeamDto team = new TeamDto(jsonDoc.ToString());

            return team;
        }

        public static async Task<TeamRaceDatasDto> GetTeamRaceDatasAsync(int id)
        {
            string url = ESRM_SERVER_URL + "teams/racedatas/" + id.ToString();

            JsonValue jsonDoc = await GetDatasAsync(url);
            TeamRaceDatasDto teamRaceData = new TeamRaceDatasDto(jsonDoc.ToString());

            return teamRaceData;
        }

        public static TeamRaceDatasDto GetTeamRaceDatas(int id)
        {
            string url = ESRM_SERVER_URL + "teams/racedatas/" + id.ToString();

            JsonValue jsonDoc = GetDatas(url);
            TeamRaceDatasDto teamRaceData = new TeamRaceDatasDto(jsonDoc.ToString());

            return teamRaceData;
        }


        public static async Task<TeamRaceDriverDatasDto> GetTeamRaceDriverDatasAsync(int id)
        {
            string url = ESRM_SERVER_URL + "teams/racedriverdatas/" + id.ToString();

            JsonValue jsonDoc = await GetDatasAsync(url);
            TeamRaceDriverDatasDto teamRaceData = new TeamRaceDriverDatasDto(jsonDoc.ToString());

            return teamRaceData;
        }

        public static TeamRaceDriverDatasDto GetTeamRaceDriverDatas(int id)
        {
            string url = ESRM_SERVER_URL + "teams/racedriverdatas/" + id.ToString();

            JsonValue jsonDoc = GetDatas(url);
            TeamRaceDriverDatasDto teamRaceData = new TeamRaceDriverDatasDto(jsonDoc.ToString());

            return teamRaceData;
        }

        #region GENERIC GET DATAS 

        public static async Task<JsonValue> GetDatasAsync(string url)
        {
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    // Return the JSON document:
                    return jsonDoc;
                }
            }
        }

        public static JsonValue GetDatas(string url)
        {
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";
            ////request.ContinueTimeout = 2000;
            //request.KeepAlive = false;
            //request.Timeout = 2000;

            WebResponse response = null;
            try
            {
                // Send the request to the server and wait for the response:
                response = request.GetResponse();
                {
                    // Get a stream representation of the HTTP web response:
                    using (Stream stream = response.GetResponseStream())
                    {
                        // Use this stream to build a JSON document object:
                        JsonValue jsonDoc = JsonObject.Load(stream);
                        // Return the JSON document:
                        return jsonDoc;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (response != null)
                {
                    response.Dispose();
                    response = null;
                }
                request.Abort();
                request = null;
            }
        }

        #endregion
        #endregion


        public static bool ConnectToServer(string ip)
        {
            string url = string.Format("http://{0}:666/{1}", ip, "esrm/servername");

            try
            {
                JsonValue jsonDoc = EsrmProxy.GetDatas(url);
                EsrmServer result = new EsrmServer(jsonDoc.ToString());
                ESRM_SERVER_URL = string.Format("http://{0}:666/", ip);
                ESRM_SERVER_IP_OR_HOST = ip;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
     
        public static void GetAllServers()
        {
            ServerList = new List<EsrmServer>();

            //IPAddress[] adresses = Dns.GetHostAddresses(Dns.GetHostName());
            IPAddress[] adresses = Dns.GetHostAddresses("PORTABLEDD");

            if (adresses != null && adresses[0] != null)
            {
                string baseIp = adresses[0].ToString();

                baseIp = baseIp.Substring(0, baseIp.LastIndexOf("."));
                IpScanner.ScanServers(baseIp);
            }

        }

    }

//using System.Threading;
//using System.Diagnostics;
//using System.Collections.Generic;
//using System;

    static class IpScanner
    {
        public static void ScanServers(string baseIP)
        {
            for (int cnt = 100; cnt <255; cnt++)
            {
                //lock (@lock)
                //{
                //    instances += 1;
                //}

                EsrmServer serverSearch = GetServerName(string.Concat(baseIP,".", cnt.ToString()));
                if (serverSearch != null)
                    EsrmProxy.ServerList.Add(serverSearch);
            }
       }

        public static  EsrmServer GetServerName(string ip)
        {
            string url = string.Format("http://{0}:666/{1}", ip, "esrm/servername");

            try
            {
                JsonValue jsonDoc =  EsrmProxy.GetDatas(url);
                EsrmServer result = new EsrmServer(jsonDoc.ToString());
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}