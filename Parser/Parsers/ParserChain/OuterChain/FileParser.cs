using Itmo.ObjectOrientedProgramming.Lab4.ParserExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParsersEnumerator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.OuterChain;

public class FileParser : OuterChainLink
{
    public override ParsingResult Handle(ParserEnumerator enumerator)
    {
        if (enumerator.Current == "file")
        {
            return NextInnerChainLink?.Handle(enumerator) ??
                   new ParsingResult.UnsuccessParsing("command can't be executed");
        }

        return NextOuterChainLink?.Handle(enumerator) ??
               new ParsingResult.UnsuccessParsing("command can't be executed");
    }
}