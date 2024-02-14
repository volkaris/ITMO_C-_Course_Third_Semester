using System.Collections.Generic;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Mesage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.InputtableEntities.User;

public class User
{
    private readonly Dictionary<string, UserMessage> _messages = new();

    public IReadOnlyCollection<UserMessage> Messages => _messages.Values.ToList();

    public User ReceiveMessage(Message message)
    {
        _messages.Add(message.UniqieId, new UserMessage(message));
        return this;
    }

    public string TrackReceivedMessages()
    {
        var stringBuilder = new StringBuilder();

        foreach (UserMessage userMessage in _messages.Values)
        {
            stringBuilder.Append(userMessage.Status);
            stringBuilder.Append('\n');
            stringBuilder.Append(userMessage.Message);
            stringBuilder.Append('\n');
        }

        return stringBuilder.ToString();
    }

    public ReadStatus ReadMessage(Message message)
    {
        if (!_messages.ContainsKey(message.UniqieId))
            return new ReadStatus.UnsuccesfullRead("This message doesn't exist");

        return _messages[message.UniqieId].ReadMessage();
    }
}