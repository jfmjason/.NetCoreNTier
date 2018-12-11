using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class BioInstall
    {
        public int Id { get; set; }
        public int? InstallingStationId { get; set; }
        public DateTime? Startdatetime { get; set; }
        public DateTime? Enddatetime { get; set; }
        public bool? Deleted { get; set; }
        public string InstalledBy { get; set; }
        public string InstallPersonDesg { get; set; }
        public DateTime? InstalledDatetime { get; set; }
        public int? OperatorId { get; set; }
        public int? AssetItemId { get; set; }
        public string ControlNo { get; set; }
        public bool? Available { get; set; }
        public int? Inspectedby { get; set; }
        public int? Fixedassetsperson { get; set; }
        public string Panicmessage { get; set; }
        public int? CurrentStationId { get; set; }
        public DateTime? WarranteePeriod { get; set; }
        public int? EquipmentGroupId { get; set; }
        public bool? CanBeScheduled { get; set; }
        public string Umdnsnumber { get; set; }
        public string Umdnsclassification { get; set; }
        public string EquipmentFunctionality { get; set; }
        public int? DepartmentId { get; set; }
        public string ExtensionNumber { get; set; }
        public bool? Alaram { get; set; }
    }
}
