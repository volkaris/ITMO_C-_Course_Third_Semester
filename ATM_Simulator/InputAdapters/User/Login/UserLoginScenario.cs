using Core.InputPorts.IScenarios;
using Core.OperationsResults;
using Core.UserServices;
using Spectre.Console;

namespace InputAdapters.User.Login;

public class UserLoginScenario : IScenario
{
    private readonly IUserServices _userService;

    public UserLoginScenario(IUserServices userService)
    {
        _userService = userService;
    }

    public string Name => "Login as user";

    public async void Run()
    {
        string id = AnsiConsole.Ask<string>("Enter your ID");

        string password = AnsiConsole.Ask<string>("Enter your password");

        LoginResult result = await _userService.Login(id, password);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        Console.ReadLine();
    }
}