using Microsoft.AspNetCore.Mvc;
using MyBakery.WepApi.Context;
using MyBakery.WepApi.Dto;
using MyBakery.WepApi.Entity;

namespace MyBakery.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MyBakeryContext _context;

        public AuthController(MyBakeryContext context)
        {
            _context = context;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginAdminDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest("Kullanıcı adı ve şifre boş olamaz.");

            var user = _context.AdminUsers.FirstOrDefault(u => u.Username == dto.Username);
            if (user == null)
                return Unauthorized("Kullanıcı adı veya şifre hatalı.");

            var isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
            if (!isValid)
                return Unauthorized("Kullanıcı adı veya şifre hatalı.");

            return Ok(new ResultAdminUserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            });
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterAdminDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest("Kullanıcı adı ve şifre boş olamaz.");

            if (_context.AdminUsers.Any(u => u.Username == dto.Username))
                return Conflict("Bu kullanıcı adı zaten kullanılıyor.");

            if (_context.AdminUsers.Any(u => u.Email == dto.Email))
                return Conflict("Bu e-posta adresi zaten kayıtlı.");

            var hashed = BCrypt.Net.BCrypt.HashPassword(dto.Password, workFactor: 12);

            var user = new AdminUser
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = hashed,
                CreatedAt = DateTime.UtcNow
            };

            _context.AdminUsers.Add(user);
            _context.SaveChanges();

            return Ok(new ResultAdminUserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            });
        }
    }
}
