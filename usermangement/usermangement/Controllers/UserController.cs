using Microsoft.AspNetCore.Mvc;
using usermangement.Entities;
using usermangement.Entities.UserRoleWithProjectAssignment;
using usermangement.Service;
namespace usermangement.controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // [HttpGet]
        // public async Task<IActionResult> GetUserWithRole(int aadharId)
        // {
        //     var user = await _userService.GetUserWithRole(aadharId);

        //     if (user == null)
        //     {
        //         return NotFound(new { message = "User not found for given Aadhar ID." });
        //     }

        //     return Ok(user);
        // }
        [HttpPost("add")]
        public async Task<IActionResult> AddUserWithRole([FromBody] AddUser user)
        {
            bool status = await _userService.AddUserWithRole(user);

            if (!status)
            {
                return BadRequest("User not added due to database error.");
            }

            return Ok(user);
        }
        // [HttpPost("Addemployee")]
        // public async Task<IActionResult> AddUserWithEmployee([FromBody] AddUser user)
        // {
        //     bool status = await _userService.AddUserWithEmployee(user);
        //     if (!status)
        //     {
        //         return BadRequest(" User not added due to database error .");
        //     }
        //     return Ok(user);
        // }
        [HttpGet("get")]
        public async Task<IActionResult> GetAllUser()
        {
            List<Userdetail> details = await _userService.GetAllUser();
            if (details == null || details.Count == 0)
            {
                return NotFound("no bill found");
            }
            return Ok(details);
        }
    }
}