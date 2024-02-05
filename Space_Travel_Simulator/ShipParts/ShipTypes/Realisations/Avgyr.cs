using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Realisations;

public class Avgyr : IJumpDriveShip
{
    public IEngine Engine { get; } = new EngineTypeE();
    public IHull Hull { get; } = new ThirdStrenghtClassHull();
    public IDeflector? Deflectors { get; } = new ThirdClassDeflectors();
    public IJumpDrive JumpDrive { get; } = new AlphaJumpDrive();
}