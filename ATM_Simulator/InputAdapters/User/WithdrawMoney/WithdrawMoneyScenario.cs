using Core.InputPorts.IScenarios;
using Core.OperationsResults;
using Core.OutputPorts.OperationType;
using Core.UserServices;
using Spectre.Console;

namespace InputAdapters.User.WithdrawMoney;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IUserServices _userService;

    public WithdrawMoneyScenario(IUserServices userService)
    {
        _userService = userService;
    }

    public string Name => "Withdraw Money";

    public async void Run()
    {
        uint substractAmount =
            AnsiConsole.Ask<uint>("Enter amount of money that you want to withdraw from the account");

        OperationResult result = await _userService.ChangeBalance(-(int)substractAmount, new Substraction());

        string message = result switch
        {
            OperationResult.Success => "Successful substractring",
            OperationResult.Unsuccess unsuccess => unsuccess.FailReason,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        Console.ReadLine();
    }
}