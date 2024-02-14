using Itmo.ObjectOrientedProgramming.Lab2.Computer.PowerUnits;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;

public interface IPowerUnitBuilder
{
    IPowerUnitBuilder WithName(string name);
    IPowerUnitBuilder WithPeakLoad(int peakLoad);
    PowerUnit Build();
}