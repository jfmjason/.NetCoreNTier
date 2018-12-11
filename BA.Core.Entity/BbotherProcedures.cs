using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class BBOtherProcedures
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Startdatetime { get; set; }
        public DateTime? Enddatetime { get; set; }
        public bool? Deleted { get; set; }
        public int? Operatorid { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifieddatetime { get; set; }
        public short? Departmentid { get; set; }
        public string Arabicname { get; set; }
        public string Arabiccode { get; set; }
        public string Code { get; set; }
        public int? Type { get; set; }
        public bool? Uploaded { get; set; }
        public DateTime? Udatetime { get; set; }
    }
}
