using BA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using BA.Core.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BA.Infra.Data.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BADbContext _dbContext;

        #region [Repositories]
        //DbSet
        public IRepository<AccessUserfeatures> AccessUserfeatures => new Repository<AccessUserfeatures>(_dbContext);
        public IRepository<Anaesthesia> Anaesthesia => new Repository<Anaesthesia>(_dbContext);
        public IRepository<ApprovalRequest> ApprovalRequest => new Repository<ApprovalRequest>(_dbContext);
        public IRepository<ApprovalRequestItem> ApprovalRequestItem => new Repository<ApprovalRequestItem>(_dbContext);
        public IRepository<ApprovalRequestItemStatus> ApprovalRequestItemStatus => new Repository<ApprovalRequestItemStatus>(_dbContext);
        public IRepository<ApprovalRequestProcessRelease> ApprovalRequestProcessRelease => new Repository<ApprovalRequestProcessRelease>(_dbContext);
        public IRepository<ApprovalRequestStatus> ApprovalRequestStatus => new Repository<ApprovalRequestStatus>(_dbContext);
        public IRepository<ApprovalRequestType> ApprovalRequestType => new Repository<ApprovalRequestType>(_dbContext);
        public IRepository<AssetControl> AssetControl => new Repository<AssetControl>(_dbContext);
        public IRepository<Batch> Batch => new Repository<Batch>(_dbContext);
        public IRepository<BBOtherProcedures> BBOtherProcedures => new Repository<BBOtherProcedures>(_dbContext);
        public IRepository<BedsideProcedure> BedsideProcedure => new Repository<BedsideProcedure>(_dbContext);
        public IRepository<BedType> BedType => new Repository<BedType>(_dbContext);
        public IRepository<BioInstall> BioInstall => new Repository<BioInstall>(_dbContext);
        public IRepository<Category> Category => new Repository<Category>(_dbContext);
        public IRepository<CathProcedure> CathProcedure => new Repository<CathProcedure>(_dbContext);
        public IRepository<ClinicalOtherOrder> ClinicalOtherOrder => new Repository<ClinicalOtherOrder>(_dbContext);
        public IRepository<ClinicalTestOrder> ClinicalTestOrder => new Repository<ClinicalTestOrder>(_dbContext);
        public IRepository<ClinicalVisit> ClinicalVisit => new Repository<ClinicalVisit>(_dbContext);
        public IRepository<Company> Company => new Repository<Company>(_dbContext);
        public IRepository<Component> Component => new Repository<Component>(_dbContext);
        public IRepository<Department> Department => new Repository<Department>(_dbContext);
        public IRepository<Employee> Employee => new Repository<Employee>(_dbContext);
        public IRepository<FoodItem> FoodItem => new Repository<FoodItem>(_dbContext);
        public IRepository<Grade> Grade => new Repository<Grade>(_dbContext);
        public IRepository<HealthCheckUp> HealthCheckUp => new Repository<HealthCheckUp>(_dbContext);
        public IRepository<Inpatient> Inpatient => new Repository<Inpatient>(_dbContext);
        public IRepository<IPBService> IPBService => new Repository<IPBService>(_dbContext);
        public IRepository<Item> Item => new Repository<Item>(_dbContext);
        public IRepository<ItemGroup> ItemGroup => new Repository<ItemGroup>(_dbContext);
        public IRepository<LaundryItem> LaundryItem => new Repository<LaundryItem>(_dbContext);
        public IRepository<MenuAccess> MenuAccess => new Repository<MenuAccess>(_dbContext);
        public IRepository<MenuParent> MenuParent => new Repository<MenuParent>(_dbContext);
        public IRepository<MiscItem> MiscItem => new Repository<MiscItem>(_dbContext);
        public IRepository<OldInpatient> OldInpatient => new Repository<OldInpatient>(_dbContext);
        public IRepository<OPBService> OPBService => new Repository<OPBService>(_dbContext);
        public IRepository<OpcompanyBillDetail> OpcompanyBillDetail => new Repository<OpcompanyBillDetail>(_dbContext);
        public IRepository<OpDoctorOrder> OpDoctorOrder => new Repository<OpDoctorOrder>(_dbContext);
        public IRepository<OrganisationDetail> OrganisationDetail => new Repository<OrganisationDetail>(_dbContext);
        public IRepository<OtherProcedure> OtherProcedure => new Repository<OtherProcedure>(_dbContext);
        public IRepository<OTNo> OTNo => new Repository<OTNo>(_dbContext);
        public IRepository<Patient> Patient => new Repository<Patient>(_dbContext);
        public IRepository<PatientType> PatientType => new Repository<PatientType>(_dbContext);
        public IRepository<PTProcedure> PTProcedure => new Repository<PTProcedure>(_dbContext);
        public IRepository<Station> Station => new Repository<Station>(_dbContext);
        public IRepository<Surgery> Surgery => new Repository<Surgery>(_dbContext);
        public IRepository<Tariff> Tariff => new Repository<Tariff>(_dbContext);
        public IRepository<Test> Test => new Repository<Test>(_dbContext);
        public IRepository<Unit> Unit => new Repository<Unit>(_dbContext);

        //DbQuery
        public IServiceItemPriceRepository ServiceItemPrice => new ServiceItemPriceRepository(_dbContext);

        #endregion

        public UnitOfWork(BADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void RejectChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries()
               .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        public void CommitAssync()
        {
            _dbContext.SaveChangesAsync();
        }
    }
}
