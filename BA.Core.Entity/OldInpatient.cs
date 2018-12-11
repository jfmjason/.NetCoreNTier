using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class OldInpatient
    {
        public int Ipid { get; set; }
        public short? Adminno { get; set; }
        public string Issueauthoritycode { get; set; }
        public int RegistrationNo { get; set; }
        public DateTime? AdmitDateTime { get; set; }
        public string Title { get; set; }
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte? Age { get; set; }
        public byte? AgeType { get; set; }
        public byte? Sex { get; set; }
        public string Sexothers { get; set; }
        public int Pcity { get; set; }
        public string Cityname { get; set; }
        public int? District { get; set; }
        public string Districtname { get; set; }
        public int? PState { get; set; }
        public string Statename { get; set; }
        public short? Pcountry { get; set; }
        public string Countryname { get; set; }
        public string Pphone { get; set; }
        public string Pcellno { get; set; }
        public string Ppagerno { get; set; }
        public string Pemail { get; set; }
        public string OtherAllergies { get; set; }
        public string BloodGroup { get; set; }
        public short? Nationality { get; set; }
        public int? DoctorId { get; set; }
        public int? DepartmentId { get; set; }
        public int? TariffId { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public int? GradeId { get; set; }
        public byte? Billtype { get; set; }
        public int BedTypeId { get; set; }
        public int PatientType { get; set; }
        public bool Block { get; set; }
        public bool? Newborn { get; set; }
        public short? NewBornSlNo { get; set; }
        public int MotherIpid { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PzipCode { get; set; }
        public string SaudiIqamaid { get; set; }
        public DateTime? Sidissuedate { get; set; }
        public DateTime? Sidexpirydate { get; set; }
        public string Sidissuedat { get; set; }
        public int? Tredoctor1 { get; set; }
        public int? Tredoctor2 { get; set; }
        public bool? NonSaudi { get; set; }
        public bool? Messages { get; set; }
        public string InsCardNo { get; set; }
        public string LetterNo { get; set; }
        public short? LetterNoType { get; set; }
        public short? Religion { get; set; }
        public short? ModeOfVisit { get; set; }
        public short? AttendRelation { get; set; }
        public bool? Vip { get; set; }
        public string MedIdnumber { get; set; }
        public string PolicyNo { get; set; }
        public short? AdmitedAtId { get; set; }
        public byte? CareType { get; set; }
        public DateTime? DischargeDateTime { get; set; }
        public short? DischargeTypeId { get; set; }
        public DateTime? ExpiryDateTime { get; set; }
        public string ReasonForDischarge { get; set; }
        public int OperatorId { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string SghregNo { get; set; }
        public byte? CreditBillSettledYn { get; set; }
        public bool? Uploadtag { get; set; }

        public string PIN { get { return Issueauthoritycode + "." + RegistrationNo.ToString("000000000"); } }
        public string Name { get { return FirstName + " " + MiddleName + " " + LastName; } }
    }
}
