using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.UI.WebV2.Models
{
    public class ApprovalRequestReleaseUpdateVm
    {
        public int RequestId { get; set; }
        public int? AssignToEmployeeId { get; set; }
        public int? StationId { get; set; }

        public string IpAddress { get; set; }
        public string Remarks { get; set; }

    }
}
