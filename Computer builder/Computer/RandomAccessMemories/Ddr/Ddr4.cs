namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Ddr;

public class Ddr4 : IDdr
{
    public override bool Equals(object? obj)
    {
        return obj is Ddr4;
    }

    public override int GetHashCode()
    {
        return GetType().GetHashCode();
    }
}