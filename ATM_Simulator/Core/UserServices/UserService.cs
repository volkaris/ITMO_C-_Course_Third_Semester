using Core.CurrentUserServices;
using Core.OperationsResults;
using Core.OutputPorts;
using Core.OutputPorts.OperationType;

namespace Core.UserServices;

public class UserService : IUserServices
{
    private readonly IUserRepository _repository;
    private readonly CurrentUser _currentUser;

    public UserService(IUserRepository repository, CurrentUser currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<LoginResult> Login(string id, string password)
    {
        User? user = await _repository.LogAsUser(id, password);

        if (user is null) return new LoginResult.NotFound();

        _currentUser.User = user;
        return new LoginResult.Success();
    }

    public async Task<CheckBalanceResult> CheckBalance()
    {
        long? result = await _repository.CheckBalance();

        if (result is not null) return new CheckBalanceResult.Success(result.Value);

        return new CheckBalanceResult.Unsuccess();
    }

    public async Task<OperationResult> ChangeBalance(int value, IOperationType operationType)
    {
        long newBalance;
        if (await CheckBalance() is CheckBalanceResult.Success success) newBalance = success.Balance + value;
        else
            return new OperationResult.Unsuccess("Failed due to problems with balance checking");

        if (newBalance < 0) return new OperationResult.Unsuccess("You don't have enough money in yours account");

        bool successBalanceChange = await _repository.ChangeBalance(newBalance, operationType);

        if (successBalanceChange) return new OperationResult.Success();

        return new OperationResult.Unsuccess("Unknown error error");
    }

    public async Task<CheckOperationHistoryResult> CheckOperationHistory()
    {
        string? result = await _repository.CheckOperationHistory();

        if (result is not null) return new CheckOperationHistoryResult.Success(result);

        return new CheckOperationHistoryResult.Unsuccess();
    }
}