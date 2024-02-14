using Itmo.ObjectOrientedProgramming.Lab2.Sizes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.RamFormFactors;

public class RamFormFactor
{
    private readonly Size _size;

    public RamFormFactor(Size size)
    {
        _size = size;
    }

    public bool CanBeFitedInto(Size other)
    {
        return _size.Height <= other.Height && _size.Width <= other.Width;
    }
}