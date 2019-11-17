using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Mapping
{
    public partial class ServerLogsMap
        : IEntityTypeConfiguration<NesopsService.Data.Entities.ServerLogs>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NesopsService.Data.Entities.ServerLogs> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("ServerLogs", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newsequentialid())");

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

            builder.Property(t => t.SeqId)
                .IsRequired()
                .HasColumnName("SeqId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.ServerId)
                .IsRequired()
                .HasColumnName("ServerId")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.Message)
                .IsRequired()
                .HasColumnName("Message")
                .HasColumnType("varchar(500)")
                .HasMaxLength(500);

            builder.Property(t => t.Level)
                .IsRequired()
                .HasColumnName("Level")
                .HasColumnType("int");

            builder.Property(t => t.Active)
                .IsRequired()
                .HasColumnName("Active")
                .HasColumnType("bit")
                .HasDefaultValueSql("((1))");

            // relationships
            builder.HasOne(t => t.ServerServers)
                .WithMany(t => t.ServerServerLogs)
                .HasForeignKey(d => d.ServerId)
                .HasConstraintName("FK__ServerLog__Serve__628FA481");

            #endregion
        }

    }
}
