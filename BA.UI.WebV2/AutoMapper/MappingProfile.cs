using AutoMapper;
using BA.Core.Entity;
using BA.UI.WebV2.Models;
using System.Collections.Generic;
using System.Globalization;

namespace BA.UI.WebV2.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<OpcompanyBillDetail, OpCompanyBillDetailVm>();

            CreateMap<OPBService, ServiceVm>()
            .ForMember(des => des.PriceTable, opt => opt.MapFrom(src => src.PriceTable.Trim()));

            CreateMap<IPBService, ServiceVm>()
            .ForMember(des => des.Name, opt => opt.MapFrom(src => src.ServiceName))
            .ForMember(des => des.PriceTable, opt => opt.MapFrom(src => src.PriceTable.Trim()));

            CreateMap<ServiceItemPrice, ServiceItemPriceVm>();

            CreateMap<Unit, UnitVm>();

            CreateMap<ApprovalRequest, ApprovalRequestListItemVm>()
           .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(des => des.RequestStatusId, opt => opt.MapFrom(src => src.ApprovalRequestStatusId))
           .ForMember(des => des.PIN, opt => opt.MapFrom(src => src.Patient != null ? src.Patient.IssueAuthorityCode + "." + src.Patient.Registrationno.ToString("0000000000") : null))
           .ForMember(des => des.RequestStatus, opt => opt.MapFrom(src => src.ApprovalRequestStatus.Name))
           .ForMember(des => des.InsuranceCardNo, opt => opt.MapFrom(src => src.InsuranceCardNumber))
           .ForMember(des => des.DoctorCode, opt => opt.MapFrom(src => src.Doctor.EmpCode))
           .ForMember(des => des.CategoryName, opt => opt.MapFrom(src => src.Category.Code))
           .ForMember(des => des.ProcessBy, opt => opt.MapFrom(src => src.ProcessById.HasValue ? src.ProcessBy.Name : null))
           .ForMember(des => des.RequestDate, opt => opt.MapFrom(src => src.CreatedDate))
           .ForMember(des => des.Items, opt => opt.MapFrom(src => src.ApprovalItems));

            CreateMap<ApprovalRequestItem, ApprovaDetailRequestItemVM>()
           .ForMember(des => des.RequestId, opt => opt.MapFrom(src => src.ApprovalRequestId))
           .ForMember(des => des.RequestItemId, opt => opt.MapFrom(src => src.Id))
           .ForMember(des => des.ItemRequestStatusId, opt => opt.MapFrom(src => src.ApprovalRequestItemStatusId))
           .ForMember(des => des.RequestedQuantity, opt => opt.MapFrom(src => src.RequestedQuantity))
           .ForMember(des => des.ApprovedQuantity, opt => opt.MapFrom(src => src.ApprovedQuantity))
           .ForMember(des => des.RequestedAmount, opt => opt.MapFrom(src => src.RequestedAmount))
           .ForMember(des => des.ApprovedAmount, opt => opt.MapFrom(src => src.ApprovedAmount))
           .ForMember(des => des.Remarks, opt => opt.MapFrom(src => src.Remarks))
           .ForMember(des => des.ItemName, opt => opt.MapFrom(src => src.ItemName))
           .ForMember(des => des.Price, opt => opt.MapFrom(src => src.ItemPrice))
           .ForMember(des => des.ItemRequestStatus, opt => opt.MapFrom(src => src.ApprovalRequestItemStatus.Name))
           .ForMember(des => des.ApprovalNo, opt => opt.MapFrom(src => src.ApprovalNumber))
           .ForMember(des => des.UnitName, opt => opt.MapFrom(src => src.Unit.Name))
           .ForMember(des => des.ItemId, opt => opt.MapFrom(src => src.ItemId))
           .ForMember(des => des.UnitId, opt => opt.MapFrom(src => src.UnitId))
           .ForMember(des => des.ServiceId, opt => opt.MapFrom(src => src.ServiceId));

            CreateMap<ApprovalRequestProcessRelease, RPTReleaseProcessVm>()
           .ForMember(des => des.ReferenceNo, opt => opt.MapFrom(src => src.ApprovalRequestId.ToString()))
           .ForMember(des => des.PIN, opt => opt.MapFrom(src => src.ApprovalRequest.IssueAuthorityCode + "." + src.ApprovalRequest.Registrationno.ToString("0000000000")))
           .ForMember(des => des.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate.ToString("dd/MM/yyyy")))
           .ForMember(des => des.Releaseby, opt => opt.MapFrom(src => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(src.ReleasedByEmployee.Name.ToLower())))
           .ForMember(des => des.ProcessOwner, opt => opt.MapFrom(src => (src.CurrentProcessOwner != null ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(src.CurrentProcessOwner.Name.ToLower()) : "")))
           .ForMember(des => des.TransferTo, opt => opt.MapFrom(src => (src.AssignToEmployee != null ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(src.AssignToEmployee.Name.ToLower()) : "")))
           .ForMember(des => des.Remarks, opt => opt.MapFrom(src => src.Remarks));
        }


    }
}
