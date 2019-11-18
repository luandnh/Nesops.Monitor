using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Mapping
{
    public partial class AuditLogsMap
        : IEntityTypeConfiguration<NesopsService.Data.Entities.AuditLogs>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NesopsService.Data.Entities.AuditLogs> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("AuditLogs", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newsequentialid())");

            builder.Property(t => t.SeqId)
                .IsRequired()
                .HasColumnName("SeqId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.SysId)
                .IsRequired()
                .HasColumnName("SysId")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.Message)
                .IsRequired()
                .HasColumnName("Message")
                .HasColumnType("varchar(500)")
                .HasMaxLength(500);

            builder.Property(t => t.Level)
                .IsRequired()
                .HasColumnName("Level")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Exception)
                .HasColumnName("Exception")
                .HasColumnType("varchar(max)");

            builder.Property(t => t.LogEvent)
                .HasColumnName("LogEvent")
                .HasColumnType("varchar(max)");

            builder.Property(t => t.CreateAt)
                .IsRequired()
                .HasColumnName("CreateAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(t => t.UpdateAt)
                .IsRequired()
                .HasColumnName("UpdateAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(t => t.Active)
                .IsRequired()
                .HasColumnName("Active")
                .HasColumnType("bit")
                .HasDefaultValueSql("((1))");

            // relationships
            #endregion
        }

    }
}
