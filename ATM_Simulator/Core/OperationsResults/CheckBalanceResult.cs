namespace Core.OperationsResults;

public abstract record CheckBalanceResult
{
    public sealed record Success(long Balance) : CheckBalanceResult;

    public sealed record Unsuccess : CheckBalanceResult;
}