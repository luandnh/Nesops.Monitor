using System;
using System.Collections.Generic;

namespace NesopsService.Domain.Models
{
    public partial class AuditLogsCreateModel
    {
        #region Generated Properties

        public Guid SysId { get; set; }

        public string Message { get; set; }

        public string Level { get; set; }

        public string Exception { get; set; }

        public string LogEvent { get; set; }

        #endregion

    }
}
