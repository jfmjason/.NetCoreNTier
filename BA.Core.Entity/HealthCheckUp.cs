using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class HealthCheckUp
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? DepartmentId { get; set; }
        public string Instructions { get; set; }
        public int? Companyid { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public short Deleted { get; set; }
        public short Blocked { get; set; }
        public int? OperatorId { get; set; }
        public bool? Uploaded { get; set; }
    }
}
