using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Coolers;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.GraphicCards;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers.Hdds;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.PcCorpus;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.PowerUnits;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Proccesors;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories;
using Itmo.ObjectOrientedProgramming.Lab2.PCBuildResults;
using Itmo.ObjectOrientedProgramming.Lab2.Validators.PcValidator;
using Itmo.ObjectOrientedProgramming.Lab2.WifiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;

public class PcBuilder : IPcBuilder
{
    private Motherboard? _motherboard;
    private Processor? _processor;
    private Cooler? _cooler;
    private RandomAccessMemory? _memory;
    private List<GraphicCard> _graphicCards = new();
    private List<IInformationKeeper> _informationKeepers = new();
    private PowerUnit? _powerUnit;
    private PсСorpus? _pcBody;
    private WiFiAdapter? _wifiAdapter;

    public IPcBuilder WithMotherboard(Motherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public IPcBuilder WithProcessor(Processor processor)
    {
        _processor = processor;
        return this;
    }

    public IPcBuilder WithСooler(Cooler cooler)
    {
        _cooler = cooler;
        return this;
    }

    public IPcBuilder WithMemory(RandomAccessMemory memory)
    {
        _memory = memory;
        return this;
    }

    public IPcBuilder WithGraphicCard(GraphicCard graphicCard)
    {
        _graphicCards.Add(graphicCard);
        return this;
    }

    public IPcBuilder WithSsd(Ssd ssd)
    {
        _motherboard?.Connect(ssd);
        _informationKeepers.Add(ssd);
        return this;
    }

    public IPcBuilder WithHdd(Hdd hdd)
    {
        _motherboard?.Connect(hdd);
        _informationKeepers.Add(hdd);
        return this;
    }

    public IPcBuilder WithPowerUnit(PowerUnit powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public IPcBuilder WithBody(PсСorpus pсСorpus)
    {
        _pcBody = pсСorpus;
        return this;
    }

    public IPcBuilder WithWifiModule(WiFiAdapter wiFiAdapter)
    {
        _wifiAdapter = wiFiAdapter;
        return this;
    }

    public PcBuildResult Build()
    {
        var computerShell = new NotAssembledComputerShell(
            _motherboard ?? throw new ArgumentNullException(nameof(_motherboard)),
            _processor ?? throw new ArgumentNullException(nameof(_processor)),
            _cooler ?? throw new ArgumentNullException(nameof(_cooler)),
            _memory ?? throw new ArgumentNullException(nameof(_memory)),
            _powerUnit ?? throw new ArgumentNullException(nameof(_powerUnit)),
            _informationKeepers ?? throw new ArgumentNullException(nameof(_informationKeepers)),
            _graphicCards ?? throw new ArgumentNullException(nameof(_graphicCards)),
            _pcBody ?? throw new ArgumentNullException(nameof(_pcBody)),
            _wifiAdapter);

        IPcValidator checker = new PcValidator();

        return checker.CanBeBuildCorrectly(computerShell);
    }
}