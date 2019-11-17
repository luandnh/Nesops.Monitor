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

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public int SeqId { get; set; }

        public Guid ServerId { get; set; }

        public string Message { get; set; }

        public int Level { get; set; }

        public bool Active { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Servers ServerServers { get; set; }

        #endregion

    }
}
