using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
   public class OpDoctorOrder
    {
        public int Id { get; set; }
        public int OpbillId { get; set; }
        public int? Stationslno { get; set; }
    }
}
