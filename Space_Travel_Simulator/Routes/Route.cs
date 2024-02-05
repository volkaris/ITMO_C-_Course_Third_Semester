using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ShipStatuses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class Route
{
    private readonly List<PartOfRoute> _wholeRoute;

    public Route(IEnumerable<PartOfRoute> wholeRoute)
    {
        _wholeRoute = wholeRoute.ToList();
    }

    public IEnumerable<PartOfRoute> WholeRoute => _wholeRoute;

    public ShipStatus Travel(IShip ship)
    {
        if (ship is null) throw new ArgumentNullException(nameof(ship));

        double travelTime = 0;
        double travelCost = 0;

        foreach (PartOfRoute smallPart in _wholeRoute)
        {
            ShipStatus shipStatus = smallPart.CouldBeTraveledToBy(ship);
            if (shipStatus is Success successStatus)
            {
                travelTime += successStatus.TimeOfJourney;
                travelCost += successStatus.TotalCost;
            }
            else
            {
                return shipStatus;
            }
        }

        return new Success(travelTime, travelCost);
    }
}