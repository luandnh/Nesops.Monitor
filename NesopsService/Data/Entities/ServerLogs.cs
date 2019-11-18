using NesopsService.Identifier;
using System;
using System.Collections.Generic;

namespace NesopsService.Data.Entities
{
    public partial class ServerLogs : IHaveIdentifier
    {
        public ServerLogs()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public Guid Id { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.UtcNow.AddHours(7);

        public DateTime UpdateAt { get; set; } = DateTime.UtcNow.AddHours(7);

        public int SeqId { get; set; }

        public Guid ServerId { get; set; }

        public string Message { get; set; }

        public string Type { get; set; }

        public string Level { get; set; }

        public bool Active { get; set; }

        #endregion

        #region Generated Relationships
        #endregion

    }
}
