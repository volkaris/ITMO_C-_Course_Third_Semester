using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Coolers;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.GraphicCards;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.PcCorpus;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.PowerUnits;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Proccesors;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories;
using Itmo.ObjectOrientedProgramming.Lab2.WifiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer;

public record NotAssembledComputerShell(
    Motherboard Motherboard,
    Processor Processor,
    Cooler Cooler,
    RandomAccessMemory Memory,
    PowerUnit PowerUnit,
    IEnumerable<IInformationKeeper> InformationKeepers,
    IReadOnlyCollection<GraphicCard> GraphicCards,
    PсСorpus PcBody,
    WiFiAdapter? WifiAdapter)
{
    public bool HaveAnyMemoryKeepers()
    {
        return InformationKeepers.Any();
    }

    public double ConsumableEnergy()
    {
        return Processor.PowerConsumption +
               Memory.PowerConsumption +
               GraphicCards.Sum(card => card.ConsumingEnergy) +
               InformationKeepers.Sum(keeper => keeper.PowerConsumption) +
               (WifiAdapter?.ConsumableEnergy ?? 0);
    }

    public bool GraphicCardCanBeInstalled()
    {
        ArgumentNullException.ThrowIfNull(GraphicCards);
        return GraphicCards.All(videoCard => videoCard.Size.IsFittable(PcBody.MaxVideoCardSize));
    }
}