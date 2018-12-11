using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BA.Core.Entity
{
   public class AssetControl
    {
        [Key]
        public int ItemId { get; set; }
        public string ControlNo { get; set; }
        public bool? Condemn { get; set; }
    }
}
