using System.Diagnostics.CodeAnalysis;
using Core.AdminServices;
using Core.CurrentUserServices;
using Core.InputPorts.IScenarios;

namespace InputAdapters.Admin.Login;

public class AdminLoginScenarioProvider : IScenarioProvider
{
    private readonly IAdminServices _adminService;
    private readonly ICurrentUserService _currentUser;

    public AdminLoginScenarioProvider(IAdminServices adminService, ICurrentUserService currentUser)
    {
        _adminService = adminService;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = new AdminLoginScenario(_adminService);
            return true;
        }

        scenario = null;
        return false;
    }
}