using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class Component
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Arabiccode { get; set; }
        public string Arabicname { get; set; }
        public int? TempId { get; set; }
        public string TempName { get; set; }
        public short? Type { get; set; }
        public bool? DefaultType { get; set; }
        public double? Costprice { get; set; }
        public int? Departmentid { get; set; }
        public short? ExpiryPeriod { get; set; }
        public string Unit { get; set; }
        public int? ReplacementCount { get; set; }
        public DateTime StartDateTime { get; set; }
        public bool Deleted { get; set; }
        public DateTime? EndDateTime { get; set; }
        public byte[] LastUpdated { get; set; }
        public int? TimeId { get; set; }
        public bool? Uploaded { get; set; }
        public DateTime? Udatetime { get; set; }
    }
}
