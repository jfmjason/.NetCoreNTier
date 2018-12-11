using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.UI.WebV2.Models
{
    public class InpatientVm
    {
        public int RegistrationNo { get; set; }
        public int IPId { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public int GradeId { get; set; }
        public int DoctorId { get; set; }
        public int BedTypeId { get; set; }

        public string Name { get; set; }
        public string PIN { get; set; }
        public string InsuranceCardNo { get; set; }
        public string ContactNo { get; set; }
    }
}
