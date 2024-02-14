using Itmo.ObjectOrientedProgramming.Lab2.Sizes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.RamFormFactors;

public class FbDimm : RamFormFactor
{
    public FbDimm()
        : base(new Size(9, 6))
    {
    }
}