using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards.MotherboardFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Sizes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.PcCorpus;

public class PсСorpus
{
    private readonly List<IMotherboardFormFactor> _supportedMotherboardsFormFactors;

    internal PсСorpus(
        Size maxVideoCardSize,
        IEnumerable<IMotherboardFormFactor> supportedMotherboardsFormFactors,
        Size pсСorpusSize,
        string name)
    {
        MaxVideoCardSize = maxVideoCardSize;
        _supportedMotherboardsFormFactors = supportedMotherboardsFormFactors.ToList();
        PсСorpusSize = pсСorpusSize;
        Name = name;
    }

    public string Name { get; }
    public Size MaxVideoCardSize { get; }

    public IEnumerable<IMotherboardFormFactor> SupportedMotherboardsFormFactors =>
        _supportedMotherboardsFormFactors;

    public Size PсСorpusSize { get; }

    public bool IsMotherboardSupported(Motherboard motherboard)
    {
        return SupportedMotherboardsFormFactors.Any(formFactor => Equals(formFactor, motherboard.FormFactor));
    }
}