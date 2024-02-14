using Itmo.ObjectOrientedProgramming.Lab3.Addressee.InputAdressee.UserAddresse;
using Itmo.ObjectOrientedProgramming.Lab3.Mesage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.InputAdressee.UserProxies.Proxy;

public class DefenceFromInsufficientImportance : IAddressee
{
    private readonly UserAddressee _userAddressee;
    private readonly int _minPriority;

    public DefenceFromInsufficientImportance(UserAddressee userAddressee, int minPriority)
    {
        _userAddressee = userAddressee;
        _minPriority = minPriority;
    }

    public IAddressee ReceiveMessage(Message message)
    {
        if (message.PriorityLevel >= _minPriority)
            _userAddressee.ReceiveMessage(message);
        return this;
    }
}