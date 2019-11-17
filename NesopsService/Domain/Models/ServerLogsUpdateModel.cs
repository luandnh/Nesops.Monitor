using System;
using System.Collections.Generic;

namespace NesopsService.Domain.Models
{
    public partial class ServerLogsUpdateModel
    {
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

    }
}
