namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Deflectors.Photonic;

public class PhotonicDeflectors : PhotonicDecorator
{
    private readonly int _noMoreHealthLeft;

    private int _maxSurvivableFlaresAmount = 3;

    public PhotonicDeflectors(IDeflector deflector)
        : base(deflector)
    {
        _noMoreHealthLeft = 0;
    }

    public override bool CanAbsorbDamage(int damage)
    {
        return DecoratedDeflector.CanAbsorbDamage(damage);
    }

    public bool CanAbsorbPhotonicDamage()
    {
        if (_maxSurvivableFlaresAmount <= _noMoreHealthLeft) return false;
        _maxSurvivableFlaresAmount--;
        return true;
    }

    public override void Destroy()
    {
        DecoratedDeflector.Destroy();
    }
}