using AzureUtils.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace AzureUtils.Util
{
    public class UserUtils
    {
        private static string graphUri = ConfigurationManager.AppSettings["ida:GraphUrl"];
        private static string tenantName = ConfigurationManager.AppSettings["ida:Tenant"];
        private static string graphApiVersion = ConfigurationManager.AppSettings["ida:GraphApiVersion"];

        public static AzureAdUser findByUserName(String UserName)
        {
            String accessToken = "";
            accessToken = Adal.AccessToken();
            string authToken = "Bearer" + " " + accessToken;

            String searchUrl = String.Format("{0}/{1}/users/{3}?api-version={2}", graphUri, tenantName, graphApiVersion, UserName);

            var client = new WebClient();
            client.Headers.Add("Authorization", authToken);
            client.Headers.Add("Content-Type", "application/json");

            String text = "";
            try
            {
                text = client.DownloadString(searchUrl);
            }
            catch (System.Net.WebException)
            {
                return null;
            }


            AzureAdUser thisUser = new AzureAdUser();

            try
            {
                thisUser = JsonConvert.DeserializeObject<AzureAdUser>(text);
            }
            catch (Exception e)
            {
                return null;
            }

            return thisUser;
            
        }
    }
}