using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public partial class OPBService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MasterTable { get; set; }
        public string OrderTable { get; set; }
        public string DetaiTtable { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool Deleted { get; set; }
        public string ServiceCode { get; set; }
        public string PriceTable { get; set; }
        public int? DisplayServiceId { get; set; }
        public string SupportTable { get; set; }
        public int? MarkUp { get; set; }
        public string OraCode { get; set; }
    }
}
