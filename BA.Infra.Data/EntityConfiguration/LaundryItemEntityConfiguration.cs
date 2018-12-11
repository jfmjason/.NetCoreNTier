using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class LaundryItemEntityConfiguration : IEntityTypeConfiguration<LaundryItem>
    {
        public void Configure(EntityTypeBuilder<LaundryItem> builder)
        {

            builder.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

            builder.HasIndex(e => e.DepartmentId)
                .HasName("Ind_NonClus_LaundryItem_DepartmentID");

            builder.HasIndex(e => e.Id)
                .HasName("Ind_Clus_LaundryItem_ID")
                .ForSqlServerIsClustered();

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.ArabicCode).HasMaxLength(50);

            builder.Property(e => e.ArabicName).HasMaxLength(100);

            builder.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            builder.Property(e => e.EndDateTime).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

            builder.Property(e => e.StartDateTime).HasColumnType("datetime");

            builder.Property(e => e.Udatetime)
                .HasColumnName("udatetime")
                .HasColumnType("datetime");

            builder.Property(e => e.Units)
                .HasMaxLength(8)
                .IsUnicode(false);

            builder.Property(e => e.Uploaded)
                .HasColumnName("uploaded")
                .HasDefaultValueSql("((0))");

        }
    }
}
