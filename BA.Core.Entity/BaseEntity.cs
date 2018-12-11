using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BA.Core.Entity
{
    public class BaseEntity
    {

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public bool Active { get; set; }

        public int CreatedById { get; set; }
        public virtual Employee CreatedBy { get; set; }

        public int? ModifiedById { get; set; }
        public virtual Employee ModifiedBy { get; set; }

    }
}
