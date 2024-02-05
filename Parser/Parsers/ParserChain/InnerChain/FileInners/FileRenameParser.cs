using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.ParserExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParsersEnumerator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.InnerChain.FileInners;

public class FileRenameParser : InnerChainLink
{
    public override ParsingResult Handle(ParserEnumerator enumerator)
    {
        if (enumerator.Current == "rename")
        {
            enumerator.MoveNext();
            string path = enumerator.Current;

            enumerator.MoveNext();
            string newFileName = enumerator.Current;

            return new ParsingResult.SuccessParsing(new FileRename(path, newFileName));
        }

        return Next?.Handle(enumerator) ?? new ParsingResult.UnsuccessParsing("command can't be executed");
    }
}