using System;

namespace BA.Core.Entity
{
    public partial class Company
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int? TariffId { get; set; }
        public string PolicyNo { get; set; }
        public short Coverage { get; set; }
        public int Oppd { get; set; }
        public int Ippd { get; set; }
        public string Address { get; set; }
        public string TelephoneNo { get; set; }
        public string FaxNo { get; set; }
        public string EmailId { get; set; }
        public string PoBox { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int OperatorId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool Active { get; set; }
        public DateTime? DateTime { get; set; }
        public bool Deleted { get; set; }
        public string ArabicName { get; set; }
        public string ArabicCode { get; set; }
        public int? Tpaid { get; set; }
        public bool? Ucf { get; set; }
        public int? BillingCollectorId { get; set; }
        public int? BillingOfficerId { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTill { get; set; }
        public bool? ArabicInvoice { get; set; }
        public string Remarks { get; set; }
        public int? AccountType { get; set; }
        public int? ReferralBasis { get; set; }
        public int? Opconsultations { get; set; }
        public int? Wfcls { get; set; }
        public int? Wfrs { get; set; }
        public int? Wfrc { get; set; }
        public int? PrintAddress { get; set; }
        public byte FollowRules { get; set; }
        public bool? Loaconsultation { get; set; }
        public short? EmpInfo { get; set; }
        public string Contactpersonname { get; set; }
        public string Contactpersondesig { get; set; }
        public string TelNo2 { get; set; }
        public string FaxNo2 { get; set; }
        public string ProviderCode { get; set; }
        public bool? RelationDetails { get; set; }
        public decimal FixedConCharges { get; set; }
        public decimal RegCharges { get; set; }
        public decimal InvoiceConFee { get; set; }
        public string BlockReason { get; set; }
        public bool PharmacyCstheader { get; set; }
        public bool? Aramco { get; set; }
        public int? NoofVisits { get; set; }
        public short? RegFeePaidBy { get; set; }
        public string PolicyRules { get; set; }
        public bool Consultationlimit { get; set; }
        public int? BlockReasonId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? ApprovalDays { get; set; }
        public short? DeductableStatus { get; set; }
        public byte? DiscountToPrint { get; set; }
        public bool? ByPassExclusionsStatus { get; set; }
        public decimal? PerAdvancetoPay { get; set; }
        public decimal? DisForAdvancePay { get; set; }
        public string HostName { get; set; }
        public bool? CheckMedId { get; set; }
        public int? TariffLevel { get; set; }
        public string InsertUpdate { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public byte? RevisitDays { get; set; }
        public int? Speccons { get; set; }
        public bool? Uploaded { get; set; }
        public string Attribute4 { get; set; }
        public string StaffAttribute4 { get; set; }
    }
}
