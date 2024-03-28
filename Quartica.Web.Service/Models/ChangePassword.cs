namespace Quartica.Web.Service.Models
{
    public class ChangePassword
    {
        public long UserId { get; set; }
        public string Password { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
