using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers.ConnectionVariant;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;

public interface ISsdBuilder
{
    ISsdBuilder WithName(string name);
    ISsdBuilder WithCapacity(int capacity);
    ISsdBuilder WithMaxWorkVelocity(int maxWorkVelocity);

    ISsdBuilder WithPowerConsumption(int powerConsumption);
    ISsdBuilder WithConnectionVariant(IConnectionVariant connectionVariant);

    Ssd Build();
}