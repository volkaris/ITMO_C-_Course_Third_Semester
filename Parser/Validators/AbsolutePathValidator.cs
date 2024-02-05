using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Validators;

public static class AbsolutePathValidator
{
    public static bool IsAbsolutePath(string path)
    {
        return Path.IsPathRooted(path);
    }
}