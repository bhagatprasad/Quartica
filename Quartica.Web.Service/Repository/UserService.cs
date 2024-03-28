using Microsoft.EntityFrameworkCore;
using Quartica.Web.Service.DdContextConfiguration;
using Quartica.Web.Service.Helpers;
using Quartica.Web.Service.Interfaces;
using Quartica.Web.Service.Models;

namespace Quartica.Web.Service.Repository
{
    public class UserService : IUserService
    {
        private readonly ApplicationDBContext dBContext;
        public UserService(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<bool> ChangePasswordAsync(ChangePassword changePassword)
        {
            if (changePassword != null)
            {
                if (changePassword.UserId > 0)
                {
                    var dbUser = await dBContext.users.FindAsync(changePassword.UserId);

                    if (dbUser != null)
                    {
                        if (!string.IsNullOrEmpty(changePassword.Password))
                        {
                            HashSalt hashSalt = HashSalt.GenerateSaltedHash(changePassword.Password);
                            dbUser.PasswordSalt = hashSalt.Salt;
                            dbUser.PasswordHash = hashSalt.Hash;
                            dbUser.ModifiedBy = changePassword.ModifiedBy;
                            dbUser.ModifiedOn = changePassword.ModifiedOn;

                            UserAuditLog userAuditLog = new UserAuditLog()
                            {
                                ActivityId = (long)UserActivity.ChangePassword,
                                UserId = changePassword.UserId,
                                ValueBefore = "",
                                ValueAfter = "New user created",
                                CreatedBy = changePassword.ModifiedBy,
                                CreatedOn = changePassword.ModifiedOn,
                                IsActive = true,
                                ModifiedBy = changePassword.ModifiedBy,
                                ModifiedOn = changePassword.ModifiedOn,
                            };
                            await dBContext.userAuditLogs.AddAsync(userAuditLog);
                            var responce = await dBContext.SaveChangesAsync();
                            return responce == 1 ? true : false;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        public async Task<List<User>> fetchAllUsersAsync(string searchString = "")
        {
            IQueryable<User> query = dBContext.users.Include(u => u.userAuditLogs);

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(u => u.Name.ToLower().Trim().Contains(searchString.ToLower().Trim()) ||
                                         u.Email.Contains(searchString) ||
                                         u.Phone.Contains(searchString));
            }

            return await query.ToListAsync();
        }

        public async Task<User> fetchUserByEmailAsync(string email)
        {
            var normalizedEmail = email.ToLower().Trim();

            if (!string.IsNullOrEmpty(normalizedEmail))
            {
                var user = await dBContext.users.Where(x => x.Email.ToLower().Trim() == normalizedEmail).Include(u => u.userAuditLogs).FirstOrDefaultAsync();

                return user;
            }
            return null;
        }

        public async Task<User> fetchUserByIdAsync(long userid)
        {
            if (userid > 0)
            {
                var user = await dBContext.users.Where(x => x.UserId == userid).Include(u => u.userAuditLogs).FirstOrDefaultAsync();
                return user;
            }
            return null;
        }

        public async Task<User> fetchUserByPhoneAsync(string phone)
        {
            var normalizedPhone = phone.Trim();

            if (!string.IsNullOrEmpty(normalizedPhone))
            {
                var user = await dBContext.users.Where(x => x.Phone.Trim() == normalizedPhone).Include(u => u.userAuditLogs).FirstOrDefaultAsync();
                return user;
            }
            return null;
        }

        public async Task<bool> RegisterUser(UserRegistration userRegistration)
        {
            if (userRegistration != null)
            {
                bool isExist = dBContext.users.Any(x => x.Email.ToLower().Trim() != userRegistration.Email.ToLower() && x.Phone.Trim() != userRegistration.Phone.Trim());

                if (isExist)
                {
                    if (!string.IsNullOrEmpty(userRegistration.Password))
                    {
                        HashSalt hashSalt = HashSalt.GenerateSaltedHash(userRegistration.Password);

                        User user = new User()
                        {
                            Email = userRegistration.Email,
                            Phone = userRegistration.Phone,
                            CreatedBy = userRegistration.CreatedBy,
                            CreatedOn = userRegistration.CreatedOn,
                            IsActive = userRegistration.IsActive,
                            ModifiedBy = userRegistration.ModifiedBy,
                            ModifiedOn = userRegistration.ModifiedOn,
                            Name = userRegistration.Name,
                            PasswordHash = hashSalt.Hash,
                            PasswordSalt = hashSalt.Salt
                        };

                        await dBContext.users.AddAsync(user);
                        await dBContext.SaveChangesAsync();

                        UserAuditLog userAuditLog = new UserAuditLog()
                        {
                            ActivityId = (long)UserActivity.Create,
                            UserId = user.UserId,
                            ValueBefore = "",
                            ValueAfter = "New user created",
                            CreatedBy = userRegistration.CreatedBy,
                            CreatedOn = userRegistration.CreatedOn,
                            IsActive = userRegistration.IsActive,
                            ModifiedBy = userRegistration.ModifiedBy,
                            ModifiedOn = userRegistration.ModifiedOn,
                        };
                        await dBContext.userAuditLogs.AddAsync(userAuditLog);
                        var responce = await dBContext.SaveChangesAsync();
                        return responce == 1 ? true : false;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }
    }
}
