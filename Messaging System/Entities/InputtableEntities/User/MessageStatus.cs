namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.InputtableEntities.User;

public abstract record MessageStatus
{
    private MessageStatus() { }

    public sealed record Read() : MessageStatus
    {
        public override string ToString()
        {
            return "Read";
        }
    }

    public sealed record NotRead() : MessageStatus
    {
        public override string ToString()
        {
            return "Not read";
        }
    }
}