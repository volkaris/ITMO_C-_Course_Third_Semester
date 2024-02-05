using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.FuelUsage;

namespace Itmo.ObjectOrientedProgramming.Lab1.FuelMarket;

public interface IFuelMarket
{
    public double CalculateCost(IFuelUsage fuel);
}