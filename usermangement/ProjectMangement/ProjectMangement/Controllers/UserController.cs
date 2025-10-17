using Microsoft.AspNetCore.Mvc;
using usermangement.Entities;
using usermangement.Entities.UserRoleWithProjectAssignment;
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
       
        [HttpGet("sarthak")]
        public async Task<IActionResult> GetAllUser()
        {
            List<Userdetail> details = await _userService.GetAllUser();
            if (details == null || details.Count == 0)
            {
                return NotFound("Users not found ");
            }
            return Ok(details);
        }
    }
}