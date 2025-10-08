using Microsoft.AspNetCore.Mvc;
using usermangement.Entities;
using usermangement.Service;
namespace usermangement.controller
{
    [ApiController]
    [Route("api/user")]
    public class usercontroller : ControllerBase
    {
        private readonly IUserService _userService;
        private usercontroller(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetUserWithRole(int aadharId)
        {
            var user = await _userService.GetUserWithRoleAsync(aadharId);

            if (user == null)
            {
                return NotFound(new { message = "User not found for given Aadhar ID." });
            }

            return Ok(user);
        }
    }

}