using Core.InputPorts.IScenarios;
using Core.OperationsResults;
using Core.OutputPorts.OperationType;
using Core.UserServices;
using Spectre.Console;

namespace InputAdapters.User.AddMoney;

public class AddMoneyScenario : IScenario
{
    private readonly IUserServices _userService;

    public AddMoneyScenario(IUserServices userService)
    {
        _userService = userService;
    }

    public string Name => "Add Money";

    public async void Run()
    {
        uint addAmount = AnsiConsole.Ask<uint>("Enter amount of money that you want to add to the account");

        OperationResult result = await _userService.ChangeBalance((int)addAmount, new Adding());

        string message = result switch
        {
            OperationResult.Success => "Successful adding",
            OperationResult.Unsuccess unsuccess => unsuccess.FailReason,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        Console.ReadLine();
    }
}