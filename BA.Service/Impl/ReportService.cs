using BA.Core.Entity;
using BA.Core.Interface;
using BA.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BA.Service.Impl
{
    public class ReportService : IReportService
    {
        private IUnitOfWork _iUnitOfWork;

        public ReportService(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }

        #region [ApprovalRequestProcessRelease]

        public IEnumerable<ApprovalRequestProcessRelease> GetApprovalRequestProcessReleases()
        {
            return _iUnitOfWork.ApprovalRequestProcessRelease.Entities;
        }

        public IEnumerable<ApprovalRequestProcessRelease> GetApprovalRequestProcessReleases(DateTime fromreleasedate, DateTime toreleasedate)
        {
            return _iUnitOfWork.ApprovalRequestProcessRelease.Entities
                    .Where(i => i.ReleaseDate.Date >= fromreleasedate.Date && i.ReleaseDate.Date <= toreleasedate.Date);
        }

        public IEnumerable<ApprovalRequestProcessRelease> GetApprovalRequestProcessReleases(DateTime fromreleasedate, DateTime toreleasedate, int? releaseBy)
        {
            return _iUnitOfWork.ApprovalRequestProcessRelease.Entities
                    .Where(i => i.ReleaseDate.Date >= fromreleasedate.Date 
                    && i.ReleaseDate.Date <= toreleasedate.Date
                    &&(releaseBy.HasValue == false || releaseBy == i.ReleasedByEmployeeId)
                    );
        }
        #endregion

    }
}
