using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Ddr;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.RamFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;

public class RandomAccessMemoryBuilder : IRandomAccessMemoryBuilder
{
    private List<MemoryTiming>? _possibleAvailableFrequencies;
    private MemoryTiming? _standartMemoryTiming;
    private int? _sizeInGb;
    private RamFormFactor? _formFactor;
    private IDdr? _ddrVersion;
    private double? _powerConsumption;
    private string? _name;

    public RandomAccessMemoryBuilder()
    {
    }

    public RandomAccessMemoryBuilder(RandomAccessMemory randomAccessMemory)
    {
        _possibleAvailableFrequencies = randomAccessMemory.PossibleAvailableFrequencies.ToList();
        _standartMemoryTiming = randomAccessMemory.StandartMemoryTiming;
        _sizeInGb = randomAccessMemory.SizeInGb;
        _formFactor = randomAccessMemory.FormFactor;
        _ddrVersion = randomAccessMemory.DdrVersion;
        _powerConsumption = randomAccessMemory.PowerConsumption;
    }

    public IRandomAccessMemoryBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IRandomAccessMemoryBuilder WithPossibleAvailableFrequencies(
        IEnumerable<MemoryTiming> possibleAvailableFrequencies)
    {
        _possibleAvailableFrequencies = possibleAvailableFrequencies.ToList();
        return this;
    }

    public IRandomAccessMemoryBuilder WithStandartMemoryTiming(MemoryTiming standartMemoryTiming)
    {
        _standartMemoryTiming = standartMemoryTiming;
        return this;
    }

    public IRandomAccessMemoryBuilder WithSizeInGb(int sizeInGb)
    {
        _sizeInGb = sizeInGb;
        return this;
    }

    public IRandomAccessMemoryBuilder WithFormFactor(RamFormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRandomAccessMemoryBuilder WithDdrVersion(IDdr ddrVersion)
    {
        _ddrVersion = ddrVersion;
        return this;
    }

    public IRandomAccessMemoryBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public RandomAccessMemory Build()
    {
        return new RandomAccessMemory(
            _standartMemoryTiming ?? throw new ArgumentNullException(nameof(_standartMemoryTiming)),
            _possibleAvailableFrequencies ?? throw new ArgumentNullException(nameof(_possibleAvailableFrequencies)),
            _sizeInGb ?? throw new ArgumentNullException(nameof(_sizeInGb)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _ddrVersion ?? throw new ArgumentNullException(nameof(_ddrVersion)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}