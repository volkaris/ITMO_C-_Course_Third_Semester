using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.ParserExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParsersEnumerator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.OuterChain;

public class ConnectBuilder
{
    private string? _mode;
    private string? _pathInCommand;

    public ConnectBuilder WithPathInCommand(ParserEnumerator enumerator)
    {
        enumerator.MoveNext();
        _pathInCommand = enumerator.Current;
        return this;
    }

    public ConnectBuilder WithMode(ParserEnumerator enumerator)
    {
        enumerator.MoveNext();
        _mode = enumerator.Current;
        return this;
    }

    public ParsingResult Build()
    {
        if (_pathInCommand is null) return new ParsingResult.UnsuccessParsing("Why you did this? For what reason?");

        if (_mode is null) return new ParsingResult.UnsuccessParsing("Mode is obligatory parametr");

        if (_mode is not "local")
        {
            return new ParsingResult.UnsuccessParsing(
                "anything except local file system dont supported");
        }

        return new ParsingResult.SuccessParsing(new Connect(_pathInCommand));
    }
}