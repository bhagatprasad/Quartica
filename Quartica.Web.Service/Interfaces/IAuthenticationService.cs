using Quartica.Web.Service.Models;

namespace Quartica.Web.Service.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthResponse> Authenticate(string username, string password);
        Task<ApplicationUser> GenarateUserClaims(AuthResponse authResponse);
    }
}
