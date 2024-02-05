using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeComands.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.FilePrinters;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystem
{
    public FileSystemExecutionResult FileCopy(string currentPath, string sourcePath, string destinationPath);
    public FileSystemExecutionResult FileDelete(string currentPath, string sourcePath);
    public FileSystemExecutionResult FileMove(string currentPath, string sourcePath, string destinationPath);
    public FileSystemExecutionResult FileRename(string currentPath, string sourcePath, string newName);

    public FileSystemExecutionResult FileShow(string currentPath, IFilePrinter printer, string sourcePath);
    public FileSystemExecutionResult TreeList(IVisitor visitor, Context currentPath, int depth);
}