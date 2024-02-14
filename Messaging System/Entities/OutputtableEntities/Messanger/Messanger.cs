using System;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.OutputtableEntities.Messanger;

public class Messanger : IMessanger
{
    public void Write(string message)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("Output using messanger\n");

        stringBuilder.Append(message);
        stringBuilder.Append('\n');

        Console.WriteLine(stringBuilder.ToString());
    }
}