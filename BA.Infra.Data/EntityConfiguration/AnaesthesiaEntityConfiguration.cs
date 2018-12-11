using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class AnaesthesiaEntityConfiguration : IEntityTypeConfiguration<Anaesthesia>
    {
        public void Configure(EntityTypeBuilder<Anaesthesia> builder)
        {

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Arabiccode)
                .HasColumnName("arabiccode")
                .HasMaxLength(50);

            builder.Property(e => e.Arabicname)
                .HasColumnName("arabicname")
                .HasMaxLength(100);

            builder.Property(e => e.Billingtype)
                .HasColumnName("billingtype")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Costprice)
                .HasColumnName("costprice")
                .HasColumnType("numeric(18, 0)");

            builder.Property(e => e.Deleted).HasColumnName("deleted");

            builder.Property(e => e.Enddatetime)
                .HasColumnName("enddatetime")
                .HasColumnType("smalldatetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Startdatetime)
                .HasColumnName("startdatetime")
                .HasColumnType("smalldatetime");

            builder.Property(e => e.Udatetime)
                .HasColumnName("udatetime")
                .HasColumnType("datetime");

            builder.Property(e => e.Uploaded)
                .HasColumnName("uploaded")
                .HasDefaultValueSql("((0))");
        }
    }
}
