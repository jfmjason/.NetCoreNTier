using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public string Name1 { get; set; }
        public string ArabicCode { get; set; }
        public string ArabicName { get; set; }
        public decimal? SellingPrice { get; set; }
        public string Strength { get; set; }
        public int? CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public bool? Eub { get; set; }
        public string ProfitCenter { get; set; }
        public int? UnitId { get; set; }
        public float? Tax { get; set; }
        public bool? Schedule { get; set; }
        public bool? Mrpitem { get; set; }
        public int ConversionQty { get; set; }
        public int DrugType { get; set; }
        public int? TempId { get; set; }
        public bool? Cssditem { get; set; }
        public bool? BatchStatus { get; set; }
        public decimal? StrengthNo { get; set; }
        public byte? CapitalRevenue { get; set; }
        public bool? Narcotic { get; set; }
        public bool? NonStocked { get; set; }
        public string ItemPrefix { get; set; }
        public bool? DrugControl { get; set; }
        public bool? Consignment { get; set; }
        public bool? Approval { get; set; }
        public short? ProfitCentreId { get; set; }
        public bool? FixedAsset { get; set; }
        public byte? IssueType { get; set; }
        public byte? DrugState { get; set; }
        public string StrengthUnit { get; set; }
        public bool? CriticalItem { get; set; }
        public bool? DuplicateLabel { get; set; }
        public string PartNumber { get; set; }
        public int? Cssdapp { get; set; }
        public string ModelNo { get; set; }
        public int? OperatorId { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDatetime { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool? Deleted { get; set; }
        public int? DeletedBy { get; set; }
        public bool? Feasibility { get; set; }
        public int? Uploaded { get; set; }
        public string OrcItemCode { get; set; }
        public string CatalogueNo { get; set; }
        public int? ItemForm { get; set; }
        public string Description { get; set; }
        public byte? IsCocktail { get; set; }
        public string OraCode { get; set; }
        public bool? IsUnified { get; set; }
        public DateTime? DateUnified { get; set; }
        public string PrevOraCode { get; set; }
    }
}
