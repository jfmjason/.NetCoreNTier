using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class MenuAccess
    {
        public int Id { get; set; }
        public int? FeatureId { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string MenuUrl { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? OperatorId { get; set; }
        public bool Deleted { get; set; }
        public int? SequenceNo { get; set; }
        public bool? Bar { get; set; }
        public bool? NewWindow { get; set; }
        public int? MenuType { get; set; }
    }
}
