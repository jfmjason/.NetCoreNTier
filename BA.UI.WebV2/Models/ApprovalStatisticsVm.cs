using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.UI.WebV2.Models
{
    public class ApprovalStatisticsVm
    {
        public string Date { get; set; }
        public int UnderProcessCount { get; set; }
        public int ForApprovalCount { get; set; }
        public int DoneCount { get; set; }
        public int OutPatientCount { get; set; }
        public int InPatientCount { get; set; }
    }
}
