using NesopsService.Identifier;
using System;
using System.Collections.Generic;

namespace NesopsService.Data.Entities
{
    public partial class AuditLogs : IHaveIdentifier
    {
        public AuditLogs()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public Guid Id { get; set; }

        public int SeqId { get; set; }

        public Guid SysId { get; set; }

        public string Message { get; set; }

        public string Level { get; set; }

        public string Exception { get; set; }

        public string LogEvent { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.UtcNow.AddHours(7);

        public DateTime UpdateAt { get; set; } = DateTime.UtcNow.AddHours(7);

        public bool Active { get; set; }

        #endregion

        #region Generated Relationships
        #endregion

    }
}
