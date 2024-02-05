using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserExecutionResult;

public abstract record ParsingResult()
{
    public record SuccessParsing(ICommand Command) : ParsingResult;

    public record UnsuccessParsing(string FailReason) : ParsingResult;
}