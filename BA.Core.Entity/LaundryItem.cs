using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
   public class LaundryItem
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double? CostPrice { get; set; }
        public string Units { get; set; }
        public int? Ip { get; set; }
        public string ArabicName { get; set; }
        public string ArabicCode { get; set; }
        public byte? StatusType { get; set; }
        public int? OperatorId { get; set; }
        public DateTime StartDateTime { get; set; }
        public bool Deleted { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool? Uploaded { get; set; }
        public DateTime? Udatetime { get; set; }
    }
}
