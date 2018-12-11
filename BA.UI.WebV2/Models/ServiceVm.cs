using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.UI.WebV2.Models
{
    public class ServiceVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MasterTable { get; set; }
        public string OrderTable { get; set; }
        public string DetaiTtable { get; set; }
        public string PriceTable { get; set; }

        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string ServiceCode { get; set; }
        public int? MarkUp { get; set; }
        public string OraCode { get; set; }

    }
}
