using System;
using System.Collections.Generic;

namespace NesopsService.Domain.Models
{
    public partial class ApplicationsReadModel
    {
        #region Generated Properties
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string UrlAddress { get; set; }

        public bool Active { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        #endregion

    }
}