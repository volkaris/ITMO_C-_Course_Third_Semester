using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards.MotherboardFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Proccesors;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Ddr;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComponentsRepository;

public class MotherboardRepository : IComponentRepository<Motherboard>
{
    private Dictionary<string, Motherboard> _availableComponents = new();

    public MotherboardRepository()
    {
        Motherboard msiMegX670EGodlike = new MotherboardBuilder().PciLinesAmount(20).SataPortAmount(14)
            .WithMemorySlotsNumber(6)
            .WithSocket(new Socket("AM5")).WithName("MSI MEG X670E GODLIKE")
            .WithBios(new Bios(
                "MSI Bios type",
                20,
                new List<Processor>()
                {
                    new ProcessorBuilder().WithName("AMD Ryzen 9 7900X3D").WithCoresAmount(12)
                        .WithCoresFrequency(4.4)
                        .WithSocket(new Socket("AM5")).WithBuiltInVideoCore(true).WithRamMaximumFrequency(5200)
                        .WithTdp(120)
                        .WithPowerConsumption(90).Build(),
                }))
            .WithChipSet(new ChipSet(
                true,
                new List<int>() { 4800, 5000, 5200, 5400, 5600, 5800, 6000, 6200, 6400, 6600, 6666 }))
            .WithDdrStandard(new Ddr5())
            .WithMotherboardFormFactor(new Eatx()).Build();

        Motherboard gigabyteZ790AorusExtreme = new MotherboardBuilder().PciLinesAmount(3).SataPortAmount(4)
            .WithMemorySlotsNumber(4)
            .WithSocket(new Socket("LGA 1700")).WithName("GIGABYTE Z790 AORUS EXTREME")
            .WithBios(
                new Bios(
                    "Gigabyte Bios type",
                    20,
                    new List<Processor>()
                    {
                        new ProcessorBuilder().WithName("Intel Core i7-13700F").WithCoresAmount(
                                16)
                            .WithCoresFrequency(2.1)
                            .WithSocket(new Socket("LGA 1700")).WithBuiltInVideoCore(true).WithRamMaximumFrequency(5600)
                            .WithTdp(219)
                            .WithPowerConsumption(95).Build(),
                    })) // todo добавить процессоры в new List<Processor>())
            .WithChipSet(new ChipSet(true, new List<int>() { 5200, 5400, 5600, 5800, 6000, 6200, 6400, 6600, 6800 }))
            .WithDdrStandard(new Ddr5()).WithMotherboardFormFactor(new Eatx()).Build();

        Motherboard msiMegZ790Godlike = new MotherboardBuilder().PciLinesAmount(2).SataPortAmount(6)
            .WithMemorySlotsNumber(3)
            .WithSocket(new Socket("LGA 1700")).WithName("MSI MEG Z790 GODLIKE").WithBios(new Bios(
                "Gigabyte Bios type",
                20,
                new List<Processor>()
                {
                    new ProcessorBuilder().WithName("Intel Core i7-13700F").WithCoresAmount(
                            16)
                        .WithCoresFrequency(2.1)
                        .WithSocket(new Socket("LGA 1700")).WithBuiltInVideoCore(true).WithRamMaximumFrequency(5600)
                        .WithTdp(219)
                        .WithPowerConsumption(95).Build(),
                })) // todo добавить процессоры в new List<Processor>())
            .WithChipSet(new ChipSet(true, new List<int>() { 5800, 6000, 6200, 6400, 6600, 6800, 7000, 7200 }))
            .WithDdrStandard(new Ddr5()).WithMotherboardFormFactor(new Eatx()).Build();

        Motherboard asusRogCrosshairX670EHero = new MotherboardBuilder().PciLinesAmount(2).SataPortAmount(6)
            .WithMemorySlotsNumber(4)
            .WithSocket(new Socket("AM5")).WithName("ASUS ROG CROSSHAIR X670E HERO").WithBios(new Bios(
                "Gigabyte Bios type",
                20,
                new List<Processor>()
                {
                    new ProcessorBuilder().WithName("AMD Ryzen 9 7900X3D").WithCoresAmount(12)
                        .WithCoresFrequency(4.4)
                        .WithSocket(new Socket("AM5")).WithBuiltInVideoCore(true).WithRamMaximumFrequency(5200)
                        .WithTdp(120)
                        .WithPowerConsumption(90).Build(),
                })) // todo добавить процессоры в new List<Processor>())
            .WithChipSet(new ChipSet(true, new List<int>() { 5400, 5600, 5800, 6000, 6200, 6400 }))
            .WithDdrStandard(new Ddr5())
            .WithMotherboardFormFactor(new Eatx()).Build();

        _availableComponents.Add(msiMegX670EGodlike.Name, msiMegX670EGodlike);
        _availableComponents.Add(gigabyteZ790AorusExtreme.Name, gigabyteZ790AorusExtreme);
        _availableComponents.Add(msiMegZ790Godlike.Name, msiMegZ790Godlike);
        _availableComponents.Add(asusRogCrosshairX670EHero.Name, asusRogCrosshairX670EHero);
    }

    public MotherboardRepository(IEnumerable<Motherboard> availableComponents)
        : this()
    {
        _availableComponents =
            availableComponents.ToDictionary(motherboard => motherboard.Name, motherboard => motherboard);
    }

    public IReadOnlyCollection<Motherboard> AvailableMotherboards => _availableComponents.Values.ToList();

    public void Add(Motherboard item)
    {
        _availableComponents.Add(item.Name, item);
    }

    public Motherboard GetItem(string name)
    {
        return _availableComponents[name];
    }
}