using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Ddr;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.RamFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Xmr;

public class XmrMemory : XmrDecorator
{
    private readonly List<MemoryTiming> _xmpProfiles;

    public XmrMemory(RandomAccessMemory memory, IEnumerable<MemoryTiming> xmpProfiles)
        : base(memory)
    {
        _xmpProfiles = xmpProfiles.ToList();
        PossibleAvailableFrequencies = memory.PossibleAvailableFrequencies;
        Name = memory.Name;
        StandartMemoryTiming = memory.StandartMemoryTiming;
        SizeInGb = memory.SizeInGb;
        FormFactor = memory.FormFactor;
        DdrVersion = memory.DdrVersion;
        PowerConsumption = memory.PowerConsumption;
    }

    public IReadOnlyCollection<MemoryTiming> XmpProfiles => _xmpProfiles;

    public override IReadOnlyCollection<MemoryTiming> PossibleAvailableFrequencies { get; }
    public override string Name { get; }
    public override MemoryTiming StandartMemoryTiming { get; }
    public override int SizeInGb { get; }
    public override RamFormFactor FormFactor { get; }
    public override IDdr DdrVersion { get; }
    public override double PowerConsumption { get; }

    public override bool IsDdrStandartCompatibleWithMotherboardDdr(Motherboard motherboard)
    {
        return DecoratedMemory.IsDdrStandartCompatibleWithMotherboardDdr(motherboard);
    }

    public override void ChangeFrequenciesUsingJedec(MemoryTiming memoryTiming)
    {
        DecoratedMemory.ChangeFrequenciesUsingJedec(memoryTiming);
    }

    public override void SetFrequencies(Motherboard motherboard)
    {
        DecoratedMemory.SetFrequencies(motherboard);
    }

    public void ChangeFrequenciesUsingXmp(XmpProfile xmpProfile)
    {
        ArgumentNullException.ThrowIfNull(xmpProfile);

        _xmpProfiles.Add(StandartMemoryTiming);
        _xmpProfiles.Remove(xmpProfile);
    }
}