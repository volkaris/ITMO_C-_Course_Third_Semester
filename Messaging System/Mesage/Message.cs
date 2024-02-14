using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Texts;

namespace Itmo.ObjectOrientedProgramming.Lab3.Mesage;

public record Message
{
    private readonly Text _header;
    private readonly Text _body;

    public Message(string header, string body, int priorityLevel)
    {
        _header = new Text(header);
        _body = new Text(body);
        PriorityLevel = priorityLevel;
        UniqieId = Guid.NewGuid().ToString();
    }

    public string UniqieId { get; }

    public int PriorityLevel { get; }

    public Message AddModifier(ITextModifier modifier)
    {
        _header.AddModifier(modifier);
        _body.AddModifier(modifier);
        return this;
    }

    public override int GetHashCode()
    {
        return UniqieId.GetHashCode(StringComparison.InvariantCulture);
    }

    public string Render()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append(_header.Render());
        stringBuilder.Append('\n');
        stringBuilder.Append(_body.Render());
        stringBuilder.Append('\n');
        return stringBuilder.ToString();
    }
}