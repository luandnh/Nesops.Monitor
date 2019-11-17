using System;
using System.Collections.Generic;
using System.Text;

namespace Nesops.Monitor.Log.Client.Models
{
    public class AuthorizeModel
    {
        public string Username { get; set; } = null;
        public string Password { get; set; } = null;
    }
    public class AuthorizeResponseModel
    {
        public string access_token { get; set; }
        public DateTime expire_utc { get; set; }
        public DateTime issued_utc { get; set; }
    }
    public class NesopsBaseResponse<T> where T : class, new()
    {
        public T data { get; set; }
        public int code { get; set; }
    }
    public class IdentityTokenResponseModel
    {
        public string User { get; set; }
        public string UserId { get; set; }
        public IDictionary<string, IEnumerable<string>> Claims { get; }

        public IdentityTokenResponseModel()
        {
        }
    }
}
