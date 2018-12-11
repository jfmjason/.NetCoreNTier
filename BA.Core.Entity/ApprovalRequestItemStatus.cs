

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BA.Core.Entity
{
    [Table("ApprovalRequestItemStatus", Schema = "MASTER")]
    public class ApprovalRequestItemStatus :BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
    }
}
