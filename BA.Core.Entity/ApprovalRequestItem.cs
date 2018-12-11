using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BA.Core.Entity
{

    public class ApprovalRequestItem : BaseEntity
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int RequestedQuantity { get; set; }
        public int ApprovedQuantity { get; set; }
      
        public decimal ApprovedAmount { get; set; }
        public decimal RequestedAmount { get; set; }
        public decimal ItemPrice { get; set; }

        [MaxLength(100)]
        public string ItemName { get; set; }
        [MaxLength(200)]
        public string Remarks { get; set; }
        [MaxLength(50)]
        public string ApprovalNumber { get; set; }

        public int ApprovalRequestItemStatusId { get; set; }
        public virtual ApprovalRequestItemStatus ApprovalRequestItemStatus { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public int TariffId { get; set; }
        public virtual Tariff Tariff { get; set; }

        public int? OPBServiceId { get; set; }
        public virtual OPBService OPBService { get; set; }

        public int? IPBServiceId { get; set; }
        public virtual IPBService IPBService { get; set; }

        public int ApprovalRequestId { get; set; }
        public virtual ApprovalRequest ApprovalRequest { get; set; }

        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }

    }
}
