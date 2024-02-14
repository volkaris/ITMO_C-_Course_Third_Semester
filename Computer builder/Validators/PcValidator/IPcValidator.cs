using Itmo.ObjectOrientedProgramming.Lab2.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.PCBuildResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators.PcValidator;

public interface IPcValidator
{
    public PcBuildResult CanBeBuildCorrectly(NotAssembledComputerShell computerShell);
}