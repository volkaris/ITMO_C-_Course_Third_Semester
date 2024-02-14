using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Proccesors;

public class Processor
{
    internal Processor(
        int coresAmount,
        double coresFrequency,
        Socket socket,
        bool builtInVideoCore,
        int ramMaximumFrequency,
        int tdp,
        int powerConsumption,
        string name)
    {
        CoresAmount = coresAmount;
        CoresFrequency = coresFrequency;
        Socket = socket;
        BuiltInVideoCore = builtInVideoCore;
        RamMaximumFrequency = ramMaximumFrequency;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public string Name { get; }
    public int CoresAmount { get; }
    public double CoresFrequency { get; }
    public Socket Socket { get; }
    public bool BuiltInVideoCore { get; }
    public int RamMaximumFrequency { get; }
    public int Tdp { get; }
    public int PowerConsumption { get; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;

        var other = (Processor)obj;
        return CoresAmount == other.CoresAmount && Socket.CompatibleWith(other.Socket)
                                                && BuiltInVideoCore == other.BuiltInVideoCore &&
                                                RamMaximumFrequency == other.RamMaximumFrequency
                                                && Tdp == other.Tdp && PowerConsumption == other.PowerConsumption;
    }

    public override int GetHashCode()
    {
        return CoresAmount.GetHashCode() ^ CoresFrequency.GetHashCode() ^ Socket.GetHashCode()
               ^ BuiltInVideoCore.GetHashCode() ^ RamMaximumFrequency.GetHashCode() ^
               Tdp.GetHashCode() ^ PowerConsumption.GetHashCode();
    }
}