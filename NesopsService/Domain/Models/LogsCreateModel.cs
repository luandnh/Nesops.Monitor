using System;
using System.Collections.Generic;

namespace NesopsService.Domain.Models
{
    public partial class LogsCreateModel
    {
        #region Generated Properties
        public Guid Id { get; set; }

        public int SeqId { get; set; }

        public Guid SysId { get; set; }

        public string Message { get; set; }

        public string Level { get; set; }

        public string Exception { get; set; }

        public string LogEvent { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public bool Active { get; set; }

        #endregion

    }
}
