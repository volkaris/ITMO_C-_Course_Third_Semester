using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemElements;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeComands.Visitor;

public interface IVisitor
{
}

public interface IVisitor<in T> : IVisitor
    where T : IFileSystemElement
{
    void Visit(T fileSystemElement);
}