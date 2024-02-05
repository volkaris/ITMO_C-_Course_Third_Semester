using Core.InputPorts.IScenarios;

namespace InputAdapters.Exi;
public class ExitScenario : IScenario
{
    public string Name => "Exit from application";

    public void Run()
    {
        Environment.Exit(0);
    }
}