using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers.ConnectionVariant;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers.Hdds;

public class Hdd : IInformationKeeper
{
    internal Hdd(int capacity, int spindleRotationSpeed, int powerConsumption, string name)
    {
        Capacity = capacity;
        SpindleRotationSpeed = spindleRotationSpeed;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public string Name { get; }
    public int Capacity { get; }
    public int SpindleRotationSpeed { get; }
    public int PowerConsumption { get; }
    public IConnectionVariant ConnectionVariant { get; } = new SataConnection();
}