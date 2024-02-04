using API.JwtAuth.Models;
using API.JwtAuth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.JwtAuth.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthServices _authService;

        public AuthController(AuthServices authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [Route("CreateToken")]
        public string Create() => _authService.Create(new()
        {
            Id = 1,
            Name = "Lucas",
            Email = "lucas@email.com",
            Password = "password",
            Roles = new List<Role>() { 
                new() { Id = 1, Name = "Admin" },
                new() { Id = 2, Name = "Developer" } 
            },
        });

    }
}