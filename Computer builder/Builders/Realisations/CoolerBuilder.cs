using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Coolers;
using Itmo.ObjectOrientedProgramming.Lab2.Sizes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;

public class CoolerBuilder : ICoolerBuilder
{
    private int? _tdp;
    private List<string>? _supportedSockets;
    private Size? _size;
    private string? _name;

    public CoolerBuilder()
    {
    }

    public CoolerBuilder(Cooler cooler)
    {
        _tdp = cooler.Tdp;
        _supportedSockets = cooler.SupportedSockets.ToList();
        _size = cooler.Size;
    }

    public ICoolerBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICoolerBuilder WithTdp(int tdp)
    {
        _tdp = tdp;

        return this;
    }

    public ICoolerBuilder WithSupportedSockets(IEnumerable<string> supportedSocket)
    {
        _supportedSockets = supportedSocket.ToList();

        return this;
    }

    public ICoolerBuilder WithSize(Size size)
    {
        _size = size;
        return this;
    }

    public Cooler Build()
    {
        return new Cooler(
            _size ?? throw new ArgumentNullException(nameof(_size)),
            _supportedSockets ?? throw new ArgumentNullException(nameof(_supportedSockets)),
            _tdp ?? throw new ArgumentNullException(nameof(_tdp)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}