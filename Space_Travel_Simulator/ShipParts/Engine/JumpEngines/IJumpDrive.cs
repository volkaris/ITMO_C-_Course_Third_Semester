using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.EngineTravelResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.JumpEngines;

public interface IJumpDrive
{
    public TravelResult Travel(double distance);
}