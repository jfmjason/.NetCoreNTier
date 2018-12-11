using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class FoodItem
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ArabicCode { get; set; }
        public string ArabicName { get; set; }
        public string Units { get; set; }
        public decimal? CostPrice { get; set; }
        public int? CategoryId { get; set; }
        public int? SectionId { get; set; }
        public byte? StatusType { get; set; }
        public int? OperatorId { get; set; }
        public DateTime StartDateTime { get; set; }
        public byte[] LastUpdated { get; set; }
        public bool Deleted { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool? Uploaded { get; set; }
        public DateTime? Udatetime { get; set; }
    }
}
