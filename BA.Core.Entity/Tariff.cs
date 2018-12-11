using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public partial class Tariff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool? Deleted { get; set; }
    }
}
