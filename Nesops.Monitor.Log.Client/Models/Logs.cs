using System;
using System.Collections.Generic;

namespace Nesops.Monitor.Log.Client.Models
{
    public partial class Logs
    {
        public Logs()
        {
        }

        public string Message { get; set; }

        public string Level { get; set; }

        public string Exception { get; set; }

        public string LogEvent { get; set; }

    }
    public class ServerLog
    {
        public string Message { get; set; }

        public string Type { get; set; }

        public string Level { get; set; }
    }
}
