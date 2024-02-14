namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories;

public class JedecProfile : MemoryTiming
{
    public JedecProfile(int timingCL, int timingTrcd, int timingTrp, int frequencyMHz, int voltage)
        : base(timingCL, timingTrcd, timingTrp, frequencyMHz, voltage)
    {
    }
}