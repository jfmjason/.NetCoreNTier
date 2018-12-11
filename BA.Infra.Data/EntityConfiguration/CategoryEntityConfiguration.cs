using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(e => e.Id)
                    .HasName("IX_Category")
                    .IsUnique();

            builder.HasIndex(e => e.ValidTill)
                    .HasName("IX_Category_1");

            builder.HasIndex(e => new { e.Code, e.Name })
                    .HasName("IX_Category_2");

            builder.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

            builder.Property(e => e.Address)
                    .HasMaxLength(300)
                    .IsUnicode(false);

            builder.Property(e => e.Arabiccode)
                    .HasColumnName("arabiccode")
                    .HasMaxLength(100);

            builder.Property(e => e.Arabicname)
                    .HasColumnName("arabicname")
                    .HasMaxLength(100);

            builder.Property(e => e.Attribute4)
                    .HasMaxLength(20)
                    .IsUnicode(false);

            builder.Property(e => e.BlockReason)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

            builder.Property(e => e.ByPassExclusionsStatus)
                    .IsRequired()
                    .HasDefaultValueSql("(0)");

            builder.Property(e => e.CatGroup)
                    .HasMaxLength(25)
                    .IsUnicode(false);

            builder.Property(e => e.City)
                    .HasMaxLength(25)
                    .IsUnicode(false);

            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Contactpersondesig)
                .IsRequired()
                .HasColumnName("CONTACTPERSONDESIG")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Contactpersonname)
                .IsRequired()
                .HasColumnName("CONTACTPERSONNAME")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DateTime).HasColumnType("datetime");

            builder.Property(e => e.EmailId)
                .HasColumnName("EmailID")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.EndDateTime).HasColumnType("smalldatetime");

            builder.Property(e => e.FaxNo)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.FaxNo2)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.FixedConCharges).HasColumnType("numeric(13, 2)");

            builder.Property(e => e.InsertUpdate)
                .HasColumnName("Insert_Update")
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('I')");

            builder.Property(e => e.InvoiceConFee).HasColumnType("numeric(13, 2)");

            builder.Property(e => e.Ippd).HasColumnName("IPPD");

            builder.Property(e => e.IquamaId).HasColumnName("IquamaID");

            builder.Property(e => e.Loaconsultation)
                .HasColumnName("LOAConsultation")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.ModifiedDateTime).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Opconsultations).HasColumnName("OPConsultations");

            builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

            builder.Property(e => e.Oppd).HasColumnName("OPPD");

            builder.Property(e => e.OraCode)
                .HasColumnName("Ora_Code")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.PayAfter)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.PharmacyCstheader).HasColumnName("PharmacyCSTHeader");

            builder.Property(e => e.PoBox)
                .HasMaxLength(250)
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

            builder.Property(e => e.Remarks)
                .HasMaxLength(5000)
                .IsUnicode(false);

            builder.Property(e => e.RevisitDays).HasDefaultValueSql("((10))");

            builder.Property(e => e.Speccons).HasColumnName("speccons");

            builder.Property(e => e.StartDateTime).HasColumnType("smalldatetime");

            builder.Property(e => e.TariffId).HasColumnName("TariffID");

            builder.Property(e => e.TelNo2)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.TelephoneNo)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Ucf)
                .HasColumnName("UCF")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.ValidFrom).HasColumnType("datetime");

            builder.Property(e => e.ValidTill).HasColumnType("datetime");

            builder.Property(e => e.Wfcls).HasColumnName("WFCLS");

            builder.Property(e => e.Wfrc).HasColumnName("WFRC");

            builder.Property(e => e.Wfrs).HasColumnName("WFRS");

            builder.Property(e => e.ZipCode)
                .HasMaxLength(25)
                .IsUnicode(false);
       
        }
    }
}
