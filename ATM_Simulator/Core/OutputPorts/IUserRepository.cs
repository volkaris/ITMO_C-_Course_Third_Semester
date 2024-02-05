using Core.OutputPorts.OperationType;

namespace Core.OutputPorts;

public interface IUserRepository
{
    public Task<bool> AddBankUser(string id, string password);

    Task<User?> LogAsUser(string id, string password);
    Task<long?> CheckBalance();
    Task<bool> ChangeBalance(long value, IOperationType operationType);
    Task<string?> CheckOperationHistory();
}