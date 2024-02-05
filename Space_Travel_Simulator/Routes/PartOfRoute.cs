using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ShipStatuses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class PartOfRoute
{
    private readonly double _distance;

    private readonly IEnvironment _environment;

    public PartOfRoute(double distance, IEnvironment environment)
    {
        _distance = distance;
        _environment = environment;
    }

    public ShipStatus CouldBeTraveledToBy(IShip ship)
    {
        return _environment.CouldBeTravelTo(ship, _distance);
    }
}