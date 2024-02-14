using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers.Hdds;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;

public interface IHddBuilder
{
    IHddBuilder WithName(string name);
    IHddBuilder WithCapacity(int capacity);
    IHddBuilder WithSpindleRotationSpeed(int spindleRotationSpeed);
    IHddBuilder WithPowerConsumption(int powerConsumption);

    Hdd Build();
}