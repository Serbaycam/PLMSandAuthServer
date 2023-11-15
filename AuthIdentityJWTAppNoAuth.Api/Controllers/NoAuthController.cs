using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthIdentityJWTAppNoAuth.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NoAuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStock()
        {
            return Ok("Ok");
        }
    }
}
