using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.CollisionResults;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public interface IObstacle
{
    public CollisionResult CouldBeHandled(IShip ship);
}