using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class PTProcedureEntityConfiguration : IEntityTypeConfiguration<PTProcedure>
    {
        public void Configure(EntityTypeBuilder<PTProcedure> builder)
        {
            builder.ToTable("PTProcedure");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.ArabicCode).HasMaxLength(50);

            builder.Property(e => e.ArabicName).HasMaxLength(100);

            builder.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.CostPrice).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            builder.Property(e => e.EndDateTime).HasColumnType("datetime");

            builder.Property(e => e.Instructions)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.ModifiedDateTime).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.StartDateTime).HasColumnType("datetime");

            builder.Property(e => e.StationId)
                .HasColumnName("StationID")
                .HasDefaultValueSql("(19)");

            builder.Property(e => e.Udatetime)
                .HasColumnName("UDATETIME")
                .HasColumnType("datetime");

            builder.Property(e => e.Uploaded)
                .HasColumnName("UPLOADED")
                .HasDefaultValueSql("((0))");
        }
    }
}
