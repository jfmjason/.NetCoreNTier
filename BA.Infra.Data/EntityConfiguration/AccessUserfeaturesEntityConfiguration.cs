using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class AccessUserfeaturesEntityConfiguration : IEntityTypeConfiguration<AccessUserfeatures>
    {
        public void Configure(EntityTypeBuilder<AccessUserfeatures> builder)
        {
            builder.ToTable("ACCESS_USERFEATURES", "HISGLOBAL");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.EndDateTime).HasColumnType("datetime");

            builder.Property(e => e.FeatureId).HasColumnName("Feature_Id");

            builder.Property(e => e.ModuleId).HasColumnName("Module_Id");

            builder.Property(e => e.StartDateTime).HasColumnType("datetime");

            builder.Property(e => e.StationId).HasColumnName("Station_Id");

            builder.Property(e => e.Userid).HasColumnName("USERID");
        }
    }
}
