using Microsoft.AspNetCore.Mvc;
using TvoeTiloApp.Contract.Services;
using TvoeTiloApp.Model.Requests;

namespace TvoeTiloApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] UserLoginRequest request)
        {
            var result = await _userService.GetLoginUser(request);

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
