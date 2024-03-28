using Quartica.Web.Service.Models;

namespace Quartica.Web.Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUser(UserRegistration userRegistration);
        Task<User> fetchUserByIdAsync(long userid);
        Task<User> fetchUserByEmailAsync(string email);
        Task<User> fetchUserByPhoneAsync(string phone);
        Task<List<User>> fetchAllUsersAsync(string searchString="");
        Task<bool> ChangePasswordAsync(ChangePassword changePassword);
    }
}
