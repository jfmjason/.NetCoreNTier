using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class ItemGroupEntityConfiguration : IEntityTypeConfiguration<ItemGroup>
    {
        public void Configure(EntityTypeBuilder<ItemGroup> builder)
        {

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .ValueGeneratedNever();

            builder.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            builder.Property(e => e.Equipment).HasDefaultValueSql("(0)");

            builder.Property(e => e.MaxId).HasColumnName("MaxID");

            builder.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false);

            builder.Property(e => e.OverSea).HasDefaultValueSql("(0)");


        }
    }
}
