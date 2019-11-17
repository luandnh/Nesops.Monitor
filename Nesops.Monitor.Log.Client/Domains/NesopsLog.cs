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
    public class NesopsLog
    {
        protected NesopsHttpClient _client { get; set; }
        protected string _routePrefix = "api/logs";
        public NesopsLog()
        {
            var client = new NesopsHttpClient();
            var config = client.NesopsHttpClientConfig();
            client = new NesopsHttpClient(config.MonitorUrl);
            this._client = client;
        }
        public NesopsLog(NesopsHttpClient client)
        {
            this._client = client;
        }
        public async ValueTask Information(string message)
        {
            var uri = _routePrefix;
            var log = new Logs()
            {
                Exception = null,
                Level = "Information",
                LogEvent = null,
                Message = message
            };
            string json = JsonConvert.SerializeObject(log, Formatting.Indented);
            var mess = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri, UriKind.Relative),
                Content = new StringContent(json, UnicodeEncoding.UTF8, "application/json")
            };
            var result = _client.Http.SendAsync(mess).Result;

        }
        public async ValueTask Information(string message,string logEvent)
        {
            var uri = _routePrefix;
            var log = new Logs()
            {
                Exception = null,
                Level = "Information",
                LogEvent = logEvent,
                Message = message
            };
            string json = JsonConvert.SerializeObject(log, Formatting.Indented);
            var mess = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri, UriKind.Relative),
                Content = new StringContent(json, UnicodeEncoding.UTF8, "application/json")
            };
            var result = _client.Http.SendAsync(mess).Result;
        }
        public async ValueTask Warning(string message)
        {
            var uri = _routePrefix;
            var log = new Logs()
            {
                Exception = null,
                Level = "Warning",
                LogEvent = null,
                Message = message
            };
            string json = JsonConvert.SerializeObject(log, Formatting.Indented);
            var mess = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri, UriKind.Relative),
                Content = new StringContent(json, UnicodeEncoding.UTF8, "application/json")
            };
            var result = _client.Http.SendAsync(mess).Result;
        }
        public async ValueTask Warning(string message, string logEvent)
        {
            var uri = _routePrefix;
            var log = new Logs()
            {
                Exception = null,
                Level = "Warning",
                LogEvent = logEvent,
                Message = message
            };
            string json = JsonConvert.SerializeObject(log, Formatting.Indented);
            var mess = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri, UriKind.Relative),
                Content = new StringContent(json, UnicodeEncoding.UTF8, "application/json")
            };
            var result = _client.Http.SendAsync(mess).Result;
        }
        public async ValueTask Exception(string message)
        {
            var uri = _routePrefix;
            var log = new Logs()
            {
                Exception = null,
                Level = "Error",
                LogEvent = null,
                Message = message
            };
            string json = JsonConvert.SerializeObject(log, Formatting.Indented);
            var mess = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri, UriKind.Relative),
                Content = new StringContent(json, UnicodeEncoding.UTF8, "application/json")
            };
            var result = _client.Http.SendAsync(mess).Result;
        }
        public async ValueTask Error(string message, string logEvent)
        {
            var uri = _routePrefix;
            var log = new Logs()
            {
                Exception = null,
                Level = "Error",
                LogEvent = logEvent,
                Message = message
            };
            string json = JsonConvert.SerializeObject(log, Formatting.Indented);
            var mess = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri, UriKind.Relative),
                Content = new StringContent(json, UnicodeEncoding.UTF8, "application/json")
            };
            var result = _client.Http.SendAsync(mess).Result;
        }
        public async ValueTask Error(Exception ex)
        {
            var uri = _routePrefix;
            var log = new Logs()
            {
                Exception = ex.ToString(),
                Level = "Error",
                LogEvent = null,
                Message = ex.Message
            };
            string json = JsonConvert.SerializeObject(log, Formatting.Indented);
            var mess = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri, UriKind.Relative),
                Content = new StringContent(json, UnicodeEncoding.UTF8, "application/json")
            };
            var result = _client.Http.SendAsync(mess).Result;
        }
        public async ValueTask Error(Exception ex, string logEvent)
        {
            var uri = _routePrefix;
            var log = new Logs()
            {
                Exception = ex.ToString(),
                Level = "Error",
                LogEvent = logEvent,
                Message = ex.Message
            };
            string json = JsonConvert.SerializeObject(log, Formatting.Indented);
            var mess = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri, UriKind.Relative),
                Content = new StringContent(json, UnicodeEncoding.UTF8, "application/json")
            };
            var result = _client.Http.SendAsync(mess).Result;
        }

    }
}
