using System;
using System.Collections.Generic;

namespace NesopsService.Domain.Models
{
    public partial class ServerLogsCreateModel
    {
        #region Generated Properties

        public Guid ServerId { get; set; }

        public string Message { get; set; }

        public string Type { get; set; }

        public string Level { get; set; }

        #endregion

    }
}
