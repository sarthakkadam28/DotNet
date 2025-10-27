using Microsoft.AspNetCore.Mvc;
using ProjectMangement.Entities;
using ProjectMangement.Services;
namespace ProjectMangement.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
       
        [HttpGet("sarthak")]
        public async Task<IActionResult> GetAllUser()
        {
            List<Userdetail> details = await _projectService.GetAllUser();
            if (details == null || details.Count == 0)
            {
                return NotFound("Users not found ");
            }
            return Ok(details);
        }
    }
}