using BA.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BA.IService
{
    public interface IMasterFileService
    {
        ApprovalRequestItemStatus GetApprovalRequestItemStatusById(int id);
        IEnumerable<ApprovalRequestItemStatus> GetApprovalRequestItemStatus();
        void AddApprovalRequestItemStatus(ApprovalRequestItemStatus requestItemStatus);
        void UpdateApprovalRequestItemStatus(ApprovalRequestItemStatus requestItemStatus);
        void DeleteApprovalRequestItemStatus(int id, int employeeId);

        ApprovalRequestStatus GetApprovalRequestStatusById(int id);
        IEnumerable<ApprovalRequestStatus> GetApprovalRequestStatus();
        void AddApprovalRequestStatus(ApprovalRequestStatus requestStatus);
        void UpdateApprovalRequestStatus(ApprovalRequestStatus requestStatus);
        void DeleteApprovalRequestStatus(int id, int employeeId);

        ApprovalRequestType GetApprovalRequestTypeById(int id);
        IEnumerable<ApprovalRequestType> GetApprovalRequestType();
        void AddApprovalRequestType(ApprovalRequestType requesttype);
        void UpdateApprovalRequestType(ApprovalRequestType requesttype);
        void DeleteApprovalRequestType(int id, int employeeId);

        PatientType GetPatientTypeById(int id);
        IEnumerable<PatientType> GetPatientType();
        void AddPatientType(PatientType patientType);
        void UpdatePatientType(PatientType patientType);
        void DeletePatientType(int id, int employeeId);

        Patient GetPatientByRegistrationNo(int registrationNo);
        IEnumerable<Patient> GetPatients(string term, int take);
        IEnumerable<Patient> GetPatients();
        IEnumerable<Patient> PagedSearchPatients(string term, int pagesize, int page, out int totalrecord);
        IEnumerable<Patient> PagedSearchPatientsByRegistrationNo(string term, int pagesize, int page, out int totalrecord);
        
        Category GetCategoryById(int id);
        IEnumerable<Category> SearchCategories(string term, int take);
        IEnumerable<Category> GetCategories();
        IEnumerable<Category> PagedSearchCategories(string term, int pagesize, int page, out int totalrecord);

        Employee GetEmployeeById(int id);
        IEnumerable<Employee> SearchEmployee(string term, int take);
        IEnumerable<Employee> PagedSearchEmployee(string term, int pagesize, int page, out int totalrecord);
        IEnumerable<Employee> PagedSearchDoctors(string term, int pagesize, int page, out int totalrecord);
        IEnumerable<Employee> GetEmployees();

        Station GetStationById(int id);
        IEnumerable<Station> SearchStation(string term, int take);
        IEnumerable<Station> PagedSearchStation(string term, int pagesize, int page, out int totalrecord);
        IEnumerable<Station> GetStations();

        OrganisationDetail GetOrganisationDetailById(int id);

        BBOtherProcedures GetBbotherProceduresById(int id);
        IEnumerable<BBOtherProcedures> GetBbotherProcedures();
        IEnumerable<BBOtherProcedures> PagedSearchBBOtherProcedures(string term, int pagesize, int page, out int totalrecord);

        CathProcedure GetCathProcedureById(int id);
        IEnumerable<CathProcedure> GetCathProcedures();
        IEnumerable<CathProcedure> PagedSearchCathProcedures(string term, int pagesize, int page, out int totalrecord);

        Component GetComponentById(int id);
        IEnumerable<Component> GetComponents();
        IEnumerable<Component> PagedSearchComponent(string term, int pagesize, int page, out int totalrecord);
        IEnumerable<Component> PagedSearchBloodComponent(string term, int pagesize, int page, out int totalrecord);
        IEnumerable<Component> PagedSearchBloodCrossMatchComponent(string term, int pagesize, int page, out int totalrecord);
        IEnumerable<Component> PagedSearchBloodDonationMasterComponent(string term, int pagesize, int page, out int totalrecord);
        IEnumerable<Component> PagedSearchBloodIssueMasterComponent(string term, int pagesize, int page, out int totalrecord);

        HealthCheckUp GetHealthCheckUpById(int id);
        IEnumerable<HealthCheckUp> GetHealthCheckUps();
        IEnumerable<HealthCheckUp> PagedSearchHealthCheckUps(string term, int pagesize, int page, out int totalrecord);

        Item GetItemById(int id);
        IEnumerable<Item> GetItems();
        IEnumerable<Item> PagedSearchItems(string term, int pagesize, int page, out int totalrecord);
        IEnumerable<Item> PagedSearchCSSItems(string term, int pagesize, int page, out int totalrecord);
        IEnumerable<Item> PagedSearchAssetItemsIP(string term, int pagesize, int page, out int totalrecord);

        OtherProcedure GetOtherProcedureById(int id);
        IEnumerable<OtherProcedure> GetOtherProcedures();
        IEnumerable<OtherProcedure> PagedSearchOtherProcedures(string term, int pagesize, int page, out int totalrecord);

        PTProcedure GetPTProcedureById(int id);
        IEnumerable<PTProcedure> GetPTProcedures();
        IEnumerable<PTProcedure> PagedSearchPTProcedures(string term, int pagesize, int page, out int totalrecord);

        Surgery GetSurgeryById(int id);
        IEnumerable<Surgery> GetSurgeries();
        IEnumerable<Surgery> PagedSearchSurgeries(string term, int pagesize, int page, out int totalrecord);

        Test GetTestById(int id);
        IEnumerable<Test> GetTest();
        IEnumerable<Test> PagedSearchTest(string term, int pagesize, int page, out int totalrecord);

        OPBService GetOPBServiceById(int id);
        IEnumerable<OPBService> GetOPBServices();

        IPBService GetIPBServiceById(int id);
        IEnumerable<IPBService> GetIPBServices();

        Anaesthesia GetAnaesthesiaById(int id);
        IEnumerable<Anaesthesia> GetAnaesthesia();
        IEnumerable<Anaesthesia> PagedSearchAnaesthesia(string term, int pagesize, int page, out int totalrecord);

        AssetControl GetAssetControlById(int id);
        IEnumerable<AssetControl> GetAssetControls();

        Batch GetBatchById(int id);
        IEnumerable<Batch> GetBatch();

        BedsideProcedure GetBedsideProcedureById(int id);
        IEnumerable<BedsideProcedure> GetBedsideProcedure();
        IEnumerable<BedsideProcedure> PagedSearchBedsideProcedures(string term, int pagesize, int page, out int totalrecord);

        BedType GetBedTypeById(int id);
        IEnumerable<BedType> GetBedTypes();
        IEnumerable<BedType> PagedSearchBedType(string term, int pagesize, int page, out int totalrecord);

        BioInstall GetBioInstallById(int id);
        IEnumerable<BioInstall> GetBioInstalls();

        ItemGroup GetItemGroupById(int id);
        IEnumerable<ItemGroup> GetItemGroup();

        LaundryItem GetLaundryItemById(int id);
        IEnumerable<LaundryItem> GetLaundryItems();
        IEnumerable<LaundryItem> PagedSearchLaundryItems(string term, int pagesize, int page, out int totalrecord);

        MiscItem GetMiscItemById(int id);
        IEnumerable<MiscItem> GetMiscItems();
        IEnumerable<MiscItem> PagedSearchMiscItems(string term, int pagesize, int page, out int totalrecord);

        OTNo GetOTNoById(int id);
        IEnumerable<OTNo> GetOTNos();
        IEnumerable<OTNo> PagedSearchOTNos(string term, int pagesize, int page, out int totalrecord);

        FoodItem GetFoodItemById(int id);
        IEnumerable<FoodItem> GetFoodItems();
        IEnumerable<FoodItem> PagedSearchFoodItems(string term, int pagesize, int page, out int totalrecord);

        Company GetCompanyById(int id);
        IEnumerable<Company> GetCompanies();
        IEnumerable<Company> PagedSearchCompanies(string term, int pagesize, int page, out int totalrecord);

        Grade GetGradeById(int id);
        IEnumerable<Grade> GetGrades();
        IEnumerable<Grade> PagedSearchGrades(string term, int pagesize, int page, out int totalrecord);

        ServiceItemPrice GetOPServiceItemPrice(int itemId, int tariffId, string pricetable);
        ServiceItemPrice GetIPServiceItemPrice(int itemId, int tariffId, int bedtypeid, string pricetable);

        Unit GetUnitById(int id);
        IEnumerable<Unit> GetUnits();

    }
}
