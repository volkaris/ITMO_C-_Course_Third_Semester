using System.Diagnostics.CodeAnalysis;
using Core.CurrentUserServices;
using Core.InputPorts.IScenarios;
using Core.OutputPorts.UserStates;
using Core.UserServices;

namespace InputAdapters.User.WithdrawMoney;

public class WithdrawMoneyScenarioProvider : IScenarioProvider
{
    private readonly IUserServices _userService;
    private readonly ICurrentUserService _currentUser;

    public WithdrawMoneyScenarioProvider(IUserServices userService, ICurrentUserService currentUser)
    {
        _userService = userService;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User?.State is LoggedAsUser)
        {
            scenario = new WithdrawMoneyScenario(_userService);
            return true;
        }

        scenario = null;
        return false;
    }
}