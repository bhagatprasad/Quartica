using Microsoft.EntityFrameworkCore;
using Quartica.Web.Service.DdContextConfiguration;
using Quartica.Web.Service.Interfaces;
using Quartica.Web.Service.Models;

namespace Quartica.Web.Service.Repository
{
    public class RoleService : IRoleService
    {

        private readonly ApplicationDBContext _dBContext;
        public RoleService(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<Role> GetRoleByIdAsync(long roleId)
        {
            return await _dBContext.roles.FindAsync(roleId);
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _dBContext.roles.ToListAsync();
            //List<Role> roles = new List<Role>();

            //roles = (from role in _dBContext.roles
            //         select new Role
            //         {
            //             CreatedBy = role.CreatedBy,
            //         }).ToList();

            //return roles;

        }

        public async Task<Role> InsertOrUpdateRoleAsync(Role role)
        {
            if (role.RoleId == 0 || role.RoleId == null)
            {
                await _dBContext.roles.AddAsync(role);
            }
            else
            {
                //update
            }
            await _dBContext.SaveChangesAsync();
            return role;
        }
    }
}
