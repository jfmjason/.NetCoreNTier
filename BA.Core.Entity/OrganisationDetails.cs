using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class OrganisationDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddInformation { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string FaxNo { get; set; }
        public string PagerNo { get; set; }
        public string CellPhoneNo { get; set; }
        public string PinCode { get; set; }
        public string District { get; set; }
        public int? CompanyId { get; set; }
        public string IssueAuthorityCode { get; set; }
        public string ContactPerson { get; set; }
        public int? Cashdefaultmarkup { get; set; }
        public string OraBranchid { get; set; }
        public string OraCountrycode { get; set; }
        public string OraCurrencycode { get; set; }
        public string OraCompanycode { get; set; }
        public DateTime? MovStartTime { get; set; }
        public DateTime? MovEndTime { get; set; }
        public byte? MovEnable { get; set; }
        public byte? IsSmsenable { get; set; }
        public byte? PicPerPage { get; set; }
        public byte? DelayPerPage { get; set; }
        public bool? NewRuleForLeave { get; set; }
        public int? TaxEnabled { get; set; }
        public int? CurrencyId { get; set; }
        public string VatregNo { get; set; }
    }
}
