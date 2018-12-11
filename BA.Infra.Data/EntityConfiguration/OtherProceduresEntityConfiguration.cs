using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class OtherProceduresEntityConfiguration : IEntityTypeConfiguration<OtherProcedure>
    {
        public void Configure(EntityTypeBuilder<OtherProcedure> builder)
        {
            builder.ToTable("OtherProcedures");
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.ArabicCode).HasMaxLength(50);

            builder.Property(e => e.ArabicName).HasMaxLength(100);

            builder.Property(e => e.Code)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.CostPrice).HasColumnType("numeric(12, 2)");

            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            builder.Property(e => e.EndDateTime).HasColumnType("datetime");

            builder.Property(e => e.Instructions).HasMaxLength(2000);

            builder.Property(e => e.ModifiedDateTime).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

            builder.Property(e => e.Remarks).HasMaxLength(500);

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
