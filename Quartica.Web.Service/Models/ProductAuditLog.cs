using System.ComponentModel.DataAnnotations;

namespace Quartica.Web.Service.Models
{
    public class ProductAuditLog
    {
        [Key]
        public long ProductAuditLogId { get; set; }
        public long? ProductId { get; set; }
        public long? UserId { get; set; }
        public long? ActivityId { get; set; }
        public string ValueBefore { get; set; }
        public string ValueAfter { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
