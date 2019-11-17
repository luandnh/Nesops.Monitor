using System;
using System.Collections.Generic;
using System.Text;

namespace NesopsService.Service.Models.ResponseModels
{
    public class BaseResponseModel<TData> where TData : class
    {
        public string name { get; set; }
        public string message { get; set; }
        public int code { get; set; }
        public string className { get; set; }
        public TData data { get; set; }
        public IDictionary<string, string> errors { get; set; } = new Dictionary<string, string>();
        public void SetError(string name, string value)
        {
            errors[name] = value;
        }
    }
}
