using BA.IService;
using BA.UI.WebV2.Common;
using BA.UI.WebV2.Extension;
using BA.UI.WebV2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.UI.WebV2.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        IMenuService _menuService;
        public MenuViewComponent(IMenuService menuService) {

            _menuService = menuService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menus = new List<MenuVm>();
            var featureaccess = _menuService.GetFeatureAccess(Global.ModuleId, User.Identity.GetEmployeeId());
            var submenu = _menuService.GetSubMenus(featureaccess.Select(i => i.FeatureId).ToArray());
            var parentmenus = _menuService.GetMenus(submenu.Select(i => i.ParentId.Value).ToArray());

            foreach (var menu in parentmenus)
            {
                var parentmenu = new MenuVm()
                {
                    Id = menu.Id,
                    Name = menu.Name,
                    SubMenus = new List<SubMenuVm>()
                };

                foreach (var sub in submenu.Where(i => i.ParentId.Value == menu.Id).OrderBy(s => s.SequenceNo))
                {
                    parentmenu.SubMenus.Add(new SubMenuVm()
                    {
                        Id = sub.Id,
                        ParentId = sub.ParentId.HasValue ? sub.ParentId.Value : 0,
                        Name = sub.Name,
                        UrlAction = sub.MenuUrl
                    });
                }
                menus.Add(parentmenu);
            }


            return View(menus);
        }
    }
}
