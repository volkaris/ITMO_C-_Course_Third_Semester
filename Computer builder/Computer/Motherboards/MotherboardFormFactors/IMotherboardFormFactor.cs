namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards.MotherboardFormFactors;

public interface IMotherboardFormFactor
{
    public bool Equals(object? obj);

    public int GetHashCode();
}