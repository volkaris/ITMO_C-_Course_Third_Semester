using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ShipStatuses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public interface IEnvironment
{
    public ShipStatus CouldBeTravelTo(
        IShip ship,
        double environmentDistance);
}