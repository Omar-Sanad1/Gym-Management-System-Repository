using GymManagementSystem.Models;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("RegisterMember")]
        public async Task<IActionResult> RegisterMemberAsync(RegisterMemberModel registerMember)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registeredMember = await _authService.RegisterMemberAsync(registerMember);

            return Ok(registeredMember);
        }

        [HttpPost("LoginMember")]
        public async Task<IActionResult> LoginMemberAsync(LoginMemberModel loginMember)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var loginedMember = await _authService.LoginMemberAsync(loginMember);
            return Ok(loginedMember);
        }
    }
}
