using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NesopsService.Data
{
    public partial class NesopsMonitorContext : DbContext
    {
        public NesopsMonitorContext(DbContextOptions<NesopsMonitorContext> options)
            : base(options)
        {
        }

        #region Generated Properties
        public virtual DbSet<NesopsService.Data.Entities.Applications> Applications { get; set; }

        public virtual DbSet<NesopsService.Data.Entities.Logs> Logs { get; set; }

        public virtual DbSet<NesopsService.Data.Entities.ServerLogs> ServerLogs { get; set; }

        public virtual DbSet<NesopsService.Data.Entities.Servers> Servers { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Generated Configuration
            modelBuilder.ApplyConfiguration(new NesopsService.Data.Mapping.ApplicationsMap());
            modelBuilder.ApplyConfiguration(new NesopsService.Data.Mapping.LogsMap());
            modelBuilder.ApplyConfiguration(new NesopsService.Data.Mapping.ServerLogsMap());
            modelBuilder.ApplyConfiguration(new NesopsService.Data.Mapping.ServersMap());
            #endregion
        }
    }
}
