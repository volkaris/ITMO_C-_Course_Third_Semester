using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeComands.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemElements;

public interface IFileSystemElement
{
    public void Accept(IVisitor visitor);
}