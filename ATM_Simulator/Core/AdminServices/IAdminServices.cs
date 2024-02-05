using Core.OperationsResults;

namespace Core.AdminServices;

public interface IAdminServices
{
    public Task<LoginResult> Login(string password);

    public Task<OperationResult> AddUser(string id, string password);
}