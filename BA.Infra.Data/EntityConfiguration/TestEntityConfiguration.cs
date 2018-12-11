using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class TestEntityConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.HasKey(e => e.Id)
                   .ForSqlServerIsClustered(false);

            builder.HasIndex(e => e.Code)
                .HasName("INDEX_DM_TEST_CODE");

            builder.HasIndex(e => e.Deleted)
                .HasName("INDEX_DM_TEST_DELETED");

            builder.HasIndex(e => e.Id)
                .HasName("IX_Test_1")
                .ForSqlServerIsClustered();

            builder.HasIndex(e => e.Name)
                .HasName("INDEX_DM_TEST_NAME");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.ArabicCode).HasMaxLength(50);

            builder.Property(e => e.ArabicName).HasMaxLength(100);

            builder.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.ConType).HasDefaultValueSql("(0)");

            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            builder.Property(e => e.EndDateTime).HasColumnType("datetime");

            builder.Property(e => e.EquipId).HasColumnName("EquipID");

            builder.Property(e => e.Icdcode)
                .HasColumnName("ICDCode")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Instructions).HasColumnType("text");

            builder.Property(e => e.LoginSname)
                .HasColumnName("Login_SName")
                .HasMaxLength(128)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.NewCode)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Notes).HasColumnType("text");

            builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

            builder.Property(e => e.Pcs)
                .HasColumnName("PCS")
                .HasMaxLength(25)
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
