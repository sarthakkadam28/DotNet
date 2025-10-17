
using ProjectMangement.Entities; 
namespace ProjectMangement.Repository 
{
    public interface IProjectMangement
    {
        Task<List<Userdetail>> GetAllUser();
    }
}