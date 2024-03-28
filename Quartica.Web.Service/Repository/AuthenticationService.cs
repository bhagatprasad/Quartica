using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quartica.Web.Service.DdContextConfiguration;
using Quartica.Web.Service.Helpers;
using Quartica.Web.Service.Interfaces;
using Quartica.Web.Service.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Quartica.Web.Service.Repository
{
    public class AuthenticationService : IAuthenticationService
    {
        public string TokenKey { get; }
        private readonly ApplicationDBContext dbContext;
        public AuthenticationService(string _tokenKey, ApplicationDBContext _dbContex)
        {
            this.dbContext = _dbContex;
            this.TokenKey = _tokenKey;
        }
        public async Task<AuthResponse> Authenticate(string username, string password)
        {
            try
            {
                User user = await dbContext.users.Where(x => x.Email.Trim().ToLower() == username.Trim().ToLower()).FirstOrDefaultAsync();
                if (user != null)
                {
                    var passwordvalidation = HashSalt.VerifyPassword(password, user.PasswordHash, user.PasswordSalt);
                    if (passwordvalidation)
                    {
                        UserAuditLog auditLog = new UserAuditLog()
                        {
                            ActivityId = (long)UserActivity.LoggedIn,
                            CreatedBy = user.UserId,
                            CreatedOn = DateTimeOffset.Now,
                            IsActive = true,
                            ModifiedBy = user.UserId,
                            ModifiedOn = DateTimeOffset.Now,
                            UserId = user.UserId,
                            ValueAfter = "Loggeg In",
                            ValueBefore = ""
                        };

                        await dbContext.userAuditLogs.AddAsync(auditLog);
                        await dbContext.SaveChangesAsync();

                        var tokenhandler = new JwtSecurityTokenHandler();
                        var tokenkey = Encoding.ASCII.GetBytes(TokenKey);
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                                new Claim(ClaimTypes.Name, username)

                            }),
                            Expires = DateTime.UtcNow.AddHours(1),
                            SigningCredentials = new SigningCredentials(
                                new SymmetricSecurityKey(tokenkey),
                                SecurityAlgorithms.HmacSha256Signature)
                        };
                        var token = tokenhandler.CreateToken(tokenDescriptor);
                        var writtoken = tokenhandler.WriteToken(token);
                        AuthResponse resp = new AuthResponse { JwtToken = writtoken };
                        resp.ValidUser = true;
                        resp.IsActive = user.IsActive;
                        resp.StatusCode = string.Empty;
                        resp.StatusMessage = string.Empty;
                        return resp;
                    }

                    AuthResponse auth = new AuthResponse();
                    auth.ValidUser = false;
                    auth.JwtToken = string.Empty;
                    auth.IsActive = false;
                    auth.StatusCode = string.Empty;
                    auth.StatusMessage = string.Empty;
                    return auth;

                }
                else
                {
                    AuthResponse auth = new AuthResponse();
                    auth.ValidUser = false;
                    auth.JwtToken = string.Empty;
                    auth.IsActive = false;
                    auth.StatusCode = string.Empty;
                    auth.StatusMessage = string.Empty;
                    return auth;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
