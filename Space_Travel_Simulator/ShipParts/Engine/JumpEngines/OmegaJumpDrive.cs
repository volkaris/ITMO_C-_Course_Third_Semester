using System;
using Itmo.ObjectOrientedProgramming.Lab1.FuelMarket;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.EngineTravelResult;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.FuelUsage;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.JumpEngines;

public class OmegaJumpDrive : IJumpDrive
{
    private const int Speed = 100;
    private const int JumpRange = 2000;
    private const double FuelConsumingPerLightYear = 40;

    public TravelResult Travel(double distance)
    {
        if (distance > JumpRange) return new UnsuccesfullTravel();

        double consumedFuel = 0;
        for (double i = 2; i < distance; ++i) consumedFuel += Math.Log(FuelConsumingPerLightYear);

        IFuelMarket fuelMarket = new PlasmaGravitonMarket();
        double cost = fuelMarket.CalculateCost(new GravitonMatterFuelUsage(consumedFuel));

        double travelTime = distance / Speed;

        return new SuccesfullTravel(cost, travelTime);
    }
}