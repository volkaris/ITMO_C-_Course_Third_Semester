namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Hull;

public class ThirdStrenghtClassHull : IHull
{
    private readonly double _damageDispersion = 0.5;
    private readonly int _noMoreHealthLeft;

    private double _survivableDamage = 2000;

    public ThirdStrenghtClassHull()
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