using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Ddr;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.RamFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComponentsRepository;

public class RandomAccessMemoryRepository : IComponentRepository<RandomAccessMemory>
{
    private Dictionary<string, RandomAccessMemory> _availableComponents = new();

    public RandomAccessMemoryRepository()
    {
        RandomAccessMemory kingstonFuryRenegadePro = new RandomAccessMemoryBuilder()
            .WithName("Kingston FURY Renegade Pro")
            .WithPossibleAvailableFrequencies(new List<MemoryTiming>() { new(36, 38, 38, 4800, 1.1) })
            .WithStandartMemoryTiming(new MemoryTiming(36, 38, 38, 4800, 1.1)).WithSizeInGb(128)
            .WithFormFactor(new Dimm()).WithDdrVersion(new Ddr5()).WithPowerConsumption(1.1).Build();

        RandomAccessMemory gSkillTridentZ5Rgb = new RandomAccessMemoryBuilder()
            .WithName("G.Skill Trident Z5 RGB")
            .WithPossibleAvailableFrequencies(new List<MemoryTiming>() { new(40, 48, 48, 8000, 1.35) })
            .WithStandartMemoryTiming(new MemoryTiming(40, 48, 48, 8000, 1.35)).WithSizeInGb(48)
            .WithFormFactor(new Dimm()).WithDdrVersion(new Ddr5()).WithPowerConsumption(1.35).Build();

        RandomAccessMemory kingstonFuryRenegadeSilverRgb = new RandomAccessMemoryBuilder()
            .WithName("Kingston FURY Renegade Silver RGB")
            .WithPossibleAvailableFrequencies(new List<MemoryTiming>()
            {
                new(38, 38, 38, 4800, 1.35),
                new(40, 40, 40, 5600, 1.35), new(32, 38, 38, 6000, 1.35),
            })
            .WithStandartMemoryTiming(new MemoryTiming(32, 38, 38, 6000, 1.35)).WithSizeInGb(64)
            .WithFormFactor(new Dimm()).WithDdrVersion(new Ddr5()).WithPowerConsumption(1.35).Build();

        RandomAccessMemory teamGroupTForceDeltaRgb = new RandomAccessMemoryBuilder()
            .WithName("Team Group T-Force Delta RGB")
            .WithPossibleAvailableFrequencies(new List<MemoryTiming>() { new(38, 48, 48, 8000, 1.45) })
            .WithStandartMemoryTiming(new MemoryTiming(38, 48, 48, 8000, 1.45)).WithSizeInGb(32)
            .WithFormFactor(new Dimm()).WithDdrVersion(new Ddr5()).WithPowerConsumption(1.35).Build();

        _availableComponents.Add(kingstonFuryRenegadePro.Name, kingstonFuryRenegadePro);
        _availableComponents.Add(gSkillTridentZ5Rgb.Name, gSkillTridentZ5Rgb);
        _availableComponents.Add(kingstonFuryRenegadeSilverRgb.Name, kingstonFuryRenegadeSilverRgb);
        _availableComponents.Add(teamGroupTForceDeltaRgb.Name, teamGroupTForceDeltaRgb);
    }

    public RandomAccessMemoryRepository(IEnumerable<RandomAccessMemory> availableComponents)
        : this()
    {
        _availableComponents =
            availableComponents.ToDictionary(
                randomAccessMemory => randomAccessMemory.Name,
                randomAccessMemory => randomAccessMemory);
    }

    public IReadOnlyCollection<RandomAccessMemory> AvailableRandomAccessMemories =>
        _availableComponents.Values.ToList();

    public void Add(RandomAccessMemory item)
    {
        throw new System.NotImplementedException();
    }

    public RandomAccessMemory GetItem(string name)
    {
        throw new System.NotImplementedException();
    }
}