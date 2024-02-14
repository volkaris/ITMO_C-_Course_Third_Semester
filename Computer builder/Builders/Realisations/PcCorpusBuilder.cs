using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards.MotherboardFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.PcCorpus;
using Itmo.ObjectOrientedProgramming.Lab2.Sizes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;

public class PcCorpusBuilder : IPcCorpusBuilder
{
    private Size? _maxVideoCardSize;
    private List<IMotherboardFormFactor> _supportedMotherboardsFormFactors;
    private Size? _pсСorpusSize;
    private string? _name;

    public PcCorpusBuilder()
    {
        _supportedMotherboardsFormFactors = new List<IMotherboardFormFactor>();
    }

    public PcCorpusBuilder(PсСorpus pcCorpus)
    {
        _name = pcCorpus.Name;
        _maxVideoCardSize = pcCorpus.MaxVideoCardSize;
        _supportedMotherboardsFormFactors = pcCorpus.SupportedMotherboardsFormFactors.ToList();
        _pсСorpusSize = pcCorpus.PсСorpusSize;
    }

    public IPcCorpusBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IPcCorpusBuilder MaxVideoCardSize(Size maxVideoCardSize)
    {
        _maxVideoCardSize = maxVideoCardSize;
        return this;
    }

    public IPcCorpusBuilder SupportedMotherboardsFormFactors(
        IMotherboardFormFactor supportedMotherboardsFormFactor)
    {
        _supportedMotherboardsFormFactors.Add(supportedMotherboardsFormFactor);
        return this;
    }

    public IPcCorpusBuilder WithСorpusSize(Size pсСorpusSize)
    {
        _pсСorpusSize = pсСorpusSize;
        return this;
    }

    public PсСorpus Build()
    {
        return new PсСorpus(
            _maxVideoCardSize ?? throw new ArgumentNullException(nameof(_maxVideoCardSize)),
            _supportedMotherboardsFormFactors ?? throw new ArgumentNullException(nameof(_supportedMotherboardsFormFactors)),
            _pсСorpusSize ?? throw new ArgumentNullException(nameof(_pсСorpusSize)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}