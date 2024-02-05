using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ShipStatuses;

namespace Itmo.ObjectOrientedProgramming.Lab1.ChooseBestShip;

public class Chooser : IChooser
{
    public IShip? ChooseBestShip(IList<IShip> ships, Route route)
    {
        ArgumentNullException.ThrowIfNull(route);
        if (ships is null) throw new ArgumentNullException(nameof(ships));

        var shipsCopy = new List<IShip>(ships);
        var possibleShips = new List<ShipAndStatus>();

        foreach (IShip ship in shipsCopy)
        {
            ShipStatus shipAndStatus = route.Travel(ship);

            if (shipAndStatus is Success success) possibleShips.Add(new ShipAndStatus(ship, success));
        }

        if (!possibleShips.Any()) return null;

        var sortedShips = possibleShips.OrderBy(ship => ship.Status.TotalCost)
            .ThenBy(ship => ship.Status.TimeOfJourney)
            .Select(ship => ship.Ship)
            .ToList();
        return sortedShips.First();
    }
}