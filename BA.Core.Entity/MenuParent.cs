using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
   public class MenuParent
   {
        public int Id { get; set; }
        public int? MenuId { get; set; }
        public string Name { get; set; }
        public int? MenuLevel { get; set; }
        public int? SequenceNo { get; set; }
    }
}
