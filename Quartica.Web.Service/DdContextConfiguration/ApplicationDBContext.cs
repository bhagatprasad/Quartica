using Microsoft.EntityFrameworkCore;
using Quartica.Web.Service.Models;

namespace Quartica.Web.Service.DdContextConfiguration
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> users { get; set; }
        public DbSet<Activity> activities { get; set; }
        public DbSet<UserAuditLog> userAuditLogs { get; set; }
    }
}
