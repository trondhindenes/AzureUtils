using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureUtils.Models
{
    public class AzureAdUser
    {
        public String userPrincipalName { get; set; }
        public String objectId { get; set; }
        public String displayName { get; set; }
    }
}