using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
   public class ClinicalVisit
    {
        public int Id { get; set; }
        public int? RegistrationNo { get; set; }
        public string IssueAuthorityCode { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? VisitDateTime { get; set; }
        public byte? Visit { get; set; }
        public int? ScheduleId { get; set; }
        public DateTime? FollowUpDateTime { get; set; }
        public string ReasonForAdmission { get; set; }
        public string AdmissionType { get; set; }
        public byte? Admitted { get; set; }
        public string ProvDiagnosis { get; set; }
        public string FinalDiagnosis { get; set; }
        public DateTime? StartDatetime { get; set; }
        public string OtherAdvice { get; set; }
        public string AdmittingInstructions { get; set; }
        public int? Ipid { get; set; }
        public int SheetId { get; set; }
        public decimal? Weight { get; set; }
        public string TreatmentPlan { get; set; }
        public int? OperatorId { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public int? ImpVisit { get; set; }
        public decimal? Height { get; set; }
        public decimal? Bmi { get; set; }
    }
}
