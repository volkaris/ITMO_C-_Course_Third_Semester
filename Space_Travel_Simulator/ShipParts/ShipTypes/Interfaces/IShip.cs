using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;

public interface IShip
{
    public IEngine Engine { get; }

    public IHull Hull { get; }

    public IDeflector? Deflectors { get; }
}