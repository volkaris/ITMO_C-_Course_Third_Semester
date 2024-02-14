using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Texts;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.OutputtableEntities.DisplayDriver;

public class DisplayDriver : IDisplayDriver
{
    private readonly List<ITextModifier> _modifiers;

    public DisplayDriver(IEnumerable<ITextModifier> modifiers)
    {
        _modifiers = modifiers.ToList();
    }

    public void ClearOutput()
    {
        Console.Clear();
    }

    public void WriteMessage(string message)
    {
        var messageText = new Text(message);

        foreach (ITextModifier modifier in _modifiers)
            messageText.AddModifier(modifier);

        Console.WriteLine(messageText.Render());
    }
}