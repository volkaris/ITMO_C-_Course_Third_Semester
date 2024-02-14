using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers.ConnectionVariant;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers;

public interface IInformationKeeper
{
    public IConnectionVariant ConnectionVariant { get; }
    public int PowerConsumption { get; }
}