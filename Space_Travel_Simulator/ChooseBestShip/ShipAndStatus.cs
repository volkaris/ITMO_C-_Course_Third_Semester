using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ShipStatuses;

namespace Itmo.ObjectOrientedProgramming.Lab1.ChooseBestShip;

public class ShipAndStatus
{
    public ShipAndStatus(IShip ship, Success status)
    {
        Ship = ship;
        Status = status;
    }

    public IShip Ship { get; }
    public Success Status { get; }
}