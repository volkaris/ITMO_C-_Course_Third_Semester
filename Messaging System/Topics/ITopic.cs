using Itmo.ObjectOrientedProgramming.Lab3.Mesage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public interface ITopic
{
    ITopic SendMessageToAddressee(Message message);
}