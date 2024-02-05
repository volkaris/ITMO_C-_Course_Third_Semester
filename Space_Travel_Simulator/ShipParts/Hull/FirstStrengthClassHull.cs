namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Hull;

public class FirstStrengthClassHull : IHull
{
    private readonly double _damageDispersion = 0.9;
    private readonly int _noMoreHealthLeft;

    private double _survivableDamage = 100;

    public FirstStrengthClassHull()
    {
        _noMoreHealthLeft = 0;
    }

    public bool CanAbsorbDamage(int damage)
    {
        if (_survivableDamage - (damage * _damageDispersion) >= _noMoreHealthLeft)
        {
            _survivableDamage -= damage;
            return true;
        }

        return false;
    }
}