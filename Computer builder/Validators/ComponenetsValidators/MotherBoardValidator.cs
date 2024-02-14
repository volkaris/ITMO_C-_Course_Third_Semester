using Itmo.ObjectOrientedProgramming.Lab2.ComponenetsConnectionResults;
using Itmo.ObjectOrientedProgramming.Lab2.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators.ComponenetsValidators;

public class MotherBoardValidator : IComponentsConnectionValidator
{
    public ComponenetsConnectionsResult CanBeBuildCorrectly(NotAssembledComputerShell computerShell)
    {
        if (!computerShell.Motherboard.IsProcessorCompatible(computerShell.Processor))
            return new ComponenetsConnectionsResult.FatalProblem("Sockets of motherboard and proccessor is not same");

        if (!computerShell.Motherboard.Bios.ValidateProccesorAvailability(computerShell.Processor))
            return new ComponenetsConnectionsResult.FatalProblem("Motherboard doesn't support this proccesor");

        if (!computerShell.Motherboard.ValidateXmrTechonologyAvailability(computerShell.Memory))
            return new ComponenetsConnectionsResult.FatalProblem("Motherboard doesn't support XMR techonology");

        if (!computerShell.Motherboard.ValidateWifiCompatibility(computerShell.WifiAdapter))
        {
            return new ComponenetsConnectionsResult.FatalProblem(
                "WifiCompatibility problem. " +
                "You have both motherboard with wiFi module and WiFi module as separate component." +
                "Choose only one of this");
        }

        return new ComponenetsConnectionsResult.ComponenetsConnectedSuccessfully();
    }
}