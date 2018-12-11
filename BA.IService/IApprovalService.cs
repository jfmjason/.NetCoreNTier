using BA.Core.Entity;
using System;
using System.Collections.Generic;

namespace BA.IService
{
    public interface IApprovalService
    {
        ApprovalRequest GetApprovalRequestById(int id);

        IEnumerable<ApprovalRequest> GetApprovalRequest(DateTime createdDate);
        IEnumerable<ApprovalRequest> GetApprovalRequest(DateTime fromDate, DateTime toDate , int? categoryId);
        IEnumerable<ApprovalRequest> GetApprovalRequest(DateTime fromDate, DateTime toDate, int? categoryId, int? registrationno);

        IEnumerable<ApprovalRequest> GetApprovalRequest(DateTime? fromCreatedDate, DateTime? toCreatedDate , int? registrationNo
            , int? patientType , int? requestStatusId, int? requestTypeId);

        IEnumerable<ApprovalRequest> GetALLApprovalRequest();

        IEnumerable<ApprovalRequest> GetApprovalRequest(string term, int take, int skip, string sortBy,
                                                    bool sortDir, out int filteredResultsCount, out int totalResultsCount);

        bool AddApprovalRequest(ApprovalRequest request);
        bool UpdateApprovalRequest(ApprovalRequest request);
        bool DeleteApprovalRequest(int id, int userId, int stationId, string ipAddress);

        bool ReleaseApprovalRequestProcess(int requestId, int releaseByEmployeeId, string remarks, string ipAddress
            , int? stationId, int? assignToEmployeeId);
    }
}
