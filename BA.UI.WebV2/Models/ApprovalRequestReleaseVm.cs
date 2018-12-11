using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.UI.WebV2.Models
{
    public class ApprovalRequestReleaseVm : ApprovalRequestDisplayVm
    {
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string CompanyName { get; set; }
        public string GradeName { get; set; }

        public string RequestType { get; set; }

        public DateTime? ProcessDate { get; set; }
    }
}
