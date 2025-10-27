using ProjectMangement.Entities;
using ProjectMangement.Repository;
namespace ProjectMangement.Services;
public class ProjectService: IProjectService
{
  public async Task<List<Userdetail>> GetAllUser()
    {
        return await ProjectRepository.GetAllUser();
    }  
}