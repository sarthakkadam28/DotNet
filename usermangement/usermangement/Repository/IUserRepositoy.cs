using usermangement.Entities;
namespace usermangement.Repository
{
    public interface IUserRepository
    {
        Task<bool> AddUserWithRole(AddUser user);
        // Task<bool> AddUserWithEmployee(AddUser user);
    }
}