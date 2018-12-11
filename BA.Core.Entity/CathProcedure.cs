using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class CathProcedure
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ArabicCode { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public int DepartmentId { get; set; }
        public double? Costprice { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool Deleted { get; set; }
        public byte[] LastUpdated { get; set; }
        public string AngioNumber { get; set; }
        public int? GroupId { get; set; }
        public string Instructions { get; set; }
        public int? OperatorId { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifieddatetime { get; set; }
        public byte? StatusType { get; set; }
        public int? Uploaded { get; set; }
        public DateTime? Udatetime { get; set; }
    }
}
