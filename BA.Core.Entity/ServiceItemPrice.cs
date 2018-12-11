using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Entity
{
    public class ServiceItemPrice
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDateTime { get; set; }

        public bool Deleted { get; set; }
    }
}
