using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts;

public class Context
{
    public Context(string? currentPath, IFileSystem fileSystem)
    {
        CurrentPath = currentPath;
        FileSystem = fileSystem;
    }

    public IFileSystem FileSystem { get; }
    internal string? CurrentPath { get; set; }
}