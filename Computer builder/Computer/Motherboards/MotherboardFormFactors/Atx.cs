namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards.MotherboardFormFactors;

public class Atx : IMotherboardFormFactor
{
    public override bool Equals(object? obj)
    {
        return obj is Atx;
    }

    public override int GetHashCode()
    {
        return GetType().GetHashCode();
    }
}