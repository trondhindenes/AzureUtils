using AzureUtils.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AzureUtils.Models;
using System.Text;
using Newtonsoft.Json;

namespace AzureUtils.Controllers
{
    public class UserSearcherController : ApiController
    {
        public HttpResponseMessage Get(String UserName)
        {
            AzureAdUser returnedUser = UserUtils.findByUserName(UserName);
            if (returnedUser == null)
            {
                var response = this.Request.CreateResponse(HttpStatusCode.NotFound);
                return response;
            }
            else
            {
                //TODO: json is the payload
                String json = JsonConvert.SerializeObject(returnedUser);
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }
            
        }
    }
}
