using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.UI.WebV2.Models
{
    public class ApprovalRequestDetailVm :ApprovalRequestDisplayVm
    {
        public string PatientName { get; set; }
        public string CompanyName { get; set; }
        public string GradeName { get; set; }

        public string DoctorName { get; set; }
        public string RequestType { get; set; }
        public string ClincalData { get; set; }

        public int StationId { get; set; }

        public DateTime? ProcessDate { get; set; }

        public IEnumerable<ApprovaDetailRequestItemVM> RequestItems { get; set; } 
    }
}
