using System;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.CollisionResults;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.AllowedInNitrideParticles;

public class SpaceWhales : IAllowedInNitrideParticles
{
    private readonly int _populationSize;

    public SpaceWhales(int populationSize)
    {
        _populationSize = populationSize;
    }

    public SpaceWhales()
    {
    }

    private static int MaximumSustainableWhalesAmountForDeclectors => 1;
    private static int MinDamage => 1;

    public CollisionResult CouldBeHandled(IShip ship)
    {
        ArgumentNullException.ThrowIfNull(ship);
        if (ship is IShipWithAntiNeutrinoEmitter) return new SurvivedCollision();

        if (ship.Deflectors is null ||
            !ship.Deflectors.CanAbsorbDamage(MinDamage) ||
            ship.Deflectors is not ThirdClassDeflectors ||
            _populationSize > MaximumSustainableWhalesAmountForDeclectors)
            return new ShipDestroyed();

        ship.Deflectors.Destroy();
        return new SurvivedCollision();
    }
}