using System;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.FuelUsage;

namespace Itmo.ObjectOrientedProgramming.Lab1.FuelMarket;

public class PlasmaGravitonMarket : IFuelMarket
{
    private readonly int _activePlasmaCost = 10;
    private readonly int _gravitonMatterCost = 50;

    public double CalculateCost(IFuelUsage fuel)
    {
        ArgumentNullException.ThrowIfNull(fuel);
        return fuel switch
        {
            ActivePlasmaFuelUsage => fuel.FuelConsumed * _activePlasmaCost,
            GravitonMatterFuelUsage => fuel.FuelConsumed * _gravitonMatterCost,
            _ => throw new InvalidOperationException(),
        };
    }
}