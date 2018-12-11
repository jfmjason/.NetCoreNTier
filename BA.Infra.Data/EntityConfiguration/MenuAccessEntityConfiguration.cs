using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class MenuAccessEntityConfiguration : IEntityTypeConfiguration<MenuAccess>
    {
        public void Configure(EntityTypeBuilder<MenuAccess> builder)
        {
            builder.ToTable("MENU_ACCESS", "HISGLOBAL");

            builder.Property(e => e.EndDateTime).HasColumnType("datetime");

            builder.Property(e => e.FeatureId).HasColumnName("FeatureID");

            builder.Property(e => e.MenuUrl)
                .IsRequired()
                .HasColumnName("MenuURL")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

            builder.Property(e => e.ParentId).HasColumnName("ParentID");

            builder.Property(e => e.StartDateTime).HasColumnType("datetime");
        }
    }
}
