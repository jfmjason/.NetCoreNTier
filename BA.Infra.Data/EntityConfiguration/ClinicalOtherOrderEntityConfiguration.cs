using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class ClinicalOtherOrderEntityConfiguration : IEntityTypeConfiguration<ClinicalOtherOrder>
    {
        public void Configure(EntityTypeBuilder<ClinicalOtherOrder> builder)
        {

            builder.HasKey(e => e.EntityId)
                    .ForSqlServerIsClustered(false);

            builder.HasIndex(e => e.RegistrationNo)
                .HasName("IX_ClinicalOtherOrder_3");

            builder.HasIndex(e => e.Testid)
                .HasName("IX_ClinicalOtherOrder_2");

            builder.HasIndex(e => e.VisitId)
                .HasName("IX_ClinicalOtherOrder_1")
                .ForSqlServerIsClustered();

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
