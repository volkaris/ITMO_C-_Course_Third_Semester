namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards.MotherboardFormFactors;

public class Eatx : IMotherboardFormFactor
{
    public override bool Equals(object? obj)
    {
        return obj is Eatx;
    }

    public override int GetHashCode()
    {
        return GetType().GetHashCode();
    }
}