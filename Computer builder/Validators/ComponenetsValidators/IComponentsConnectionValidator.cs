using Itmo.ObjectOrientedProgramming.Lab2.ComponenetsConnectionResults;
using Itmo.ObjectOrientedProgramming.Lab2.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators.ComponenetsValidators;

public interface IComponentsConnectionValidator
{
    public ComponenetsConnectionsResult CanBeBuildCorrectly(NotAssembledComputerShell computerShell);
}