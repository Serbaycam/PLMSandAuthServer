using AuthIdentityJWT.SharedLibrary.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AuthIdentityJWT.Api.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
