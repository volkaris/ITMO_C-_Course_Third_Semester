using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.GraphicCards;
using Itmo.ObjectOrientedProgramming.Lab2.PciVersions;
using Itmo.ObjectOrientedProgramming.Lab2.Sizes;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComponentsRepository;

public class GraphicCardRepository : IComponentRepository<GraphicCard>
{
    private Dictionary<string, GraphicCard> _availableComponents = new();

    public GraphicCardRepository()
    {
        GraphicCard msiGeForceRtx4090Suprimx = new GraphicCardBuilder().WithName("MSI GeForce RTX 4090 SUPRIM X")
            .WithMemoryAmount(24)
            .WithPciVersion(new X16Pci()).WithChipFrequency(2235).ConsumingEnergy(480).WithSize(new Size(336, 142))
            .Build();

        GraphicCard gigabyteAmdRadeonRx6900XtGamingOc = new GraphicCardBuilder()
            .WithName("GIGABYTE AMD Radeon RX 6900 XT GAMING OC").WithMemoryAmount(16)
            .WithPciVersion(new X16Pci()).WithChipFrequency(1825).ConsumingEnergy(300).WithSize(new Size(286, 118))
            .Build();

        GraphicCard gigabyteGeForceRtx4080AeroOc = new GraphicCardBuilder()
            .WithName("GIGABYTE GeForce RTX 4080 AERO OC").WithMemoryAmount(16)
            .WithPciVersion(new X16Pci()).WithChipFrequency(2210).ConsumingEnergy(350).WithSize(new Size(342, 150))
            .Build();

        GraphicCard palitGeForceRtx4080GameRockOmniBlack = new GraphicCardBuilder()
            .WithName("Palit GeForce RTX 4080 GameRock OmniBlack").WithMemoryAmount(16)
            .WithPciVersion(new X16Pci()).WithChipFrequency(2300).ConsumingEnergy(300).WithSize(new Size(329, 137))
            .Build();

        _availableComponents.Add(msiGeForceRtx4090Suprimx.Name, msiGeForceRtx4090Suprimx);
        _availableComponents.Add(gigabyteAmdRadeonRx6900XtGamingOc.Name, gigabyteAmdRadeonRx6900XtGamingOc);
        _availableComponents.Add(gigabyteGeForceRtx4080AeroOc.Name, gigabyteGeForceRtx4080AeroOc);
        _availableComponents.Add(palitGeForceRtx4080GameRockOmniBlack.Name, palitGeForceRtx4080GameRockOmniBlack);
    }

    public GraphicCardRepository(IEnumerable<GraphicCard> availableComponents)
        : this()
    {
        _availableComponents =
            availableComponents.ToDictionary(graphicCard => graphicCard.Name, graphicCard => graphicCard);
    }

    public IReadOnlyCollection<GraphicCard> AvailableGraphicCards => _availableComponents.Values.ToList();

    public void Add(GraphicCard item)
    {
        _availableComponents.Add(item.Name, item);
    }

    public GraphicCard GetItem(string name)
    {
        return _availableComponents[name];
    }
}