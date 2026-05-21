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
            var result = _userService.GetActiveClients();

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientUserRequest request)
        {
            await _userService.CreateClientUser(request);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateClient([FromRoute] int userId, [FromBody] UpdateClientUserRequest request)
        {
            await _userService.UpdateClientUser(userId, request);

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int userId)
        {
            await _userService.DeleteClientUser(userId);

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
