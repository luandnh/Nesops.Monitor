using NesopsService.Identifier;
using System;
using System.Collections.Generic;

namespace NesopsService.Data.Entities
{
    public partial class Servers : IHaveIdentifier
    {
        public Servers()
        {
            #region Generated Constructor
            ServerServerLogs = new HashSet<ServerLogs>();
            #endregion
        }

        #region Generated Properties
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public int ServerType { get; set; }

        public int ServerOS { get; set; }

        public bool Active { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<ServerLogs> ServerServerLogs { get; set; }

        #endregion

    }
}
