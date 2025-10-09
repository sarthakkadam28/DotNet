using Microsoft.AspNetCore.Mvc;
using usermangement.Entities;
using usermangement.Service;
namespace usermangement.controller
{
    [ApiController]
    [Route("api/[controller]")]
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
                return NotFound(new { message = "User not added." });
            }

            return Ok(user);
        }
    }

}