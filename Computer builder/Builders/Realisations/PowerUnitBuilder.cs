using System;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.PowerUnits;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;

public class PowerUnitBuilder : IPowerUnitBuilder
{
    private int? _peakLoad;
    private string? _name;

    public PowerUnitBuilder()
    {
    }

    public PowerUnitBuilder(PowerUnit powerUnit)
    {
        _peakLoad = powerUnit.PeakLoad;
    }

    public IPowerUnitBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IPowerUnitBuilder WithPeakLoad(int peakLoad)
    {
        _peakLoad = peakLoad;
        return this;
    }

    public PowerUnit Build()
    {
        return new PowerUnit(
            _peakLoad ?? throw new ArgumentNullException(nameof(_peakLoad)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}