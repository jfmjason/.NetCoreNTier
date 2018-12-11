using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class BedTypeEntityConfiguration : IEntityTypeConfiguration<BedType>
    {
        public void Configure(EntityTypeBuilder<BedType> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Arabiccode)
                .HasColumnName("arabiccode")
                .HasMaxLength(50);

            builder.Property(e => e.Arabicname)
                .HasColumnName("arabicname")
                .HasMaxLength(100);

            builder.Property(e => e.Billable)
                .HasColumnName("BILLABLE")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.Code)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Deleted).HasColumnName("deleted");

            builder.Property(e => e.Enddatetime)
                .HasColumnName("enddatetime")
                .HasColumnType("smalldatetime");

            builder.Property(e => e.Label)
                .HasColumnName("label")
                .HasMaxLength(8)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Startdatetime)
                .HasColumnName("startdatetime")
                .HasColumnType("smalldatetime");

            builder.Property(e => e.Type).HasColumnName("type");



        }
    }
}
