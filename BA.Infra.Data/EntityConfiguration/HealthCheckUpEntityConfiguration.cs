using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class HealthCheckUpEntityConfiguration : IEntityTypeConfiguration<HealthCheckUp>
    {
        public void Configure(EntityTypeBuilder<HealthCheckUp> builder)
        {

            builder.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

            builder.Property(e => e.Code)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.Companyid).HasColumnName("companyid");

            builder.Property(e => e.EndDateTime).HasColumnType("datetime");

            builder.Property(e => e.Instructions)
                .HasColumnName("instructions")
                .HasColumnType("text");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

            builder.Property(e => e.StartDateTime).HasColumnType("datetime");

            builder.Property(e => e.Uploaded)
                .HasColumnName("UPLOADED")
                .HasDefaultValueSql("((0))");


        }
    }
}
