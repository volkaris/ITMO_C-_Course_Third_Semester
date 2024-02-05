using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class YouArentSuppostedToSeeThisException : Exception
{
    public YouArentSuppostedToSeeThisException()
        : base(
            "You shouldn't see this text.This exception was made because the compiler does not allow otherwise")
    {
    }

    public YouArentSuppostedToSeeThisException(string message)
        : base(message)
    {
    }

    public YouArentSuppostedToSeeThisException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}