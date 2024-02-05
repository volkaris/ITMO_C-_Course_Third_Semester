using System.Diagnostics.CodeAnalysis;
using Core.AdminServices;
using Core.CurrentUserServices;
using Core.InputPorts.IScenarios;
using Core.OutputPorts.UserStates;

namespace InputAdapters.Admin.AddUser;

public class AddUserScenarioProvder : IScenarioProvider
{
    private readonly IAdminServices _adminService;
    private readonly ICurrentUserService _currentUser;

    public AddUserScenarioProvder(IAdminServices adminService, ICurrentUserService currentUser)
    {
        _adminService = adminService;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User?.State is LoggedAsAdmin)
        {
            scenario = new AddUserScenario(_adminService);
            return true;
        }

        scenario = null;
        return false;
    }
}