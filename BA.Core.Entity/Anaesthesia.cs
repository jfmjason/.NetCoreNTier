using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
   public class Anaesthesia
    {
        public short Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public short? Type { get; set; }
        public int? DepartmentId { get; set; }
        public decimal? Costprice { get; set; }
        public string Arabiccode { get; set; }
        public string Arabicname { get; set; }
        public byte Billingtype { get; set; }
        public DateTime Startdatetime { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? Enddatetime { get; set; }
        public bool Deleted { get; set; }
        public bool? Uploaded { get; set; }
        public DateTime? Udatetime { get; set; }
    }
}
