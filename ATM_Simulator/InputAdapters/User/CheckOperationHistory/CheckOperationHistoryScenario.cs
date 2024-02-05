using Core.InputPorts.IScenarios;
using Core.OperationsResults;
using Core.UserServices;
using Spectre.Console;

namespace InputAdapters.User.CheckOperationHistory;

public class CheckOperationHistoryScenario : IScenario
{
    private readonly IUserServices _userService;

    public CheckOperationHistoryScenario(IUserServices userService)
    {
        _userService = userService;
    }

    public string Name => "Check Operation History";

    public async void Run()
    {
        CheckOperationHistoryResult result = await _userService.CheckOperationHistory();

        string message = result switch
        {
            CheckOperationHistoryResult.Success success => success.History,
            CheckOperationHistoryResult.Unsuccess => "Error happened",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        Console.ReadLine();
    }
}