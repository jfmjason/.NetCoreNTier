using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class ItemEntityConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {

            builder.HasIndex(e => e.CategoryId)
                       .HasName("IX_ItemCategory");

            builder.HasIndex(e => e.ItemCode)
                .HasName("IX_Item_Code");

            builder.HasIndex(e => e.Name)
                .HasName("DM_INDX_ITEM_BYNAME");

            builder.HasIndex(e => e.OraCode)
                .HasName("item_oracode");

            builder.HasIndex(e => new { e.ItemCode, e.CategoryId })
                .HasName("IX_ITEM_1");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            builder.Property(e => e.Approval).HasDefaultValueSql("(0)");

            builder.Property(e => e.ArabicCode).HasMaxLength(50);

            builder.Property(e => e.ArabicName).HasMaxLength(100);

            builder.Property(e => e.CapitalRevenue).HasDefaultValueSql("(0)");

            builder.Property(e => e.CatalogueNo)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");

            builder.Property(e => e.Consignment).HasDefaultValueSql("(0)");

            builder.Property(e => e.CriticalItem).HasDefaultValueSql("(0)");

            builder.Property(e => e.Cssdapp)
                .HasColumnName("CSSDApp")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.Cssditem).HasColumnName("CSSDItem");

            builder.Property(e => e.DateUnified)
                .HasColumnName("Date_Unified")
                .HasColumnType("datetime");

            builder.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.DuplicateLabel).HasDefaultValueSql("(0)");

            builder.Property(e => e.EndDateTime).HasColumnType("datetime");

            builder.Property(e => e.Eub).HasColumnName("EUB");

            builder.Property(e => e.FixedAsset).HasDefaultValueSql("(0)");

            builder.Property(e => e.IsUnified).HasDefaultValueSql("((0))");

            builder.Property(e => e.IssueType).HasDefaultValueSql("(0)");

            builder.Property(e => e.ItemCode)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ItemPrefix)
                .HasMaxLength(6)
                .IsUnicode(false);

            builder.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

            builder.Property(e => e.ModelNo)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.ModifiedDatetime).HasColumnType("datetime");

            builder.Property(e => e.Mrpitem).HasColumnName("MRPItem");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Name1)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.OraCode)
                .HasColumnName("Ora_code")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.OrcItemCode)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.PartNumber)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.PrevOraCode)
                .HasColumnName("Prev_Ora_Code")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ProfitCenter)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ProfitCentreId).HasColumnName("ProfitCentreID");

            builder.Property(e => e.SellingPrice).HasColumnType("money");

            builder.Property(e => e.StartDateTime).HasColumnType("datetime");

            builder.Property(e => e.Strength)
                .HasMaxLength(35)
                .IsUnicode(false);

            builder.Property(e => e.StrengthNo)
                .HasColumnName("Strength_No")
                .HasColumnType("numeric(12, 2)");

            builder.Property(e => e.StrengthUnit)
                .HasColumnName("Strength_Unit")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.TempId).HasColumnName("TempID");

            builder.Property(e => e.UnitId).HasColumnName("UnitID");

            builder.Property(e => e.Uploaded).HasDefaultValueSql("(0)");
        }
    }
}
