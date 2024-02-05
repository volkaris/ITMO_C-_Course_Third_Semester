using System.Diagnostics.CodeAnalysis;
using Core.InputPorts.IScenarios;

namespace InputAdapters.Exi;

public class ExitScenarioProvider : IScenarioProvider
{
    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new ExitScenario();
        return true;
    }
}