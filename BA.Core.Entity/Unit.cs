using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? StartDateTime { get; set; }
    }
}
