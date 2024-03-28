using System.ComponentModel.DataAnnotations;

namespace Quartica.Web.Service.Models
{
    public class UserAuditLog
    {
        [Key]
        public long Id { get; set; }
        public long? ActivityId { get; set; }
        public long? UserId { get; set; }
        public string ValueBefore { get; set; }
        public string ValueAfter { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
