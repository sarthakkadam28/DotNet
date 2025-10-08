using usermangement.Entities;
using usermangement.Repository;
namespace usermangement.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserWithRole> GetUserWithRoleAsync(int AadharId)
    {
        return await _userRepository.GetUserWithRoleAsync(AadharId);
    }

   
}