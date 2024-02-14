using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComponenetsConnectionResults;
using Itmo.ObjectOrientedProgramming.Lab2.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCBuildResults;

public abstract record PcBuildResult
{
    public sealed record SuccesfullBuild(
        PersonalComputer BuildedPersonalComputer,
        IEnumerable<ComponenetsConnectionsResult> BuildInformation) : PcBuildResult;
    public record UnsuccesfullBuild(IEnumerable<ComponenetsConnectionsResult> FailReasons) : PcBuildResult;
}