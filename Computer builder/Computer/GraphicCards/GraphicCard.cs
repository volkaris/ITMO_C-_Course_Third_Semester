using Itmo.ObjectOrientedProgramming.Lab2.PciVersions;
using Itmo.ObjectOrientedProgramming.Lab2.Sizes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.GraphicCards;

public class GraphicCard
{
    internal GraphicCard(
        Size size,
        int amountOfMemory,
        int chipFrequency,
        int consumingEnergy,
        IPci pciVersion,
        string name)
    {
        Size = size;
        AmountOfMemory = amountOfMemory;
        ChipFrequency = chipFrequency;
        ConsumingEnergy = consumingEnergy;
        PciVersion = pciVersion;
        Name = name;
    }

    public Size Size { get; }
    public string Name { get; }
    public int AmountOfMemory { get; }
    public IPci PciVersion { get; }
    public int ChipFrequency { get; }
    public int ConsumingEnergy { get; }
}