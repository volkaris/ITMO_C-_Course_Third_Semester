using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.ParserExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParsersEnumerator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.InnerChain.FileInners;

public class FileMoveParser : InnerChainLink
{
    public override ParsingResult Handle(ParserEnumerator enumerator)
    {
        if (enumerator.Current == "move")
        {
            enumerator.MoveNext();

            string sourcePath = enumerator.Current;
            enumerator.MoveNext();
            string destinationPath = enumerator.Current;
            return new ParsingResult.SuccessParsing(new FileMove(sourcePath, destinationPath));
        }

        return Next?.Handle(enumerator) ?? new ParsingResult.UnsuccessParsing("command can't be executed");
    }
}