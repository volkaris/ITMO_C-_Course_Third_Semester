using Itmo.ObjectOrientedProgramming.Lab2.ComponenetsConnectionResults;
using Itmo.ObjectOrientedProgramming.Lab2.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators.ComponenetsValidators;

public class ProccesorValidator : IComponentsConnectionValidator
{
    public ComponenetsConnectionsResult CanBeBuildCorrectly(NotAssembledComputerShell computerShell)
    {
        if (computerShell.GraphicCardCanBeInstalled() && !computerShell.Processor.BuiltInVideoCore)
            return new ComponenetsConnectionsResult.FatalProblem("Video card can't be fitted into corpus");

        return new ComponenetsConnectionsResult.ComponenetsConnectedSuccessfully();
    }
}