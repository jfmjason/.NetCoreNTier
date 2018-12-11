using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class OldInpatientEntityConfiguration : IEntityTypeConfiguration<OldInpatient>
    {
        public void Configure(EntityTypeBuilder<OldInpatient> builder)
        {
            builder.HasKey(e => e.Ipid);

            builder.HasIndex(e => e.AdmitDateTime)
                .HasName("IX_OldInPatient_1");

            builder.HasIndex(e => e.CompanyId)
                .HasName("IX_OldInPatient_4");

            builder.HasIndex(e => e.DischargeDateTime)
                .HasName("IX_OldInPatient_2");

            builder.HasIndex(e => e.Ipid)
                .HasName("IDX_DM_OLDINPATIENT_IPID");

            builder.HasIndex(e => e.Issueauthoritycode)
                .HasName("IDX_DM_OLDINPATIENT_IACODE");

            builder.HasIndex(e => e.RegistrationNo)
                .HasName("IDX_DM_OLDINPATIENT_REGNO");

            builder.HasIndex(e => new { e.Issueauthoritycode, e.RegistrationNo })
                .HasName("IX_OldInPatient");

            builder.HasIndex(e => new { e.CategoryId, e.CompanyId, e.GradeId })
                .HasName("IX_OldInPatient_3");

            builder.HasIndex(e => new { e.RegistrationNo, e.Issueauthoritycode, e.DischargeDateTime })
                .HasName("IDX_OldInPatient_6");

            builder.HasIndex(e => new { e.DoctorId, e.RegistrationNo, e.Issueauthoritycode, e.DischargeDateTime })
                .HasName("IDX_OldInPatient_5");

            builder.Property(e => e.Ipid)
                .HasColumnName("IPID")
                .ValueGeneratedNever();

            builder.Property(e => e.Address1)
                .HasColumnName("address1")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Address2)
                .HasColumnName("address2")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Address3)
                .HasColumnName("address3")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.AdmitDateTime).HasColumnType("datetime");

            builder.Property(e => e.AdmitedAtId).HasDefaultValueSql("(2)");

            builder.Property(e => e.BedTypeId).HasColumnName("BedTypeID");

            builder.Property(e => e.BloodGroup)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");

            builder.Property(e => e.Cityname)
                .HasColumnName("cityname")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.CompanyId).HasColumnName("CompanyID");

            builder.Property(e => e.Countryname)
                .HasColumnName("countryname")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.CreditBillSettledYn)
                .HasColumnName("CreditBill_SettledYN")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.DateOfBirth).HasColumnType("datetime");

            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            builder.Property(e => e.DischargeDateTime).HasColumnType("datetime");

            builder.Property(e => e.Districtname)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DoctorId).HasColumnName("DoctorID");

            builder.Property(e => e.ExpiryDateTime).HasColumnType("datetime");

            builder.Property(e => e.FamilyName)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.GradeId).HasColumnName("GradeID");

            builder.Property(e => e.InsCardNo)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Issueauthoritycode)
                .IsRequired()
                .HasColumnName("issueauthoritycode")
                .HasMaxLength(6)
                .IsUnicode(false);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.LetterNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.MedIdnumber)
                .HasColumnName("MedIDNumber")
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.MiddleName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

            builder.Property(e => e.OtherAllergies)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.PState).HasColumnName("pState");

            builder.Property(e => e.Pcellno)
                .HasColumnName("pcellno")
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Pcity).HasColumnName("PCity");

            builder.Property(e => e.Pcountry).HasColumnName("PCountry");

            builder.Property(e => e.Pemail)
                .HasColumnName("PEMail")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.PolicyNo)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Ppagerno)
                .HasColumnName("ppagerno")
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Pphone)
                .HasColumnName("PPhone")
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.PzipCode)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.ReasonForDischarge)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.SaudiIqamaid)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Sexothers)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.SghregNo)
                .HasColumnName("SGHRegNO")
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Sidexpirydate).HasColumnType("datetime");

            builder.Property(e => e.Sidissuedat)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Sidissuedate).HasColumnType("datetime");

            builder.Property(e => e.Statename)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.TariffId).HasColumnName("TariffID");

            builder.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Uploadtag)
                .HasColumnName("UPLOADTAG")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.Vip).HasColumnName("VIP");

        }
    }
}
