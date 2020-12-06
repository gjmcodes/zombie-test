
using Domain.Core.Operations;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult ApiResponse(CommandResult result)
        {
            if(result.HasErrors)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

         protected IActionResult ApiResponse(object dataResult)
        {
            return Ok(dataResult);
        }
    }
}