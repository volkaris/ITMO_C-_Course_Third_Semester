namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Ddr;

public class Ddr5 : IDdr
{
    public override bool Equals(object? obj)
    {
        return obj is Ddr5;
    }

    public override int GetHashCode()
    {
        return GetType().GetHashCode();
    }
}