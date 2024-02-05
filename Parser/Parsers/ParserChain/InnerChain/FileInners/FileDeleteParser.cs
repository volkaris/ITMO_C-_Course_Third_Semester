using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.ParserExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParsersEnumerator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.InnerChain.FileInners;

public class FileDeleteParser : InnerChainLink
{
    public override ParsingResult Handle(ParserEnumerator enumerator)
    {
        if (enumerator.Current == "delete")
        {
            enumerator.MoveNext();
            string sourcePath = enumerator.Current;
            return new ParsingResult.SuccessParsing(new FileDelete(sourcePath));
        }

        return Next?.Handle(enumerator) ?? new ParsingResult.UnsuccessParsing("command can't be executed");
    }
}