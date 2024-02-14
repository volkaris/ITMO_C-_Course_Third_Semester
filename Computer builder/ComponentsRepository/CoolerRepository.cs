using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Coolers;
using Itmo.ObjectOrientedProgramming.Lab2.Sizes;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComponentsRepository;

public class CoolerRepository : IComponentRepository<Cooler>
{
    private Dictionary<string, Cooler> _availableComponents = new();

    public CoolerRepository()
    {
        Cooler coolerMasterMasterAirMa612StealthArgb =
            new CoolerBuilder().WithName("Cooler Master MasterAir MA612 Stealth ARGB").WithTdp(250)
                .WithSupportedSockets(new List<string>()
                {
                    "AM2", "AM2+", "AM3", "AM3+", "AM4", "FM1", "FM2",
                    "FM2+", "LGA 1150", "LGA 1151", "LGA 1155", "LGA 1156", "LGA 1200", "LGA 1366", "LGA 1700",
                    "LGA 2011", "LGA 2011-3", "LGA 2066",
                }).WithSize(new Size(158, 129)).Build();

        Cooler noctuaNhP1 =
            new CoolerBuilder().WithName("Noctua NH-P1").WithTdp(125)
                .WithSupportedSockets(new List<string>()
                {
                    "AM4", "AM5+", "LGA 1150", "LGA 1151", "LGA 1155", "LGA 1156", "LGA 1156",
                    "LGA 1700", " LGA 2011", " LGA 2011-3", "LGA 2066",
                }).WithSize(new Size(158, 154)).Build();

        Cooler beQuietDarkRockPro4 =
            new CoolerBuilder().WithName("be quiet! DARK ROCK PRO 4").WithTdp(250)
                .WithSupportedSockets(new List<string>()
                {
                    "AM2", "AM2+", "AM3", "AM3+", "AM4", "AM5", "FM1", "FM2",
                    "FM2+", "LGA 1150", "LGA 1151", "LGA 1151-v2", "LGA 1155", "LGA 1156", "LGA 1200", "LGA 1366",
                    "LGA 1700",
                    "LGA 2011", "LGA 2011-3", "LGA 2066",
                }).WithSize(new Size(163, 136)).Build();

        Cooler pcCoolerPaladinS9W =
            new CoolerBuilder().WithName("PCCooler Paladin S9 W").WithTdp(250)
                .WithSupportedSockets(new List<string>()
                {
                    "AM2", "AM2+", "AM3", "AM3+", "AM4", "FM1", "FM2",
                    "FM2+", "LGA 1150", "LGA 1151", "LGA 1155", "LGA 1151-v2", "LGA 1155", "LGA 1156", "LGA 1200",
                    "LGA 1700",
                    "LGA 2011", "LGA 2011-3", "LGA 2066",
                }).WithSize(new Size(156, 130)).Build();

        _availableComponents.Add(coolerMasterMasterAirMa612StealthArgb.Name, coolerMasterMasterAirMa612StealthArgb);
        _availableComponents.Add(noctuaNhP1.Name, noctuaNhP1);
        _availableComponents.Add(beQuietDarkRockPro4.Name, beQuietDarkRockPro4);
        _availableComponents.Add(pcCoolerPaladinS9W.Name, pcCoolerPaladinS9W);
    }

    public CoolerRepository(IEnumerable<Cooler> availableComponents)
        : this()
    {
        _availableComponents =
            availableComponents.ToDictionary(cooler => cooler.Name, cooler => cooler);
    }

    public IReadOnlyCollection<Cooler> AvailableCoolers => _availableComponents.Values.ToList();

    public void Add(Cooler item)
    {
        _availableComponents.Add(item.Name, item);
    }

    public Cooler GetItem(string name)
    {
        return _availableComponents[name];
    }
}