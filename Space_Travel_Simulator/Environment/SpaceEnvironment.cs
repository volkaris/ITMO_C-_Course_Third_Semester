using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.AllowedInSpaceObstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.CollisionResults;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.EngineTravelResult;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ShipStatuses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class SpaceEnvironment : IEnvironment
{
    private readonly List<IAllowedInSpaceObstacle> _obstaclesList;

    public SpaceEnvironment(IEnumerable<IAllowedInSpaceObstacle> obstaclesList)
    {
        _obstaclesList = obstaclesList.ToList();
    }

    public IReadOnlyCollection<IAllowedInSpaceObstacle> ObstaclesList => _obstaclesList;

    public ShipStatus CouldBeTravelTo(IShip ship, double environmentDistance)
    {
        ArgumentNullException.ThrowIfNull(ship);

        foreach (IAllowedInSpaceObstacle obstacle in _obstaclesList)
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