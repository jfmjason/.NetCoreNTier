using System;
using System.ComponentModel.DataAnnotations;

namespace BA.Core.Entity
{
    public partial class Patient
    {
        public DateTime RegDateTime { get; set; }
        public string IssueAuthorityCode { get; set; }
        public int Registrationno { get; set; }
        public string Title { get; set; }
        public string FamilyName { get; set; }
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MothersMaidenName { get; set; }
        public string FathersName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Age { get; set; }
        public short Agetype { get; set; }
        public short Sex { get; set; }
        public short MaritalStatus { get; set; }
        public string Occupation { get; set; }
        public string Guardian { get; set; }
        public string Grelationship { get; set; }
        public int Pcity { get; set; }
        public string Pphone { get; set; }
        public string Pemail { get; set; }
        public string WrkAddress { get; set; }
        public string WrkPhone { get; set; }
        public string WrkEmail { get; set; }
        public string OtherAllergies { get; set; }
        public bool Caution { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public int OperatorId { get; set; }
        public int? Country { get; set; }
        public string PassportNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Ccurrency { get; set; }
        public string ReferredDocName { get; set; }
        public string ReferredDocAddress { get; set; }
        public string ReferredDocPhone { get; set; }
        public string ReferredDocEmail { get; set; }
        public string ReferredDocCellNo { get; set; }
        public short? Religion { get; set; }
        public int? ModifiedOperator { get; set; }
        public bool Deleted { get; set; }
        public bool? Vip { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string Password { get; set; }
        public string ReferredDocSpecialisation { get; set; }
        public string Pcellno { get; set; }
        public string Gphone { get; set; }
        public string Gcellno { get; set; }
        public string Gaddress { get; set; }
        public string Gemail { get; set; }
        public string BloodGroup { get; set; }
        public string WrkFax { get; set; }
        public string Ppagerno { get; set; }
        public string Cpagerno { get; set; }
        public string Rpagerno { get; set; }
        public bool? ChequeBounce { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public bool NonSaudi { get; set; }
        public string PZipCode { get; set; }
        public int? Nationality { get; set; }
        public byte? Billtype { get; set; }
        public string WrkCompanyName { get; set; }
        public int? CompanyId { get; set; }
        public DateTime? SidIssueDate { get; set; }
        public string SidIssuedAt { get; set; }
        public string SaudiIqamaId { get; set; }
        public DateTime? SidExpiryDate { get; set; }
        public string PassportIssuedAt { get; set; }
        public string Sexothers { get; set; }
        public bool? Messages { get; set; }
        public bool? BilledBy { get; set; }
        public int? DoctorId { get; set; }
        public string EmployeeId { get; set; }
        public byte? Embose { get; set; }
        public string AfirstName { get; set; }
        public string AmiddleName { get; set; }
        public string AlastName { get; set; }
        public string AfamilyName { get; set; }
        public string Aaddress1 { get; set; }
        public string Aaddress2 { get; set; }
        public int? CategoryId { get; set; }
        public int? GradeId { get; set; }
        public string PolicyNo { get; set; }
        public DateTime? IdexpiryDate { get; set; }
        public string MedIdnumber { get; set; }
        public bool? Billed { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public short? Mrblocked { get; set; }
        public byte? IsInvoiced { get; set; }
        public DateTime? InvoiceDateTime { get; set; }
        public int? CompanyLetterId { get; set; }
        public string SghregNo { get; set; }
        public DateTime? SghdateTime { get; set; }
        public bool? EmboseCharged { get; set; }
        public DateTime? AramcoRegDateTime { get; set; }
        public string Sghname { get; set; }
        public bool? Uploadtag { get; set; }
        public DateTime? BirthTime { get; set; }
        public string InsertUpdate { get; set; }

        public string PIN { get {  return IssueAuthorityCode + "." + Registrationno.ToString("0000000000");} }

        public string Name { get { return Firstname + " " + MiddleName + " " + LastName; } }
    }
}
