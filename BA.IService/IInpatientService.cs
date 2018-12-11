using BA.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BA.IService
{
    public interface IInpatientService
    {
        Inpatient GetCurrentInPatientByRegno(int regno);
        OldInpatient GetOldInPatientByRegno(int regno);

        Inpatient GetCurrentInPatientByIpId(int ipid);
        OldInpatient GetOldInPatientByIpId(int ipid);

        IEnumerable<Inpatient> SearchCurrentInPatient(string term, int take);
        IEnumerable<OldInpatient> SearchOldInPatient(string term, int take);
        IEnumerable<Inpatient> GetAllCurrentInpatients();
        IEnumerable<OldInpatient> GetAllOldInpatients();

        

    }
}
