using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class InpatientEntityConfiguration : IEntityTypeConfiguration<Inpatient>
    {
        public void Configure(EntityTypeBuilder<Inpatient> builder)
        {
            builder.HasKey(e => e.Ipid);

            builder.HasIndex(e => e.AdmitDateTime)
                .HasName("IX_InPatient_1");

            builder.HasIndex(e => e.CompanyId)
                .HasName("IX_InPatient_3");

            builder.HasIndex(e => e.DepartmentId)
                .HasName("InPatient_IX7");

            builder.HasIndex(e => e.Ipid)
                .HasName("IDX_DM_INPATIENT_IPID");

            builder.HasIndex(e => e.IssueAuthorityCode)
                .HasName("IDX_DM_INPATIENT_IACODE");

            builder.HasIndex(e => e.RegistrationNo)
                .HasName("IDX_DM_INPATIENT_REGNO");

            builder.HasIndex(e => new { e.IssueAuthorityCode, e.RegistrationNo })
                .HasName("IX_InPatient");

            builder.HasIndex(e => new { e.RegistrationNo, e.IssueAuthorityCode })
                .HasName("InPatient_idx6");

            builder.HasIndex(e => new { e.CategoryId, e.CompanyId, e.GradeId })
                .HasName("IX_InPatient_2");

            builder.Property(e => e.Ipid)
                .HasColumnName("IPID")
                .ValueGeneratedNever();

            builder.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Address3)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.AdminNo).HasDefaultValueSql("(1)");

            builder.Property(e => e.AdmitDateTime).HasColumnType("datetime");

            builder.Property(e => e.AdmitedAtId).HasColumnName("AdmitedAtID");

            builder.Property(e => e.BedTypeId).HasColumnName("BedTypeID");

            builder.Property(e => e.BloodGroup)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");

            builder.Property(e => e.CityName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.CompanyId).HasColumnName("CompanyID");

            builder.Property(e => e.CountryName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DateOfBirth).HasColumnType("datetime");

            builder.Property(e => e.DistrictName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DoctorId).HasColumnName("DoctorID");

            builder.Property(e => e.FamilyName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql(@"
create default space as  ' '



");

            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql(@"
create default space as  ' '



");

            builder.Property(e => e.InsCardNo)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.IssueAuthorityCode)
                .IsRequired()
                .HasMaxLength(6)
                .IsUnicode(false);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql(@"
create default space as  ' '



");

            builder.Property(e => e.LetterNo)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.MedIdnumber)
                .HasColumnName("MedIDNumber")
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.MiddleName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql(@"
create default space as  ' '



");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.MotherIpid).HasColumnName("MotherIPID");

            builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

            builder.Property(e => e.OtherAllergies)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.PcellNo)
                .HasColumnName("PCellNo")
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

            builder.Property(e => e.PpagerNo)
                .HasColumnName("PPagerNo")
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Pphone)
                .HasColumnName("PPhone")
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Pstate).HasColumnName("PState");

            builder.Property(e => e.Ptname)
                .IsRequired()
                .HasColumnName("PTName")
                .HasMaxLength(123)
                .IsUnicode(false)
                .HasComputedColumnSql("(isnull(ltrim(rtrim([Familyname])),'') + ' ' + isnull(ltrim(rtrim([Firstname])),'') + ' ' + isnull(ltrim(rtrim([Middlename])),'') + ' ' + isnull(ltrim(rtrim([lastname])),''))");

            builder.Property(e => e.PzipCode)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.SaudiIqamaId)
                .HasColumnName("SaudiIqamaID")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Sexothers)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.SghregNo)
                .HasColumnName("SGHRegNO")
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.SidexpiryDate)
                .HasColumnName("SIDExpiryDate")
                .HasColumnType("datetime");

            builder.Property(e => e.SidissueDate)
                .HasColumnName("SIDIssueDate")
                .HasColumnType("datetime");

            builder.Property(e => e.SidissuedAt)
                .HasColumnName("SIDIssuedAt")
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.StateName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.TariffId).HasColumnName("TariffID");

            builder.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql(@"
create default space as  ' '



");

            builder.Property(e => e.Uploadtag)
                .HasColumnName("UPLOADTAG")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.Vip).HasColumnName("VIP");
  
       
        }


    }
}
