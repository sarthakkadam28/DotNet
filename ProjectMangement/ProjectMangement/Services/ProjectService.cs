using ProjectMangement.Entities;
using ProjectMangement.Repository;
namespace ProjectMangement.Services;
public class ProjectService: IProjectService
{
  private readonly IProjectRepository _ProjectRepository;
  public ProjectService(IProjectRepository projectRepository)
    {
     _ProjectRepository = projectRepository;
    }
  public async Task<List<Userdetail>> GetAllUser()
    {
        return await _ProjectRepository.GetAllUser();
    }  
}