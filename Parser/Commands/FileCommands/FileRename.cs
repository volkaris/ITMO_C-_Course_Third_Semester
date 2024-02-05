using Itmo.ObjectOrientedProgramming.Lab4.CommandExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class FileRename : ICommand
{
    private string _sourcePath;
    private string _newName;

    public FileRename(string sourcePath, string newName)
    {
        _sourcePath = sourcePath;
        _newName = newName;
    }

    public CommandsExecutionResult ExecuteCommand(Context currentContext)
    {
        string? path = currentContext.CurrentPath;

        if (path is null) return new CommandsExecutionResult.UnsuccessCommandExecution("You forgot to connect");

        FileSystemExecutionResult result =
            currentContext.FileSystem.FileRename(path, _sourcePath, _newName);

        if (result is FileSystemExecutionResult.UnsuccessFileSystemExecution unsuccess)
            return new CommandsExecutionResult.UnsuccessCommandExecution(unsuccess.FailReason);

        return new CommandsExecutionResult.SuccessCommandExecution();
    }
}