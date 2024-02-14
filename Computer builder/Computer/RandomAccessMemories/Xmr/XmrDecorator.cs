using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Ddr;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.RamFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Xmr;

public abstract class XmrDecorator : IRam
{
    protected XmrDecorator(RandomAccessMemory memory)
    {
        DecoratedMemory = memory;
    }

    public abstract IReadOnlyCollection<MemoryTiming> PossibleAvailableFrequencies { get; }

    public abstract string Name { get; }
    public abstract MemoryTiming StandartMemoryTiming { get; }

    public abstract int SizeInGb { get; }
    public abstract RamFormFactor FormFactor { get; }

    public abstract IDdr DdrVersion { get; }
    public abstract double PowerConsumption { get; }

    protected IRam DecoratedMemory { get; }

    public abstract bool IsDdrStandartCompatibleWithMotherboardDdr(Motherboard motherboard);
    public abstract void ChangeFrequenciesUsingJedec(MemoryTiming memoryTiming);
    public abstract void SetFrequencies(Motherboard motherboard);
}