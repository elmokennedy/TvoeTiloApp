using Microsoft.AspNetCore.Mvc;
using TvoeTiloApp.Contract.Services;

namespace TvoeTiloApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _clientService.GetAll();

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
