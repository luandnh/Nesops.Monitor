using Microsoft.Extensions.Configuration;
using Nesops.Monitor.Log.Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Nesops.Monitor.Log.Client
{
    public class NesopsHttpClient
    {
        public HttpClient Http { get; set; }
        public NesopsHttpClientInfo _clientInfo { get; set; }
        public NesopsHttpClient()
        {
        }
        public NesopsHttpClient(NesopsHttpClientInfo clientInfo)
        {
            this._clientInfo = clientInfo;
            Http = new HttpClient(new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (a, b, c, d) => true
            });
            Http.Timeout = TimeSpan.FromMinutes(1);
            Http.BaseAddress = new Uri(clientInfo.BaseAddress);
        }
        public NesopsHttpClient(string httpClientUrl)
        {
            string baseAddress = httpClientUrl;
            if (baseAddress.EndsWith("/") || baseAddress.EndsWith("\\"))
                baseAddress.Remove(baseAddress.Length - 1);
            Http = new HttpClient(new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (a, b, c, d) => true
            });
            Http.Timeout = TimeSpan.FromMinutes(1);
            Http.BaseAddress = new Uri(baseAddress);
        }
        public AppSettingsModel NesopsHttpClientConfig()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json",optional:true,reloadOnChange:true);
            var config = builder.Build();
            return config.GetSection("NesopsConfiguration").Get<AppSettingsModel>();
        }
        public void UpdateAppSettings<T>(string key, T value)
        {
            try
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, "appSettings.json");
                string json = File.ReadAllText(filePath);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                var sectionPathArr = key.Split(":");
                var sectionPath = key.Split(":")[0];
                if (!string.IsNullOrEmpty(sectionPath))
                {
                    var keyLength = sectionPathArr.Length - 1;
                    var keyPath = sectionPathArr[keyLength];
                    switch (keyLength)
                    {
                        case 1: jsonObj[sectionPath][keyPath] = value;
                            break;
                        case 2:
                            var keyPath1 = sectionPathArr[1];
                            jsonObj[sectionPath][keyPath1][keyPath] = value;
                            break;
                        case 3:
                            keyPath1 = sectionPathArr[1];
                            var keyPath2 = sectionPathArr[2];
                            jsonObj[sectionPath][keyPath1][keyPath2][keyPath] = value;
                            break;
                        case 4:
                            keyPath1 = sectionPathArr[1];
                            keyPath2 = sectionPathArr[2];
                            var keyPath3 = sectionPathArr[3];
                            jsonObj[sectionPath][keyPath1][keyPath2][keyPath3][keyPath] = value;
                            break;
                        case 5:
                            keyPath1 = sectionPathArr[1];
                            keyPath2 = sectionPathArr[2];
                            keyPath3 = sectionPathArr[3];
                            var keyPath4 = sectionPathArr[4];
                            jsonObj[sectionPath][keyPath1][keyPath2][keyPath3][keyPath4][keyPath] = value;
                            break;
                    };
                }
                else
                {
                    jsonObj[sectionPath] = value;
                }
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, output);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing app settings : "+ex.Message);
            }
        }
        public void ResetAppSettings()
        {
            UpdateAppSettings<string>("NesopsConfiguration:MonitorUrl", "http://monitor.nesops.xyz");
            UpdateAppSettings<string>("NesopsConfiguration:AuthorizeUrl", "http://authorize.nesops.xyz");
            UpdateAppSettings<string>("NesopsConfiguration:LocalUsername", "nesops.xyz");
            UpdateAppSettings<string>("NesopsConfiguration:LocalPassword", "nesops.xyz");
            UpdateAppSettings<string>("NesopsConfiguration:AuthorizeConfiguration:Access_token", "token");
            UpdateAppSettings<string>("NesopsConfiguration:AuthorizeConfiguration:Expire_utc", DateTime.UtcNow.AddDays(-1).ToString());
            UpdateAppSettings<string>("NesopsConfiguration:AuthorizeConfiguration:Issued_utc", DateTime.UtcNow.AddDays(-1).ToString());
        }
    }
    public class NesopsHttpClientInfo
    {
        public NesopsHttpClientInfo() { }
        public NesopsHttpClientInfo(string baseAddress)
        {
            this.BaseAddress = baseAddress;
        }
        private string baseAddress;
        public string BaseAddress
        {
            get
            {
                return baseAddress;
            }
            set
            {
                baseAddress = value;
                if (baseAddress.EndsWith("/") || baseAddress.EndsWith("\\"))
                    baseAddress.Remove(baseAddress.Length - 1);
            }
        }
    }
}
