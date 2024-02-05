using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Realisations;

public class WalkingShuttle : IShip
{
    public IEngine Engine { get; } = new EngineTypeC();
    public IHull Hull { get; } = new FirstStrengthClassHull();
    public IDeflector? Deflectors { get; } = new FirstClassDeflectors();
}