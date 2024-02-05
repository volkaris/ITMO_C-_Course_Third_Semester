using System;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.CollisionResults;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Deflectors.Photonic;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.AllowedInSpaceDensityNebula;

public class AntimatterFlares : IAllowedInSpaceDensityNebula
{
    public CollisionResult CouldBeHandled(IShip ship)
    {
        ArgumentNullException.ThrowIfNull(ship);

        if (ship.Deflectors is PhotonicDeflectors photonicDeflectors && photonicDeflectors.CanAbsorbPhotonicDamage())
            return new SurvivedCollision();

        return new CrewKilledInAction();
    }
}