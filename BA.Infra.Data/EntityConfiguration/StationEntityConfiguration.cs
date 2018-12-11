using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class StationEntityConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {

            builder.HasIndex(e => e.Id)
                .HasName("IX_Station");

            builder.HasIndex(e => new { e.Id, e.DepartmentId })
                .HasName("IX_Station_1");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            builder.Property(e => e.Appid).HasColumnName("appid");

            builder.Property(e => e.Arabicname)
                .HasColumnName("ARABICNAME")
                .HasMaxLength(100);

            builder.Property(e => e.Code)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.EndDateTime).HasColumnType("datetime");

            builder.Property(e => e.Location)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Modifiedby).HasColumnName("modifiedby");

            builder.Property(e => e.Modifieddatetime).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Operatorid).HasColumnName("operatorid");

            builder.Property(e => e.OraCode)
                .HasColumnName("ORA_CODE")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Prefix)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.StartDateTime).HasColumnType("datetime");

            builder.Property(e => e.StationTypeId).HasColumnName("StationTypeID");


        }
    }
}
