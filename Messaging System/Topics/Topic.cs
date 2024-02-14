using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Mesage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic : ITopic
{
    private readonly string _title;
    private readonly IAddressee _addressee;

    public Topic(IAddressee addressee, string title)
    {
        _title = title;
        _addressee = addressee;
    }

    public ITopic SendMessageToAddressee(Message message)
    {
        _addressee.ReceiveMessage(message);
        return this;
    }
}