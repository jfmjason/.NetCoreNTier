using BA.IService;
using System;
using System.Collections.Generic;
using System.Text;
using BA.Core.Entity;
using BA.Core.Interface;
using System.Linq;

namespace BA.Service.Impl
{
    public class MenuService : IMenuService, IDisposable
    {
        private bool disposed = false;
        private readonly IUnitOfWork _unitOfWork;

        public MenuService(IUnitOfWork unitOfWork) {

            _unitOfWork = unitOfWork;

        }

        public IEnumerable<AccessUserfeatures> GetFeatureAccess(int moduleId, int userId)
        {
            return _unitOfWork.AccessUserfeatures.Entities
                   .Where(a => a.ModuleId == moduleId && a.Userid == userId && a.Deleted == false);
                   
        }

        public MenuParent GetMenu(int menuId)
        {
            return _unitOfWork.MenuParent.Entities
                   .FirstOrDefault(a => a.MenuId.Value == menuId);
        }

        public IEnumerable<MenuParent> GetMenus(int[] menuIds)
        {
            return _unitOfWork.MenuParent.Entities
                  .Where(a => menuIds.Contains(a.MenuId.Value));
        }

        public MenuAccess GetSubMenu(int featureId)
        {
            return _unitOfWork.MenuAccess.Entities
                  .FirstOrDefault(a => a.FeatureId.Value == featureId);
        }

        public IEnumerable<MenuAccess> GetSubMenus(int[] featureIds)
        {
            return _unitOfWork.MenuAccess.Entities
                .Where(a => featureIds.Contains(a.FeatureId.Value));
        }

        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _unitOfWork.Dispose();
            }

            disposed = true;
        }

    }
}
