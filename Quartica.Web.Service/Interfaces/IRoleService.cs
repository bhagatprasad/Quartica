using Quartica.Web.Service.Models;

namespace Quartica.Web.Service.Interfaces
{
    public interface IRoleService
    {
        Task<Role> InsertOrUpdateRoleAsync(Role role);
        Task<Role> GetRoleByIdAsync(long roleId);

        Task<List<Role>> GetRolesAsync();
    }
}
