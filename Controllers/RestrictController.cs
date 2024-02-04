using API.JwtAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.JwtAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestrictController : ControllerBase
    {
        [HttpGet("OnlyAuthenticated")]
        public IActionResult OnlyAuthenticated()
        {
            return Ok($"Hello {User.Identity?.Name}. Succesfuly Authenticated!");
        }

        [Authorize(Policy = AppPolicies.AdminOnlyPolicy)]
        [HttpGet("OnlyWithAdminRole")]
        public IActionResult OnlyWithAdminRole()
        {
            return Ok($"{User.Identity?.Name}, you are an Admin! ");
        }
    }
}
