using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilePrinters;

public class ConsoleFilePrinter : IFilePrinter
{
    public void Print(string pathToFile)
    {
        string fileText = "\n" + File.ReadAllText(pathToFile) + "\n";
        Console.WriteLine(fileText);
    }
}