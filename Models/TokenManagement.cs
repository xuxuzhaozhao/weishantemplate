using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 微山ASP.NETCore_LayUI开发框架.Models
{
    public class TokenManagement
    {
        [JsonProperty("secret")]
        public string Secret { get; set; }
        [JsonProperty("issuer")]
        public string Issuer { get; set; }
        [JsonProperty("audience")]
        public string Audience { get; set; }
        [JsonProperty("accessExpiration")]
        public int AccessExpiration { get; set; }
        [JsonProperty("refreshExpiration")]
        public int RefreshExpiration { get; set; }
    }
}
