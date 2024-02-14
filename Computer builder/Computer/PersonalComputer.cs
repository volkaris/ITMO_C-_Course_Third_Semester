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

public class PersonalComputer
{
    private readonly List<GraphicCard> _graphicCards;
    private readonly List<IInformationKeeper> _informationKeepers;

    internal PersonalComputer(
        Motherboard motherboard,
        Processor processor,
        Cooler cooler,
        RandomAccessMemory memory,
        PowerUnit powerUnit,
        IEnumerable<IInformationKeeper> informationKeepers,
        IEnumerable<GraphicCard> graphicCards,
        PсСorpus pcBody,
        WiFiAdapter? wifiAdapter)
    {
        Motherboard = motherboard;
        Processor = processor;
        Cooler = cooler;
        Memory = memory;
        PowerUnit = powerUnit;
        PcBody = pcBody;
        WifiAdapter = wifiAdapter;
        _graphicCards = graphicCards.ToList();
        _informationKeepers = informationKeepers.ToList();
    }

    internal PersonalComputer(NotAssembledComputerShell shell)
    {
        _graphicCards = shell.GraphicCards.ToList();
        _informationKeepers = shell.InformationKeepers.ToList();
        WifiAdapter = shell.WifiAdapter;
        Motherboard = shell.Motherboard;
        Processor = shell.Processor;
        Cooler = shell.Cooler;
        PowerUnit = shell.PowerUnit;
        Memory = shell.Memory;
        PcBody = shell.PcBody;
    }

    public WiFiAdapter? WifiAdapter { get; }
    public Motherboard Motherboard { get; }
    public Processor Processor { get; }
    public Cooler Cooler { get; }
    public PowerUnit PowerUnit { get; }
    public RandomAccessMemory Memory { get; }

    public PсСorpus PcBody { get; }
    public IReadOnlyCollection<GraphicCard> GraphicCards => _graphicCards;
    public IEnumerable<IInformationKeeper> InformationKeepers => _informationKeepers;
}