namespace Core.OutputPorts;

public interface IAdminRepository
{
    public Task<User?> LogAsAdmin(string password);
}