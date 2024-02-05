using Core.OperationsResults;
using Core.OutputPorts.OperationType;

namespace Core.UserServices;

public interface IUserServices
{
    public Task<LoginResult> Login(string id, string password);
    public Task<CheckBalanceResult> CheckBalance();
    public Task<OperationResult> ChangeBalance(int value, IOperationType operationType);

    public Task<CheckOperationHistoryResult> CheckOperationHistory();
}