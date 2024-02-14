using Itmo.ObjectOrientedProgramming.Lab2.ComponenetsConnectionResults;
using Itmo.ObjectOrientedProgramming.Lab2.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators.ComponenetsValidators;

public class MemoryValidator : IComponentsConnectionValidator
{
    public ComponenetsConnectionsResult CanBeBuildCorrectly(NotAssembledComputerShell computerShell)
    {
        if (!computerShell.Memory.IsDdrStandartCompatibleWithMotherboardDdr(computerShell.Motherboard))
            return new ComponenetsConnectionsResult.FatalProblem("Motherboard are'n compatible with DDR standart of memory");
        return new ComponenetsConnectionsResult.ComponenetsConnectedSuccessfully();
    }
}