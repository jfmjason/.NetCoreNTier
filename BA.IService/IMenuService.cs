using BA.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BA.IService
{
   public interface IMenuService
   {
        IEnumerable<AccessUserfeatures> GetFeatureAccess(int moduleId, int userId);
        IEnumerable<MenuParent> GetMenus(int[] menuIds);
        IEnumerable<MenuAccess> GetSubMenus(int[] menuIds);

        MenuParent GetMenu(int menuId);
        MenuAccess GetSubMenu(int menuId);
    }
}
