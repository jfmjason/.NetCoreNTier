using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class OrganisationDetailsEntityConfiguration : IEntityTypeConfiguration<OrganisationDetail>
    {
        public void Configure(EntityTypeBuilder<OrganisationDetail> builder)
        {
            builder.ToTable("OrganisationDetails");

            builder.HasKey(e => e.Id)
                .ForSqlServerIsClustered(false);

            builder.HasIndex(e => e.CompanyId)
                .HasName("Ind_NonClus_OrganisationDetails_CompanyID");

            builder.HasIndex(e => e.Id)
                .HasName("Ind_Clus_OrganisationDetails_ID")
                .ForSqlServerIsClustered();

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.AddInformation)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Address1)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Address2)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Address3)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Cashdefaultmarkup).HasColumnName("CASHDEFAULTMARKUP");

            builder.Property(e => e.CellPhoneNo)
                .HasMaxLength(40)
                .IsUnicode(false);

            builder.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ContactPerson)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.District)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .HasColumnName("EMail")
                .HasMaxLength(40)
                .IsUnicode(false);

            builder.Property(e => e.FaxNo)
                .HasMaxLength(40)
                .IsUnicode(false);

            builder.Property(e => e.IsSmsenable).HasColumnName("IsSMSEnable");

            builder.Property(e => e.IssueAuthorityCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.MovEnable).HasColumnName("movEnable");

            builder.Property(e => e.MovEndTime)
                .HasColumnName("movEndTime")
                .HasColumnType("datetime");

            builder.Property(e => e.MovStartTime)
                .HasColumnName("movStartTime")
                .HasColumnType("datetime");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.NewRuleForLeave).HasColumnName("new_rule_for_leave");

            builder.Property(e => e.OraBranchid)
                .HasColumnName("ORA_BRANCHID")
                .HasMaxLength(5)
                .IsUnicode(false);

            builder.Property(e => e.OraCompanycode)
                .HasColumnName("ORA_COMPANYCODE")
                .HasMaxLength(5)
                .IsUnicode(false);

            builder.Property(e => e.OraCountrycode)
                .HasColumnName("ORA_COUNTRYCODE")
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.OraCurrencycode)
                .HasColumnName("ORA_CURRENCYCODE")
                .HasMaxLength(5)
                .IsUnicode(false);

            builder.Property(e => e.PagerNo)
                .HasMaxLength(40)
                .IsUnicode(false);

            builder.Property(e => e.PhoneNo)
                .HasMaxLength(40)
                .IsUnicode(false);

            builder.Property(e => e.PinCode)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.TaxEnabled).HasColumnName("Tax_Enabled");

            builder.Property(e => e.VatregNo)
                .HasColumnName("VATRegNo")
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
