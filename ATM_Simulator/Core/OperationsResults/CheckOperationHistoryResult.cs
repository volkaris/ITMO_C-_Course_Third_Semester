namespace Core.OperationsResults;

public abstract record CheckOperationHistoryResult
{
    public sealed record Success(string History) : CheckOperationHistoryResult;

    public sealed record Unsuccess : CheckOperationHistoryResult;
}