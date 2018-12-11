using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class OPBServiceEntityConfiguration : IEntityTypeConfiguration<OPBService>
    {
        public void Configure(EntityTypeBuilder<OPBService> builder)
        {

                builder.ToTable("OPBService");

                builder.Property(e => e.Id).ValueGeneratedNever();

                builder.Property(e => e.DetaiTtable)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                builder.Property(e => e.EndDateTime).HasColumnType("datetime");

                builder.Property(e => e.MasterTable)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                builder.Property(e => e.OraCode)
                    .HasColumnName("Ora_Code")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                builder.Property(e => e.OrderTable)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                builder.Property(e => e.PriceTable)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                builder.Property(e => e.ServiceCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                builder.Property(e => e.StartDateTime).HasColumnType("datetime");

                builder.Property(e => e.SupportTable)
                    .HasMaxLength(20)
                    .IsUnicode(false);
     

        }
    }
}
