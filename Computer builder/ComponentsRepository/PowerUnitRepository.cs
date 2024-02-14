using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.PowerUnits;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComponentsRepository;

public class PowerUnitRepository : IComponentRepository<PowerUnit>
{
    private Dictionary<string, PowerUnit> _availableComponents = new();

    public PowerUnitRepository()
    {
        PowerUnit silverstoneSt1000Pts =
            new PowerUnitBuilder().WithName("Silverstone ST1000-PTS").WithPeakLoad(1000).Build();

        PowerUnit xpgCybercore1300W = new PowerUnitBuilder().WithName("XPG CYBERCORE 1300W").WithPeakLoad(1300).Build();

        PowerUnit gigabyteUd1300GmPg5 =
            new PowerUnitBuilder().WithName("GIGABYTE UD1300GM PG5").WithPeakLoad(130).Build();

        PowerUnit beqQietPurePower12Mfm =
            new PowerUnitBuilder().WithName("be quiet! PURE POWER 12 M FM").WithPeakLoad(1000).Build();

        _availableComponents.Add(silverstoneSt1000Pts.Name, silverstoneSt1000Pts);
        _availableComponents.Add(xpgCybercore1300W.Name, xpgCybercore1300W);
        _availableComponents.Add(gigabyteUd1300GmPg5.Name, gigabyteUd1300GmPg5);
        _availableComponents.Add(beqQietPurePower12Mfm.Name, beqQietPurePower12Mfm);
    }

    public PowerUnitRepository(IEnumerable<PowerUnit> availableComponents)
        : this()
    {
        _availableComponents =
            availableComponents.ToDictionary(powerUnit => powerUnit.Name, powerUnit => powerUnit);
    }

    public IReadOnlyCollection<PowerUnit> AvailablePowerUnits => _availableComponents.Values.ToList();

    public void Add(PowerUnit item)
    {
        _availableComponents.Add(item.Name, item);
    }

    public PowerUnit GetItem(string name)
    {
        return _availableComponents[name];
    }
}