using Itmo.ObjectOrientedProgramming.Lab3.Entities.OutputtableEntities.DisplayDriver;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.OutputtableEntities.Display;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void Write(string message)
    {
        _displayDriver.ClearOutput();
        _displayDriver.WriteMessage(message);
    }
}