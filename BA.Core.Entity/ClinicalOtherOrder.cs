using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class ClinicalOtherOrder
    {
        public int? Orderid { get; set; }
        public string IssueAuthorityCode { get; set; }
        public int? RegistrationNo { get; set; }
        public int VisitId { get; set; }
        public int? Testid { get; set; }
        public int? DeptId { get; set; }
        public bool? Billed { get; set; }
        public string Remarks { get; set; }
        public int EntityId { get; set; }
    }
}
