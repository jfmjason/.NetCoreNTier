using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
   public class OTNo
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public short OttypeId { get; set; }
        public DateTime StartDateTime { get; set; }
        public bool Deleted { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? Stationid { get; set; }
        public short? Type { get; set; }
    }
}
