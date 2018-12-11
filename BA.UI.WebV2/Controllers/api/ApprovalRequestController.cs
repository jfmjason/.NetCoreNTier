using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AutoMapper;
using BA.Core.Entity;
using BA.Core.Entity.data;
using BA.IService;
using BA.UI.WebV2.Extension;
using BA.UI.WebV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientType = BA.Core.Entity.data.PatientType;

namespace BA.UI.WebV2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ApprovalRequestController : Controller
    {
        IApprovalService _iApprovalService;
        IMasterFileService _imasterFileService;
        IMapper _imapper;
        public ApprovalRequestController(IApprovalService iApprovalService, IMasterFileService imasterFileService, IMapper imapper) {

            _iApprovalService = iApprovalService;
            _imasterFileService = imasterFileService;
            _imapper = imapper;

        }

        [HttpGet("{fromdate}/{todate}/{categoryId?}/{registrationno?}")]
        public IEnumerable<ApprovalRequestListItemVm> Get(DateTime fromdate, DateTime todate, int? categoryId, int? registrationno)
        {
            var request = _iApprovalService.GetApprovalRequest(fromdate, todate.AddDays(1), categoryId, registrationno);

            return _imapper.Map<List<ApprovalRequestListItemVm>>(request);
        }

        [HttpGet("status/statistics/{fromdate}/{todate}")]
        public IEnumerable<ApprovalStatisticsVm> Get(DateTime fromdate, DateTime todate)
        {
            var statistics = new List<ApprovalStatisticsVm>();
            var request = _iApprovalService.GetApprovalRequest(fromdate, todate.AddDays(1), null);

            foreach(var stat in request.GroupBy(i=> i.CreatedDate.Date))
            {
                statistics.Add(new ApprovalStatisticsVm()
                {
                    Date = stat.First().CreatedDate.ToString("dd-MMM-yyyy"),
                    ForApprovalCount = stat.Count(i=>i.ApprovalRequestStatusId == (int)RequestStatus.FOR_APPROVAL),
                    UnderProcessCount = stat.Count(i => i.ApprovalRequestStatusId == (int)RequestStatus.UNDER_PROCESS),
                    DoneCount = stat.Count(i => i.ApprovalRequestStatusId == (int)RequestStatus.DONE),
                    InPatientCount = stat.Count(i=>i.PatientTypeId == (int)PatientType.IN_PATIENT),
                    OutPatientCount = stat.Count(i => i.PatientTypeId == (int)PatientType.OUT_PATIENT)
                });
            }

            return statistics;
        }


        [HttpGet("{fromdate?}/{todate?}/{registrationNo?}/{patientType?}/{requestStatusId?}/{requestTypeId?}")]
        public IEnumerable<ApprovalRequestDisplayVm> Get( int? registrationNo
            , int? patientType, int? requestStatusId, int? requestTypeId, DateTime? fromdate = null, DateTime? todate = null)
        {
            return _iApprovalService.GetApprovalRequest(fromdate, todate, registrationNo, patientType
                     , requestStatusId, requestTypeId)
                    .toListApprovalRequestDisplayVm();
        }


        [HttpGet("{id}")]
        public ApprovalRequestDetailVm Get(int id)
        {
            return _iApprovalService.GetApprovalRequestById(id).toApprovalRequestDetailVm();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody]ApprovalRequestDetailVm value)
        {
            var entity = new ApprovalRequest()
            {
                Id = id,
                ModifiedById = User.Identity.GetEmployeeId(),
                ModifiedDate = DateTime.Now,
                ModificationIPAddress = User.Identity.GetIpAddress(),
                RequestModificationStationId = value.StationId,
                ApprovalItems = value.RequestItems.Select(i =>
                new ApprovalRequestItem()
                {
                    Id = i.RequestItemId,
                    ApprovalRequestId = i.RequestId,
                    ItemName = i.ItemName,
                    RequestedQuantity = i.RequestedQuantity,
                    RequestedAmount = i.RequestedAmount,
                    ApprovedAmount = i.ApprovedAmount,
                    ApprovedQuantity = i.ApprovedQuantity,
                    ApprovalNumber = i.ApprovalNo,
                    Remarks = i.Remarks,
                    ApprovalRequestItemStatusId = i.ItemRequestStatusId,
                    

                }).ToList()

            };

            _iApprovalService.UpdateApprovalRequest(entity);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }


        [HttpPut("release/{id}")]
        public HttpResponseMessage Put(int id, [FromBody]ApprovalRequestReleaseUpdateVm value)
        {
            _iApprovalService.ReleaseApprovalRequestProcess(id,User.Identity.GetEmployeeId(),value.Remarks
                , User.Identity.GetIpAddress(), value.StationId ,value.AssignToEmployeeId);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut("delete/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] int stationId)
        {
            _iApprovalService.DeleteApprovalRequest(id, User.Identity.GetEmployeeId(), stationId, User.Identity.GetIpAddress());

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]CreateApprovalRequestVm value)
        {
            var organizationdetail = _imasterFileService.GetOrganisationDetailById(1);
            var doctor = _imasterFileService.GetEmployeeById(value.DoctorId);

            var request = new ApprovalRequest()
            {
                ApprovalRequestTypeId = value.RequestTypeId,
                ApprovalRequestStatusId = (int)RequestStatus.FOR_APPROVAL,
                Registrationno = value.Registrationno,
                PatientTypeId = value.PatientTypeId,
                IPId = value.IPId,
                CategoryId = value.CategoryId,
                CompanyId = value.CompanyId,
                GradeId = value.GradeId,
                CreatedById = User.Identity.GetEmployeeId(),
                CreatedDate = DateTime.Now,
                CreationIPAddress = User.Identity.GetIpAddress(),
                RequestCreationStationId = value.StationId,
                DoctorId = value.DoctorId,
                BranchId = organizationdetail.Id,
                IssueAuthorityCode = organizationdetail.IssueAuthorityCode,
                InsuranceCardNumber = value.InsuranceCardNumber,
                ClinicalData = value.ClinicalData,
                ApprovalItems = value.Items.Select(x => new ApprovalRequestItem()
                {
                    ServiceId = x.ServiceId,
                    ApprovalRequestItemStatusId = (int)ItemRequestStatus.PENDING,
                    OPBServiceId = value.PatientTypeId == 2 ? x.ServiceId : default(int?),
                    IPBServiceId = value.PatientTypeId == 1 ? x.ServiceId : default(int?),
                    ItemId = x.ItemId,
                    ItemName = x.ItemName,
                    ItemPrice = x.Price,
                    TariffId = value.TariffId,
                    UnitId = x.UnitId,
                    DepartmentId = doctor.DepartmentId.Value,
                    RequestedQuantity = x.Quantity,
                    RequestedAmount = x.Amount,
                    Remarks = x.Remarks,
                    CreatedById = User.Identity.GetEmployeeId(),
                    CreatedDate = DateTime.Now,
                    Active = true
                }).ToList()
            };

            var result = _iApprovalService.AddApprovalRequest(request);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }


   
}
