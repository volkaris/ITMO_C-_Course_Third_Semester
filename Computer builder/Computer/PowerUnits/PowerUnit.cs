namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.PowerUnits;

public class PowerUnit
{
    private readonly double _vendorOverestimationCoefficient = 0.7;

    internal PowerUnit(int peakLoad, string name)
    {
        PeakLoad = peakLoad;
        Name = name;
    }

    public string Name { get; }
    public int PeakLoad { get; }

    public bool HanHandleEnergy(double energyAmount)
    {
        return PeakLoad > energyAmount * _vendorOverestimationCoefficient;
    }
}