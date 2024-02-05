using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeComands;
using Itmo.ObjectOrientedProgramming.Lab4.ParserExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParsersEnumerator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.InnerChain.TreeInners;

public class TreeGoToParser : InnerChainLink
{
    public override ParsingResult Handle(ParserEnumerator enumerator)
    {
        if (enumerator.Current == "goto")
        {
            enumerator.MoveNext();
            return new ParsingResult.SuccessParsing(new GotoCommand(enumerator.Current));
        }

        return Next?.Handle(enumerator)
               ?? new ParsingResult.UnsuccessParsing("command can't be executed");
    }
}