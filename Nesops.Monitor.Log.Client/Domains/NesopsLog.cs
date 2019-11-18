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
        protected AppSettingsModel _appSettings = new AppSettingsModel();
        public NesopsLog()
        {
            var client = new NesopsHttpClient();
            _appSettings = client.NesopsHttpClientConfig();
            client = new NesopsHttpClient(_appSettings.MonitorUrl);
            this._client = client;
            CheckAuthorize();
        }
        public NesopsLog(NesopsHttpClient client)
        {
            _appSettings = client.NesopsHttpClientConfig();
            this._client = client;
            CheckAuthorize();
        }
        public void Information(string message)
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
        public void Information(string message,string logEvent)
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
        public void Warning(string message)
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
        public void Warning(string message, string logEvent)
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
        public void Exception(string message)
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
        public void Error(string message, string logEvent)
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
        public void Error(Exception ex)
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
        public void Error(Exception ex, string logEvent)
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
        private async void CheckAuthorize()
        {
            var authorize = new NesopsAuthorize();
            if (!authorize.CheckAuthorizeExpiredTime())
                await authorize.UpdateAuthorize();
        }
    }
}
