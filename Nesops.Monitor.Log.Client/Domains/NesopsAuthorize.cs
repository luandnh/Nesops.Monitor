using Nesops.Monitor.Log.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nesops.Monitor.Log.Client.Domains
{
    public class NesopsAuthorize
    {
        protected NesopsHttpClient _client { get; set; }
        protected string _routePrefix = "api/authorize";
        protected AppSettingsModel _appSettings = new AppSettingsModel();
        public NesopsAuthorize()
        {
            var client = new NesopsHttpClient();
            _appSettings = client.NesopsHttpClientConfig();
            client = new NesopsHttpClient(_appSettings.AuthorizeUrl);
            this._client = client;
        }
        public NesopsAuthorize(NesopsHttpClient client)
        {
            _appSettings = client.NesopsHttpClientConfig();
            this._client = client;
        }
        public async ValueTask<HttpResponseMessage> Authorize(string username, string password)
        {
            var uri = _routePrefix;
            if (username == null || password == null)
            {
                return null;
            }
            var log = new AuthorizeModel()
            {
                Username = username,
                Password = password
            };
            string json = JsonConvert.SerializeObject(log, Formatting.Indented);
            var mess = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri, UriKind.Relative),
                Content = new StringContent(json, UnicodeEncoding.UTF8, "application/json")
            };
            var result = await _client.Http.SendAsync(mess);
            return result;
        }
        public async Task<HttpResponseMessage> CheckToken(string token)
        {
            var route = "checkToken";
            var uri = _routePrefix + "/" + route;
            var mess = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri, UriKind.Relative)
            };
            mess.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            return await _client.Http.SendAsync(mess);
        }
        public async Task<IdentityTokenResponseModel> CheckTokenParseResponse(string token)
        {
            var resp = await CheckToken(token);
            if (resp.IsSuccessStatusCode)
            {
                var result = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IdentityTokenResponseModel>(result);
            }
            return null;
        }
        public async ValueTask<bool> UpdateAuthorize()
        {
            var result = await  Authorize(_appSettings.LocalUsername, _appSettings.LocalPassword);
            if (!result.IsSuccessStatusCode)
            {
                return false;
            }
            if (result == null)
            {
                return false;
            }
            var resJson = await result.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<NesopsBaseResponse<AuthorizeResponseModel>>(resJson);
            _client.UpdateAppSettings<string>("NesopsConfiguration:AuthorizeConfiguration:Access_token", res.data.access_token);
            _client.UpdateAppSettings<string>("NesopsConfiguration:AuthorizeConfiguration:Expire_utc", res.data.expire_utc.ToString());
            _client.UpdateAppSettings<string>("NesopsConfiguration:AuthorizeConfiguration:Issued_utc", res.data.issued_utc.ToString());
            return true;
        }
        public async Task<bool> CheckAuthorizeExpiredTime()
        {
            var result = await CheckToken(_appSettings.AuthorizeConfiguration.access_token);
            if (!result.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }
    }
}
