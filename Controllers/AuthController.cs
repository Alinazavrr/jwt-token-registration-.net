using JwtAuthApi.Data;
using JwtAuthApi.Helpers;
using JwtAuthApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace JwtAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtHelper _jwtHelper;

        public AuthController(ApplicationDbContext context, JwtHelper jwtHelper)
        {
            _context = context;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("register")]
        public IActionResult Register(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(UserModel login)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == login.Username && x.Password == login.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = _jwtHelper.GenerateJwtToken(user.Username);
            return Ok(new { token });
        }
    }
}
