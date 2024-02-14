using Itmo.ObjectOrientedProgramming.Lab2.Sizes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.RamFormFactors;

public class Dimm : RamFormFactor
{
    public Dimm()
        : base(new Size(10, 15))
    {
    }
}