using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Ddr;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.RamFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories;

public class RandomAccessMemory : IRam
{
    private readonly List<MemoryTiming> _possibleAvailableFrequencies;

    internal RandomAccessMemory(
        MemoryTiming standartMemoryTiming,
        IEnumerable<MemoryTiming> possibleAvailableFrequencies,
        int sizeInGb,
        RamFormFactor formFactor,
        double powerConsumption,
        IDdr ddrVersion,
        string name)
    {
        StandartMemoryTiming = standartMemoryTiming;
        _possibleAvailableFrequencies = possibleAvailableFrequencies.ToList();
        SizeInGb = sizeInGb;
        FormFactor = formFactor;
        PowerConsumption = powerConsumption;
        DdrVersion = ddrVersion;
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Name { get; }
    public IReadOnlyCollection<MemoryTiming> PossibleAvailableFrequencies => _possibleAvailableFrequencies;

    public MemoryTiming StandartMemoryTiming { get; private set; }

    public int SizeInGb { get; }

    public RamFormFactor FormFactor { get; }

    public IDdr DdrVersion { get; }

    public double PowerConsumption { get; }

    public bool IsDdrStandartCompatibleWithMotherboardDdr(Motherboard motherboard)
    {
        return DdrVersion.Equals(motherboard.DdrStandard);
    }

    public void ChangeFrequenciesUsingJedec(MemoryTiming memoryTiming)
    {
        _possibleAvailableFrequencies.Add(StandartMemoryTiming);
        _possibleAvailableFrequencies.Remove(memoryTiming);
        StandartMemoryTiming = memoryTiming;
    }

    public void SetFrequencies(Motherboard motherboard)
    {
        ArgumentNullException.ThrowIfNull(motherboard);

        double currentRamFrequency = StandartMemoryTiming.FrequencyMHz;
        int maxMotherboardFrequency = motherboard.ChipSet.MaxMemoryFrequency;

        if (currentRamFrequency > maxMotherboardFrequency)
        {
            _possibleAvailableFrequencies.Add(StandartMemoryTiming);
            StandartMemoryTiming.FrequencyMHz = motherboard.ChipSet.MaxMemoryFrequency;
        }
    }
}