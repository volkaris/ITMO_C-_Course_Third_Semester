using Itmo.ObjectOrientedProgramming.Lab1.FuelMarket;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.EngineTravelResult;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.FuelUsage;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.JumpEngines;

public class AlphaJumpDrive : IJumpDrive
{
    private const int Speed = 100;
    private const int JumpRange = 1000;
    private const double FuelConsumingPerLightYear = 20;

    public TravelResult Travel(double distance)
    {
        if (distance > JumpRange) return new UnsuccesfullTravel();

        double consumedFuel = distance * FuelConsumingPerLightYear;

        IFuelMarket fuelMarket = new PlasmaGravitonMarket();

        double cost = fuelMarket.CalculateCost(new GravitonMatterFuelUsage(consumedFuel));

        double travelTime = distance / Speed;

        return new SuccesfullTravel(cost, travelTime);
    }
}