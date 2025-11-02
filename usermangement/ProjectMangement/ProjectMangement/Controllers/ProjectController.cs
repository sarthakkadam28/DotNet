using Microsoft.AspNetCore.Mvc;
using ProjectMangement.Entities;
using ProjectMangement.Services;
namespace ProjectMangement.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectServices _projectService;
        public ProjectController(IProjectServices projectService)
        {

            Console.WriteLine("Project Controller constructor...");
            
            _projectService = projectService;
        }
       
        [HttpGet("/sarthak")]
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