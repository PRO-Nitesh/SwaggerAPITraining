using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineRetailShop.Repository;
using OnlineRetailShop.Repository.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineRetailShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly ApplicationDbContext _context;

        public AuthorizationController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
       
        [HttpPost]
        [Route("/Login")]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (user != null && user.UserName != null && user.Password != null)
            {
                var userData = await GetUser(user.UserName, user.Password);
                if (userData == null) { return BadRequest("Invalid Credentials"); }
                if (user.UserName == userData.UserName && user.Password == userData.Password)
                {
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                            new Claim("ID",user.UserId.ToString()),
                            new Claim("Password",user.Password),
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                    };

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                        _configuration["Jwt:Issuer"],
                        claims,
                        expires: DateTime.Now.AddMinutes(120),
                        signingCredentials: credentials);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                }
            }
            return BadRequest("Invalid Credentials");
        }

        private async Task<User> GetUser(string username, string password)
        {
            User user = null;
            user = _context.Users.FirstOrDefault(x => x.UserName == username);
            if (user.Password != password) return null;
            if (user != null)
            {
                user = new User { UserId = user.UserId, UserName = user.UserName, Password = user.Password };
            }
            return user;
        }
    }
}
