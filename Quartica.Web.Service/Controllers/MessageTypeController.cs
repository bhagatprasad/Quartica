using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quartica.Web.Service.Helpers;
using Quartica.Web.Service.Interfaces;
using Quartica.Web.Service.Models;

namespace Quartica.Web.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [QuarticaAuthorize]
    public class MessageTypeController : ControllerBase
    {
        private readonly IMessageTypeService messageTypeService;
        public MessageTypeController(IMessageTypeService messageTypeService)
        {
            this.messageTypeService = messageTypeService;
        }

        [HttpGet]
        [Route("fetchMessageTypesAync")]
        public async Task<IActionResult> fetchMessageTypesAync()
        {
            try
            {
                var responce = await messageTypeService.fetchMessageTypesAync();
                return Ok(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        [Route("InsertOrUpdateMessageTypeAsync")]
        public async Task<IActionResult> InsertOrUpdateMessageTypeAsync(MessageType messageType)
        {
            try
            {
                if (messageType == null)
                    return new BadRequestObjectResult("Messagetype Not Valid");

                var responce = await messageTypeService.InsertOrUpdateMessageTypeAsync(messageType);

                return Ok(new { StatusCodes.Status200OK, responce });
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
