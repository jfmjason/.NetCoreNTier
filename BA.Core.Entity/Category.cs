using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
   public class Category
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public short CategoryType { get; set; }
        public string PayAfter { get; set; }
        public bool InsuranceCard { get; set; }
        public bool IquamaId { get; set; }
        public bool RefLetter { get; set; }
        public string Address { get; set; }
        public string TelephoneNo { get; set; }
        public string FaxNo { get; set; }
        public string EmailId { get; set; }
        public string PoBox { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool Active { get; set; }
        public int OperatorId { get; set; }
        public DateTime? DateTime { get; set; }
        public bool Deleted { get; set; }
        public string Arabicname { get; set; }
        public string Arabiccode { get; set; }
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
        public int? Oppd { get; set; }
        public int? Ippd { get; set; }
        public byte? Coverage { get; set; }
        public string Contactpersonname { get; set; }
        public string Contactpersondesig { get; set; }
        public string TelNo2 { get; set; }
        public string FaxNo2 { get; set; }
        public string ProviderCode { get; set; }
        public decimal FixedConCharges { get; set; }
        public decimal RegCharges { get; set; }
        public decimal InvoiceConFee { get; set; }
        public string BlockReason { get; set; }
        public bool PharmacyCstheader { get; set; }
        public short? RegfeePaidby { get; set; }
        public string PolicyRules { get; set; }
        public int? ApprovalDays { get; set; }
        public bool? ByPassExclusionsStatus { get; set; }
        public int? TariffId { get; set; }
        public int? BillingCollectorId { get; set; }
        public int? BillingOfficerId { get; set; }
        public bool? Loaconsultation { get; set; }
        public bool? Ucf { get; set; }
        public string CatGroup { get; set; }
        public string InsertUpdate { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public string OraCode { get; set; }
        public byte? RevisitDays { get; set; }
        public int? Speccons { get; set; }
        public string Attribute4 { get; set; }
    }
}
