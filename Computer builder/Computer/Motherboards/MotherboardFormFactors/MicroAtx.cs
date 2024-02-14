namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards.MotherboardFormFactors;

public class MicroAtx : IMotherboardFormFactor
{
    public override bool Equals(object? obj)
    {
        return obj is MicroAtx;
    }

    public override int GetHashCode()
    {
        return GetType().GetHashCode();
    }
}