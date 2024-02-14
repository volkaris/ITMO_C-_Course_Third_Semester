using Itmo.ObjectOrientedProgramming.Lab2.ComponenetsConnectionResults;
using Itmo.ObjectOrientedProgramming.Lab2.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators.ComponenetsValidators;

public class PowerUnitValidator : IComponentsConnectionValidator
{
    public ComponenetsConnectionsResult CanBeBuildCorrectly(NotAssembledComputerShell computerShell)
    {
        return !computerShell.PowerUnit.HanHandleEnergy(computerShell.ConsumableEnergy())
            ? new ComponenetsConnectionsResult.BuildingRemarks("Getting little on energy. Computer has barely enough energy to start")
            : new ComponenetsConnectionsResult.ComponenetsConnectedSuccessfully();
    }
}