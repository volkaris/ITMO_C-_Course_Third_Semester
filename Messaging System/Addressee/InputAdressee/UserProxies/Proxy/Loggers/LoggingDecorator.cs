using Itmo.ObjectOrientedProgramming.Lab3.Mesage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.InputAdressee.UserProxies.Proxy.Loggers;

public class LoggingDecorator : IAddressee
{
    private readonly IAddressee _decoratee;

    public LoggingDecorator(
        IAddressee decoratee,
        ILogger logger)
    {
        _decoratee = decoratee;
        Logger = logger;
    }

    public ILogger Logger { get; }

    public IAddressee ReceiveMessage(Message message)
    {
        _decoratee.ReceiveMessage(message);
        Logger.Log(message);
        return this;
    }
}