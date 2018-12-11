using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class GradeEntityConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
                builder.HasIndex(e => new { e.CategoryId, e.CompanyId })
                    .HasName("IX_Grade");

                builder.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                builder.Property(e => e.ArabicName).HasMaxLength(100);

                builder.Property(e => e.BedTypeId).HasColumnName("BedTypeID");

                builder.Property(e => e.CategoryId).HasColumnName("CategoryID");

                builder.Property(e => e.CompanyId).HasColumnName("CompanyID");

                builder.Property(e => e.EndDateTime).HasColumnType("datetime");

                builder.Property(e => e.FixedConCharges).HasColumnType("numeric(9, 2)");

                builder.Property(e => e.GradeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.InvoiceConFee).HasColumnType("numeric(9, 2)");

                builder.Property(e => e.IpcreditLimit)
                    .HasColumnName("IPCreditLimit")
                    .HasColumnType("numeric(14, 2)");

                builder.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                builder.Property(e => e.Opconsultations)
                    .HasColumnName("OPConsultations")
                    .HasDefaultValueSql("(0)");

                builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

                builder.Property(e => e.PolicyNo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                builder.Property(e => e.RoomCharges).HasColumnType("decimal(9, 4)");

                builder.Property(e => e.StartDateTime).HasColumnType("datetime");

                builder.Property(e => e.TariffId)
                    .HasColumnName("TariffID")
                    .HasDefaultValueSql("(0)");
         

        }
    }
}
