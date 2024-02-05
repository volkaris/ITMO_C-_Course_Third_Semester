using Core.AdminServices;
using Core.InputPorts.IScenarios;
using Core.OperationsResults;
using Spectre.Console;

namespace InputAdapters.Admin.AddUser;

public class AddUserScenario : IScenario
{
    private readonly IAdminServices _userService;

    public AddUserScenario(IAdminServices adminService)
    {
        _userService = adminService;
    }

    public string Name => "Adding new user";

    public async void Run()
    {
        string id = AnsiConsole.Ask<string>("Enter new user ID");

        string password = AnsiConsole.Ask<string>("Enter new user password");

        OperationResult result = await _userService.AddUser(id, password);

        string message = result switch
        {
            OperationResult.Success => "Successful adding",
            OperationResult.Unsuccess => "Unsuccessful adding",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        Console.ReadLine();
    }
}