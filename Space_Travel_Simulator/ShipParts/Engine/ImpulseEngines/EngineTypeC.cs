using Itmo.ObjectOrientedProgramming.Lab1.FuelMarket;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.EngineTravelResult;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.FuelUsage;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.ImpulseEngines;

public class EngineTypeC : IEngine
{
    private const double FuelConsumingPerLightYear = 10;
    private const int FuelToStartEngine = 5;
    private const int Speed = 2;

    public TravelResult Travel(double distance)
    {
        double travelTime = distance / Speed;
        double consumedFuel = (distance * FuelConsumingPerLightYear) + FuelToStartEngine;

        IFuelMarket fuelMarket = new PlasmaGravitonMarket();
        double cost = fuelMarket.CalculateCost(new ActivePlasmaFuelUsage(consumedFuel));

        return new SuccesfullTravel(cost, travelTime);
    }
}