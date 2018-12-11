using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
                builder.HasIndex(e => e.Id)
                    .HasName("IDX_DEPTID");

                builder.Property(e => e.Id).HasColumnName("ID");

                builder.Property(e => e.AccountCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                builder.Property(e => e.ArabicCode).HasMaxLength(100);

                builder.Property(e => e.ArabicName).HasMaxLength(100);

                builder.Property(e => e.Bscname)
                    .HasColumnName("BSCName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.DdbarabicName)
                    .HasColumnName("DDBArabicName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.DeptClassId)
                    .HasColumnName("DeptClassID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                builder.Property(e => e.DeptCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                builder.Property(e => e.EndDateTime).HasColumnType("datetime");

                builder.Property(e => e.ModifiedDateTime).HasColumnType("datetime");

                builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.NonSghdept)
                    .HasColumnName("NonSGHDept")
                    .HasDefaultValueSql("(0)");

                builder.Property(e => e.Oldid).HasColumnName("OLDID");

                builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

                builder.Property(e => e.OraCode)
                    .HasColumnName("Ora_Code")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                builder.Property(e => e.RecordId)
                    .HasColumnName("RecordID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                builder.Property(e => e.StartDateTime).HasColumnType("datetime");

                builder.Property(e => e.Udatetime)
                    .HasColumnName("UDATETIME")
                    .HasColumnType("datetime");

                builder.Property(e => e.Uploaded)
                    .HasColumnName("UPLOADED")
                    .HasDefaultValueSql("((0))");
        }
    }
}
