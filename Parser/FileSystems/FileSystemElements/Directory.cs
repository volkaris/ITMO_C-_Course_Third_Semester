using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeComands.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemElements;

public class Directory : IFileSystemElement
{
    private readonly List<IFileSystemElement> _fileSystemElements = new();

    public Directory(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public IEnumerable<IFileSystemElement> FileSystemElements => _fileSystemElements;

    public void AddChild(IFileSystemElement element)
    {
        _fileSystemElements.Add(element);
    }

    public void Accept(IVisitor visitor)
    {
        if (visitor is IVisitor<Directory> v)
            v.Visit(this);
    }
}