using BA.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Interface
{
    public interface IUnitOfWork
    {
        IRepository<AccessUserfeatures> AccessUserfeatures { get; }
        IRepository<Anaesthesia> Anaesthesia { get; }
        IRepository<ApprovalRequest> ApprovalRequest { get; }
        IRepository<ApprovalRequestItem> ApprovalRequestItem { get; }
        IRepository<ApprovalRequestItemStatus> ApprovalRequestItemStatus { get; }
        IRepository<ApprovalRequestProcessRelease> ApprovalRequestProcessRelease { get; }
        IRepository<ApprovalRequestStatus> ApprovalRequestStatus { get; }
        IRepository<ApprovalRequestType> ApprovalRequestType { get; }
        IRepository<AssetControl> AssetControl { get; }
        IRepository<Batch> Batch { get; }
        IRepository<BBOtherProcedures> BBOtherProcedures { get; }
        IRepository<BedsideProcedure> BedsideProcedure { get; }
        IRepository<BedType> BedType { get; }
        IRepository<BioInstall> BioInstall { get; }
        IRepository<Category> Category { get; }
        IRepository<CathProcedure> CathProcedure { get; }
        IRepository<ClinicalOtherOrder> ClinicalOtherOrder { get; }
        IRepository<ClinicalTestOrder> ClinicalTestOrder { get; }
        IRepository<ClinicalVisit> ClinicalVisit { get; }
        IRepository<Company> Company { get; }
        IRepository<Component> Component { get; }
        IRepository<Department> Department { get; }
        IRepository<Employee> Employee { get; }
        IRepository<FoodItem> FoodItem { get; }
        IRepository<Grade> Grade { get; }
        IRepository<HealthCheckUp> HealthCheckUp { get; }
        IRepository<Inpatient> Inpatient { get; }
        IRepository<IPBService> IPBService { get; }
        IRepository<Item> Item { get; }
        IRepository<ItemGroup> ItemGroup { get; }
        IRepository<LaundryItem> LaundryItem { get; }
        IRepository<MenuAccess> MenuAccess { get; }
        IRepository<MenuParent> MenuParent { get; }
        IRepository<MiscItem> MiscItem { get; }
        IRepository<OldInpatient> OldInpatient { get; }
        IRepository<OPBService> OPBService { get; }
        IRepository<OpcompanyBillDetail> OpcompanyBillDetail { get; }
        IRepository<OpDoctorOrder> OpDoctorOrder { get; }
        IRepository<OrganisationDetail> OrganisationDetail { get; }
        IRepository<OtherProcedure> OtherProcedure { get; }
        IRepository<OTNo> OTNo { get; }
        IRepository<Patient> Patient { get; }
        IRepository<PatientType> PatientType { get; }
        IRepository<PTProcedure> PTProcedure { get; }
        IRepository<Station> Station { get; }
        IRepository<Surgery> Surgery { get; }
        IRepository<Tariff> Tariff { get; }
        IRepository<Test> Test { get; }
        IRepository<Unit> Unit { get; }

        IServiceItemPriceRepository ServiceItemPrice { get; }

        void Commit();
        void CommitAssync();
        void RejectChanges();
        void Dispose();

    }
}
