using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Ddr;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.RamFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;

public interface IRandomAccessMemoryBuilder
{
    IRandomAccessMemoryBuilder WithName(string name);
    IRandomAccessMemoryBuilder WithPossibleAvailableFrequencies(IEnumerable<MemoryTiming> possibleAvailableFrequencies);
    IRandomAccessMemoryBuilder WithStandartMemoryTiming(MemoryTiming standartMemoryTiming);
    IRandomAccessMemoryBuilder WithSizeInGb(int sizeInGb);
    IRandomAccessMemoryBuilder WithFormFactor(RamFormFactor formFactor);
    IRandomAccessMemoryBuilder WithDdrVersion(IDdr ddrVersion);
    IRandomAccessMemoryBuilder WithPowerConsumption(double powerConsumption);

    RandomAccessMemory Build();
}