using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class UnitEntityConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {

            builder.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.StartDateTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");


        }
    }
}
