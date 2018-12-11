using System;

namespace BA.Core.Entity
{
    public partial class Station
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int StationTypeId { get; set; }
        public int? LocationId { get; set; }
        public string Location { get; set; }
        public int? DepartmentId { get; set; }
        public string Prefix { get; set; }
        public byte? Stores { get; set; }
        public int? Appid { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? Operatorid { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifieddatetime { get; set; }
        public bool Deleted { get; set; }
        public string Arabicname { get; set; }
        public int? IpMaxNo { get; set; }
        public short? IndentLevel { get; set; }
        public string OraCode { get; set; }
    }
}
