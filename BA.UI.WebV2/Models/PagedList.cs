using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.UI.WebV2.Models
{
    public class PagedList<T> where T:class
    {
        public int Page { get; set; }
        public int Pagesize { get; set; }
        public int Recordcount { get; set; }

        public List<T> Data { get; set; }
    }
}
