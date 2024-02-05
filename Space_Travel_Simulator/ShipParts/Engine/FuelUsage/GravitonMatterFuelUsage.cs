namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.FuelUsage;

public class GravitonMatterFuelUsage : IFuelUsage
{
    public GravitonMatterFuelUsage(double fuelConsumed)
    {
        FuelConsumed = fuelConsumed;
    }

    public double FuelConsumed { get; }
}