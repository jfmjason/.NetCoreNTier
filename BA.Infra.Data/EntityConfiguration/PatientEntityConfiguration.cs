using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class PatientEntityConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => new { e.IssueAuthorityCode, e.Registrationno });

            builder.HasIndex(e => e.MedIdnumber)
                .HasName("IDX_MEDIDNUMBER");

            builder.HasIndex(e => e.RegDateTime)
                .HasName("IX_Patient");

            builder.HasIndex(e => e.Registrationno)
                .HasName("IDX_REGNO");

            builder.HasIndex(e => new { e.Registrationno, e.IssueAuthorityCode })
                .HasName("IDX_REGNO_ISSUE");

            builder.HasIndex(e => new { e.CategoryId, e.CompanyId, e.GradeId })
                .HasName("IDX_CAT_COM_GR");

            builder.HasIndex(e => new { e.Firstname, e.MiddleName, e.LastName })
                .HasName("IDX_Patient_Firstname");

            builder.Property(e => e.IssueAuthorityCode)
                .HasMaxLength(6)
                .IsUnicode(false);

            builder.Property(e => e.Aaddress1)
                .HasColumnName("AAddress1")
                .HasMaxLength(50);

            builder.Property(e => e.Aaddress2)
                .HasColumnName("AAddress2")
                .HasMaxLength(50);

            builder.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Address3)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.AfamilyName)
                .HasColumnName("AFamilyName")
                .HasMaxLength(50);

            builder.Property(e => e.AfirstName)
                .HasColumnName("AFirstName")
                .HasMaxLength(50);

            builder.Property(e => e.AlastName)
                .HasColumnName("ALastName")
                .HasMaxLength(50);

            builder.Property(e => e.AmiddleName)
                .HasColumnName("AMiddleName")
                .HasMaxLength(50);

            builder.Property(e => e.AramcoRegDateTime).HasColumnType("datetime");

            builder.Property(e => e.BirthTime).HasColumnType("datetime");

            builder.Property(e => e.BloodGroup)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Ccurrency)
                .HasColumnName("CCurrency")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.CityName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.CountryName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Cpagerno)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.DateOfBirth).HasColumnType("datetime");

            builder.Property(e => e.Embose).HasDefaultValueSql("(0)");

            builder.Property(e => e.EmboseCharged).HasDefaultValueSql("(0)");

            builder.Property(e => e.EmployeeId)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.ExpiryDate).HasColumnType("datetime");

            builder.Property(e => e.FamilyName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.FathersName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Firstname)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Gaddress)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.Gcellno)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Gemail)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Gphone)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Grelationship)
                .HasColumnName("GRelationship")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Guardian)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.IdexpiryDate)
                .HasColumnName("IDExpiryDate")
                .HasColumnType("datetime");

            builder.Property(e => e.InsertUpdate)
                .HasColumnName("Insert_Update")
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('I')");

            builder.Property(e => e.InvoiceDateTime).HasColumnType("datetime");

            builder.Property(e => e.IssueDate).HasColumnType("datetime");

            builder.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.MedIdnumber)
                .HasColumnName("MedIDNumber")
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.MothersMaidenName)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Mrblocked).HasColumnName("MRBlocked");

            builder.Property(e => e.Occupation)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

            builder.Property(e => e.OtherAllergies)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.PZipCode)
                .HasColumnName("pZipCode")
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.PassportIssuedAt)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.PassportNo)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasMaxLength(14)
                .IsUnicode(false);

            builder.Property(e => e.Pcellno)
                .HasColumnName("PCellno")
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Pcity).HasColumnName("PCity");

            builder.Property(e => e.Pemail)
                .HasColumnName("PEMail")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.PolicyNo)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Ppagerno)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Pphone)
                .HasColumnName("PPhone")
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.ReferredDocAddress)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.ReferredDocCellNo)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.ReferredDocEmail)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ReferredDocName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ReferredDocPhone)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.ReferredDocSpecialisation)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.RegDateTime).HasColumnType("datetime");

            builder.Property(e => e.Rpagerno)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.SaudiIqamaId)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Sexothers)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.SghdateTime)
                .HasColumnName("SGHDateTime")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Sghname)
                .HasColumnName("SGHName")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.SghregNo)
                .HasColumnName("SGHRegNO")
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.SidExpiryDate).HasColumnType("datetime");

            builder.Property(e => e.SidIssueDate).HasColumnType("datetime");

            builder.Property(e => e.SidIssuedAt)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Uploadtag)
                .HasColumnName("UPLOADTAG")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.ValidFrom).HasColumnType("datetime");

            builder.Property(e => e.ValidTo).HasColumnType("datetime");

            builder.Property(e => e.WrkAddress)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.WrkCompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.WrkEmail)
                .HasColumnName("WrkEMail")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.WrkFax)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.WrkPhone)
                .HasMaxLength(25)
                .IsUnicode(false);

        }
    }
}
