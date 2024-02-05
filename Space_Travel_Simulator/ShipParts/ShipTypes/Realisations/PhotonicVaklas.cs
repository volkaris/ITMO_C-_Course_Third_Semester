using System;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Deflectors.Photonic;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.ShipTypes.Realisations;

public class PhotonicVaklas : IJumpDriveShip
{
    public IEngine Engine { get; } = new EngineTypeE();
    public IHull Hull { get; } = new SecondStrenghtClassHull();
    public IDeflector? Deflectors { get; private set; } = new FirstClassDeflectors();

    public IJumpDrive JumpDrive { get; } = new AlphaJumpDrive();

    public IShip WithPhotonicDeflectors()
    {
        ArgumentNullException.ThrowIfNull(Deflectors);
        Deflectors = new PhotonicDeflectors(Deflectors);
        return this;
    }
}