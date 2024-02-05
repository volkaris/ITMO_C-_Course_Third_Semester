using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeComands.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.DirectoryGraphs;
using Itmo.ObjectOrientedProgramming.Lab4.FilePrinters;
using Itmo.ObjectOrientedProgramming.Lab4.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public FileSystemExecutionResult FileCopy(string currentPath, string sourcePath, string destinationPath)
    {
        if (!AbsolutePathValidator.IsAbsolutePath(sourcePath))
            sourcePath = currentPath + System.IO.Path.DirectorySeparatorChar + sourcePath;

        if (!AbsolutePathValidator.IsAbsolutePath(destinationPath))
            destinationPath = currentPath + System.IO.Path.DirectorySeparatorChar + destinationPath;

        try
        {
            System.IO.File.Copy(sourcePath, destinationPath);
            return new FileSystemExecutionResult.SuccessFileSystemExecution();
        }
        catch (Exception e)
        {
            return new FileSystemExecutionResult.UnsuccessFileSystemExecution(e.Message);
        }
    }

    public FileSystemExecutionResult FileDelete(string currentPath, string sourcePath)
    {
        if (!AbsolutePathValidator.IsAbsolutePath(sourcePath))
            sourcePath = currentPath + System.IO.Path.DirectorySeparatorChar + sourcePath;
        try
        {
            System.IO.File.Delete(sourcePath);
            return new FileSystemExecutionResult.SuccessFileSystemExecution();
        }
        catch (Exception e)
        {
            return new FileSystemExecutionResult.UnsuccessFileSystemExecution(e.Message);
        }
    }

    public FileSystemExecutionResult FileMove(string currentPath, string sourcePath, string destinationPath)
    {
        if (!AbsolutePathValidator.IsAbsolutePath(sourcePath))
            sourcePath = currentPath + System.IO.Path.DirectorySeparatorChar + sourcePath;

        if (!AbsolutePathValidator.IsAbsolutePath(destinationPath))
            destinationPath = currentPath + System.IO.Path.DirectorySeparatorChar + destinationPath;
        try
        {
            System.IO.File.Move(sourcePath, destinationPath);
            return new FileSystemExecutionResult.SuccessFileSystemExecution();
        }
        catch (Exception e)
        {
            return new FileSystemExecutionResult.UnsuccessFileSystemExecution(e.Message);
        }
    }

    public FileSystemExecutionResult FileRename(string currentPath, string sourcePath, string newName)
    {
        if (!AbsolutePathValidator.IsAbsolutePath(sourcePath))
            sourcePath = currentPath + System.IO.Path.DirectorySeparatorChar + sourcePath;

        string newPath = currentPath + System.IO.Path.DirectorySeparatorChar + newName;

        try
        {
            System.IO.File.Move(sourcePath, newPath);

            return new FileSystemExecutionResult.SuccessFileSystemExecution();
        }
        catch (Exception e)
        {
            return new FileSystemExecutionResult.UnsuccessFileSystemExecution(e.Message);
        }
    }

    public FileSystemExecutionResult FileShow(string currentPath, IFilePrinter printer, string sourcePath)
    {
        if (!AbsolutePathValidator.IsAbsolutePath(sourcePath))
            sourcePath = currentPath + System.IO.Path.DirectorySeparatorChar + sourcePath;
        try
        {
            printer.Print(sourcePath);
            return new FileSystemExecutionResult.SuccessFileSystemExecution();
        }
        catch (Exception e)
        {
            return new FileSystemExecutionResult.UnsuccessFileSystemExecution(e.Message);
        }
    }

    public FileSystemExecutionResult TreeList(IVisitor visitor, Context currentPath, int depth)
    {
        try
        {
            string? path = currentPath.CurrentPath;

            if (path is null)
                return new FileSystemExecutionResult.UnsuccessFileSystemExecution("You forgot to connect");

            new DirectoryGraph(depth).ConfigurateDirectoryGraph(path).Accept(visitor);
            return new FileSystemExecutionResult.SuccessFileSystemExecution();
        }
        catch (Exception e)
        {
            return new FileSystemExecutionResult.UnsuccessFileSystemExecution(e.Message);
        }
    }
}