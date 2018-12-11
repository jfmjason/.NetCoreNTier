using System.Collections.Generic;

namespace BA.UI.WebV2.Models
{
    public class MenuVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubMenuVm> SubMenus { get; set; }
    }
}
