using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class AccessUserfeatures
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int StationId { get; set; }
        public int ModuleId { get; set; }
        public int FeatureId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? OperatorId { get; set; }
        public bool Deleted { get; set; }
    }
}
