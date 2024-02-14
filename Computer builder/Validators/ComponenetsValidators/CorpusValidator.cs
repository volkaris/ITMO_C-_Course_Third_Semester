using Itmo.ObjectOrientedProgramming.Lab2.ComponenetsConnectionResults;
using Itmo.ObjectOrientedProgramming.Lab2.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators.ComponenetsValidators;

public class CorpusValidator : IComponentsConnectionValidator
{
    public ComponenetsConnectionsResult CanBeBuildCorrectly(NotAssembledComputerShell computerShell)
    {
        if (!computerShell.PcBody.IsMotherboardSupported(computerShell.Motherboard))
            return new ComponenetsConnectionsResult.FatalProblem("Motherboard can't be fitted into ");

        return new ComponenetsConnectionsResult.ComponenetsConnectedSuccessfully();
    }
}