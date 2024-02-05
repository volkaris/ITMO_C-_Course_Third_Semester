using Itmo.ObjectOrientedProgramming.Lab4.CommandExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeComands.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeComands;

public class TreeList : ICommand
{
    private readonly int _depth;
    private readonly IVisitor _visitor;

    public TreeList(IVisitor visitor, int depth)
    {
        _visitor = visitor;
        _depth = depth;
    }

    public CommandsExecutionResult ExecuteCommand(Context currentContext)
    {
        string? path = currentContext.CurrentPath;

        if (path is null) return new CommandsExecutionResult.UnsuccessCommandExecution("You forgot to connect");

        FileSystemExecutionResult result =
            currentContext.FileSystem.TreeList(_visitor, currentContext, _depth);

        if (result is FileSystemExecutionResult.UnsuccessFileSystemExecution unsuccess)
            return new CommandsExecutionResult.UnsuccessCommandExecution(unsuccess.FailReason);

        return new CommandsExecutionResult.SuccessCommandExecution();
    }
}