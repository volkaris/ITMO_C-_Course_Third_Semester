using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Proccesors;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComponentsRepository;

public class ProccesorRepository : IComponentRepository<Processor>
{
    private Dictionary<string, Processor> _availableComponents = new();

    public ProccesorRepository()
    {
        Processor intelCoreI910980Xe = new ProcessorBuilder().WithName("Intel Core i9-10980XE BOX").WithCoresAmount(18)
            .WithCoresFrequency(3)
            .WithSocket(new Socket("LGA 2066")).WithBuiltInVideoCore(true).WithRamMaximumFrequency(2933).WithTdp(165)
            .WithPowerConsumption(100).Build();

        Processor amdRyzen97900X3D = new ProcessorBuilder().WithName("AMD Ryzen 9 7900X3D").WithCoresAmount(12)
            .WithCoresFrequency(4.4)
            .WithSocket(new Socket("AM5")).WithBuiltInVideoCore(true).WithRamMaximumFrequency(5200).WithTdp(120)
            .WithPowerConsumption(90).Build();

        Processor intelCoreI713700F = new ProcessorBuilder().WithName("Intel Core i7-13700F").WithCoresAmount(
                16)
            .WithCoresFrequency(2.1)
            .WithSocket(new Socket("LGA 1700")).WithBuiltInVideoCore(true).WithRamMaximumFrequency(5600).WithTdp(219)
            .WithPowerConsumption(95).Build();

        Processor intelCoreI911900Kf = new ProcessorBuilder().WithName("Intel Core i9-11900KF").WithCoresAmount(8)
            .WithCoresFrequency(3.5)
            .WithSocket(new Socket("LGA 1200")).WithBuiltInVideoCore(true).WithRamMaximumFrequency(3200).WithTdp(125)
            .WithPowerConsumption(95).Build();

        _availableComponents.Add(intelCoreI910980Xe.Name, intelCoreI910980Xe);
        _availableComponents.Add(amdRyzen97900X3D.Name, amdRyzen97900X3D);
        _availableComponents.Add(intelCoreI713700F.Name, intelCoreI713700F);
        _availableComponents.Add(intelCoreI911900Kf.Name, intelCoreI911900Kf);
    }

    public ProccesorRepository(IEnumerable<Processor> availableComponents)
        : this()
    {
        _availableComponents =
            availableComponents.ToDictionary(processor => processor.Name, processor => processor);
    }

    public IReadOnlyCollection<Processor> AvailableProcessors => _availableComponents.Values.ToList();

    public void Add(Processor item)
    {
        _availableComponents.Add(item.Name, item);
    }

    public Processor GetItem(string name)
    {
        return _availableComponents[name];
    }
}