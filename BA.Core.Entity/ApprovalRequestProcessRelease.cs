using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BA.Core.Entity
{

    public class ApprovalRequestProcessRelease
    {
       
        public int Id { get; set; }

        public DateTime ReleaseDate { get; set; }
        [MaxLength(20)]
        public string IpAddress { get; set; }
        [MaxLength(200)]
        public string Remarks { get; set; }

        public int CurrentProcessOwnerId { get; set; }
        public virtual Employee CurrentProcessOwner { get; set; }

        public int? AssignToEmployeeId { get; set; }
        public virtual Employee AssignToEmployee { get; set; }

        public int ReleasedByEmployeeId { get; set; }
        public virtual Employee ReleasedByEmployee { get; set; }

        public int ApprovalRequestId { get; set; }
        public virtual ApprovalRequest ApprovalRequest { get; set; }

        public int? StationId { get; set; }
        public  virtual Station Station { get;set;}

    }
}
