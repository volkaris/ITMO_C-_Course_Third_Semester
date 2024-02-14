using Itmo.ObjectOrientedProgramming.Lab3.Entities.OutputtableEntities.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Mesage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.OutputAddresse;

public class DisplayAdresse : IAddressee
{
    private readonly IDisplay _display;

    public DisplayAdresse(IDisplay display)
    {
        _display = display;
    }

    public IAddressee ReceiveMessage(Message message)
    {
        _display.Write(message.Render());
        return this;
    }
}