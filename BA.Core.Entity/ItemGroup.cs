using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class ItemGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Parent { get; set; }
        public int? MaxId { get; set; }
        public int? Fixed { get; set; }
        public int? Medical { get; set; }
        public bool? MaintDept { get; set; }
        public byte? Equipment { get; set; }
        public byte? OverSea { get; set; }
        public bool? Deleted { get; set; }
    }
}
