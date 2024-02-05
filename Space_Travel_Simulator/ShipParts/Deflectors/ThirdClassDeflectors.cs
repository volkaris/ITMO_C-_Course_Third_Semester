namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Deflectors;

public class ThirdClassDeflectors : IDeflector
{
    private double _survivableDamage = 2000;
    private static int NoMoreHealthLeft => 0;

    public void Destroy()
    {
        _survivableDamage = 0;
    }

    public bool CanAbsorbDamage(int damage)
    {
        if (_survivableDamage - damage >= NoMoreHealthLeft)
        {
            _survivableDamage -= damage;
            return true;
        }

        return false;
    }
}