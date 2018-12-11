using BA.Core.Entity;
using BA.Core.Interface;
using BA.IService;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BA.Service.Impl
{
    public class MasterFileService : IMasterFileService
    {
        private IUnitOfWork _iUnitOfWork;

        public MasterFileService(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }

        #region[ApprovalRequestItemStatus]
        public IEnumerable<ApprovalRequestItemStatus> GetApprovalRequestItemStatus()
        {
            return _iUnitOfWork.ApprovalRequestItemStatus.Entities.Where(i => i.Active == true);
        }
        public ApprovalRequestItemStatus GetApprovalRequestItemStatusById(int id)
        {
            return _iUnitOfWork.ApprovalRequestItemStatus.Entities.FirstOrDefault(i => i.Active == true);
        }
        public void AddApprovalRequestItemStatus(ApprovalRequestItemStatus requestItemStatus)
        {
            requestItemStatus.Active = true;
            _iUnitOfWork.ApprovalRequestItemStatus.Add(requestItemStatus);
            _iUnitOfWork.Commit();
        }
        public void UpdateApprovalRequestItemStatus(ApprovalRequestItemStatus requestItemStatus)
        {
            var entity = _iUnitOfWork.ApprovalRequestItemStatus.GetById(requestItemStatus.Id);
            entity.Name = requestItemStatus.Name;
            entity.Code = requestItemStatus.Code;
            entity.ModifiedById = requestItemStatus.ModifiedById;
            entity.ModifiedDate = DateTime.Now;

            _iUnitOfWork.ApprovalRequestItemStatus.Update(entity);
            _iUnitOfWork.Commit();
        }
        public void DeleteApprovalRequestItemStatus(int id, int employeeId)
        {
            var entity = _iUnitOfWork.ApprovalRequestItemStatus.GetById(id);

            entity.Active = false;
            entity.ModifiedById = employeeId;
            entity.ModifiedDate = DateTime.Now;

            _iUnitOfWork.ApprovalRequestItemStatus.Update(entity);
            _iUnitOfWork.Commit();
        }
        #endregion

        #region[ApprovalRequestStatus]
        public IEnumerable<ApprovalRequestStatus> GetApprovalRequestStatus()
        {
            return _iUnitOfWork.ApprovalRequestStatus.Entities.Where(i => i.Active == true);
        }
        public ApprovalRequestStatus GetApprovalRequestStatusById(int id)
        {
            return _iUnitOfWork.ApprovalRequestStatus.GetById(id);
        }
        public void AddApprovalRequestStatus(ApprovalRequestStatus requestStatus)
        {
            _iUnitOfWork.ApprovalRequestStatus.Add(requestStatus);
            _iUnitOfWork.Commit();
        }
        public void UpdateApprovalRequestStatus(ApprovalRequestStatus requestStatus)
        {
            var entity = _iUnitOfWork.ApprovalRequestStatus.GetById(requestStatus.Id);
            entity.Name = requestStatus.Name;
            entity.Code = requestStatus.Code;
            entity.ModifiedById = requestStatus.ModifiedById;
            entity.ModifiedDate = DateTime.Now;

            _iUnitOfWork.ApprovalRequestStatus.Update(entity);
            _iUnitOfWork.Commit();
        }
        public void DeleteApprovalRequestStatus(int id, int employeeId)
        {
            var entity = _iUnitOfWork.ApprovalRequestStatus.GetById(id);

            entity.ModifiedById = employeeId;
            entity.ModifiedDate = DateTime.Now;
            entity.Active = false;

            _iUnitOfWork.ApprovalRequestStatus.Update(entity);
            _iUnitOfWork.Commit();
        }
        #endregion

        #region[ApprovalRequestType]
        public IEnumerable<ApprovalRequestType> GetApprovalRequestType()
        {
            return _iUnitOfWork.ApprovalRequestType.Entities.Where(i => i.Active == true);
        }
        public ApprovalRequestType GetApprovalRequestTypeById(int id)
        {
            return _iUnitOfWork.ApprovalRequestType.GetById(id);
        }
        public void AddApprovalRequestType(ApprovalRequestType requesttype)
        {
            requesttype.Active = true;
            _iUnitOfWork.ApprovalRequestType.Add(requesttype);
            _iUnitOfWork.Commit();
        }
        public void UpdateApprovalRequestType(ApprovalRequestType requesttype)
        {
            var entity = _iUnitOfWork.ApprovalRequestType.GetById(requesttype.Id);
            entity.Name = requesttype.Name;
            entity.Code = requesttype.Code;
            entity.ModifiedById = requesttype.ModifiedById;
            entity.ModifiedDate = DateTime.Now;

            _iUnitOfWork.ApprovalRequestType.Update(entity);
            _iUnitOfWork.Commit();
        }
        public void DeleteApprovalRequestType(int id, int employeeId)
        {
            var entity = _iUnitOfWork.ApprovalRequestType.GetById(id);

            entity.Active = false;
            entity.ModifiedById = employeeId;
            entity.ModifiedDate = DateTime.Now;

            _iUnitOfWork.ApprovalRequestType.Update(entity);
            _iUnitOfWork.Commit();
        }
        #endregion

        #region[Patient]
        public Patient GetPatientByRegistrationNo(int registrationNo)
        {
            return _iUnitOfWork.Patient.Entities.FirstOrDefault(i => i.Registrationno == registrationNo);
        }
        public IEnumerable<Patient> GetPatients(string term, int take)
        {
            var query = _iUnitOfWork.Patient.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query.Where(i => i.Registrationno.ToString().StartsWith(term)
                          || (i.FamilyName + " " + i.Firstname + " " + i.LastName + " " + i.MiddleName).ToLower().Contains(term.ToLower()));
            }

            return query.Take(take);
        }
        public IEnumerable<Patient> GetPatients()
        {
            return _iUnitOfWork.Patient.Entities.Where(i => i.Deleted == false);
        }
        public IEnumerable<Patient> PagedSearchPatients(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Patient.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => (i.Firstname + " " + i.MiddleName + " " + i.LastName).ToLower().Contains(term.ToLower())
                || i.Registrationno.ToString().ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Registrationno).Skip((page - 1) * pagesize).Take(pagesize);
        }

        public IEnumerable<Patient> PagedSearchPatientsByRegistrationNo(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Patient.Entities;

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Registrationno.ToString().ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.Where(i => i.Deleted == false).OrderBy(i => i.Registrationno).Skip((page - 1) * pagesize).Take(pagesize);
        }
        #endregion

        #region[PatientType]
        public PatientType GetPatientTypeById(int id)
        {
            return _iUnitOfWork.PatientType.GetById(id);
        }

        public IEnumerable<PatientType> GetPatientType()
        {
            return _iUnitOfWork.PatientType.Entities.Where(i => i.Active == true);
        }

        public void AddPatientType(PatientType patientType)
        {
            _iUnitOfWork.PatientType.Add(patientType);
            _iUnitOfWork.Commit();
        }

        public void UpdatePatientType(PatientType patientType)
        {
            var entity = GetPatientTypeById(patientType.Id);

            entity.ModifiedById = patientType.ModifiedById;
            entity.ModifiedDate = patientType.ModifiedDate;

            _iUnitOfWork.PatientType.Update(entity);
            _iUnitOfWork.Commit();

        }

        public void DeletePatientType(int id, int employeeId)
        {
            var entity = GetPatientTypeById(id);

            entity.ModifiedById = employeeId;
            entity.ModifiedDate = DateTime.Now;

            _iUnitOfWork.PatientType.Update(entity);
            _iUnitOfWork.Commit();
        }
        #endregion

        #region[Category]
        public Category GetCategoryById(int id)
        {
            return _iUnitOfWork.Category.GetById(id);
        }

        public IEnumerable<Category> SearchCategories(string term, int take)
        {
            var query = _iUnitOfWork.Category.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower()));
            }

            return query.OrderBy(i => i.Name).Take(take);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _iUnitOfWork.Category.Entities.Where(i => i.Deleted == false);
        }

        public IEnumerable<Category> PagedSearchCategories(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Category.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLowerInvariant().Contains(term.ToLower()) );
            }

            totalrecord = query.Count();

            return query.OrderBy(i => i.Name).Skip((page - 1) * pagesize).Take(pagesize);
        }
        #endregion

        #region[Employee]
        public Employee GetEmployeeById(int id)
        {
            return _iUnitOfWork.Employee.GetById(id);
        }

        public IEnumerable<Employee> SearchEmployee(string term, int take)
        {
            var query = _iUnitOfWork.Employee.Entities.Where(i => i.Deleted == 0);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.EmployeeId.ToString().StartsWith(term.ToLower())
                );
            }

            return query.OrderBy(i => i.EmployeeId).Take(take);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _iUnitOfWork.Employee.Entities.Where(i => i.Deleted == 0);
        }

        public IEnumerable<Employee> PagedSearchEmployee(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Employee.Entities.Where(i => i.Deleted == 0);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.EmployeeId.ToString().StartsWith(term.ToLower())
                );
            }

            totalrecord = query.Count();

            return query.OrderBy(i => i.EmployeeId).Skip((page - 1) * pagesize).Take(pagesize);

        }

        public IEnumerable<Employee> PagedSearchDoctors(string term, int pagesize, int page, out int totalrecord)
        {
            var doctorcategories = new[] { 1, 2, 4, 27, 28 };
            var excludedempcode = new[] { "/PDS1", "AC01", "AC02", "AD001", "ARAM", "BUPA", "DR01", "DR02", "DR02A" };

            var query = _iUnitOfWork.Employee.Entities.Where(i => i.Deleted == 0);
            query = query.Where(i => (doctorcategories.Contains(i.CategoryId != null ? i.CategoryId.Value : 0) && i.EmpCode.Length >= 4 && !excludedempcode.Contains(i.EmpCode))
            || i.EmpCode == "KT01"
            );

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.EmpCode.ToLower().StartsWith(term.ToLower())
                 || i.Name.ToLower().Contains(term.ToLower())
                );
            }

            totalrecord = query.Count();

            return query.OrderBy(i => i.EmpCode.Trim()).Skip((page - 1) * pagesize).Take(pagesize);
        }
        #endregion

        #region[Station]
        public Station GetStationById(int id)
        {
            return _iUnitOfWork.Station.GetById(id);
        }

        public IEnumerable<Station> SearchStation(string term, int take)
        {
            var query = _iUnitOfWork.Station.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToString().Contains(term.ToLower())
                );
            }

            return query.OrderBy(i => i.Code).Take(take);
        }

        public IEnumerable<Station> PagedSearchStation(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Station.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower()));
            }

            totalrecord = query.Count();

            return query.OrderBy(i => i.Name).Skip((page - 1) * pagesize).Take(pagesize);
        }

        public IEnumerable<Station> GetStations()
        {
            return _iUnitOfWork.Station.Entities.Where(i => i.Deleted == false);
        }
        #endregion

        #region[OrganisationDetail]
        public OrganisationDetail GetOrganisationDetailById(int id)
        {
            return _iUnitOfWork.OrganisationDetail.GetById(1);
        }
        #endregion

        #region[BbotherProcedures]
        public BBOtherProcedures GetBbotherProceduresById(int id)
        {
            return _iUnitOfWork.BBOtherProcedures.GetById(id);
        }

        public IEnumerable<BBOtherProcedures> GetBbotherProcedures()
        {
            return _iUnitOfWork.BBOtherProcedures.Entities;
        }

        public IEnumerable<BBOtherProcedures> PagedSearchBBOtherProcedures(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.BBOtherProcedures.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }
        #endregion

        #region[CathProcedure]
        public CathProcedure GetCathProcedureById(int id)
        {
            return _iUnitOfWork.CathProcedure.GetById(id);
        }

        public IEnumerable<CathProcedure> GetCathProcedures()
        {
            return _iUnitOfWork.CathProcedure.Entities;
        }


        public IEnumerable<CathProcedure> PagedSearchCathProcedures(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.CathProcedure.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }
        #endregion

        #region[Component]
        public Component GetComponentById(int id)
        {
            return _iUnitOfWork.Component.GetById(id);
        }

        public IEnumerable<Component> GetComponents()
        {
            return _iUnitOfWork.Component.Entities;
        }

        public IEnumerable<Component> PagedSearchComponent(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Component.Entities.Where(i => i.Deleted == false );

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }

        public IEnumerable<Component> PagedSearchBloodComponent(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Component.Entities.Where(i => i.Deleted == false && i.Type != 1);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }

        public IEnumerable<Component> PagedSearchBloodCrossMatchComponent(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Component.Entities.Where(i => i.Deleted == false && i.Type == 1);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }

        public IEnumerable<Component> PagedSearchBloodDonationMasterComponent(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Component.Entities.Where(i => i.Deleted == false && ((i.Type == 1 && i.DefaultType == true) || i.Type == 3));

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }

        public IEnumerable<Component> PagedSearchBloodIssueMasterComponent(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Component.Entities.Where(i => i.Deleted == false && i.Type == 1);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }

        #endregion

        #region[HealthCheckUp]
        public HealthCheckUp GetHealthCheckUpById(int id)
        {
            return _iUnitOfWork.HealthCheckUp.GetById(id);
        }

        public IEnumerable<HealthCheckUp> GetHealthCheckUps()
        {
            return _iUnitOfWork.HealthCheckUp.Entities;
        }

        public IEnumerable<HealthCheckUp> PagedSearchHealthCheckUps(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.HealthCheckUp.Entities.Where(i => i.Deleted == 0);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }
        #endregion

        #region[Item]
        public Item GetItemById(int id)
        {
            return _iUnitOfWork.Item.GetById(id);
        }

        public IEnumerable<Item> GetItems()
        {
            return _iUnitOfWork.Item.Entities;
        }

        public IEnumerable<Item> PagedSearchItems(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Item.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.ItemCode.ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.ItemCode).Skip((page - 1) * pagesize).Take(pagesize);
        }

        public IEnumerable<Item> PagedSearchCSSItems(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Item.Entities.Where(i => i.CategoryId == 7 && i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.ItemCode.ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.ItemCode).Skip((page - 1) * pagesize).Take(pagesize);
        }

        public IEnumerable<Item> PagedSearchAssetItemsIP(string term, int pagesize, int page, out int totalrecord)
        {
            var itemquery = _iUnitOfWork.Item.Entities.Where(i => i.Deleted == false);
            var itemgroupquery = _iUnitOfWork.ItemGroup.Entities.Where(i => i.Deleted == false);
            var batchquery = _iUnitOfWork.Batch.Entities;
            var assetControlquery = _iUnitOfWork.AssetControl.Entities;
            var bioInstallquery = _iUnitOfWork.BioInstall.Entities.Where(i=>i.Deleted == false);
            
            var query = batchquery
                       .Join(itemquery,
                            batch => batch.ItemId,
                            item => item.Id,
                            (batch, item) => new { Batch = batch, Item = item })
                       .Join(itemgroupquery,
                             bi => bi.Item.CategoryId,
                             itemgroup => itemgroup.Id,
                            (bi, itemgroup) => new { bi.Batch, bi.Item, ItemGroup = itemgroup })
                       .Join(assetControlquery,
                            bii => bii.Batch.BatchId,
                            assetctrl => assetctrl.ItemId,
                           (bii, assetctrl) => new { bii.Batch, bii.Item, bii.ItemGroup, AssetControl = assetctrl })
                       .Join(bioInstallquery,
                            biia => biia.AssetControl.ItemId,
                            bioinstall => bioinstall.AssetItemId,
                            (biia, bioinstall) => new { biia.Batch, biia.Item, biia.ItemGroup, biia.AssetControl, BioInstall = bioinstall })
                       .Where(biiab => biiab.ItemGroup.Fixed == 1 && biiab.ItemGroup.Medical == 1 && biiab.ItemGroup.Equipment == 1)
                       .Select(i => i.Item);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.ItemCode.ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.ItemCode).Skip((page - 1) * pagesize).Take(pagesize);
        }
        #endregion

        #region[OtherProcedures]
        public OtherProcedure GetOtherProcedureById(int id)
        {
            return _iUnitOfWork.OtherProcedure.GetById(id);
        }

        public IEnumerable<OtherProcedure> GetOtherProcedures()
        {
            return _iUnitOfWork.OtherProcedure.Entities;
        }

        public IEnumerable<OtherProcedure> PagedSearchOtherProcedures(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.OtherProcedure.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }

        #endregion

        #region[PTProcedure]
        public PTProcedure GetPTProcedureById(int id)
        {
            return _iUnitOfWork.PTProcedure.GetById(id);
        }

        public IEnumerable<PTProcedure> GetPTProcedures()
        {
            return _iUnitOfWork.PTProcedure.Entities;
        }

        public IEnumerable<PTProcedure> PagedSearchPTProcedures(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.PTProcedure.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToString().ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }
        #endregion

        #region[Surgery]
        public Surgery GetSurgeryById(int id)
        {
            return _iUnitOfWork.Surgery.GetById(id);
        }

        public IEnumerable<Surgery> GetSurgeries()
        {
            return _iUnitOfWork.Surgery.Entities;
        }

        public IEnumerable<Surgery> PagedSearchSurgeries(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Surgery.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToString().ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }
        #endregion

        #region[Test]
        public Test GetTestById(int id)
        {
            return _iUnitOfWork.Test.GetById(id);
        }

        public IEnumerable<Test> GetTest()
        {
            return _iUnitOfWork.Test.Entities;
        }

        public IEnumerable<Test> PagedSearchTest(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Test.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToString().ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }
        #endregion

        #region[OPBService]
        public OPBService GetOPBServiceById(int id)
        {
            return _iUnitOfWork.OPBService.GetById(id);
        }

        public IEnumerable<OPBService> GetOPBServices()
        {
            return _iUnitOfWork.OPBService.Entities.Where(i=> i.Deleted == false).ToList().OrderBy(i => i.Name);
        }
        #endregion

        #region[IPBService]
        public IPBService GetIPBServiceById(int id)
        {
            return _iUnitOfWork.IPBService.GetById(id);
        }

        public IEnumerable<IPBService> GetIPBServices()
        {
            return _iUnitOfWork.IPBService.Entities.Where(i => i.Deleted == false).ToList().OrderBy(i=>i.ServiceName);
        }
        #endregion

        #region[Anaesthesia]
        public Anaesthesia GetAnaesthesiaById(int id)
        {
            return _iUnitOfWork.Anaesthesia.GetById(id);
        }

        public IEnumerable<Anaesthesia> GetAnaesthesia()
        {
            return _iUnitOfWork.Anaesthesia.Entities;
        }

        public IEnumerable<Anaesthesia> PagedSearchAnaesthesia(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Anaesthesia.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToString().ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }
        #endregion

        #region[AssetControl]
        public AssetControl GetAssetControlById(int id)
        {
            return _iUnitOfWork.AssetControl.GetById(id);
        }

        public IEnumerable<AssetControl> GetAssetControls()
        {
            return _iUnitOfWork.AssetControl.Entities;
        }
        #endregion

        #region[Batch]
        public Batch GetBatchById(int id)
        {
            return _iUnitOfWork.Batch.GetById(id);
        }

        public IEnumerable<Batch> GetBatch()
        {
            return _iUnitOfWork.Batch.Entities;
        }
        #endregion

        #region[BedsideProcedure]
        public BedsideProcedure GetBedsideProcedureById(int id)
        {
            return _iUnitOfWork.BedsideProcedure.GetById(id);
        }

        public IEnumerable<BedsideProcedure> GetBedsideProcedure()
        {
            return _iUnitOfWork.BedsideProcedure.Entities;
        }

        public IEnumerable<BedsideProcedure> PagedSearchBedsideProcedures(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.BedsideProcedure.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToString().ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }

        #endregion

        #region[BedType]
        public BedType GetBedTypeById(int id)
        {
            return _iUnitOfWork.BedType.GetById(id);
        }

        public IEnumerable<BedType> GetBedTypes()
        {
            return _iUnitOfWork.BedType.Entities;
        }

        public IEnumerable<BedType> PagedSearchBedType(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.BedType.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToString().ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }


        #endregion

        #region[BioInstall]
        public BioInstall GetBioInstallById(int id)
        {
            return _iUnitOfWork.BioInstall.GetById(id);
        }

        public IEnumerable<BioInstall> GetBioInstalls()
        {
            return _iUnitOfWork.BioInstall.Entities;
        }
        #endregion

        #region[ItemGroup]
        public ItemGroup GetItemGroupById(int id)
        {
            return _iUnitOfWork.ItemGroup.GetById(id);
        }

        public IEnumerable<ItemGroup> GetItemGroup()
        {
            return _iUnitOfWork.ItemGroup.Entities;
        }
        #endregion

        #region[LaundryItem]
        public LaundryItem GetLaundryItemById(int id)
        {
            return _iUnitOfWork.LaundryItem.GetById(id);
        }

        public IEnumerable<LaundryItem> GetLaundryItems()
        {
            return _iUnitOfWork.LaundryItem.Entities;
        }

        public IEnumerable<LaundryItem> PagedSearchLaundryItems(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.LaundryItem.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToString().ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }

        #endregion

        #region[MiscItem]
        public MiscItem GetMiscItemById(int id)
        {
            return _iUnitOfWork.MiscItem.GetById(id);
        }

        public IEnumerable<MiscItem> GetMiscItems()
        {
            return _iUnitOfWork.MiscItem.Entities;
        }

        public IEnumerable<MiscItem> PagedSearchMiscItems(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.MiscItem.Entities.Where(i => i.Deleted == 0);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToString().ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }

        #endregion

        #region[OTNo]
        public OTNo GetOTNoById(int id)
        {
            return _iUnitOfWork.OTNo.GetById(id);
        }

        public IEnumerable<OTNo> GetOTNos()
        {
            return _iUnitOfWork.OTNo.Entities;
        }

        public IEnumerable<OTNo> PagedSearchOTNos(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.OTNo.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower()));
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Name).Skip((page - 1) * pagesize).Take(pagesize);
        }
        #endregion

        #region[FoodItem]
        public FoodItem GetFoodItemById(int id)
        {
            return _iUnitOfWork.FoodItem.GetById(id);
        }

        public IEnumerable<FoodItem> GetFoodItems()
        {
            return _iUnitOfWork.FoodItem.Entities;
        }

        public IEnumerable<FoodItem> PagedSearchFoodItems(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.FoodItem.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLower().Contains(term.ToLower())
                || i.Code.ToLower().StartsWith(term.ToLower())
                );
            }
            totalrecord = query.Count();

            return query.OrderBy(i => i.Code).Skip((page - 1) * pagesize).Take(pagesize);
        }
        #endregion

        #region[Company]
        public Company GetCompanyById(int id)
        {
            return _iUnitOfWork.Company.GetById(id);
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _iUnitOfWork.Company.Entities;
        }

        public IEnumerable<Company> PagedSearchCompanies(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Company.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLowerInvariant().Contains(term.ToLower()));
            }

            totalrecord = query.Count();

            return query.OrderBy(i => i.Name).Skip((page - 1) * pagesize).Take(pagesize);
        }
        #endregion

        #region[Grade]
        public Grade GetGradeById(int id)
        {
            return _iUnitOfWork.Grade.GetById(id);
        }

        public IEnumerable<Grade> GetGrades()
        {
            return _iUnitOfWork.Grade.Entities;
        }

        public IEnumerable<Grade> PagedSearchGrades(string term, int pagesize, int page, out int totalrecord)
        {
            var query = _iUnitOfWork.Grade.Entities.Where(i => i.Deleted == false);

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.Name.ToLowerInvariant().Contains(term.ToLower()));
            }

            totalrecord = query.Count();

            return query.OrderBy(i => i.Name).Skip((page - 1) * pagesize).Take(pagesize);
        }
        #endregion

        #region[ServiceItem]
        public ServiceItemPrice GetOPServiceItemPrice(int itemId, int tariffId, string pricetable)
        {
            return _iUnitOfWork.ServiceItemPrice.GetOPServiceItemPrice(itemId,tariffId, pricetable);
        }

        public ServiceItemPrice GetIPServiceItemPrice(int itemId, int tariffId, int bedtypeid, string pricetable)
        {
           return _iUnitOfWork.ServiceItemPrice.GetIPServiceItemPrice(itemId, tariffId, bedtypeid, pricetable);
        }

        #endregion

        #region[Units]

        public Unit GetUnitById(int id)
        {
            return _iUnitOfWork.Unit.GetById(id);
        }

        public IEnumerable<Unit> GetUnits()
        {
            return _iUnitOfWork.Unit.Entities.ToList().OrderBy(i=>i.Name);
        }
        #endregion

    }
}
