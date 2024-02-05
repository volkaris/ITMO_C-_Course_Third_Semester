using Core.AdminServices;
using Core.InputPorts.IScenarios;
using Core.OperationsResults;
using Spectre.Console;

namespace InputAdapters.Admin.Login;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminServices _adminServices;

    public AdminLoginScenario(IAdminServices adminServices)
    {
        _adminServices = adminServices;
    }

    public string Name => "Login as admin";

    public async void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter admin password");

        LoginResult result = await _adminServices.Login(password);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "Incorrect password. Try again later.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        Thread.Sleep(1000);
    }
}