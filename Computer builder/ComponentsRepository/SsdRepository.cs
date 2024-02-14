using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers.ConnectionVariant;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComponentsRepository;

public class SsdRepository : IComponentRepository<Ssd>
{
    private Dictionary<string, Ssd> _availableComponents = new();

    public SsdRepository()
    {
        Ssd samsung870Evo = new SsdBuilder().WithName("Samsung 870 EVO").WithCapacity(4000).WithMaxWorkVelocity(560)
            .WithPowerConsumption(5)
            .WithConnectionVariant(new SataConnection()).Build();

        Ssd wdBlue = new SsdBuilder().WithName("WD Blue").WithCapacity(2000).WithMaxWorkVelocity(560)
            .WithPowerConsumption(4)
            .WithConnectionVariant(new SataConnection()).Build();

        Ssd samsung870Qvo = new SsdBuilder().WithName("Samsung 870 QVO").WithCapacity(1000).WithMaxWorkVelocity(560)
            .WithPowerConsumption(4)
            .WithConnectionVariant(new SataConnection()).Build();

        Ssd wdGreen = new SsdBuilder().WithName("WD Green").WithCapacity(1000).WithMaxWorkVelocity(545)
            .WithPowerConsumption(3)
            .WithConnectionVariant(new SataConnection()).Build();

        _availableComponents.Add(samsung870Evo.Name, samsung870Evo);
        _availableComponents.Add(wdBlue.Name, wdBlue);
        _availableComponents.Add(samsung870Qvo.Name, samsung870Qvo);
        _availableComponents.Add(wdGreen.Name, wdGreen);
    }

    public SsdRepository(IEnumerable<Ssd> availableComponents)
        : this()
    {
        _availableComponents =
            availableComponents.ToDictionary(ssd => ssd.Name, ssd => ssd);
    }

    public IReadOnlyCollection<Ssd> AvailablesSsds => _availableComponents.Values.ToList();

    public void Add(Ssd item)
    {
        _availableComponents.Add(item.Name, item);
    }

    public Ssd GetItem(string name)
    {
        return _availableComponents[name];
    }
}