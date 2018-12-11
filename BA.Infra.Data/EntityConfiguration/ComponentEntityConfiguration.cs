using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class ComponentEntityConfiguration : IEntityTypeConfiguration<Component>
    {
        public void Configure(EntityTypeBuilder<Component> builder)
        {
            builder.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

            builder.Property(e => e.Arabiccode).HasMaxLength(100);

            builder.Property(e => e.Arabicname).HasMaxLength(100);

            builder.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.EndDateTime).HasColumnType("datetime");

            builder.Property(e => e.LastUpdated)
                .IsRequired()
                .IsRowVersion();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.StartDateTime).HasColumnType("datetime");

            builder.Property(e => e.TempName)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Udatetime)
                .HasColumnName("udatetime")
                .HasColumnType("datetime");

            builder.Property(e => e.Unit)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Uploaded)
                .HasColumnName("uploaded")
                .HasDefaultValueSql("((0))");
        }
    }
}
