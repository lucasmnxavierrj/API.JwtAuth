using API.JwtAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.JwtAuth.Services
{
    public class AuthServices
    {
        [NonAction]
        public string Create(User user)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(Configuration.SecretKey);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(2),
                Subject = CreateClaims(user),
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        [NonAction]
        public static ClaimsIdentity CreateClaims(User user)
        {
            var claimsIdentity = new ClaimsIdentity();

            claimsIdentity.AddClaim(new(ClaimTypes.Name, user.Name));
            claimsIdentity.AddClaim(new(ClaimTypes.Email, user.Email));

            foreach (var role in user.Roles)
                claimsIdentity.AddClaim(new(ClaimTypes.Role, role.Name));


            return claimsIdentity;
        }
    }
}
