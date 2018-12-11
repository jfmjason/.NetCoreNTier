using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.HasIndex(e => e.DesignationId)
                .HasName("IX_Employee_3");

            builder.HasIndex(e => e.EmpCode)
                .HasName("Idx_Employee_EmpCode");

            builder.HasIndex(e => e.RegNo)
                .HasName("IX_Employee_2");

            builder.HasIndex(e => new { e.CategoryId, e.EmpCode })
                .HasName("Idx_CatId_EmpCode");

            builder.HasIndex(e => new { e.EmployeeId, e.Deleted })
                .HasName("Idx_Employee_EmpID_Del");

            builder.HasIndex(e => new { e.Iacode, e.RegNo })
                .HasName("IX_Employee_Regno");

            builder.HasIndex(e => new { e.Id, e.EmployeeId, e.DesignationId, e.Name, e.Deleted })
                .HasName("ExcludeAlpaEmployeeID, sysname,>");

            builder.HasIndex(e => new { e.Id, e.EmployeeId, e.DepartmentId, e.Name, e.DivisionId, e.Deleted })
                .HasName("ix_Employee_ID2");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.AduserName)
                .HasColumnName("ADUserName")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ArabicName).HasMaxLength(100);

            builder.Property(e => e.Arabiccode).HasMaxLength(50);

            builder.Property(e => e.BranchCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValueSql("('110')");

            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");

            builder.Property(e => e.CellNo)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ContactTime)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            builder.Property(e => e.DesignationId).HasColumnName("DesignationID");

            builder.Property(e => e.DivisionId).HasColumnName("DivisionID");

            builder.Property(e => e.Dob)
                .HasColumnName("DOB")
                .HasColumnType("smalldatetime");

            builder.Property(e => e.Eadd1)
                .HasColumnName("EAdd1")
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.Ecity)
                .HasColumnName("ECity")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.EcontactPerson)
                .HasColumnName("EContactPerson")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Ecountry)
                .HasColumnName("ECountry")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .HasColumnName("EMail")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.EmpCode)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.EmployeeId)
                .HasColumnName("EmployeeID")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.EndDateTime).HasColumnType("smalldatetime");

            builder.Property(e => e.EphoneNo)
                .HasColumnName("EPhoneNo")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Epincode)
                .HasColumnName("EPINcode")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Estate)
                .HasColumnName("EState")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.FaxNo)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Glcode)
                .HasColumnName("GLCode")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Hadd1)
                .HasColumnName("HAdd1")
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.Hcity)
                .HasColumnName("HCity")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Hcountry)
                .HasColumnName("HCountry")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.HphoneNo)
                .HasColumnName("HPhoneNo")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Hpincode)
                .HasColumnName("HPINCode")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Hstate)
                .HasColumnName("HState")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Iacode)
                .HasColumnName("IACode")
                .HasMaxLength(6)
                .IsUnicode(false);

            builder.Property(e => e.InsertUpdate)
                .HasColumnName("Insert_Update")
                .HasMaxLength(1)
                .IsUnicode(false);

            builder.Property(e => e.InsuranceNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.IsPractisingDoctor).HasDefaultValueSql("(0)");

            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.LastUpdated).HasColumnType("smalldatetime");

            builder.Property(e => e.LockedYn)
                .HasColumnName("Locked_YN")
                .HasMaxLength(1)
                .IsUnicode(false);

            builder.Property(e => e.LoggedIpaddress)
                .HasColumnName("LoggedIPAddress")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.LoggedYn).HasColumnName("LoggedYN");

            builder.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasMaxLength(122)
                .IsUnicode(false);

            builder.Property(e => e.NationId).HasColumnName("NationID");

            builder.Property(e => e.OldEmpCode)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.OperatorId).HasColumnName("OperatorID");

            builder.Property(e => e.OpmarkUpPercent).HasColumnName("OPMarkUpPercent");

            builder.Property(e => e.PagerNo)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.PlaceOfContact)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.PwSetDate)
                .HasColumnName("PW_SET_DATE")
                .HasColumnType("datetime");

            builder.Property(e => e.PwdExpiredYn)
                .HasColumnName("PWD_EXPIRED_YN")
                .HasMaxLength(1)
                .IsUnicode(false);

            builder.Property(e => e.PwdSetDate)
                .HasColumnName("PWD_SET_DATE")
                .HasColumnType("datetime");

            builder.Property(e => e.Qualification)
                .HasMaxLength(75)
                .IsUnicode(false);

            builder.Property(e => e.Remarks)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.SectionId).HasColumnName("Section_ID");

            builder.Property(e => e.SocialRegisterId).HasColumnName("SocialRegisterID");

            builder.Property(e => e.StartDateTime).HasColumnType("smalldatetime");

            builder.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

            builder.Property(e => e.SystemName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.TempRegNo)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Timings)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UserEndTime)
                .HasColumnName("USER_END_TIME")
                .HasColumnType("datetime");

            builder.Property(e => e.UserStartTime)
                .HasColumnName("USER_START_TIME")
                .HasColumnType("datetime");

            builder.Property(e => e.VisitingProf).HasDefaultValueSql("(0)");

            builder.Property(e => e.Wadd1)
                .HasColumnName("WAdd1")
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.Wcity)
                .HasColumnName("WCity")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Wcountry)
                .HasColumnName("WCountry")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.WorkHours).HasDefaultValueSql("((8))");

            builder.Property(e => e.WorkHoursScs).HasColumnName("WorkHours_SCS");

            builder.Property(e => e.WphoneNo)
                .HasColumnName("WPhoneNo")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Wpincode)
                .HasColumnName("WPINCode")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Wstate)
                .HasColumnName("WState")
                .HasMaxLength(50)
                .IsUnicode(false);

        }
    }
}
