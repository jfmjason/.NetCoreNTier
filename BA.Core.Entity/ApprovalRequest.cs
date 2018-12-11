using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BA.Core.Entity
{
    public class ApprovalRequest : BaseEntity
    {
        public ApprovalRequest()
        {
            ApprovalItems = new List<ApprovalRequestItem>();
        }

        public int Id { get; set; }
        public int AuthorityId { get; set; }
        public int? IPId { get; set; }

        [MaxLength(20)] 
        public string CreationIPAddress { get; set; }
        [MaxLength(20)]
        public string ModificationIPAddress { get; set; }
        [MaxLength(20)]
        public string SMSCode { get; set; }
        [MaxLength(20)]
        public string SMSStatus { get; set; }
        [MaxLength(50)]
        public string InsuranceCardNumber { get; set; }
        [MaxLength(20)]
        public string ContactNumber { get; set; }
        public string ClinicalData { get; set; }

        public DateTime? ProcessingDate { get; set; }

        public int? ProcessById { get; set; }
        public virtual Employee ProcessBy { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        public int DoctorId { get; set; }
        public virtual Employee Doctor { get; set; }

        public int BranchId { get; set; }
        public virtual OrganisationDetail Branch { get; set; }

        public int PatientTypeId { get; set; }
        public virtual PatientType PatientType { get; set; }

        public int ApprovalRequestStatusId { get; set; }
       
        public virtual ApprovalRequestStatus ApprovalRequestStatus { get; set; }

        public int ApprovalRequestTypeId { get; set; }
        public virtual ApprovalRequestType ApprovalRequestType { get; set; }

        public string IssueAuthorityCode { get; set; }
        public int Registrationno { get; set; }
        public virtual Patient Patient { get; set; }

        public int RequestCreationStationId { get; set; }
        public virtual Station RequestCreationStation { get; set; }

        public int? RequestModificationStationId { get; set; }
        public virtual Station RequestModificationStation { get; set; }

        public virtual List<ApprovalRequestItem> ApprovalItems { get; set; }
        

    }
}
