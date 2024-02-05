namespace Itmo.ObjectOrientedProgramming.Lab1.ShipParts.Deflectors.Photonic;

public abstract class PhotonicDecorator : IDeflector
{
    protected PhotonicDecorator(IDeflector deflector)
    {
        DecoratedDeflector = deflector;
    }

    protected IDeflector DecoratedDeflector { get; }
    public abstract bool CanAbsorbDamage(int damage);
    public abstract void Destroy();
}