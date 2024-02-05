using System.Diagnostics.CodeAnalysis;
using Core.CurrentUserServices;
using Core.InputPorts.IScenarios;
using Core.OutputPorts.UserStates;
using Core.UserServices;

namespace InputAdapters.User.CheckBalance;

public class CheckBalanceScenarioProvider : IScenarioProvider
{
    private readonly IUserServices _userService;
    private readonly ICurrentUserService _currentUser;

    public CheckBalanceScenarioProvider(IUserServices userService, ICurrentUserService currentUser)
    {
        _userService = userService;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User?.State is LoggedAsUser)
        {
            scenario = new CheckBalanceScenario(_userService);
            return true;
        }

        scenario = null;
        return false;
    }
}