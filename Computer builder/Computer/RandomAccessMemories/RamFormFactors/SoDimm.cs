using Itmo.ObjectOrientedProgramming.Lab2.Sizes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.RamFormFactors;

public class SoDimm : RamFormFactor
{
    public SoDimm()
        : base(new Size(5, 9))
    {
    }
}