namespace Core.InputPorts.IScenarios;

public interface IScenario
{
    string Name { get; }

    void Run();
}