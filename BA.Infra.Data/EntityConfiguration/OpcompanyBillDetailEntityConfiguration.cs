using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class OpcompanyBillDetailEntityConfiguration : IEntityTypeConfiguration<OpcompanyBillDetail>
    {
        public void Configure(EntityTypeBuilder<OpcompanyBillDetail> builder)
        {

            builder.ToTable("OPCompanyBillDetail");

            builder.HasIndex(e => e.AuthorityId)
                .HasName("IX_OPCompanyBillDetail_5");

            builder.HasIndex(e => e.DepartmentId)
                .HasName("IX_OPCompanyBillDetail_2");

            builder.HasIndex(e => e.OpbillId)
                .HasName("IX_OPCompanyBillDetail_1");

            builder.HasIndex(e => new { e.AuthorityId, e.ServiceId })
                .HasName("IX_OPCompanyBillDetail_13");

            builder.HasIndex(e => new { e.BillNo, e.ItemCode })
                .HasName("IX_OPCompanyBillDetail_8");

            builder.HasIndex(e => new { e.CategoryId, e.CompanyId, e.GradeId })
                .HasName("IX_OPCompanyBillDetail_3");

            builder.HasIndex(e => new { e.IssueAuthorityCode, e.RegistrationNo, e.ServiceId })
                .HasName("IX_OPCompanyBillDetail");

            builder.HasIndex(e => new { e.RegistrationNo, e.Billdatetime, e.DoctorId })
                .HasName("IX_OPCompanyBillDetail_10");

            builder.HasIndex(e => new { e.ServiceId, e.ItemId, e.OpbillId })
                .HasName("IX_OPCompanyBillDetail_11");

            builder.HasIndex(e => new { e.Billdatetime, e.OpbillId, e.BillTypeId, e.ServiceId })
                .HasName("IX_OPCompanyBillDetail_6");

            builder.HasIndex(e => new { e.CompanyId, e.IssueUnit, e.RegistrationNo, e.Billdatetime })
                .HasName("IX_OPCompanyBillDetail_9");

            builder.HasIndex(e => new { e.ServiceId, e.RegistrationNo, e.Billdatetime, e.DoctorId })
                .HasName("IX_OPCompanyBillDetail_12");

            builder.Property(e => e.ActualDate).HasColumnType("smalldatetime");

            builder.Property(e => e.Balance).HasColumnType("numeric(10, 2)");

            builder.Property(e => e.BillAmount).HasColumnType("numeric(10, 2)");

            builder.Property(e => e.BillNo)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Billdatetime).HasColumnType("datetime");

            builder.Property(e => e.Discount).HasColumnType("numeric(10, 2)");

            builder.Property(e => e.InvoiceAmount).HasColumnType("numeric(14, 2)");

            builder.Property(e => e.IssueAuthorityCode)
                .HasMaxLength(6)
                .IsUnicode(false);

            builder.Property(e => e.Issueqty)
                .HasColumnName("ISSUEQTY")
                .HasColumnType("numeric(9, 2)");

            builder.Property(e => e.ItemCode)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.OpbillId).HasColumnName("OPBillId");

            builder.Property(e => e.PaidAmount).HasColumnType("numeric(10, 2)");

            builder.Property(e => e.SghauthorityId)
                .HasColumnName("SGHAuthorityID")
                .HasMaxLength(25)
                .IsUnicode(false);


        }
    }
}
