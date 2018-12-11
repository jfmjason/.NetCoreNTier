using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class MiscItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Amount { get; set; }
        public int DepartmentId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int OperatorId { get; set; }
        public int Deleted { get; set; }
        public string Arabicname { get; set; }
        public string Arabiccode { get; set; }
    }
}
