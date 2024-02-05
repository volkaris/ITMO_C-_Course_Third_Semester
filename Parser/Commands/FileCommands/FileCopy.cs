using Itmo.ObjectOrientedProgramming.Lab4.CommandExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class FileCopy : ICommand
{
    private string _sourcePath;
    private string _destinationPath;

    public FileCopy(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandsExecutionResult ExecuteCommand(Context currentContext)
    {
        string? path = currentContext.CurrentPath;

        if (path is null) return new CommandsExecutionResult.UnsuccessCommandExecution("You forgot to connect");

        if (!AbsolutePathValidator.IsAbsolutePath(_sourcePath)) _sourcePath = currentContext.CurrentPath + _sourcePath;

        if (!AbsolutePathValidator.IsAbsolutePath(_destinationPath))
            _destinationPath = currentContext.CurrentPath + _destinationPath;

        FileSystemExecutionResult result =
            currentContext.FileSystem.FileCopy(path, _sourcePath, _destinationPath);

        if (result is FileSystemExecutionResult.UnsuccessFileSystemExecution unsuccess)
            return new CommandsExecutionResult.UnsuccessCommandExecution(unsuccess.FailReason);

        return new CommandsExecutionResult.SuccessCommandExecution();
    }
}