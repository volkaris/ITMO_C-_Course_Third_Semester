using Itmo.ObjectOrientedProgramming.Lab3.Entities.InputtableEntities.User;
using Itmo.ObjectOrientedProgramming.Lab3.Mesage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.InputAdressee.UserAddresse;

public class UserAddressee : IAddressee
{
    private readonly User _user;

    public UserAddressee(User user)
    {
        _user = user;
    }

    public IAddressee ReceiveMessage(Message message)
    {
        _user.ReceiveMessage(message);
        return this;
    }
}