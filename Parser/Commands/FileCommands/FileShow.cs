using Itmo.ObjectOrientedProgramming.Lab4.CommandExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.FilePrinters;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class FileShow : ICommand
{
    private string _sourcePath;
    private IFilePrinter _printer;

    public FileShow(IFilePrinter printer, string sourcePath)
    {
        _printer = printer;
        _sourcePath = sourcePath;
    }

    public CommandsExecutionResult ExecuteCommand(Context currentContext)
    {
        string? path = currentContext.CurrentPath;

        if (path is null) return new CommandsExecutionResult.UnsuccessCommandExecution("You forgot to connect");

        if (!AbsolutePathValidator.IsAbsolutePath(_sourcePath)) _sourcePath = currentContext.CurrentPath + _sourcePath;

        FileSystemExecutionResult result =
            currentContext.FileSystem.FileShow(path, _printer, _sourcePath);

        if (result is FileSystemExecutionResult.UnsuccessFileSystemExecution unsuccess)
            return new CommandsExecutionResult.UnsuccessCommandExecution(unsuccess.FailReason);

        return new CommandsExecutionResult.SuccessCommandExecution();
    }
}