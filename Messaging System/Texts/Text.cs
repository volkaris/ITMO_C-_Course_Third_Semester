using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Texts;

public class Text : IText
{
    private readonly string _content;
    private List<ITextModifier> _modifiers;

    public Text(string content)
    {
        _modifiers = new List<ITextModifier>();
        _content = content;
    }

    public Text(string content, IEnumerable<ITextModifier> modifiers)
    {
        _content = content;
        _modifiers = modifiers.ToList();
    }

    public IText AddModifier(ITextModifier modifier)
    {
        _modifiers.Add(modifier);
        return this;
    }

    public string Render()
    {
        return _modifiers.Aggregate(
            _content,
            (content, m) => m.Modify(content));
    }
}