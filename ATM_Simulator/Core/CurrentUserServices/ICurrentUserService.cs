using Core.OutputPorts;

namespace Core.CurrentUserServices;

public interface ICurrentUserService
{
    User? User { get; }
}