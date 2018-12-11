using System;

namespace BA.Core.Entity
{
    public partial class Department
    {
        public int Id { get; set; }
        public string DeptCode { get; set; }
        public string Name { get; set; }
        public string AccountCode { get; set; }
        public string DeptClassId { get; set; }
        public string RecordId { get; set; }
        public DateTime StartDateTime { get; set; }
        public bool Deleted { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? OperatorId { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public int? DivisionId { get; set; }
        public string ArabicName { get; set; }
        public string ArabicCode { get; set; }
        public int? Oldid { get; set; }
        public byte? NonSghdept { get; set; }
        public string OraCode { get; set; }
        public bool? Uploaded { get; set; }
        public DateTime? Udatetime { get; set; }
        public string Bscname { get; set; }
        public string DdbarabicName { get; set; }
    }
}
