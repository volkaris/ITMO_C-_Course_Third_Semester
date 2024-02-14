namespace Itmo.ObjectOrientedProgramming.Lab2.Sizes;

public record Size(int Height, int Width)
{
    public bool IsFittable(Size other)
    {
        return Height <= other.Height && Width <= other.Width;
    }
}