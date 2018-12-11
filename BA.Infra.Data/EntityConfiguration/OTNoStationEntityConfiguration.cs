using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class OTNoEntityConfiguration : IEntityTypeConfiguration<OTNo>
    {
        public void Configure(EntityTypeBuilder<OTNo> builder)
        {

            builder.ToTable("OTNo");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.EndDateTime).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.OttypeId).HasColumnName("OTTypeID");

            builder.Property(e => e.StartDateTime).HasColumnType("datetime");

            builder.Property(e => e.Stationid).HasColumnName("stationid");


        }
    }
}
