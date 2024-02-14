using System;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers.Hdds;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;

public class HddBuilder : IHddBuilder
{
    private int? _capacity;
    private int? _spindleRotationSpeed;
    private int? _powerConsumption;
    private string? _name;

    public HddBuilder()
    {
    }

    public HddBuilder(Hdd hdd)
    {
        _capacity = hdd.Capacity;
        _spindleRotationSpeed = hdd.SpindleRotationSpeed;
        _powerConsumption = hdd.PowerConsumption;
    }

    public IHddBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IHddBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public IHddBuilder WithSpindleRotationSpeed(int spindleRotationSpeed)
    {
        _spindleRotationSpeed = spindleRotationSpeed;
        return this;
    }

    public IHddBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Hdd Build()
    {
        return new Hdd(
            _capacity ?? throw new ArgumentNullException(nameof(_capacity)),
            _spindleRotationSpeed ?? throw new ArgumentNullException(nameof(_spindleRotationSpeed)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}