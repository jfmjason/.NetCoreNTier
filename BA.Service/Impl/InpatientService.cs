using BA.Core.Entity;
using BA.Core.Interface;
using BA.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BA.Service.Impl
{
    public class InpatientService : IInpatientService, IDisposable
    {

        private bool disposed = false;
        private readonly IUnitOfWork _unitOfWork;

        public InpatientService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);

        }

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

        public Inpatient GetCurrentInPatientByRegno(int regno)
        {
            return _unitOfWork.Inpatient.Entities.FirstOrDefault(i => i.RegistrationNo == regno);
        }

        public OldInpatient GetOldInPatientByRegno(int regno)
        {
            return _unitOfWork.OldInpatient.Entities.FirstOrDefault(i => i.RegistrationNo == regno);
        }

        public IEnumerable<Inpatient> SearchCurrentInPatient(string term, int take)
        {
            var query = _unitOfWork.Inpatient.Entities;

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.RegistrationNo.ToString().StartsWith(term.ToLower())
                );
            }

            return query.OrderBy(i => i.RegistrationNo).Take(take);
        }

        public IEnumerable<OldInpatient> SearchOldInPatient(string term, int take)
        {
            var query = _unitOfWork.OldInpatient.Entities;

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(i => i.RegistrationNo.ToString().StartsWith(term.ToLower())
                );
            }

            return query.OrderBy(i => i.RegistrationNo).Take(take);
        }

        public IEnumerable<Inpatient> GetAllCurrentInpatients()
        {
           return _unitOfWork.Inpatient.Entities.ToList().OrderBy(i=>i.RegistrationNo);
        }

        public IEnumerable<OldInpatient> GetAllOldInpatients()
        {
            return _unitOfWork.OldInpatient.Entities.OrderBy(i => i.RegistrationNo); 
        }

        public Inpatient GetCurrentInPatientByIpId(int ipid)
        {
            return _unitOfWork.Inpatient.Entities.FirstOrDefault(i => i.Ipid == ipid);
        }

        public OldInpatient GetOldInPatientByIpId(int ipid)
        {
            return _unitOfWork.OldInpatient.Entities.FirstOrDefault(i => i.Ipid == ipid);
        }
    }
}
