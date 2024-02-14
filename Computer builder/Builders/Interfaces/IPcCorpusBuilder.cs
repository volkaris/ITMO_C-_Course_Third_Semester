using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards.MotherboardFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.PcCorpus;
using Itmo.ObjectOrientedProgramming.Lab2.Sizes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;

public interface IPcCorpusBuilder
{
    IPcCorpusBuilder WithName(string name);
    IPcCorpusBuilder MaxVideoCardSize(Size maxVideoCardSize);

    IPcCorpusBuilder SupportedMotherboardsFormFactors(
        IMotherboardFormFactor supportedMotherboardsFormFactor);

    IPcCorpusBuilder WithСorpusSize(Size pсСorpusSize);

    PсСorpus Build();
}