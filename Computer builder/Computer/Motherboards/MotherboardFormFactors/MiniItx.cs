namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards.MotherboardFormFactors;

public class MiniItx : IMotherboardFormFactor
{
    public override bool Equals(object? obj)
    {
        return obj is MiniItx;
    }

    public override int GetHashCode()
    {
        return GetType().GetHashCode();
    }
}