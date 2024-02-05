using Core.InputPorts.IScenarios;
using Core.OperationsResults;
using Core.UserServices;
using Spectre.Console;

namespace InputAdapters.User.CheckBalance;

public class CheckBalanceScenario : IScenario
{
    private readonly IUserServices _userService;

    public CheckBalanceScenario(IUserServices userService)
    {
        _userService = userService;
    }

    public string Name => "Check balance";

    public async void Run()
    {
        CheckBalanceResult result = await _userService.CheckBalance();

        string message = result switch
        {
            CheckBalanceResult.Success success => "Your balance is : " + success.Balance,
            CheckBalanceResult.Unsuccess => "Error happened",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        Console.ReadLine();
    }
}