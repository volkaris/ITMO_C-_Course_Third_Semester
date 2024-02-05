namespace Core.OperationsResults;

public abstract record OperationResult
{
    public sealed record Success() : OperationResult;
    public sealed record Unsuccess(string FailReason) : OperationResult;
}