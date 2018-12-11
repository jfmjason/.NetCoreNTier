using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class BedType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Startdatetime { get; set; }
        public bool Deleted { get; set; }
        public DateTime? Enddatetime { get; set; }
        public string Label { get; set; }
        public short? Type { get; set; }
        public string Arabicname { get; set; }
        public string Arabiccode { get; set; }
        public string Code { get; set; }
        public int? OperatorId { get; set; }
        public bool? Billable { get; set; }
    }
}
