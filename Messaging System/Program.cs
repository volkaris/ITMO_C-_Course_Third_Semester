using System.Collections.Generic;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.OutputAddresse;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.OutputtableEntities.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.OutputtableEntities.DisplayDriver;
using Itmo.ObjectOrientedProgramming.Lab3.Mesage;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public static class Program
{
    public static void Main()
    {
        var firstMessage = new Message(
            "first header",
            "first text abobus",
            10);
        var mockableDisplayDriver =
            new DisplayDriver(new List<ITextModifier>() { new ColorModifier(Color.Chartreuse) });

        var display = new Display(mockableDisplayDriver);

        var displayAdresseMock = new DisplayAdresse(display);

        var topic = new Topic(displayAdresseMock, "abobus");

        topic.SendMessageToAddressee(firstMessage);
    }
}