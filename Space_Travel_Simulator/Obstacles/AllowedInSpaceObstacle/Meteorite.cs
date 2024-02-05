using System;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.CollisionResults;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.AllowedInSpaceObstacle;

public class Meteorite : IAllowedInSpaceObstacle
{
    private readonly int _causableDamage = 100;

    public CollisionResult CouldBeHandled(IShip ship)
    {
        ArgumentNullException.ThrowIfNull(ship);
        ArgumentNullException.ThrowIfNull(ship.Deflectors);

        if (ship.Deflectors.CanAbsorbDamage(_causableDamage)) return new SurvivedCollision();

        if (ship.Hull.CanAbsorbDamage(_causableDamage)) return new SurvivedCollision();

        return new ShipDestroyed();
    }
}