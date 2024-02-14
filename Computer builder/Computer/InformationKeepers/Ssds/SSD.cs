using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers.ConnectionVariant;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers;

public class Ssd : IInformationKeeper
{
    internal Ssd(
        int powerConsumption,
        int maxWorkVelocity,
        int capacity,
        IConnectionVariant connectionVariant,
        string name)
    {
        PowerConsumption = powerConsumption;
        MaxWorkVelocity = maxWorkVelocity;
        Capacity = capacity;
        ConnectionVariant = connectionVariant;
        Name = name;
    }

    public string Name { get; }
    public int Capacity { get; }
    public int MaxWorkVelocity { get; }
    public int PowerConsumption { get; }
    public IConnectionVariant ConnectionVariant { get; }
}