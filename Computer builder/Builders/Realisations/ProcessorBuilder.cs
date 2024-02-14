using System;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Proccesors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;

public class ProcessorBuilder : IProcessorBuilder
{
    private int? _coresAmount;
    private double? _coresFrequency;
    private Socket? _socket;
    private bool? _builtInVideoCore;
    private int? _ramMaximumFrequency;
    private int? _tdp;
    private int? _powerConsumption;
    private string? _name;

    public ProcessorBuilder()
    {
    }

    public ProcessorBuilder(Processor processor)
    {
        _coresAmount = processor.CoresAmount;
        _coresFrequency = processor.CoresFrequency;
        _socket = processor.Socket;
        _builtInVideoCore = processor.BuiltInVideoCore;
        _ramMaximumFrequency = processor.RamMaximumFrequency;
        _tdp = processor.Tdp;
        _powerConsumption = processor.PowerConsumption;
    }

    public IProcessorBuilder WithCoresAmount(int coresAmount)
    {
        _coresAmount = coresAmount;

        return this;
    }

    public IProcessorBuilder WithCoresFrequency(double coresFrequency)
    {
        _coresFrequency = coresFrequency;
        return this;
    }

    public IProcessorBuilder WithSocket(Socket socket)
    {
        _socket = socket;
        return this;
    }

    public IProcessorBuilder WithBuiltInVideoCore(bool builtInVideoCore)
    {
        _builtInVideoCore = builtInVideoCore;

        return this;
    }

    public IProcessorBuilder WithRamMaximumFrequency(int ramMaximumFrequency)
    {
        _ramMaximumFrequency = ramMaximumFrequency;
        return this;
    }

    public IProcessorBuilder WithTdp(int tdp)
    {
        _tdp = tdp;

        return this;
    }

    public IProcessorBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IProcessorBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public Processor Build()
    {
        return new Processor(
            _coresAmount ?? throw new ArgumentNullException(nameof(_coresAmount)),
            _coresFrequency ?? throw new ArgumentNullException(nameof(_coresFrequency)),
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _builtInVideoCore ?? throw new ArgumentNullException(nameof(_builtInVideoCore)),
            _ramMaximumFrequency ?? throw new ArgumentNullException(nameof(_ramMaximumFrequency)),
            _tdp ?? throw new ArgumentNullException(nameof(_tdp)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}