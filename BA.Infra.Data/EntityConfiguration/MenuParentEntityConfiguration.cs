using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class MenuParentEntityConfiguration : IEntityTypeConfiguration<MenuParent>
    {
        public void Configure(EntityTypeBuilder<MenuParent> builder)
        {
            builder.ToTable("MENU_PARENT", "HISGLOBAL");

            builder.Property(e => e.MenuId).HasColumnName("MenuID");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
