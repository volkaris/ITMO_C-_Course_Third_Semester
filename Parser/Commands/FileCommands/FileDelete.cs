using Itmo.ObjectOrientedProgramming.Lab4.CommandExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class FileDelete : ICommand
{
    private string _sourcePath;

    public FileDelete(string sourcePath)
    {
        _sourcePath = sourcePath;
    }

    public CommandsExecutionResult ExecuteCommand(Context currentContext)
    {
        string? path = currentContext.CurrentPath;

        if (path is null) return new CommandsExecutionResult.UnsuccessCommandExecution("You forgot to connect");

        if (!AbsolutePathValidator.IsAbsolutePath(_sourcePath)) _sourcePath = currentContext.CurrentPath + _sourcePath;

        FileSystemExecutionResult
            result = currentContext.FileSystem.FileDelete(path, _sourcePath);

        if (result is FileSystemExecutionResult.UnsuccessFileSystemExecution unsuccess)
            return new CommandsExecutionResult.UnsuccessCommandExecution(unsuccess.FailReason);

        return new CommandsExecutionResult.SuccessCommandExecution();
    }
}