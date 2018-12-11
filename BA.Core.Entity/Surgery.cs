using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class Surgery
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ArabicCode { get; set; }
        public string ArabicName { get; set; }
        public double? CostPrice { get; set; }
        public bool? Package { get; set; }
        public byte? Grade { get; set; }
        public string Instructions { get; set; }
        public int DepartmentId { get; set; }
        public byte? SurgeryType { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public int? ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public byte? StatusType { get; set; }
        public int? Uploaded { get; set; }
        public DateTime? Udatetime { get; set; }
    }
}
