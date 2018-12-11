using BA.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BA.IService
{
   public interface IReportService
   {
        IEnumerable<ApprovalRequestProcessRelease> GetApprovalRequestProcessReleases();

        IEnumerable<ApprovalRequestProcessRelease> GetApprovalRequestProcessReleases(DateTime fromreleasedate, DateTime toreleasedate);

        IEnumerable<ApprovalRequestProcessRelease> GetApprovalRequestProcessReleases(DateTime fromreleasedate, DateTime toreleasedate, int? releaseBy );
    }
}
