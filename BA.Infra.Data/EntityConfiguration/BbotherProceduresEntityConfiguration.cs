using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class BBOtherProceduresEntityConfiguration : IEntityTypeConfiguration<BBOtherProcedures>
    {
        public void Configure(EntityTypeBuilder<BBOtherProcedures> builder)
        {

            builder.ToTable("BBOtherProcedures");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.Arabiccode)
                .HasColumnName("arabiccode")
                .HasMaxLength(50);

            builder.Property(e => e.Arabicname)
                .HasColumnName("arabicname")
                .HasMaxLength(100);

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Deleted).HasColumnName("deleted");

            builder.Property(e => e.Departmentid).HasColumnName("departmentid");

            builder.Property(e => e.Enddatetime)
                .HasColumnName("enddatetime")
                .HasColumnType("smalldatetime");

            builder.Property(e => e.Modifiedby).HasColumnName("modifiedby");

            builder.Property(e => e.Modifieddatetime)
                .HasColumnName("modifieddatetime")
                .HasColumnType("datetime");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Operatorid).HasColumnName("operatorid");

            builder.Property(e => e.Startdatetime)
                .HasColumnName("startdatetime")
                .HasColumnType("smalldatetime");

            builder.Property(e => e.Type)
                .HasColumnName("type")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.Udatetime)
                .HasColumnName("udatetime")
                .HasColumnType("datetime");

            builder.Property(e => e.Uploaded)
                .HasColumnName("uploaded")
                .HasDefaultValueSql("((0))");

        }
    }
}
