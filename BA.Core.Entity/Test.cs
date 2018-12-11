using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
   public class Test
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ArabicCode { get; set; }
        public string ArabicName { get; set; }
        public float? CostPrice { get; set; }
        public bool Profile { get; set; }
        public string Instructions { get; set; }
        public bool? Images { get; set; }
        public bool? ClinicalDetails { get; set; }
        public string LoginSname { get; set; }
        public byte? Type { get; set; }
        public string Notes { get; set; }
        public string Icdcode { get; set; }
        public string Pcs { get; set; }
        public int? EquipId { get; set; }
        public int? Sequence { get; set; }
        public int DepartmentId { get; set; }
        public short ConType { get; set; }
        public bool? IsCulture { get; set; }
        public byte? Zonediameter { get; set; }
        public bool? PendingTestsDisplay { get; set; }
        public bool? Anaesthetist { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool Deleted { get; set; }
        public int? OperatorId { get; set; }
        public string NewCode { get; set; }
        public int? ModifiedBy { get; set; }
        public int? Uploaded { get; set; }
        public DateTime? Udatetime { get; set; }
    }
}
