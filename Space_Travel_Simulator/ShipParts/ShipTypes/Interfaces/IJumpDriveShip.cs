using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.JumpEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;

public interface IJumpDriveShip : IShip
{
    public IJumpDrive JumpDrive { get; }
}