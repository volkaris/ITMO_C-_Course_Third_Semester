using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.AllowedInNitrideParticles;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.CollisionResults;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.EngineTravelResult;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ShipStatuses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class NitrideParticlesNebulae : IEnvironment
{
    private readonly List<IAllowedInNitrideParticles> _obstaclesList;

    public NitrideParticlesNebulae(IEnumerable<IAllowedInNitrideParticles> obstaclesList)
    {
        _obstaclesList = obstaclesList.ToList();
    }

    public NitrideParticlesNebulae()
    {
        _obstaclesList = new List<IAllowedInNitrideParticles>();
    }

    public IReadOnlyCollection<IAllowedInNitrideParticles> ObstaclesList => _obstaclesList;

    public ShipStatus CouldBeTravelTo(IShip ship, double environmentDistance)
    {
        ArgumentNullException.ThrowIfNull(ship);

        if (ship.Engine is not EngineTypeE)
            return new ShipEradicated(new LostInSpace());

        foreach (IAllowedInNitrideParticles obstacle in _obstaclesList)
        {
            CollisionResult shipStatus = obstacle.CouldBeHandled(ship);
            if (shipStatus is not SurvivedCollision) return new ShipEradicated(shipStatus);
        }

        TravelResult travelResult = ship.Engine.Travel(environmentDistance);

        if (travelResult is SuccesfullTravel succesfullTravel)
        {
            double travelCost = succesfullTravel.TotalCost;
            double travelTime = succesfullTravel.TravelTime;

            return new Success(travelTime, travelCost);
        }

        throw new YouArentSuppostedToSeeThisException();
    }
}