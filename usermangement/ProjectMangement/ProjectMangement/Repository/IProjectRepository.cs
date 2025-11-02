
using ProjectMangement.Entities; 
namespace ProjectMangement.Repository;
    public interface IProjectRepository
    {
        Task<List<Userdetail>> GetAllUser();
    }
