using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
   public class OpcompanyBillDetail
    {
        public int Id { get; set; }
        public string IssueAuthorityCode { get; set; }
        public int? RegistrationNo { get; set; }
        public int? OpbillId { get; set; }
        public string BillNo { get; set; }
        public int? CategoryId { get; set; }
        public int? CompanyId { get; set; }
        public int? GradeId { get; set; }
        public int? DoctorId { get; set; }
        public int? ServiceId { get; set; }
        public int? ItemId { get; set; }
        public short? DiscountType { get; set; }
        public bool? Deductable { get; set; }
        public decimal? BillAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Balance { get; set; }
        public DateTime? Billdatetime { get; set; }
        public int? DepartmentId { get; set; }
        public int? Quantity { get; set; }
        public short? BillTypeId { get; set; }
        public int? StationId { get; set; }
        public int? AuthorityId { get; set; }
        public short? Posted { get; set; }
        public int? BatchId { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public int? BillingofficerId { get; set; }
        public byte? IsInvDone { get; set; }
        public int? OperatorId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string SghauthorityId { get; set; }
        public decimal? Issueqty { get; set; }
        public int? IssueUnit { get; set; }
        public int? SubPolicy { get; set; }
        public DateTime? ActualDate { get; set; }
    }
}
