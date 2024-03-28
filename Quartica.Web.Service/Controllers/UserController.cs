using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quartica.Web.Service.Interfaces;
using Quartica.Web.Service.Models;

namespace Quartica.Web.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("fetchAllUsersAsync")]
        public async Task<IActionResult> fetchAllUsersAsync([FromQuery] string searchString = "")
        {
            try
            {
                var users = await _userService.fetchAllUsersAsync(searchString);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

       
        [HttpGet("fetchUserByIdAsync/{userId}")]
        public async Task<IActionResult> GetUserById(long userId)
        {
            try
            {
                var user = await _userService.fetchUserByIdAsync(userId);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("fetchUserByEmailAsync/{email}")]
        public async Task<IActionResult> fetchUserByEmailAsync(string email)
        {
            try
            {
                var user = await _userService.fetchUserByEmailAsync(email);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("fetchUserByPhoneAsync/{phone}")]
        public async Task<IActionResult> fetchUserByPhoneAsync(string phone)
        {
            try
            {
                var user = await _userService.fetchUserByPhoneAsync(phone);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(UserRegistration userRegistration)
        {
            try
            {
                var result = await _userService.RegisterUser(userRegistration);
                if (result)
                {
                    return Ok("User registered successfully");
                }
                else
                {
                    return BadRequest("Failed to register user");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("ChangePasswordAsync")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePassword changePassword)
        {
            try
            {
                var result = await _userService.ChangePasswordAsync(changePassword);
                if (result)
                {
                    return Ok("Password changes successfully");
                }
                else
                {
                    return BadRequest("Failed to change Password");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
