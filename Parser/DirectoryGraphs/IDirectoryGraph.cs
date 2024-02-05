using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemElements;

namespace Itmo.ObjectOrientedProgramming.Lab4.DirectoryGraphs;

public interface IDirectoryGraph
{
    public Directory ConfigurateDirectoryGraph(string directoryLocation);
}