using Itmo.ObjectOrientedProgramming.Lab2.ComponenetsConnectionResults;
using Itmo.ObjectOrientedProgramming.Lab2.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators.ComponenetsValidators;

public class CoolerValidator : IComponentsConnectionValidator
{
    public ComponenetsConnectionsResult CanBeBuildCorrectly(NotAssembledComputerShell computerShell)
    {
        if (!computerShell.Cooler.CanHandleProccesor(computerShell.Processor))
        {
            return new ComponenetsConnectionsResult.DisclaimerOfWarranty(
                "Cooler has quity low heat consumption");
        }

        return new ComponenetsConnectionsResult.ComponenetsConnectedSuccessfully();
    }
}