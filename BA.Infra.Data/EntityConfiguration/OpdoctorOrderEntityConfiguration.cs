using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class OpdoctorOrderEntityConfiguration : IEntityTypeConfiguration<OpDoctorOrder>
    {
        public void Configure(EntityTypeBuilder<OpDoctorOrder> builder)
        {

            builder.ToTable("OPDoctorOrder");

            builder.HasIndex(e => e.OpbillId)
                .HasName("IX_OPDoctorOrder_OPBillId");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            builder.Property(e => e.OpbillId).HasColumnName("OPBillID");


        }
    }
}
