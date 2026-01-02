using Microsoft.AspNetCore.Mvc;
using UserSessionAPI.Models;
using UserSessionAPI.services.Interfaces;

namespace UserSessionAPI.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IuserSessionService _userService;

        public UserController(IuserSessionService userService)
        {
            _userService = userService;
        }

        // POST: api/user/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] Register request)
        {
            var user = _userService.Register(request);

            if (user == null)
                return BadRequest(new { Message = "User already exists" });

            return Ok(new { Message = "Registration successful" });
        }



        // POST: api/user/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] login request)
        {
            var user = _userService.Login(request);

            if (user == null)
                return Unauthorized(new { Message = "Invalid username or password" });

            return Ok(new { Message = "Login successful" });
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("API working");
        }

        // GET: api/user/all
        [HttpGet("GetAll")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        
        public IActionResult GetById(int id)
        {
            var users = _userService.GetById(id);
            if (users == null)
                return NotFound(new { Message = "User not found" });
            return Ok(new { users.Id, users.Username, users.Email });
        }


    }
}
