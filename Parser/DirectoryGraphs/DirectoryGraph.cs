using System.IO;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemElements.Directory;
using File = Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemElements.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.DirectoryGraphs;

public class DirectoryGraph : IDirectoryGraph
{
    private int _depth;
    private int _currentDepth = 1;

    public DirectoryGraph(int depth)
    {
        _depth = depth;
    }

    public Directory ConfigurateDirectoryGraph(string directoryLocation)
    {
        var directory = new Directory(Path.GetFileName(directoryLocation));
        if (_currentDepth <= _depth)
        {
            ++_currentDepth;
            string[] files = System.IO.Directory.GetFiles(directoryLocation);
            foreach (string file in files) directory.AddChild(new File(Path.GetFileName(file)));

            string[] subdirectories = System.IO.Directory.GetDirectories(directoryLocation);
            foreach (string subdirectory in subdirectories) directory.AddChild(ConfigurateDirectoryGraph(subdirectory));
        }

        return directory;
    }
}