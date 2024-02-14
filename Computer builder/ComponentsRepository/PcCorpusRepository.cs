using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards.MotherboardFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.PcCorpus;
using Itmo.ObjectOrientedProgramming.Lab2.Sizes;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComponentsRepository;

public class PcCorpusRepository : IComponentRepository<PсСorpus>
{
    private Dictionary<string, PсСorpus> _availableComponents = new();

    public PcCorpusRepository()
    {
        PсСorpus coolerMasterCosmosC700M = new PcCorpusBuilder().WithName("Cooler Master Cosmos C700M")
            .SupportedMotherboardsFormFactors(new Eatx()).SupportedMotherboardsFormFactors(new MicroAtx())
            .SupportedMotherboardsFormFactors(new MiniItx()).SupportedMotherboardsFormFactors(new Atx())
            .MaxVideoCardSize(new Size(490, 200)).WithСorpusSize(new Size(600, 700)).Build();

        PсСorpus coolerMasterCosmosC700PBlackEdition = new PcCorpusBuilder()
            .WithName("Cooler Master Cosmos C700P BLACK EDITION")
            .SupportedMotherboardsFormFactors(new Eatx()).SupportedMotherboardsFormFactors(new MicroAtx())
            .SupportedMotherboardsFormFactors(new MiniItx()).SupportedMotherboardsFormFactors(new Atx())
            .MaxVideoCardSize(new Size(490, 200)).WithСorpusSize(new Size(600, 700)).Build();

        PсСorpus thermaltakeDistroCase350P = new PcCorpusBuilder().WithName("Thermaltake DistroCase 350P")
            .SupportedMotherboardsFormFactors(new MicroAtx())
            .SupportedMotherboardsFormFactors(new MiniItx()).SupportedMotherboardsFormFactors(new Atx())
            .MaxVideoCardSize(new Size(320, 150)).WithСorpusSize(new Size(490, 600)).Build();

        PсСorpus msiMegProspect700R = new PcCorpusBuilder().WithName("MSI MEG PROSPECT 700R")
            .SupportedMotherboardsFormFactors(new Eatx()).SupportedMotherboardsFormFactors(new MicroAtx())
            .SupportedMotherboardsFormFactors(new MiniItx()).SupportedMotherboardsFormFactors(new Atx())
            .MaxVideoCardSize(new Size(700, 800)).WithСorpusSize(new Size(550, 600)).Build();
        _availableComponents.Add(coolerMasterCosmosC700M.Name, coolerMasterCosmosC700M);
        _availableComponents.Add(coolerMasterCosmosC700PBlackEdition.Name, coolerMasterCosmosC700PBlackEdition);
        _availableComponents.Add(thermaltakeDistroCase350P.Name, thermaltakeDistroCase350P);
        _availableComponents.Add(msiMegProspect700R.Name, msiMegProspect700R);
    }

    public PcCorpusRepository(IEnumerable<PсСorpus> availableComponents)
        : this()
    {
        _availableComponents =
            availableComponents.ToDictionary(pсСorpus => pсСorpus.Name, pсСorpus => pсСorpus);
    }

    public IReadOnlyCollection<PсСorpus> AvailablePсСorpuses => _availableComponents.Values.ToList();

    public void Add(PсСorpus item)
    {
        _availableComponents.Add(item.Name, item);
    }

    public PсСorpus GetItem(string name)
    {
        return _availableComponents[name];
    }
}