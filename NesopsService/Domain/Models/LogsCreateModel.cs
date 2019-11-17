using System;
using System.Collections.Generic;

namespace NesopsService.Domain.Models
{
    public partial class LogsCreateModel
    {
        #region Generated Properties

        public string Message { get; set; }

        public string Level { get; set; }

        public string Exception { get; set; }

        public string LogEvent { get; set; }

        #endregion

    }
}
