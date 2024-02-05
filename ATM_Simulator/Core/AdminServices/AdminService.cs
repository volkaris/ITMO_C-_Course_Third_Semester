using Core.CurrentUserServices;
using Core.OperationsResults;
using Core.OutputPorts;

namespace Core.AdminServices;

public class AdminService : IAdminServices
{
    private readonly IAdminRepository _adminRepository;
    private readonly IUserRepository _userRepository;
    private readonly CurrentUser _currentUserManager;

    public AdminService(
        CurrentUser currentUserManager,
        IAdminRepository adminRepository,
        IUserRepository userRepository)
    {
        _currentUserManager = currentUserManager;
        _adminRepository = adminRepository;
        _userRepository = userRepository;
    }

    public async Task<LoginResult> Login(string password)
    {
        User? user = await _adminRepository.LogAsAdmin(password);

        if (user is null) return new LoginResult.NotFound();

        _currentUserManager.User = user;
        return new LoginResult.Success();
    }

    public async Task<OperationResult> AddUser(string id, string password)
    {
        if (await _userRepository.AddBankUser(id, password)) return new OperationResult.Success();

        return new OperationResult.Unsuccess("Error while adding user happened.");
    }
}