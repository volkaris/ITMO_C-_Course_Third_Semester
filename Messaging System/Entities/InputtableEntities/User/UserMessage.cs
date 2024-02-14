using Itmo.ObjectOrientedProgramming.Lab3.Mesage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.InputtableEntities.User;

public class UserMessage
{
    public UserMessage(Message message)
    {
        Message = message;
        Status = new MessageStatus.NotRead();
    }

    public Message Message { get; }
    public MessageStatus Status { get; private set; }

    public ReadStatus ReadMessage()
    {
        if (Status is MessageStatus.Read)
            return new ReadStatus.UnsuccesfullRead("You trying to read message that had read already");

        Status = new MessageStatus.Read();
        return new ReadStatus.SuccefullRead();
    }
}