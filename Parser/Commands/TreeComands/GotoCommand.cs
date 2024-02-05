using Itmo.ObjectOrientedProgramming.Lab4.CommandExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeComands;

public class GotoCommand : ICommand
{
    private readonly string _newPath;

    public GotoCommand(string newPath)
    {
        _newPath = newPath;
    }

    public CommandsExecutionResult ExecuteCommand(Context currentContext)
    {
        currentContext.CurrentPath = _newPath;
        return new CommandsExecutionResult.SuccessCommandExecution();
    }
}