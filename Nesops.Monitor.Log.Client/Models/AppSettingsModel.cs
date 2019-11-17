using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nesops.Monitor.Log.Client.Models
{
    [JsonObject("NesopsConfiguration")]
    public class AppSettingsModel
    {
        [JsonProperty("AuthorizeUrl")]
        public string AuthorizeUrl { get; set; } = null;
        [JsonProperty("MonitorUrl")] 
        public string MonitorUrl { get; set; } = null;
        [JsonProperty("LocalUsername")]
        public string LocalUsername { get; set; } = null;
        [JsonProperty("LocalPassword")]
        public string LocalPassword { get; set; } = null;
        [JsonProperty("AuthorizeConfiguration")]
        public AuthorizeConfiguration AuthorizeConfiguration { get; set; } = null;
    }
    public class AuthorizeConfiguration
    {
        [JsonProperty("Access_token")]
        public string access_token { get; set; }
        [JsonProperty("Expire_utc")]
        public string expire_utc { get; set; }
        [JsonProperty("Issued_utc")]
        public string issued_utc { get; set; }
    }
}
