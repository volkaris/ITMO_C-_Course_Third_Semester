using System.Diagnostics.CodeAnalysis;

namespace Core.InputPorts.IScenarios;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}