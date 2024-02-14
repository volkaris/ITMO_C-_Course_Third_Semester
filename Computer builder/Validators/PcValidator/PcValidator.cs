using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.ComponenetsConnectionResults;
using Itmo.ObjectOrientedProgramming.Lab2.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.PCBuildResults;
using Itmo.ObjectOrientedProgramming.Lab2.Validators.ComponenetsValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators.PcValidator;

public class PcValidator : IPcValidator
{
    public PcBuildResult CanBeBuildCorrectly(NotAssembledComputerShell computerShell)
    {
        var validators = new List<IComponentsConnectionValidator>()
        {
            new MotherBoardValidator(), new CoolerValidator(), new MemoryValidator(), new VideoCardValidator(),
            new CorpusValidator(), new ProccesorValidator(), new PowerUnitValidator(),
        };

        var connectionsResult =
            validators.Select(validator => validator.CanBeBuildCorrectly(computerShell)).ToList();

        IList<ComponenetsConnectionsResult> fatalConnectionsResults = new List<ComponenetsConnectionsResult>();
        IList<ComponenetsConnectionsResult> buildInformation = new List<ComponenetsConnectionsResult>();

        foreach (ComponenetsConnectionsResult result in connectionsResult)
        {
            if (result is not ComponenetsConnectionsResult.ComponenetsConnectedSuccessfully)
                fatalConnectionsResults.Add(result);
            else
                buildInformation.Add(result);
        }

        if (fatalConnectionsResults.Any())
            return new PcBuildResult.UnsuccesfullBuild(fatalConnectionsResults);

        var computer = new PersonalComputer(computerShell);

        return new PcBuildResult.SuccesfullBuild(computer, buildInformation);
    }
}