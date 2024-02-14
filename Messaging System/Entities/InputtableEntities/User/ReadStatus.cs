namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.InputtableEntities.User;

public abstract record ReadStatus
{
    private ReadStatus() { }

    public sealed record SuccefullRead() : ReadStatus;

    public sealed record UnsuccesfullRead(string FailReason) : ReadStatus;
}