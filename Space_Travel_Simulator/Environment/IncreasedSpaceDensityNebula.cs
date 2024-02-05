using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.AllowedInSpaceDensityNebula;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.CollisionResults;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.EngineTravelResult;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ShipStatuses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class IncreasedSpaceDensityNebula : IEnvironment
{
    private readonly List<IAllowedInSpaceDensityNebula> _obstaclesList;
    private readonly double _subspaceChannelLength;

    public IncreasedSpaceDensityNebula(
        double subspaceChannelLength,
        IEnumerable<IAllowedInSpaceDensityNebula> obstaclesList)
    {
        _obstaclesList = obstaclesList.ToList();
        _subspaceChannelLength = subspaceChannelLength;
    }

    public IncreasedSpaceDensityNebula()
    {
        _obstaclesList = new List<IAllowedInSpaceDensityNebula>();
    }

    public IReadOnlyCollection<IAllowedInSpaceDensityNebula> ObstaclesList => _obstaclesList;

    public ShipStatus CouldBeTravelTo(IShip ship, double environmentDistance)
    {
        if (ship is not IJumpDriveShip jumpDriveShip ||
            jumpDriveShip.JumpDrive?.Travel(environmentDistance) is not SuccesfullTravel succesfullTravel)
            return new ShipEradicated(new LostInSpace());

        foreach (IAllowedInSpaceDensityNebula obstacle in _obstaclesList)
        {
            CollisionResult shipStatus = obstacle.CouldBeHandled(ship);
            if (shipStatus is not SurvivedCollision) return new ShipEradicated(shipStatus);
        }

        double travelCost = succesfullTravel.TotalCost;
        double travelTime = succesfullTravel.TravelTime;

        return new Success(travelTime, travelCost);
    }
}