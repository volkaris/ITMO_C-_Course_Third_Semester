using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers.Hdds;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComponentsRepository;

public class HddRepository : IComponentRepository<Hdd>
{
    private Dictionary<string, Hdd> _availableComponents = new();

    public HddRepository()
    {
        Hdd seagateSkyHawkAi = new HddBuilder().WithName("Seagate SkyHawk AI").WithCapacity(18000)
            .WithSpindleRotationSpeed(7200)
            .WithPowerConsumption(8)
            .Build();

        Hdd wDPurplePro = new HddBuilder().WithName("WD Purple Pro").WithCapacity(18000).WithSpindleRotationSpeed(7200)
            .WithPowerConsumption(7).Build();

        Hdd seagateIronWolfPro = new HddBuilder().WithName("Seagate IronWolf Pro").WithCapacity(18000)
            .WithSpindleRotationSpeed(7200)
            .WithPowerConsumption(8).Build();

        Hdd wdUltrastarDchC550 = new HddBuilder().WithName("WD Ultrastar DC HC550").WithCapacity(18000)
            .WithSpindleRotationSpeed(7200)
            .WithPowerConsumption(6).Build();

        _availableComponents.Add(seagateSkyHawkAi.Name, seagateSkyHawkAi);
        _availableComponents.Add(wDPurplePro.Name, wDPurplePro);
        _availableComponents.Add(seagateIronWolfPro.Name, seagateIronWolfPro);
        _availableComponents.Add(wdUltrastarDchC550.Name, wdUltrastarDchC550);
    }

    public HddRepository(IEnumerable<Hdd> availableComponents)
        : this()
    {
        _availableComponents =
            availableComponents.ToDictionary(ssd => ssd.Name, ssd => ssd);
    }

    public IReadOnlyCollection<Hdd> AvailableHdds => _availableComponents.Values.ToList();

    public void Add(Hdd item)
    {
        _availableComponents.Add(item.Name, item);
    }

    public Hdd GetItem(string name)
    {
        return _availableComponents[name];
    }
}