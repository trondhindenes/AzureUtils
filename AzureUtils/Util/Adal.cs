using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AzureUtils.Util
{
    public class Adal
    {
        private static string tenant = ConfigurationManager.AppSettings["ida:Tenant"];
        private static string authorityUri = ConfigurationManager.AppSettings["ida:authorityUri"];
        private static string resourceUri = ConfigurationManager.AppSettings["ida:resourceUri"];
        private static string graphUri = ConfigurationManager.AppSettings["ida:GraphUrl"];
        private static string clientID = ConfigurationManager.AppSettings["ida:clientID"];
        private static string clientSecret = ConfigurationManager.AppSettings["ida:clientSecret"];
        private static string redirectUri = ConfigurationManager.AppSettings["ida:redirectUri"];
        private static string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];



        private static string Result = "";
        static string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);
        public static String AccessToken(bool forceReauth = false)
        {
            if ((Result == "") || (forceReauth = true))
            {
                //UserCredential uc = new UserCredential(username, password);
                var cred = new ClientCredential(clientID, clientSecret);

                AuthenticationContext authContext = new AuthenticationContext(authority);
                Result = authContext.AcquireToken(graphUri, cred).AccessToken.ToString();
                System.Diagnostics.Debug.WriteLine("Bearer " + Result);
            }



            //public AuthenticationResult AcquireToken(string resource, string clientId, UserCredential userCredential);
            return Result;
        }
    }
}