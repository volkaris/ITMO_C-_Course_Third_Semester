using System;
using Itmo.ObjectOrientedProgramming.Lab1.FuelMarket;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.EngineTravelResult;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.FuelUsage;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.ImpulseEngines;

public class EngineTypeE : IEngine
{
    private const double FuelConsumingPerLightYear = 15;
    private const int FuelToStartEngine = 20;

    public TravelResult Travel(double distance)
    {
        static double AccelerationFunction(double t)
        {
            return Math.Pow(Math.E, t);
        }

        double travelTime = 0;
        double velocity = 0;
        double currentPosition = 0;

        while (currentPosition < distance)
        {
            double a = AccelerationFunction(travelTime); // Get acceleration at time
            velocity += a;
            currentPosition += velocity;
            travelTime += 0.1;
        }

        travelTime = Math.Ceiling(travelTime);

        double consumedFuel = (distance * FuelConsumingPerLightYear) + FuelToStartEngine;

        IFuelMarket fuelMarket = new PlasmaGravitonMarket();
        double cost = fuelMarket.CalculateCost(new ActivePlasmaFuelUsage(consumedFuel));

        return new SuccesfullTravel(cost, travelTime);
    }
}