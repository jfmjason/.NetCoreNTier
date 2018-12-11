
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BA.Core.Entity
{
    [Table("ApprovalRequestStatus", Schema = "MASTER")]
    public class ApprovalRequestStatus :BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
    }
}
