using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
   public class BedsideProcedure
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public decimal? Costprice { get; set; }
        public DateTime Startdatetime { get; set; }
        public bool Deleted { get; set; }
        public DateTime? Enddatetime { get; set; }
        public string Code { get; set; }
        public short Departmentid { get; set; }
        public string Arabicname { get; set; }
        public string Arabiccode { get; set; }
        public byte? StatusType { get; set; }
        public bool? Uploaded { get; set; }
        public DateTime? Udatetime { get; set; }
    }
}
