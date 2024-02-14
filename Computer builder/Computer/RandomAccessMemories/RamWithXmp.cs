using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Ddr;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.RamFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories;

public class RamWithXmp : RandomAccessMemory
{
    private readonly List<MemoryTiming> _xmpProfiles;

    public RamWithXmp(
        MemoryTiming standartMemoryTiming,
        IEnumerable<MemoryTiming> possibleAvailableFrequencies,
        IEnumerable<MemoryTiming> xmpProfiles,
        int sizeInGb,
        RamFormFactor formFactor,
        int powerConsumption,
        IDdr ddrVersion,
        string name)
        : base(
            standartMemoryTiming,
            possibleAvailableFrequencies,
            sizeInGb,
            formFactor,
            powerConsumption,
            ddrVersion,
            name)
    {
        _xmpProfiles = xmpProfiles.ToList();
    }

    public IReadOnlyCollection<MemoryTiming> XmpProfiles => _xmpProfiles;

    public void ChangeFrequenciesUsingXmp(XmpProfile xmpProfile)
    {
        ArgumentNullException.ThrowIfNull(xmpProfile);
        _xmpProfiles.Add(StandartMemoryTiming);
        _xmpProfiles.Remove(xmpProfile);
    }
}