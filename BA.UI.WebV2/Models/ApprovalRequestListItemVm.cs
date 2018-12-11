using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.UI.WebV2.Models
{
    public class ApprovalRequestListItemVm : ApprovalRequestDisplayVm
    {
       public List<ApprovaDetailRequestItemVM> Items { get; set; }
    }
}
