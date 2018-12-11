using System;
using System.Collections.Generic;

namespace BA.Core.Entity
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmpCode { get; set; }
        public int? Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? Sex { get; set; }
        public DateTime? Dob { get; set; }
        public short? Age { get; set; }
        public string Hadd1 { get; set; }
        public string Hcity { get; set; }
        public string Hstate { get; set; }
        public string Hcountry { get; set; }
        public string Hpincode { get; set; }
        public string HphoneNo { get; set; }
        public string Wadd1 { get; set; }
        public string Wcity { get; set; }
        public string Wstate { get; set; }
        public string Wcountry { get; set; }
        public string Wpincode { get; set; }
        public string WphoneNo { get; set; }
        public string FaxNo { get; set; }
        public string PagerNo { get; set; }
        public string CellNo { get; set; }
        public string Email { get; set; }
        public string Ecity { get; set; }
        public string Eadd1 { get; set; }
        public string Estate { get; set; }
        public string Ecountry { get; set; }
        public string Epincode { get; set; }
        public string EphoneNo { get; set; }
        public string Qualification { get; set; }
        public string PlaceOfContact { get; set; }
        public string EcontactPerson { get; set; }
        public string ContactTime { get; set; }
        public string Timings { get; set; }
        public string Remarks { get; set; }
        public byte? EmployeeType { get; set; }
        public byte? VisitingProf { get; set; }
        public byte? IsPractisingDoctor { get; set; }
        public int? DivisionId { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? Medical { get; set; }
        public byte? Supervisor { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public int? NationId { get; set; }
        public string Iacode { get; set; }
        public int? RegNo { get; set; }
        public int? OpmarkUpPercent { get; set; }
        public string Password { get; set; }
        public string Glcode { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int Deleted { get; set; }
        public bool? Indent { get; set; }
        public string SystemName { get; set; }
        public bool? LoggedYn { get; set; }
        public string LoggedIpaddress { get; set; }
        public string LockedYn { get; set; }
        public DateTime? PwSetDate { get; set; }
        public DateTime? PwdSetDate { get; set; }
        public string PwdExpiredYn { get; set; }
        public DateTime? UserStartTime { get; set; }
        public DateTime? UserEndTime { get; set; }
        public string InsertUpdate { get; set; }
        public bool? IsUploaded { get; set; }
        public string TempRegNo { get; set; }
        public string Arabiccode { get; set; }
        public string OldEmpCode { get; set; }
        public string AduserName { get; set; }
        public string InsuranceNumber { get; set; }
        public int? WorkHours { get; set; }
        public string BranchCode { get; set; }
        public int? IsHalfDayDuty { get; set; }
        public int? TaxId { get; set; }
        public int? SocialRegisterId { get; set; }
        public int? SocialNumber { get; set; }
        public int? SocialId { get; set; }
        public int? WorkHoursScs { get; set; }
        public int? SectionId { get; set; }
        public int? IsExpat { get; set; }
    }
}
