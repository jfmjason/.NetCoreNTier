
using BA.Core.Entity;
using BA.Infra.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BA.Infra.Data
{
    public sealed class BADbContext : DbContext
    {
        public BADbContext(DbContextOptions<BADbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<AccessUserfeatures> AccessUserfeatures { get; set; }
        public DbSet<Anaesthesia> Anaesthesia { get; set; }
        public DbSet<ApprovalRequestProcessRelease> ApprovalRequestProcessRelease { get; set; }
        public DbSet<ApprovalRequest> ApprovalRequest { get; set; }
        public DbSet<ApprovalRequestItem> ApprovalRequestedItem { get; set; }
        public DbSet<ApprovalRequestItemStatus> ApprovalRequestItemStatus { get; set; }
        public DbSet<ApprovalRequestStatus> ApprovalRequestStatus { get; set; }
        public DbSet<ApprovalRequestType> ApprovalRequestType { get; set; }
        public DbSet<AssetControl> AssetControl { get; set; }
        public DbSet<Batch> Batch { get; set; }
        public DbSet<BBOtherProcedures> BBOtherProcedures { get; set; }
        public DbSet<BedsideProcedure> BedsideProcedure { get; set; }
        public DbSet<BedType> BedType { get; set; }
        public DbSet<BioInstall> BioInstall { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CathProcedure> CathProcedure { get; set; }
        public DbSet<ClinicalOtherOrder> ClinicalOtherOrder { get; set; }
        public DbSet<ClinicalTestOrder> ClinicalTestOrder { get; set; }
        public DbSet<ClinicalVisit> ClinicalVisit { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Component> Component { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<FoodItem> FoodItem { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<HealthCheckUp> HealthCheckUp { get; set; }
        public DbSet<Inpatient> Inpatient { get; set; }
        public DbSet<IPBService> IPBService { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemGroup> ItemGroup { get; set; }
        public DbSet<LaundryItem> LaundryItem { get; set; }
        public DbSet<MenuAccess> MenuAccess { get; set; }
        public DbSet<MenuParent> MenuParent { get; set; }
        public DbSet<MiscItem> MiscItem { get; set; }
        public DbSet<OldInpatient> OldInpatient { get; set; }
        public DbSet<OPBService> OPBService { get; set; }
        public DbSet<OpcompanyBillDetail> OpcompanyBillDetail { get; set; }
        public DbSet<OpDoctorOrder> OpdoctorOrder { get; set; }
        public DbSet<OrganisationDetail> OrganisationDetails { get; set; }
        public DbSet<OtherProcedure> OtherProcedures { get; set; }
        public DbSet<OTNo> OTNo { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<PatientType> PatientType { get; set; }
        public DbSet<PTProcedure> PTProcedure { get; set; }
        public DbSet<Station> Station { get; set; }
        public DbSet<Surgery> Surgery { get; set; }
        public DbSet<Tariff> Tariff { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Unit> Unit { get; set; }

        public DbQuery<ServiceItemPrice> ServiceItemPrice { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema(DatabaseSchema.DBO);

            builder.ApplyConfiguration(new ApprovalRequestEntityConfiguration());
            builder.ApplyConfiguration(new ApprovalRequestItemEntityConfiguration());
            builder.ApplyConfiguration(new ApprovalRequestProcessReleaseEntityConfiguration());
            builder.ApplyConfiguration(new CategoryEntityConfiguration());
            builder.ApplyConfiguration(new CompanyEntityConfiguration());
            builder.ApplyConfiguration(new DepartmentEntityConfiguration());
            builder.ApplyConfiguration(new EmployeeEntityConfiguration());
            builder.ApplyConfiguration(new GradeEntityConfiguration());
            builder.ApplyConfiguration(new IPBServiceEntityConfiguration());
            builder.ApplyConfiguration(new OPBServiceEntityConfiguration());
            builder.ApplyConfiguration(new OrganisationDetailsEntityConfiguration());
            builder.ApplyConfiguration(new PatientEntityConfiguration());
            builder.ApplyConfiguration(new StationEntityConfiguration());
            builder.ApplyConfiguration(new TariffEntityConfiguration());
            builder.ApplyConfiguration(new MenuAccessEntityConfiguration());
            builder.ApplyConfiguration(new MenuParentEntityConfiguration());
            builder.ApplyConfiguration(new AccessUserfeaturesEntityConfiguration());
            builder.ApplyConfiguration(new InpatientEntityConfiguration());
            builder.ApplyConfiguration(new OldInpatientEntityConfiguration());
            builder.ApplyConfiguration(new BBOtherProceduresEntityConfiguration());
            builder.ApplyConfiguration(new CathProcedureEntityConfiguration());
            builder.ApplyConfiguration(new CompanyEntityConfiguration());
            builder.ApplyConfiguration(new FoodItemEntityConfiguration());
            builder.ApplyConfiguration(new HealthCheckUpEntityConfiguration());
            builder.ApplyConfiguration(new ItemEntityConfiguration());
            builder.ApplyConfiguration(new OtherProceduresEntityConfiguration());
            builder.ApplyConfiguration(new PTProcedureEntityConfiguration());
            builder.ApplyConfiguration(new SurgeryEntityConfiguration());
            builder.ApplyConfiguration(new TestEntityConfiguration());
            builder.ApplyConfiguration(new AnaesthesiaEntityConfiguration());
            builder.ApplyConfiguration(new BatchEntityConfiguration());
            builder.ApplyConfiguration(new BedsideProcedureConfiguration());
            builder.ApplyConfiguration(new BedTypeEntityConfiguration());
            builder.ApplyConfiguration(new BioInstallEntityConfiguration());
            builder.ApplyConfiguration(new ItemGroupEntityConfiguration());
            builder.ApplyConfiguration(new LaundryItemEntityConfiguration());
            builder.ApplyConfiguration(new MiscItemEntityConfiguration());
            builder.ApplyConfiguration(new OTNoEntityConfiguration());
            builder.ApplyConfiguration(new ClinicalOtherOrderEntityConfiguration());
            builder.ApplyConfiguration(new ClinicalTestOrderEntityConfiguration());
            builder.ApplyConfiguration(new ClinicalVisitEntityConfiguration ());
            builder.ApplyConfiguration(new OpcompanyBillDetailEntityConfiguration());
            builder.ApplyConfiguration(new OpdoctorOrderEntityConfiguration());
            builder.ApplyConfiguration(new UnitEntityConfiguration());
        }

    }
}
