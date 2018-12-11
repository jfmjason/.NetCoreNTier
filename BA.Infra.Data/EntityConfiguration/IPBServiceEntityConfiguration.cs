using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class IPBServiceEntityConfiguration : IEntityTypeConfiguration<IPBService>
    {
        public void Configure(EntityTypeBuilder<IPBService> builder)
        {
            builder.HasKey(e => e.Id)
                .ForSqlServerIsClustered(false);

            builder.ToTable("IPBService");

            builder.HasIndex(e => e.DisplayServiceId)
                .HasName("Ind_NonClus_IpBServie_DiscplayServiceID");

            builder.HasIndex(e => e.Id)
                .HasName("Ind_Clus_IpBService_ID")
                .ForSqlServerIsClustered();

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            builder.Property(e => e.ArabicServiceCode).HasMaxLength(100);

            builder.Property(e => e.ArabicServiceName).HasMaxLength(100);

            builder.Property(e => e.Category).HasColumnName("category");

            builder.Property(e => e.DetailTable)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.DisplayServiceId).HasColumnName("DisplayServiceID");

            builder.Property(e => e.GroupTable)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Itemlevel).HasColumnName("itemlevel");

            builder.Property(e => e.MasterTable)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.OraCode)
                .HasColumnName("Ora_Code")
                .HasMaxLength(5)
                .IsUnicode(false);

            builder.Property(e => e.OrderTable)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.PriceTable)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.ServiceName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.SupportTable)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Udatetime)
                .HasColumnName("udatetime")
                .HasColumnType("datetime");

            builder.Property(e => e.Uploaded)
                .HasColumnName("uploaded")
                .HasDefaultValueSql("((0))");

        }
    }
}
