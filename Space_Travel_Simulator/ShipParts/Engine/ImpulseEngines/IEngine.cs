using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.EngineTravelResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.ImpulseEngines;

public interface IEngine
{
    public TravelResult Travel(double distance);
}