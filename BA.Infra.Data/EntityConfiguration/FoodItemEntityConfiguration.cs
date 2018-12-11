using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class FoodItemEntityConfiguration : IEntityTypeConfiguration<FoodItem>
    {
        public void Configure(EntityTypeBuilder<FoodItem> builder)
        {

            builder.Property(e => e.ArabicCode).HasMaxLength(50);

            builder.Property(e => e.ArabicName).HasMaxLength(100);

            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");

            builder.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.CostPrice).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            builder.Property(e => e.EndDateTime).HasColumnType("datetime");

            builder.Property(e => e.LastUpdated).HasMaxLength(1);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

            builder.Property(e => e.SectionId).HasColumnName("SectionID");

            builder.Property(e => e.StartDateTime).HasColumnType("datetime");

            builder.Property(e => e.Udatetime)
                .HasColumnName("udatetime")
                .HasColumnType("datetime");

            builder.Property(e => e.Units)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Uploaded)
                .HasColumnName("uploaded")
                .HasDefaultValueSql("((0))");


        }
    }
}
