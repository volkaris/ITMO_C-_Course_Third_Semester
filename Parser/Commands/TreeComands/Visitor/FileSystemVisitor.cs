using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemElements;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeComands.Visitor;

public class FileSystemVisitor : IVisitor<Directory>, IVisitor<File>
{
    private readonly string _currentIndent;
    private int _depth;

    public FileSystemVisitor(string pathToConfigFile)
    {
        try
        {
            _currentIndent = System.IO.File.ReadAllText(pathToConfigFile);
        }
        catch
        {
            _currentIndent = "|   ";
        }
    }

    public void Visit(Directory fileSystemElement)
    {
        string result = string.Concat(Enumerable.Repeat(_currentIndent, _depth)) + fileSystemElement.Name;
        Console.WriteLine(result);

        _depth += 1;

        foreach (IFileSystemElement element in fileSystemElement.FileSystemElements) element.Accept(this);

        _depth -= 1;
    }

    public void Visit(File fileSystemElement)
    {
        Console.WriteLine(string.Concat(Enumerable.Repeat(_currentIndent, _depth)) + fileSystemElement.Name);
    }
}