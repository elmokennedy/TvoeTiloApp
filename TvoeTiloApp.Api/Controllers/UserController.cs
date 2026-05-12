using Microsoft.AspNetCore.Mvc;
using TvoeTiloApp.Contract.Services;
using TvoeTiloApp.Model.Requests;

namespace TvoeTiloApp.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientUserRequest request)
        {
            await _userService.CreateClientUser(request);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient(UpdateClientUserRequest request)
        {
            await _userService.UpdateClientUser(request);

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
