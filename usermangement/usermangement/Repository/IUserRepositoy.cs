using usermangement.Entities;
namespace usermangement.Repository
{
    public interface IUserRepository
    {
        Task<UserWithRole> GetUserWithRoleAsync(int aadharId);
    }
}