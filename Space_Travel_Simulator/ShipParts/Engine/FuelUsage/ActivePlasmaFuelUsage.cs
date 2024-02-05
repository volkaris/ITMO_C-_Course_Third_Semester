namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.FuelUsage;

public class ActivePlasmaFuelUsage : IFuelUsage
{
    public ActivePlasmaFuelUsage(double fuelConsumed)
    {
        FuelConsumed = fuelConsumed;
    }

    public double FuelConsumed { get; }
}