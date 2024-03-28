using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quartica.Web.Service.Interfaces;
using Quartica.Web.Service.Models;

namespace Quartica.Web.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
                this.authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate(UserLoginModel model)
        {
            var appuser = await authenticationService.Authenticate(model.username, model.password);

            if (appuser == null)
                return Unauthorized();

            return Ok(appuser);
        }
    }
}
