using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Mesage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.InputAdressee.UserProxies.Proxy.Loggers;

public class Logger : ILogger
{
    private readonly List<Log> _logs = new();

    public IReadOnlyCollection<Log> Logs => _logs;

    public void Log(Message message)
    {
        _logs.Add(new Log(message.Render(), DateTime.Now));
    }
}