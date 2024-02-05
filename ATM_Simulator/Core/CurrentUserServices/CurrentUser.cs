using Core.OutputPorts;

namespace Core.CurrentUserServices;

public class CurrentUser : ICurrentUserService
{
    public User? User { get; internal set; }
}