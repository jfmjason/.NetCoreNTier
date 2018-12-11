using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
          
                builder.HasIndex(e => e.CategoryId)
                    .HasName("IX_Company_1");

                builder.HasIndex(e => e.ValidTill)
                    .HasName("IX_Company");

                builder.HasIndex(e => new { e.Code, e.SubCategoryId })
                    .HasName("IX_Company_2");

                builder.HasIndex(e => new { e.Deleted, e.CategoryId, e.Name })
                    .HasName("IDX_Company_Active");

                builder.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                builder.Property(e => e.Address)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                builder.Property(e => e.ArabicCode).HasMaxLength(100);

                builder.Property(e => e.ArabicName).HasMaxLength(100);

                builder.Property(e => e.Attribute4)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                builder.Property(e => e.BlockReason)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                builder.Property(e => e.CategoryId).HasColumnName("CategoryID");

                builder.Property(e => e.CheckMedId).HasDefaultValueSql("(0)");

                builder.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                builder.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                builder.Property(e => e.Consultationlimit).HasColumnName("CONSULTATIONLIMIT");

                builder.Property(e => e.Contactpersondesig)
                    .HasColumnName("CONTACTPERSONDESIG")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.Contactpersonname)
                    .HasColumnName("CONTACTPERSONNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.DateTime).HasColumnType("datetime");

                builder.Property(e => e.DisForAdvancePay)
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("(0)");

                builder.Property(e => e.DiscountToPrint).HasDefaultValueSql("(0)");

                builder.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnName("EMailID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.EndDateTime).HasColumnType("datetime");

                builder.Property(e => e.FaxNo)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                builder.Property(e => e.FaxNo2)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                builder.Property(e => e.FixedConCharges).HasColumnType("numeric(13, 2)");

                builder.Property(e => e.HostName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.InsertUpdate)
                    .HasColumnName("Insert_Update")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('I')");

                builder.Property(e => e.InvoiceConFee).HasColumnType("numeric(13, 2)");

                builder.Property(e => e.Ippd).HasColumnName("IPPD");

                builder.Property(e => e.Loaconsultation).HasColumnName("LOAConsultation");

                builder.Property(e => e.ModifiedDateTime).HasColumnType("datetime");

                builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                builder.Property(e => e.Opconsultations).HasColumnName("OPConsultations");

                builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

                builder.Property(e => e.Oppd).HasColumnName("OPPD");

                builder.Property(e => e.PerAdvancetoPay)
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("(0)");

                builder.Property(e => e.PharmacyCstheader).HasColumnName("PharmacyCSTHeader");

                builder.Property(e => e.PoBox)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                builder.Property(e => e.PolicyNo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                builder.Property(e => e.PolicyRules)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                builder.Property(e => e.ProviderCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.RegCharges).HasColumnType("numeric(13, 2)");

                builder.Property(e => e.Remarks).HasColumnType("text");

                builder.Property(e => e.RevisitDays).HasDefaultValueSql("((10))");

                builder.Property(e => e.Speccons).HasColumnName("speccons");

                builder.Property(e => e.StaffAttribute4)
                    .HasColumnName("Staff_Attribute4")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                builder.Property(e => e.StartDateTime).HasColumnType("datetime");

                builder.Property(e => e.TariffId).HasColumnName("TariffID");

                builder.Property(e => e.TariffLevel).HasDefaultValueSql("(1)");

                builder.Property(e => e.TelNo2)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                builder.Property(e => e.TelephoneNo)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                builder.Property(e => e.Tpaid).HasColumnName("TPAId");

                builder.Property(e => e.Ucf).HasColumnName("UCF");

                builder.Property(e => e.Uploaded)
                    .HasColumnName("UPLOADED")
                    .HasDefaultValueSql("((0))");

                builder.Property(e => e.ValidFrom).HasColumnType("datetime");

                builder.Property(e => e.ValidTill).HasColumnType("datetime");

                builder.Property(e => e.Wfcls).HasColumnName("WFCLS");

                builder.Property(e => e.Wfrc).HasColumnName("WFRC");

                builder.Property(e => e.Wfrs).HasColumnName("WFRS");

                builder.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);


            }
    }
}
