namespace BA.UI.WebV2.Models
{
    public class CreateApprovalRequestItemVm
    {
        public string ItemName { get; set; }
        public string Remarks { get; set; }

        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public int ServiceId { get; set; }

        public decimal Price { get; set; }
        public decimal Amount { get; set; }

    }
}
