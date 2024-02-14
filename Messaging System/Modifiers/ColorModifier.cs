using System.Drawing;
using static Crayon.Output;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class ColorModifier : ITextModifier
{
    private readonly Color _color;

    public ColorModifier(Color color)
    {
        _color = color;
    }

    public string Modify(string value)
    {
        return Rgb(_color.R, _color.G, _color.B).Text(value);
    }
}