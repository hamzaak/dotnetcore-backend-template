using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Ponente.Business.Abstract;
using Ponente.Entity.Concrete;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Ponente.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]User user)
        {
            IActionResult response = Unauthorized();
            var usr = _userService.Get(user.Username, user.Password);

            if (usr != null)
            {
                var tokenString = GetToken(usr);
                response = Ok(new { user = usr, token = tokenString });
            }

            return response;
        }

        [Authorize]
        [HttpGet]
        [Route("check")]
        public IActionResult Check()
        {
            return Ok();
        }

        private string GetToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                null,
                expires: user.Remember ? DateTime.Now.AddMonths(3) : DateTime.Now.AddHours(24),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}