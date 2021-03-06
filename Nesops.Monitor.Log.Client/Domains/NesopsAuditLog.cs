﻿using Nesops.Monitor.Log.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nesops.Monitor.Log.Client.Domains
{
    public class NesopsAuditLog
    {
        protected NesopsHttpClient _client { get; set; }
        protected string _routePrefix = "api/auditlogs";
        protected AppSettingsModel _appSettings = new AppSettingsModel();
        public NesopsAuditLog()
        {
            var client = new NesopsHttpClient();
            _appSettings = client.NesopsHttpClientConfig();
            client = new NesopsHttpClient(_appSettings.MonitorUrl);
            this._client = client;
            CheckAuthorize().Wait();
        }
        public NesopsAuditLog(NesopsHttpClient client)
        {
            _appSettings = client.NesopsHttpClientConfig();
            this._client = client;
            CheckAuthorize().Wait();
        }
        public async Task<HttpResponseMessage> Information(string message)
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
            mess.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _appSettings.AuthorizeConfiguration.access_token);
            return await _client.Http.SendAsync(mess);
        }
        public async Task<HttpResponseMessage> Information(string message, string logEvent)
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
            mess.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _appSettings.AuthorizeConfiguration.access_token);
            return await _client.Http.SendAsync(mess);
        }
        public async Task<HttpResponseMessage> Warning(string message)
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
            mess.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _appSettings.AuthorizeConfiguration.access_token);
            return await _client.Http.SendAsync(mess);
        }
        public async Task<HttpResponseMessage> Warning(string message, string logEvent)
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
            mess.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _appSettings.AuthorizeConfiguration.access_token);
            return await _client.Http.SendAsync(mess);
        }
        public async Task<HttpResponseMessage> Error(string message)
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
            mess.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _appSettings.AuthorizeConfiguration.access_token);
            return await _client.Http.SendAsync(mess);
        }
        public async Task<HttpResponseMessage> Error(string message, string logEvent)
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
            mess.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _appSettings.AuthorizeConfiguration.access_token);
            return await _client.Http.SendAsync(mess);
        }
        public async Task<HttpResponseMessage> Error(Exception ex)
        {
            var uri = _routePrefix;
            var log = new Logs()
            {
                Exception = JsonConvert.SerializeObject(ex),
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
            mess.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _appSettings.AuthorizeConfiguration.access_token);
            return await _client.Http.SendAsync(mess);
        }
        public async Task<HttpResponseMessage> Error(Exception ex, string logEvent)
        {
            var uri = _routePrefix;
            var log = new Logs()
            {
                Exception = JsonConvert.SerializeObject(ex),
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
