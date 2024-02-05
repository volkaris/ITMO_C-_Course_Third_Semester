namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public abstract record FileSystemExecutionResult
{
    private FileSystemExecutionResult() { }

    public sealed record SuccessFileSystemExecution() : FileSystemExecutionResult;

    public sealed record UnsuccessFileSystemExecution(string FailReason) : FileSystemExecutionResult;
}