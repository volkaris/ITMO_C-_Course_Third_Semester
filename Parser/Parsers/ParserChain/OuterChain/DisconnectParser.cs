using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.ParserExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParsersEnumerator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.OuterChain;

public class DisconnectParser : OuterChainLink
{
    public override ParsingResult Handle(ParserEnumerator enumerator)
    {
        if (enumerator.Current == "disconnect") return new ParsingResult.SuccessParsing(new Disconnect());

        return NextOuterChainLink?.Handle(enumerator) ??
               new ParsingResult.UnsuccessParsing("command can't be executed");
    }
}