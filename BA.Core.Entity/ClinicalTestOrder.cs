using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
   public class ClinicalTestOrder
    {
        public string IssueAuthorityCode { get; set; }
        public int? RegistrationNo { get; set; }
        public int VisitId { get; set; }
        public int? Orderid { get; set; }
        public int? Testid { get; set; }
        public bool? Billed { get; set; }
        public int? DeptId { get; set; }
        public string Remarks { get; set; }
        public int? StatOrder { get; set; }
        public int EntityId { get; set; }
    }
}
