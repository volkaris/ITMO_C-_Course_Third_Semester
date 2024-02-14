using System;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.GraphicCards;
using Itmo.ObjectOrientedProgramming.Lab2.PciVersions;
using Itmo.ObjectOrientedProgramming.Lab2.Sizes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;

public class GraphicCardBuilder : IGraphicCardBuilder
{
    private Size? _size;
    private int? _amountOfMemory;
    private IPci? _pciVersion;
    private int? _chipFrequency;
    private int? _consumingEnergy;
    private string? _name;

    public GraphicCardBuilder()
    {
    }

    public GraphicCardBuilder(GraphicCard graphicCard)
    {
        _size = graphicCard.Size;
        _amountOfMemory = graphicCard.AmountOfMemory;
        _pciVersion = graphicCard.PciVersion;
        _chipFrequency = graphicCard.ChipFrequency;
        _consumingEnergy = graphicCard.ConsumingEnergy;
    }

    public IGraphicCardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IGraphicCardBuilder WithSize(Size size)
    {
        _size = size;
        return this;
    }

    public IGraphicCardBuilder WithMemoryAmount(int amountOfMemory)
    {
        _amountOfMemory = amountOfMemory;
        return this;
    }

    public IGraphicCardBuilder WithPciVersion(IPci pciVersion)
    {
        _pciVersion = pciVersion;
        return this;
    }

    public IGraphicCardBuilder WithChipFrequency(int chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public IGraphicCardBuilder ConsumingEnergy(int consumingEnergy)
    {
        _consumingEnergy = consumingEnergy;
        return this;
    }

    public GraphicCard Build()
    {
        return new GraphicCard(
            _size ?? throw new ArgumentNullException(nameof(_size)),
            _amountOfMemory ?? throw new ArgumentNullException(nameof(_amountOfMemory)),
            _chipFrequency ?? throw new ArgumentNullException(nameof(_chipFrequency)),
            _consumingEnergy ?? throw new ArgumentNullException(nameof(_consumingEnergy)),
            _pciVersion ?? throw new ArgumentNullException(nameof(_pciVersion)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}