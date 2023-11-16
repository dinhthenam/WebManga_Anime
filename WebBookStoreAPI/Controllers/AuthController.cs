using BusinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebBookStoreAPI.DTO;

namespace WebBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase

    {
        private readonly IConfiguration _configuration;
        private readonly BookStoreContext _context;

        public AuthController(BookStoreContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
              
                var user = _context.Users.SingleOrDefault(u => u.User_Email == model.User_Email && u.User_Password == model.User_Password);

                if (user != null)
                {
                    var token = GenerateJwtToken(user);
                    return Ok(new { token });

                 
                }
                else
                {
                   
                    return BadRequest("Tên đăng nhập hoặc mật khẩu không đúng");
                }
            }

          
            return BadRequest("Dữ liệu đầu vào không hợp lệ");
        }
        [AllowAnonymous]
        [HttpPost("signup")]
        public IActionResult Signup([FromBody] User model)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(model);
                _context.SaveChanges(); 
                return Ok("Đăng ký thành công");
            }
            return BadRequest("Dữ liệu đầu vào không hợp lệ");
        }
        private string GenerateJwtToken(User user)
        {
            var secretKey = _configuration["Jwt:Key"]; 
            var issuer = _configuration["Jwt:Issuer"]; 

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
           
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.User_Id.ToString()),
            new Claim(ClaimTypes.Name, user.User_Name),
            new Claim(ClaimTypes.Email, user.User_Email),
            
           
        };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(10), 
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}

