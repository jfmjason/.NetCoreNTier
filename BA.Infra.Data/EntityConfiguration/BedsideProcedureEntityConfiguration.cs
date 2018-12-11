using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class BedsideProcedureConfiguration : IEntityTypeConfiguration<BedsideProcedure>
    {
        public void Configure(EntityTypeBuilder<BedsideProcedure> builder)
        {
            builder.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

            builder.HasIndex(e => e.Departmentid)
                .HasName("Ind_NonClust_BedSideProcedure_DepartmentID");

            builder.HasIndex(e => e.Id)
                .HasName("Ind_Clust_BedSideProcedure_ID")
                .ForSqlServerIsClustered();

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Arabiccode)
                .HasColumnName("arabiccode")
                .HasMaxLength(50);

            builder.Property(e => e.Arabicname)
                .HasColumnName("arabicname")
                .HasMaxLength(100);

            builder.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code")
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.Costprice)
                .HasColumnName("costprice")
                .HasColumnType("numeric(16, 2)");

            builder.Property(e => e.Deleted).HasColumnName("deleted");

            builder.Property(e => e.Departmentid).HasColumnName("departmentid");

            builder.Property(e => e.Enddatetime)
                .HasColumnName("enddatetime")
                .HasColumnType("smalldatetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Startdatetime)
                .HasColumnName("startdatetime")
                .HasColumnType("smalldatetime");

            builder.Property(e => e.Udatetime)
                .HasColumnName("udatetime")
                .HasColumnType("datetime");

            builder.Property(e => e.Uploaded)
                .HasColumnName("uploaded")
                .HasDefaultValueSql("((0))");



        }
    }
}
