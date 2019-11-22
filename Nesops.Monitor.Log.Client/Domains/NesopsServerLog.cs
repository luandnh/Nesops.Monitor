using Nesops.Monitor.Log.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nesops.Monitor.Log.Client.Domains
{
    public class NesopsServerLog
    {
        protected NesopsHttpClient _client { get; set; }
        protected string _routePrefix = "api/serverlogs";
        protected AppSettingsModel _appSettings = new AppSettingsModel();
        public NesopsServerLog()
        {
            var client = new NesopsHttpClient();
            _appSettings = client.NesopsHttpClientConfig();
            client = new NesopsHttpClient(_appSettings.MonitorUrl);
            this._client = client;
            CheckAuthorize().Wait();
        }
        public NesopsServerLog(NesopsHttpClient client)
        {
            _appSettings = client.NesopsHttpClientConfig();
            this._client = client;
            CheckAuthorize().Wait();
        }
        public async Task<HttpResponseMessage> Information(string message, string type)
        {
            var uri = _routePrefix;
            var log = new ServerLog()
            {
                Level = "Information",
                Type = type,
                Message = message
            };
            string json = JsonConvert.SerializeObject(log, Formatting.Indented);
            var mess = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri, UriKind.Relative),
                Content = new StringContent(json, UnicodeEncoding.UTF8, "application/json")
            };
            mess.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _appSettings.AuthorizeConfiguration.access_token);
            return await _client.Http.SendAsync(mess);
        }
        private async Task CheckAuthorize()
        {
            var authorize = new NesopsAuthorize();
            if (!await authorize.CheckAuthorizeExpiredTime())
            {
                var result = await authorize.UpdateAuthorize();
            }
        }
    }
}
