using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Mapping
{
    public partial class ApplicationsMap
        : IEntityTypeConfiguration<NesopsService.Data.Entities.Applications>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NesopsService.Data.Entities.Applications> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Applications", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newsequentialid())");

            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(200)")
                .HasMaxLength(200);

            builder.Property(t => t.DisplayName)
                .HasColumnName("DisplayName")
                .HasColumnType("varchar(200)")
                .HasMaxLength(200);

            builder.Property(t => t.Description)
                .HasColumnName("Description")
                .HasColumnType("text");

            builder.Property(t => t.UrlAddress)
                .HasColumnName("UrlAddress")
                .HasColumnType("varchar(200)")
                .HasMaxLength(200);

            builder.Property(t => t.Active)
                .IsRequired()
                .HasColumnName("Active")
                .HasColumnType("bit")
                .HasDefaultValueSql("((1))");

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

            // relationships
            #endregion
        }

    }
}
