namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Ddr;

public class Ddr3 : IDdr
{
    public override bool Equals(object? obj)
    {
        return obj is Ddr3;
    }

    public override int GetHashCode()
    {
        return GetType().GetHashCode();
    }
}