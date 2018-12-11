using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class BioInstallEntityConfiguration : IEntityTypeConfiguration<BioInstall>
    {
        public void Configure(EntityTypeBuilder<BioInstall> builder)
        {

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.CanBeScheduled).HasDefaultValueSql("(0)");

            builder.Property(e => e.ControlNo)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.CurrentStationId).HasColumnName("CurrentStationID");

            builder.Property(e => e.Enddatetime).HasColumnType("datetime");

            builder.Property(e => e.EquipmentFunctionality)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.EquipmentGroupId).HasColumnName("EquipmentGroupID");

            builder.Property(e => e.ExtensionNumber)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Fixedassetsperson).HasColumnName("fixedassetsperson");

            builder.Property(e => e.Inspectedby).HasColumnName("inspectedby");

            builder.Property(e => e.InstallPersonDesg)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.InstalledBy)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.InstalledDatetime).HasColumnType("datetime");

            builder.Property(e => e.Panicmessage)
                .HasColumnName("panicmessage")
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.Startdatetime).HasColumnType("datetime");

            builder.Property(e => e.Umdnsclassification)
                .HasColumnName("UMDNSClassification")
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Umdnsnumber)
                .HasColumnName("UMDNSNumber")
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.WarranteePeriod).HasColumnType("datetime");


        }
    }
}
