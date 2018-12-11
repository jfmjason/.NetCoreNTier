using BA.Core.Entity;
using BA.UI.WebV2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BA.UI.WebV2.Extension
{
    public static class EntityToViewModelMapper
    {
        public static ApprovalRequestTypeVm toApprovalRequestTypeVm(this ApprovalRequestType entity)
        {
            return new ApprovalRequestTypeVm()
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code
            };
        }

        public static IEnumerable<ApprovalRequestTypeVm> toListApprovalRequestTypeVm(this IEnumerable<ApprovalRequestType> entities)
        {
            var vmlist = new List<ApprovalRequestTypeVm>();

            foreach (var entity in entities)
            {
                vmlist.Add(entity.toApprovalRequestTypeVm());
            }

            return vmlist;
        }

        public static ApprovalRequestStatusVm toApprovalRequestStatusVm(this ApprovalRequestStatus entity)
        {
            return new ApprovalRequestStatusVm()
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code
            };
        }

        public static IEnumerable<ApprovalRequestStatusVm> toListApprovalRequestStatusVm(this IEnumerable<ApprovalRequestStatus> entities)
        {
            var vmlist = new List<ApprovalRequestStatusVm>();

            foreach (var entity in entities)
            {
                vmlist.Add(entity.toApprovalRequestStatusVm());
            }

            return vmlist;
        }

        public static ApprovalRequestItemStatusVm toApprovalRequestItemStatusVm(this ApprovalRequestItemStatus entity)
        {
            return new ApprovalRequestItemStatusVm()
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code
            };
        }

        public static IEnumerable<ApprovalRequestItemStatusVm> toListApprovalRequestItemStatusVm(this IEnumerable<ApprovalRequestItemStatus> entities)
        {
            var vmlist = new List<ApprovalRequestItemStatusVm>();

            foreach (var entity in entities)
            {
                vmlist.Add(entity.toApprovalRequestItemStatusVm());
            }

            return vmlist;
        }

        public static PatientTypeVm toPatientTypeVm(this PatientType entity)
        {
            return new PatientTypeVm()
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code
            };
        }

        public static IEnumerable<PatientTypeVm> toListPatientTypeVm(this IEnumerable<PatientType> entities)
        {
            var vmlist = new List<PatientTypeVm>();

            foreach (var entity in entities)
            {
                vmlist.Add(entity.toPatientTypeVm());
            }

            return vmlist;
        }

        public static ApprovalRequestDisplayVm toApprovalRequestDisplayVm(this ApprovalRequest entity)
        {
            if (entity != null)
                return new ApprovalRequestDisplayVm()
            {
                Id = entity.Id,
                RequestStatusId = entity.ApprovalRequestStatusId,
                PIN = entity.Patient?.IssueAuthorityCode + "." + entity.Patient?.Registrationno.ToString("0000000000"),
                RequestStatus = entity.ApprovalRequestStatus.Name,
                InsuranceCardNo = entity.InsuranceCardNumber,
                DoctorCode = entity.Doctor.EmpCode,
                CategoryName = entity.Category.Code,
                ProcessBy = entity.ProcessById.HasValue? entity.ProcessBy.Name :null,
                RequestDate = entity.CreatedDate
            };


            return new ApprovalRequestDisplayVm();
        }

        public static ApprovalRequestDetailVm toApprovalRequestDetailVm(this ApprovalRequest entity)
        {

            if (entity != null)
                return new ApprovalRequestDetailVm()
                {
                    Id = entity.Id,
                    RequestStatusId = entity.ApprovalRequestStatusId,
                    PatientName = entity.Patient.LastName + ", " + entity.Patient.Firstname,
                    PIN = entity.Patient.IssueAuthorityCode + "." + entity.Patient.Registrationno.ToString("0000000000"),
                    RequestStatus = entity.ApprovalRequestStatus.Name,
                    InsuranceCardNo = entity.InsuranceCardNumber,
                    DoctorCode = entity.Doctor.EmpCode,
                    CategoryName = entity.Category.Code,
                    CompanyName = entity.Company.Name,
                    GradeName = entity.Grade.Name,
                    ProcessBy = entity.ProcessById.HasValue ? entity.ProcessBy.Name : null,
                    ProcessById = entity.ProcessById.HasValue ? entity.ProcessBy.Id : 0,
                    RequestDate = entity.CreatedDate,
                    RequestItems = entity.ApprovalItems.toListApprovaDetailRequestItemVM(),
                    ProcessDate = entity.ProcessingDate,
                    DoctorName = entity.Doctor.Name,
                    RequestType = entity.ApprovalRequestType.Name,
                    ClincalData = entity.ClinicalData
                };


            return new ApprovalRequestDetailVm();
        }

        public static IEnumerable<ApprovalRequestDisplayVm> toListApprovalRequestDisplayVm(this IEnumerable<ApprovalRequest> entities)
        {
            var vmlist = new List<ApprovalRequestDisplayVm>();

            foreach (var entity in entities)
            {
                vmlist.Add(entity.toApprovalRequestDisplayVm());
            }

            return vmlist;
        }

        public static CategoryVm toCategoryVm(this Category entity)
        {
            return new CategoryVm()
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code
            };
        }

        public static IEnumerable<CategoryVm> toListCategoryVm(this IEnumerable<Category> entities)
        {
            var vmlist = new List<CategoryVm>();

            foreach (var entity in entities)
            {
                vmlist.Add(entity.toCategoryVm());
            }

            return vmlist;
        }

        public static ApprovaDetailRequestItemVM toApprovaDetailRequestItemVM(this ApprovalRequestItem entity)
        {
            return new ApprovaDetailRequestItemVM()
            {
                RequestId = entity.ApprovalRequestId,
                RequestItemId = entity.Id,
                ItemRequestStatusId = entity.ApprovalRequestItemStatusId,
                RequestedQuantity = entity.RequestedQuantity,
                ApprovedQuantity = entity.ApprovedQuantity,
                RequestedAmount = entity.RequestedAmount,
                ApprovedAmount = entity.ApprovedAmount,
                Remarks = entity.Remarks,
                ItemName = entity.ItemName,
                ItemRequestStatus = entity.ApprovalRequestItemStatus.Name,
                ApprovalNo = entity.ApprovalNumber,
                UnitName = entity.Unit?.Name,
                ItemId = entity.ItemId,
                UnitId = entity.UnitId,
                ServiceId = entity.ServiceId.Value

            };
        }

        public static IEnumerable<ApprovaDetailRequestItemVM> toListApprovaDetailRequestItemVM(this IEnumerable<ApprovalRequestItem> entities)
        {
            var vmlist = new List<ApprovaDetailRequestItemVM>();

            foreach (var entity in entities)
            {
                vmlist.Add(entity.toApprovaDetailRequestItemVM());
            }

            return vmlist;
        }

        public static EmployeeVm toEmployeeVM(this Employee entity)
        {
            if(entity != null) { 
                return new EmployeeVm()
                {
                   Id = entity.Id,
                   EmployeeNo = entity.EmployeeId,
                   Name = entity.Name,
                   Code = entity.EmpCode
                };
            }

            return new EmployeeVm();
        }

        public static IEnumerable<EmployeeVm> toListEmployeeVM(this IEnumerable<Employee> entities)
        {
            var vmlist = new List<EmployeeVm>();

            foreach (var entity in entities)
            {
                vmlist.Add(entity.toEmployeeVM());
            }

            return vmlist;
        }

        public static ApprovalRequestReleaseVm toApprovalRequestReleaseVm(this ApprovalRequest entity)
        {
            return new ApprovalRequestReleaseVm()
            {
                Id = entity.Id,
                RequestStatusId = entity.ApprovalRequestStatusId,
                PatientName = entity.Patient.LastName + ", " + entity.Patient.Firstname,
                PIN = entity.Patient.IssueAuthorityCode + "." + entity.Patient.Registrationno.ToString("0000000000"),
                RequestStatus = entity.ApprovalRequestStatus.Name,
                InsuranceCardNo = entity.InsuranceCardNumber,
                DoctorCode = entity.Doctor.EmpCode,
                CategoryName = entity.Category.Code,
                CompanyName = entity.Company.Name,
                GradeName = entity.Grade.Name,
                ProcessBy = entity.ProcessById.HasValue ? entity.ProcessBy.Name : null,
                ProcessById = entity.ProcessById.HasValue ? entity.ProcessBy.Id : 0,
                RequestDate = entity.CreatedDate,
                ProcessDate = entity.ProcessingDate,
                DoctorName = entity.Doctor.Name,
                RequestType = entity.ApprovalRequestType.Name,


            };
        }

        public static StationVm toStationVm(this Station entity)
        {
            if (entity != null)
            {
                return new StationVm()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Code = entity.Code
                };
            }

            return new StationVm();
        }

        public static IEnumerable<StationVm> toListStationVm(this IEnumerable<Station> entities)
        {
            var vmlist = new List<StationVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toStationVm());
            }

            return vmlist;
        }

        public static List<RPTReleaseProcessVm> toRPTReleaseProcessVm(this IEnumerable<ApprovalRequestProcessRelease> entities)
        {
            var vmlist = new List<RPTReleaseProcessVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(
                    new RPTReleaseProcessVm() {
                        ReferenceNo = entity.ApprovalRequestId.ToString(),
                        PIN = entity.ApprovalRequest.IssueAuthorityCode + "."+ entity.ApprovalRequest.Registrationno.ToString("0000000000"),
                        ReleaseDate = entity.ReleaseDate.ToString("dd/MM/yyyy"),
                        Releaseby =  CultureInfo.CurrentCulture.TextInfo.ToTitleCase(entity.ReleasedByEmployee.Name.ToLower()),
                        ProcessOwner = entity.CurrentProcessOwner!= null? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(entity.CurrentProcessOwner.Name.ToLower()):"",
                        TransferTo = entity.AssignToEmployee != null ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(entity.AssignToEmployee.Name.ToLower()):"",
                        Remarks = entity.Remarks
                    });
            }

            return vmlist;
        }

        public static InpatientVm toInpatientVm(this Inpatient entity)
        {
            if (entity != null)
            {
                return new InpatientVm()
                {
                    IPId = entity.Ipid,
                    RegistrationNo = entity.RegistrationNo,
                    PIN = entity.PIN,
                    Name = entity.Name,
                    CategoryId = entity.CategoryId,
                    CompanyId = entity.CompanyId,
                    GradeId = entity.GradeId.Value,
                    DoctorId = entity.DoctorId,
                    BedTypeId = entity.BedTypeId
                };
            }
            else
                return new InpatientVm();
        }

        public static List<InpatientVm> toListInpatientVm(this IEnumerable<Inpatient> entities)
        {
            var vmlist = new List<InpatientVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toInpatientVm());
                   
            }
            return vmlist;
        }

        public static InpatientVm toInpatientVm(this OldInpatient entity)
        {
            if (entity != null)
            {
                return new InpatientVm()
                {
                    IPId = entity.Ipid,
                    RegistrationNo = entity.RegistrationNo,
                    PIN = entity.PIN,
                    Name = entity.Name,
                    CategoryId = entity.CategoryId,
                    CompanyId = entity.CompanyId,
                    GradeId = entity.GradeId.Value,
                    DoctorId = entity.DoctorId.Value,
                    InsuranceCardNo = entity.MedIdnumber,
                    ContactNo = entity.Pcellno + "/"+entity.Pphone,
                    BedTypeId = entity.BedTypeId
                };
            }
            else
                return new InpatientVm();
        }

        public static List<InpatientVm> toListInpatientVm(this IEnumerable<OldInpatient> entities)
        {
            var vmlist = new List<InpatientVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toInpatientVm());

            }
            return vmlist;
        }

        public static PatientVm toPatientVm(this Patient entity)
        {
            if (entity != null)
            {
                return new PatientVm()
                {
                    RegistrationNo = entity.Registrationno,
                    PIN = entity.PIN,
                    Name = entity.Name,
                    CategoryId = entity.CategoryId.Value,
                    CompanyId = entity.CompanyId.Value,
                    GradeId = entity.GradeId.Value,
                    DoctorId = entity.DoctorId.Value,
                    InsuranceCardNo = entity.MedIdnumber,
                    ContactNo = entity.Pcellno + (string.IsNullOrEmpty(entity.Pcellno)? " ": " / ") + entity.Pphone,
                    Age = entity.Age,
                    AgeType = entity.Agetype,
                    Sex = entity.Sex

                };
            }
            else
                return new PatientVm();
        }

        public static List<PatientVm> toListPatientVm(this IEnumerable<Patient> entities)
        {
            var vmlist = new List<PatientVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toPatientVm());

            }
            return vmlist;
        }


        public static ServiceItemVm toServiceItemVm(this BBOtherProcedures entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Code +" "+ entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<BBOtherProcedures> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }

        public static ServiceItemVm toServiceItemVm(this Component entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Code + " " + entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<Component> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }

        public static ServiceItemVm toServiceItemVm(this CathProcedure entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Code + " " + entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<CathProcedure> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }


        public static ServiceItemVm toServiceItemVm(this Employee entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = entity.EmpCode,
                    Description = entity.EmpCode + " " + entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<Employee> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }

        public static ServiceItemVm toServiceItemVm(this FoodItem entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Code + " " + entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<FoodItem> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }

        public static ServiceItemVm toServiceItemVm(this HealthCheckUp entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Code + " " + entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<HealthCheckUp> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }

        public static ServiceItemVm toServiceItemVm(this Item entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = entity.ItemCode,
                    Description = entity.ItemCode + " " + entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<Item> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }

        public static ServiceItemVm toServiceItemVm(this OtherProcedure entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Code + " " + entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<OtherProcedure> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }

        public static ServiceItemVm toServiceItemVm(this Patient entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Registrationno,
                    Code = entity.IssueAuthorityCode,
                    Description = entity.PIN + " " + entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<Patient> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }

        public static ServiceItemVm toServiceItemVm(this PTProcedure entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Code + " " + entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<PTProcedure> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }

        public static ServiceItemVm toServiceItemVm(this Surgery entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Code + " " + entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<Surgery> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }

        public static ServiceItemVm toServiceItemVm(this Test entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Code + " " + entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<Test> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }

        public static ServiceItemVm toServiceItemVm(this Anaesthesia entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Code + " " + entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<Anaesthesia> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }

        public static ServiceItemVm toServiceItemVm(this BedsideProcedure entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Code + " " + entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<BedsideProcedure> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }

        public static ServiceItemVm toServiceItemVm(this BedType entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Code + " " + entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<BedType> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }

        public static ServiceItemVm toServiceItemVm(this LaundryItem entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Code + " " + entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<LaundryItem> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }

        public static ServiceItemVm toServiceItemVm(this MiscItem entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Code + " " + entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<MiscItem> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }

        public static ServiceItemVm toServiceItemVm(this OTNo entity)
        {
            if (entity != null)
            {
                return new ServiceItemVm()
                {
                    Id = entity.Id,
                    Code = "",
                    Description = entity.Name,
                    Name = entity.Name
                };
            }
            else
                return new ServiceItemVm();
        }

        public static List<ServiceItemVm> toListServiceItemVm(this IEnumerable<OTNo> entities)
        {
            var vmlist = new List<ServiceItemVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toServiceItemVm());

            }
            return vmlist;
        }


        public static CompanyVm toCompanyVm(this Company entity)
        {
            if (entity != null)
            {
                return new CompanyVm()
                {
                    Id = entity.Id,
                    Code =entity.Code,
                    Name = entity.Name,
                    TariffId = entity.TariffId.Value
                };
            }
            else
                return new CompanyVm();
        }

        public static List<CompanyVm> toListCompanyVm(this IEnumerable<Company> entities)
        {
            var vmlist = new List<CompanyVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toCompanyVm());

            }
            return vmlist;
        }



        public static GradeVm toGradeVm(this Grade entity)
        {
            if (entity != null)
            {
                return new GradeVm()
                {
                    Id = entity.Id,
                    Code = "",
                    Name = entity.Name
                };
            }
            else
                return new GradeVm();
        }

        public static List<GradeVm> toListGradeVm(this IEnumerable<Grade> entities)
        {
            var vmlist = new List<GradeVm>();

            foreach (var entity in entities.ToList())
            {
                vmlist.Add(entity.toGradeVm());

            }
            return vmlist;
        }
    }
}
