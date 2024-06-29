using Microsoft.AspNetCore.Mvc;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Others;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateAction<T>(CustomResponseDto<T> request)
        {
            if (request.StatusCode == 204)
            {
                return new ObjectResult(null) { StatusCode = 204 };
            }
            else
            {
                return new ObjectResult(request) { StatusCode = request.StatusCode };
            }
        }
    }
}
