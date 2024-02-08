using InventoryManagementSystem.Interface;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace InventoryManagementSystem.Controllers
{
    [ApiController]
    [Route("login/")]
    public class LoginController : Controller
    {
        public ILoginService _config;

        public LoginController(ILoginService loginService)
        {
            _config = loginService;
        }

        [HttpPost]
        public IActionResult AddLogin([FromBody] LoginDto loginDto)
        {
            if (_config.IsValidUser(loginDto.email, loginDto.Password))
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetJwtKey()));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(_config.GetJwtIssuer(),
                  _config.GetJwtIssuer(),
                  null,
                  expires: DateTime.Now.AddHours(7),
                  signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                return Ok(token);
            }

            return Unauthorized("Invalid username or password");
        }
    }
}
