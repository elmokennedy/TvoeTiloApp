using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TvoeTiloApp.Api.Auth;
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
        public async Task<IResult> Index([FromBody] UserLoginRequest request)
        {
            var result = await _userService.GetLoginUser(request);

            if (result is null) 
                return Results.Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, result.Email) };
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = result.Email
            };

            return Results.Json(response);
            //return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
