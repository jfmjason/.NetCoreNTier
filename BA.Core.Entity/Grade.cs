using System;
using System.Collections.Generic;

namespace BA.Core.Entity
{
    public partial class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GradeName { get; set; }
        public string ArabicName { get; set; }
        public string PolicyNo { get; set; }
        public int? CategoryId { get; set; }
        public int CompanyId { get; set; }
        public decimal? RoomCharges { get; set; }
        public decimal? FixedConCharges { get; set; }
        public decimal? InvoiceConFee { get; set; }
        public decimal? IpcreditLimit { get; set; }
        public int? BedTypeId { get; set; }
        public bool? Blocked { get; set; }
        public bool Deleted { get; set; }
        public int OperatorId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? TariffId { get; set; }
        public int? Opconsultations { get; set; }
    }
}
