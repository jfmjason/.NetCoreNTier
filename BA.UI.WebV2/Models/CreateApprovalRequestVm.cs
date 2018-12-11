using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.UI.WebV2.Models
{
    public class CreateApprovalRequestVm
    {
        public int RequestTypeId { get; set; }
        public int? AuthorityId { get; set; }
        public int? IPId { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public int GradeId { get; set; }
        public int DoctorId { get; set; }
        public int PatientTypeId { get; set; }
        public int Registrationno { get; set; }
        public int TariffId { get; set; }
        public int StationId { get; set; }

        public string InsuranceCardNumber { get; set; }
        public string ContactNumber { get; set; }
        public string ClinicalData { get; set; }

        public List<CreateApprovalRequestItemVm> Items { get; set; }

    }
}
