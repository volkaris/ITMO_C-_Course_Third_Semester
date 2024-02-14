using Itmo.ObjectOrientedProgramming.Lab2.Computer.GraphicCards;
using Itmo.ObjectOrientedProgramming.Lab2.PciVersions;
using Itmo.ObjectOrientedProgramming.Lab2.Sizes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;

public interface IGraphicCardBuilder
{
    IGraphicCardBuilder WithName(string name);
    IGraphicCardBuilder WithSize(Size size);
    IGraphicCardBuilder WithMemoryAmount(int amountOfMemory);
    IGraphicCardBuilder WithPciVersion(IPci pciVersion);
    IGraphicCardBuilder WithChipFrequency(int chipFrequency);
    IGraphicCardBuilder ConsumingEnergy(int consumingEnergy);
    GraphicCard Build();
}