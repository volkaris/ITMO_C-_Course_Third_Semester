using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.ChooseBestShip;

public interface IChooser
{
    public IShip? ChooseBestShip(IList<IShip> ships, Route route);
}