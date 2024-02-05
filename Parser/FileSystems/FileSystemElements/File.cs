using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeComands.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemElements;

public class File : IFileSystemElement
{
    public File(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Accept(IVisitor visitor)
    {
        if (visitor is IVisitor<File> v)
            v.Visit(this);
    }
}