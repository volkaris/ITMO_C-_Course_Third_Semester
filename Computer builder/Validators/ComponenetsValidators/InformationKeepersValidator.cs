using Itmo.ObjectOrientedProgramming.Lab2.ComponenetsConnectionResults;
using Itmo.ObjectOrientedProgramming.Lab2.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators.ComponenetsValidators;

public class InformationKeepersValidator : IComponentsConnectionValidator
{
    public ComponenetsConnectionsResult CanBeBuildCorrectly(NotAssembledComputerShell computerShell)
    {
        if (!computerShell.HaveAnyMemoryKeepers())
            return new ComponenetsConnectionsResult.FatalProblem("Trying to build computer without any SSD or HDD");

        if (computerShell.Motherboard.DoesNotHaveAnySpaceForMemoryKeepers())
            return new ComponenetsConnectionsResult.FatalProblem("Trying to build computer without too many HDD's or SSD's");

        return new ComponenetsConnectionsResult.ComponenetsConnectedSuccessfully();
    }
}