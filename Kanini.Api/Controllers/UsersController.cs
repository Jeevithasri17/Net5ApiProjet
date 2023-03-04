using Kanini.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Kanini.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly EmployeeDBContext _context;

        public UsersController(EmployeeDBContext context)
        {
            _context = context;
        }

        [HttpPost("SignUp")]
        public IActionResult Signup(User user)
        {

            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Email))
            {
                return BadRequest("Please provide username, password and email.");
            }

            else if (_context.Users.Any(u => u.Email == user.Email))
            {
                return BadRequest("Username is already taken");
            }

            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok("User Registered Successfully");
            }


        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                var hash = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    hash.Append(hashedBytes[i].ToString("x2"));
                }

                return hash.ToString();
            }
        }

        private static bool VerifyPassword(string password, string hashedPassword)
        {
            var hashedInput = HashPassword(password);

            return hashedInput == hashedPassword;
        }


        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var existingUser = _context.Users.SingleOrDefault(u => u.Username == user.Username);

            if (existingUser == null)
            {
                return BadRequest("Username is incorrect.");
            }

            else if (!VerifyPassword(user.Password, HashPassword(existingUser.Password)))
            {
                return BadRequest("Username or password is incorrect.");
            }

            else
            {
                User userlogin = _context.Users.Where(userlogin => userlogin.Username == user.Username && userlogin.Password == user.Password).SingleOrDefault();

                return Ok("Welcome");
            }


        }
    }
}
