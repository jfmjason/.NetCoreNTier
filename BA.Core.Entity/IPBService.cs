using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public partial class IPBService
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string MasterTable { get; set; }
        public string OrderTable { get; set; }
        public string DetailTable { get; set; }
        public string PriceTable { get; set; }
        public short? PriceType { get; set; }
        public short? OrderType { get; set; }
        public short? NoofPrices { get; set; }
        public short? CalType { get; set; }
        public short? DisplayServiceId { get; set; }
        public short? OrderNo { get; set; }
        public short? NextDisplay { get; set; }
        public bool? Deleted { get; set; }
        public bool? Procedure { get; set; }
        public int? Itemlevel { get; set; }
        public bool? Category { get; set; }
        public string GroupTable { get; set; }
        public string SupportTable { get; set; }
        public int? MarkUp { get; set; }
        public string ArabicServiceName { get; set; }
        public string ArabicServiceCode { get; set; }
        public int? DepartmentId { get; set; }
        public string OraCode { get; set; }
        public bool? Uploaded { get; set; }
        public DateTime? Udatetime { get; set; }
    }
}
