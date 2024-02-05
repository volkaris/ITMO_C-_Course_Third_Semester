using System.Diagnostics.CodeAnalysis;
using Core.CurrentUserServices;
using Core.InputPorts.IScenarios;
using Core.UserServices;

namespace InputAdapters.User.Login;

public class UserLoginScenarioProvider : IScenarioProvider
{
    private readonly IUserServices _userService;
    private readonly ICurrentUserService _currentUser;

    public UserLoginScenarioProvider(
        IUserServices createUserService,
        ICurrentUserService currentUser)
    {
        _userService = createUserService;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = new UserLoginScenario(_userService);
            return true;
        }

        scenario = null;
        return false;
    }
}