namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories;

public class XmpProfile : MemoryTiming
{
    public XmpProfile(int timingCL, int timingTrcd, int timingTrp, int frequencyMHz, int voltage)
        : base(timingCL, timingTrcd, timingTrp, frequencyMHz, voltage)
    {
    }
}