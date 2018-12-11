using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class ClinicalTestOrderEntityConfiguration : IEntityTypeConfiguration<ClinicalTestOrder>
    {
        public void Configure(EntityTypeBuilder<ClinicalTestOrder> builder)
        {

            builder.HasKey(e => e.EntityId);

            builder.HasIndex(e => e.Orderid)
                .HasName("IX_ClinicaltestOrder_2");

            builder.HasIndex(e => new { e.VisitId, e.Testid })
                .HasName("IX_ClinicalTestOrder_1");

            builder.HasIndex(e => new { e.RegistrationNo, e.Billed, e.Testid })
                .HasName("IX_ClinicaltestOrder_3");

            builder.Property(e => e.EntityId).HasColumnName("EntityID");

            builder.Property(e => e.Billed).HasDefaultValueSql("(0)");

            builder.Property(e => e.IssueAuthorityCode)
                .HasMaxLength(6)
                .IsUnicode(false);

            builder.Property(e => e.Remarks)
                .HasMaxLength(1000)
                .IsUnicode(false);

        }
    }
}
