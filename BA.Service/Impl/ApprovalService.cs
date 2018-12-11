using BA.Core.Interface;
using BA.IService;
using System;
using System.Collections.Generic;
using BA.Core.Entity;
using System.Linq;
using BA.Core.Entity.data;

namespace BA.Service.Impl
{
   public class ApprovalService : IApprovalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private bool disposed = false;

        public ApprovalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;  
        }

        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);

        }

        #region[ApprovalRequest]
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

        public bool AddApprovalRequest(ApprovalRequest request)
        {
            request.Active = true;
            _unitOfWork.ApprovalRequest.Add(request);
            _unitOfWork.Commit();

            return request.Id > 0;
        }

        public bool DeleteApprovalRequest(int id, int userId, int stationId ,string ipAddress)
        {
            var approvalRequest = _unitOfWork.ApprovalRequest.GetById(id);

            approvalRequest.Active = false;
            approvalRequest.ModifiedById = userId;
            approvalRequest.ModifiedDate = DateTime.Now;
            approvalRequest.RequestModificationStationId = stationId;
            approvalRequest.ModificationIPAddress = ipAddress;

            approvalRequest.ApprovalItems.ForEach(i =>
            {
                i.Active = false;
                i.ModifiedById = userId;
                i.ModifiedDate = DateTime.Now;
            });

            _unitOfWork.ApprovalRequest.Update(approvalRequest);
            _unitOfWork.Commit();

            return true;
        }

        public IEnumerable<ApprovalRequest> GetALLApprovalRequest()
        {
            return _unitOfWork.ApprovalRequest.Entities;
        }

        public IEnumerable<ApprovalRequest> GetApprovalRequest(DateTime createdDate)
        {
            return _unitOfWork.ApprovalRequest.Entities
                    .Where(i=> i.CreatedDate.Date == createdDate.Date &&  i.Active ==true);
        }

        public ApprovalRequest GetApprovalRequestById(int id)
        {
            return _unitOfWork.ApprovalRequest.GetById(id);
        }

        public bool UpdateApprovalRequest(ApprovalRequest request)
        {
            var entity = _unitOfWork.ApprovalRequest.GetById(request.Id);
            bool haspending = false;

            entity.ApprovalItems.Select(item => 
            {
                var newitem = request.ApprovalItems.SingleOrDefault(n => item.Id == n.Id);

                if(newitem != null)
                {
                    if (item.ApprovalRequestItemStatusId != newitem.ApprovalRequestItemStatusId
                          || item.Remarks != newitem.Remarks
                          || item.ApprovalNumber != newitem.ApprovalNumber
                          )
                    {
                        item.ModifiedById = entity.ModifiedById;
                        item.ModifiedDate = entity.ModifiedDate;
                        item.Remarks = newitem.Remarks;
                        item.ApprovalNumber = newitem.ApprovalNumber;
                        item.ApprovalRequestItemStatusId = newitem.ApprovalRequestItemStatusId;
                        item.ApprovedAmount = newitem.ApprovedAmount;
                        item.ApprovedQuantity = newitem.ApprovedQuantity;
                    }
                }
                return item;
            }).ToList();

            haspending = entity.ApprovalItems.Any(i => i.ApprovalRequestItemStatusId == (int) ItemRequestStatus.PENDING 
                        || i.ApprovalRequestItemStatusId == (int)ItemRequestStatus.UNDER_PROCESS);

            entity.ModifiedById = request.ModifiedById;
            entity.ModifiedDate = request.ModifiedDate;
            entity.ProcessById = request.ModifiedById;
            entity.RequestModificationStationId = request.RequestModificationStationId;
            entity.ModificationIPAddress = request.ModificationIPAddress;
            entity.RequestModificationStationId = request.RequestModificationStationId;

            if (!entity.ProcessingDate.HasValue)
                entity.ProcessingDate = DateTime.Now;

            if (haspending){
                entity.ApprovalRequestStatusId = (int)RequestStatus.UNDER_PROCESS;
            }
            else
            {
                entity.ApprovalRequestStatusId = (int)RequestStatus.DONE;
            }

            _unitOfWork.ApprovalRequest.Update(entity);
            _unitOfWork.Commit();

            return true;
        }

        public IEnumerable<ApprovalRequest> GetApprovalRequest(string term, int take, int skip, string sortBy, bool sortDir, out int filteredResultsCount, out int totalResultsCount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApprovalRequest> GetApprovalRequest(DateTime fromDate, DateTime toDate, int? categoryId)
        {
   
            return _unitOfWork.ApprovalRequest.Entities
                      .Where(i =>
                      i.CreatedDate >= fromDate.Date && i.CreatedDate < toDate.Date &&
                      i.Active == true
                      && (categoryId.HasValue == false || categoryId.Value == i.CategoryId) ).OrderBy(i=>i.CreatedDate);
        }

        public IEnumerable<ApprovalRequest> GetApprovalRequest(DateTime fromDate, DateTime toDate, int? categoryId, int? registrationno)
        {

            return _unitOfWork.ApprovalRequest.Entities
                      .Where(i =>
                      i.CreatedDate >= fromDate.Date && i.CreatedDate < toDate.Date 
                      && (categoryId.HasValue == false || categoryId.Value == i.CategoryId)
                      && (registrationno.HasValue == false || registrationno.Value == i.Registrationno)
                      && i.Active == true).OrderBy(i => i.CreatedDate);
        }

        public IEnumerable<ApprovalRequest> GetApprovalRequest(DateTime? fromCreatedDate, DateTime? toCreatedDate
            , int? registrationNo, int? patientType, int? requestStatusId, int? requestTypeId)
        {
            var query = _unitOfWork.ApprovalRequest.Entities.Where(i => i.Active == true);

            if(fromCreatedDate.HasValue && toCreatedDate.HasValue)
                query.Where(i => i.CreatedDate.Date >= fromCreatedDate.Value.Date && i.CreatedDate.Date <= toCreatedDate.Value.Date);

            if (registrationNo.HasValue)
                query.Where(i => i.Registrationno == registrationNo.Value);

            if (patientType.HasValue)
                query.Where(i => i.PatientTypeId == patientType.Value);

            if(requestStatusId.HasValue)
                query.Where(i => i.PatientTypeId == requestStatusId.Value);

            if (requestTypeId.HasValue)
                query.Where(i => i.ApprovalRequestTypeId == requestTypeId.Value);

        
            return query;
        }

        public bool ReleaseApprovalRequestProcess(int requestId, int releaseByEmployeeId, string remarks, string ipAddress, int? stationId, int? assignToEmployeeId)
        {
            var approvalRequestEntity = _unitOfWork.ApprovalRequest.GetById(requestId);

            var processReleaseEntity = new ApprovalRequestProcessRelease()
            {
                ApprovalRequestId = requestId,
                ReleasedByEmployeeId = releaseByEmployeeId,
                CurrentProcessOwnerId = approvalRequestEntity.ProcessById.Value,
                AssignToEmployeeId = assignToEmployeeId,
                Remarks = remarks,
                ReleaseDate = DateTime.Now,
                IpAddress = ipAddress,
                StationId = stationId
            };


            approvalRequestEntity.ModificationIPAddress = ipAddress;
            approvalRequestEntity.RequestModificationStationId = stationId;
            approvalRequestEntity.ModifiedById = releaseByEmployeeId;
            approvalRequestEntity.ModifiedDate = DateTime.Now;
            approvalRequestEntity.ProcessById = assignToEmployeeId;

            _unitOfWork.ApprovalRequestProcessRelease.Add(processReleaseEntity);
            _unitOfWork.ApprovalRequest.Update(approvalRequestEntity);

            _unitOfWork.Commit();

            return true;
        }

        #endregion
    }
}
