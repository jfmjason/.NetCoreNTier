
using System;

namespace BA.UI.WebV2.Models
{
    public class ApprovalRequestDisplayVm
    {
        public int Id { get; set; }

        public int RequestStatusId { get; set; }
        public int ProcessById { get; set; }

        public string RequestStatus { get; set; }
        public string PIN { get; set; }
        public string InsuranceCardNo { get; set; }
        public string DoctorCode { get; set; }
        public string CategoryName { get; set; }
        public string ProcessBy { get; set; }

        public DateTime RequestDate { get; set; }

       
    }
}
