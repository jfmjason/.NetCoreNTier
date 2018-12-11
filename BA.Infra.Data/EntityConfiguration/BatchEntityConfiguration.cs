using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class BatchEntityConfiguration : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder)
        {
            builder.HasKey(e => new { e.BatchId, e.BatchNo });

            builder.HasIndex(e => e.BatchNo)
                .HasName("IX_Batch");

            builder.HasIndex(e => e.ItemId)
                .HasName("ix_Batch_ItemID");

            builder.HasIndex(e => e.StartDate)
                .HasName("IX_Batch_2");

            builder.Property(e => e.BatchId)
                .HasColumnName("BatchID")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.BatchNo)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.CostPrice).HasColumnType("numeric(20, 8)");

            builder.Property(e => e.ExpiryDate).HasColumnType("datetime");

            builder.Property(e => e.ItemId).HasColumnName("ItemID");

            builder.Property(e => e.Middleware).HasColumnName("MIDDLEWARE");

            builder.Property(e => e.Mrp)
                .HasColumnName("MRP")
                .HasColumnType("numeric(18, 6)");

            builder.Property(e => e.PurRate).HasColumnType("numeric(24, 4)");

            builder.Property(e => e.SellingPrice).HasColumnType("numeric(18, 6)");

            builder.Property(e => e.StartDate).HasColumnType("datetime");

            builder.Property(e => e.Tax).HasColumnType("numeric(12, 2)");

            builder.Property(e => e.UnitEpr).HasColumnType("numeric(14, 5)");
        }
    }
}
