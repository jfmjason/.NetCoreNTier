using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class SurgeryEntityConfiguration : IEntityTypeConfiguration<Surgery>
    {
        public void Configure(EntityTypeBuilder<Surgery> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.ArabicCode).HasMaxLength(50);

            builder.Property(e => e.ArabicName).HasMaxLength(100);

            builder.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            builder.Property(e => e.EndDateTime).HasColumnType("datetime");

            builder.Property(e => e.Instructions)
                .HasMaxLength(2000)
                .IsUnicode(false);

            builder.Property(e => e.ModifiedDateTime).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

            builder.Property(e => e.Package)
                .HasColumnName("package")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.StartDateTime).HasColumnType("datetime");

            builder.Property(e => e.Udatetime)
                .HasColumnName("UDATETIME")
                .HasColumnType("datetime");

            builder.Property(e => e.Uploaded)
                .HasColumnName("UPLOADED")
                .HasDefaultValueSql("((0))");
        }
    }
}
