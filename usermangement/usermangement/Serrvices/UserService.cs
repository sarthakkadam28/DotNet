using usermangement.Entities;
using usermangement.Repository;
using usermangement.Entities.UserRoleWithProjectAssignment;
namespace usermangement.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> AddUserWithRole(AddUser user)
    {
        return await _userRepository.AddUserWithRole(user);
    }
    // public async Task<bool> AddUserWithEmployee(AddUser user)
    // {
    //     return await _userRepository.AddUserWithEmployee(user);
    // }
     public async Task<List<Userdetail>> GetAllUser()
    {
        return await _userRepository.GetAllUser();
    } 
}