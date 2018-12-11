using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class MiscItemEntityConfiguration : IEntityTypeConfiguration<MiscItem>
    {
        public void Configure(EntityTypeBuilder<MiscItem> builder)
        {
            builder.ToTable("MiscItems");
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

            builder.Property(e => e.Arabiccode)
                .HasColumnName("ARABICCODE")
                .HasMaxLength(50);

            builder.Property(e => e.Arabicname)
                .HasColumnName("ARABICNAME")
                .HasMaxLength(100);

            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            builder.Property(e => e.EndDateTime).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

            builder.Property(e => e.StartDateTime).HasColumnType("datetime");

        }
    }
}
