using System.ComponentModel.DataAnnotations;

namespace Quartica.Web.Service.Models
{
    public class Product
    {
        [Key]
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? RegularPrice { get; set; }
        public decimal? OfferPrice { get; set; }
        public int Avilabulity { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public virtual List<ProductAuditLog> productAuditLogs { get; set; }
    }
}
