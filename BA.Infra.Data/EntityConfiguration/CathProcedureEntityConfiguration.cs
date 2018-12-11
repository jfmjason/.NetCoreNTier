using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class CathProcedureEntityConfiguration : IEntityTypeConfiguration<CathProcedure>
    {
        public void Configure(EntityTypeBuilder<CathProcedure> builder)
        {

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.AngioNumber)
                .HasMaxLength(6)
                .IsUnicode(false);

            builder.Property(e => e.ArabicCode).HasMaxLength(50);

            builder.Property(e => e.ArabicName).HasMaxLength(100);

            builder.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            builder.Property(e => e.EndDateTime).HasColumnType("datetime");

            builder.Property(e => e.Instructions).HasColumnType("text");

            builder.Property(e => e.LastUpdated).HasMaxLength(8);

            builder.Property(e => e.Modifieddatetime).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

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
