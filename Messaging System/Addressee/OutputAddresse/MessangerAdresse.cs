using Itmo.ObjectOrientedProgramming.Lab3.Entities.OutputtableEntities.Messanger;
using Itmo.ObjectOrientedProgramming.Lab3.Mesage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.OutputAddresse;

public class MessangerAdresse : IAddressee
{
    private readonly IMessanger _messanger;

    public MessangerAdresse(IMessanger messanger)
    {
        _messanger = messanger;
    }

    public IAddressee ReceiveMessage(Message message)
    {
        _messanger.Write(message.Render());
        return this;
    }
}