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
using Itmo.ObjectOrientedProgramming.Lab2.WifiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;

public interface IPcBuilder
{
    IPcBuilder WithMotherboard(Motherboard motherboard);
    IPcBuilder WithProcessor(Processor processor);
    IPcBuilder WithСooler(Cooler cooler);
    IPcBuilder WithMemory(RandomAccessMemory memory);

    IPcBuilder WithGraphicCard(GraphicCard graphicCard);
    IPcBuilder WithSsd(Ssd ssd);

    IPcBuilder WithHdd(Hdd hdd);

    IPcBuilder WithPowerUnit(PowerUnit powerUnit);
    IPcBuilder WithBody(PсСorpus pсСorpus);

    IPcBuilder WithWifiModule(WiFiAdapter wiFiAdapter);

    PcBuildResult Build();
}