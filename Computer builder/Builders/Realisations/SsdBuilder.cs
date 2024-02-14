using System;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers.ConnectionVariant;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;

public class SsdBuilder : ISsdBuilder
{
    private int? _capacity;
    private int? _maxWorkVelocity;
    private int? _powerConsumption;
    private IConnectionVariant? _connectionVariant;
    private string? _name;

    public SsdBuilder()
    {
    }

    public SsdBuilder(Ssd ssd)
    {
        _capacity = ssd.Capacity;
        _maxWorkVelocity = ssd.MaxWorkVelocity;
        _powerConsumption = ssd.PowerConsumption;
        _connectionVariant = ssd.ConnectionVariant;
    }

    public ISsdBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ISsdBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public ISsdBuilder WithMaxWorkVelocity(int maxWorkVelocity)
    {
        _maxWorkVelocity = maxWorkVelocity;
        return this;
    }

    public ISsdBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ISsdBuilder WithConnectionVariant(IConnectionVariant connectionVariant)
    {
        _connectionVariant = connectionVariant;
        return this;
    }

    public Ssd Build()
    {
        return new Ssd(
            _powerConsumption ?? throw new ArgumentNullException(nameof(_capacity)),
            _maxWorkVelocity ?? throw new ArgumentNullException(nameof(_maxWorkVelocity)),
            _capacity ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _connectionVariant ?? throw new ArgumentNullException(nameof(_connectionVariant)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}