using Itmo.ObjectOrientedProgramming.Lab4.CommandExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileSystemCommands;

public class Disconnect : ICommand
{
    public CommandsExecutionResult ExecuteCommand(Context currentContext)
    {
        currentContext.CurrentPath = null;
        return new CommandsExecutionResult.SuccessCommandExecution();
    }
}