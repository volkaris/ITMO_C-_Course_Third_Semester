namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories;

public class MemoryTiming
{
    public MemoryTiming(double timingCl, double timingTrcd, double timingTrp, double frequencyMHz, double voltage)
    {
        TimingCL = timingCl;
        TimingTrcd = timingTrcd;
        TimingTrp = timingTrp;
        FrequencyMHz = frequencyMHz;
        Voltage = voltage;
    }

    public double TimingCL { get; } // CAS Latency
    public double TimingTrcd { get; } // RAS to CAS Delay
    public double TimingTrp { get; } // RAS Precharge Time
    public double FrequencyMHz { get; set; }
    public double Voltage { get; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;

        var other = (MemoryTiming)obj;
        return TimingCL == other.TimingCL && TimingTrcd == other.TimingTrcd && TimingTrp == other.TimingTrp
               && FrequencyMHz == other.FrequencyMHz && Voltage == other.Voltage;
    }

    public override int GetHashCode()
    {
        return TimingCL.GetHashCode() ^ TimingTrcd.GetHashCode() ^ TimingTrp.GetHashCode()
               ^ FrequencyMHz.GetHashCode() ^ Voltage.GetHashCode();
    }
}