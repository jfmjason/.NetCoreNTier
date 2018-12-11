using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
   public class Batch
   {
        public int ItemId { get; set; }
        public int BatchId { get; set; }
        public string BatchNo { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? Supplierid { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Mrp { get; set; }
        public int Quantity { get; set; }
        public bool? ItemType { get; set; }
        public decimal? PurRate { get; set; }
        public decimal? UnitEpr { get; set; }
        public DateTime StartDate { get; set; }
        public int? Middleware { get; set; }
    }
}
