using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Ddr;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.RamFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories;

public interface IRam
{
    public IReadOnlyCollection<MemoryTiming> PossibleAvailableFrequencies { get; }
    public string Name { get; }

    public MemoryTiming StandartMemoryTiming { get; }

    public int SizeInGb { get; }

    public RamFormFactor FormFactor { get; }

    public IDdr DdrVersion { get; }

    public double PowerConsumption { get; }

    public bool IsDdrStandartCompatibleWithMotherboardDdr(Motherboard motherboard);

    public void ChangeFrequenciesUsingJedec(MemoryTiming memoryTiming);

    public void SetFrequencies(Motherboard motherboard);
}