using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SecuredController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            return Ok("Hello from secured controller");
        }
    }
}
