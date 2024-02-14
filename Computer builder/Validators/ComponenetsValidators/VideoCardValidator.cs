using System;
using Itmo.ObjectOrientedProgramming.Lab2.ComponenetsConnectionResults;
using Itmo.ObjectOrientedProgramming.Lab2.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators.ComponenetsValidators;

public class VideoCardValidator : IComponentsConnectionValidator
{
    public ComponenetsConnectionsResult CanBeBuildCorrectly(NotAssembledComputerShell computerShell)
    {
        ArgumentNullException.ThrowIfNull(computerShell.GraphicCards);
        if (!computerShell.GraphicCardCanBeInstalled())
            return new ComponenetsConnectionsResult.FatalProblem("Video card can't be fitted into corpus");
        return new ComponenetsConnectionsResult.ComponenetsConnectedSuccessfully();
    }
}