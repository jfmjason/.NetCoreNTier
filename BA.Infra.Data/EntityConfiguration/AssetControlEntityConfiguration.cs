using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class AssetControlEntityConfiguration : IEntityTypeConfiguration<AssetControl>
    {
        public void Configure(EntityTypeBuilder<AssetControl> builder)
        {
            builder.HasKey(e => e.ItemId);

            builder.HasIndex(e => new { e.ItemId, e.ControlNo })
                .HasName("IX_AssetControl");

            builder.Property(e => e.ItemId).ValueGeneratedNever();

            builder.Property(e => e.ControlNo)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
