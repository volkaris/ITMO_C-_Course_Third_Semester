namespace Itmo.ObjectOrientedProgramming.Lab4.CommandExecutionResult;

public abstract record CommandsExecutionResult
{
    private CommandsExecutionResult() { }

    public sealed record SuccessCommandExecution() : CommandsExecutionResult;

    public sealed record UnsuccessCommandExecution(string FailReason) : CommandsExecutionResult;
}