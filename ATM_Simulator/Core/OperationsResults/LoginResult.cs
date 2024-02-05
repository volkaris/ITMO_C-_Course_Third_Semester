namespace Core.OperationsResults;

public abstract record LoginResult
{
    public sealed record Success : LoginResult;

    public sealed record NotFound : LoginResult;
}