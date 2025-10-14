using usermangement.Entities;
using usermangement.Entities.UserRoleWithProjectAssignment;
namespace usermangement.Repository
{
    public interface IUserRepository
    {
        Task<bool> AddUserWithRole(AddUser user);
        // Task<bool> AddUserWithEmployee(AddUser user);

        Task<List<Userdetail>> GetAllUser();
    
    }
}