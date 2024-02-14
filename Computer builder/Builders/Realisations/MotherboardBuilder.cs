using System;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards.MotherboardFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Proccesors;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Ddr;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;

public class MotherboardBuilder : IMotherboardBuilder
{
    private Bios? _bios;

    private int? _amountOfPciLines;
    private int? _amountOfSataPort;
    private int? _memorySlotsNumber;
    private bool? _gotBuiltInWifiModule = false;
    private Socket? _socket;
    private string? _name;

    private ChipSet? _chipSet;
    private IDdr? _ddr;
    private IMotherboardFormFactor? _formFactor;

    public MotherboardBuilder() { }

    public MotherboardBuilder(Motherboard motherboard)
    {
        _bios = motherboard.Bios;
        _amountOfPciLines = motherboard.AmountOfPciLines;
        _amountOfSataPort = motherboard.AmountOfSataPorts;
        _memorySlotsNumber = motherboard.MemorySlotsNumber;
        _socket = motherboard.Socket;
        _name = motherboard.Name;
        _chipSet = motherboard.ChipSet;
        _ddr = motherboard.DdrStandard;
        _formFactor = motherboard.FormFactor;
        _gotBuiltInWifiModule = motherboard.GotBuiltInWifiModule;
    }

    public IMotherboardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IMotherboardBuilder WithBios(Bios bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherboardBuilder PciLinesAmount(int amountOfPciLines)
    {
        _amountOfPciLines = amountOfPciLines;
        return this;
    }

    public IMotherboardBuilder SataPortAmount(int amountOfSataPort)
    {
        _amountOfSataPort = amountOfSataPort;
        return this;
    }

    public IMotherboardBuilder WithSocket(Socket socket)
    {
        _socket = socket;
        return this;
    }

    public IMotherboardBuilder WithChipSet(ChipSet chipSet)
    {
        _chipSet = chipSet;
        return this;
    }

    public IMotherboardBuilder WithDdrStandard(IDdr ddr)
    {
        _ddr = ddr;
        return this;
    }

    public IMotherboardBuilder WithMemorySlotsNumber(int memorySlotsNumber)
    {
        _memorySlotsNumber = memorySlotsNumber;
        return this;
    }

    public IMotherboardBuilder WithMotherboardFormFactor(IMotherboardFormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherboardBuilder WithWifiModule(bool gotBuiltInWifiModule)
    {
        _gotBuiltInWifiModule = gotBuiltInWifiModule;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _chipSet ?? throw new ArgumentNullException(nameof(_chipSet)),
            _ddr ?? throw new ArgumentNullException(nameof(_ddr)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _amountOfPciLines ?? throw new ArgumentNullException(nameof(_amountOfPciLines)),
            _amountOfSataPort ?? throw new ArgumentNullException(nameof(_amountOfSataPort)),
            _memorySlotsNumber ?? throw new ArgumentNullException(nameof(_memorySlotsNumber)),
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _bios ?? throw new ArgumentNullException(nameof(_bios)),
            _gotBuiltInWifiModule ?? throw new ArgumentNullException(nameof(_gotBuiltInWifiModule)));
    }
}