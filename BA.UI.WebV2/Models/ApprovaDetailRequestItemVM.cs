
namespace BA.UI.WebV2.Models
{
    public class ApprovaDetailRequestItemVM
    {
 
        public int RequestId { get; set; }
        public int RequestItemId { get; set; }
        public int ItemRequestStatusId { get; set; }
        public int RequestedQuantity { get; set; }
        public int ApprovedQuantity { get; set; }
        public int UnitId { get; set; }
        public int ServiceId { get; set; }
        public int ItemId { get; set; }

        public decimal ApprovedAmount { get; set; }
        public decimal RequestedAmount { get; set; }
        public decimal Price { get; set; }

        public string ItemRequestStatus { get; set; }
        public string ItemName { get; set; }
        public string UnitName { get; set; }
        public string Remarks { get; set; }
        public string ApprovalNo { get; set; }
    


    }
}
