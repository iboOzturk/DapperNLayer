using EntityLayer.Concrete;
using JWTDapper.API.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTDapper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BuildToken _buildToken;

        public AuthController(BuildToken buildToken)
        {
            _buildToken = buildToken;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var token = await _buildToken.AuthenticateUserAsync(request.Username, request.Password);

                if (token != null)
                {
                    return Ok(new { Token = token });
                }
                else
                {
                    return Unauthorized(new { Message = "Invalid credentials" });
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
