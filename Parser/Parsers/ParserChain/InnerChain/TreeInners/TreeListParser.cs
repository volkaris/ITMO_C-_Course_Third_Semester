using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeComands.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.ParserExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParsersEnumerator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.InnerChain.TreeInners;

public class TreeListParser : InnerChainLink
{
    private readonly IVisitor _visitor;

    public TreeListParser(IVisitor visitor)
    {
        _visitor = visitor;
    }

    public override ParsingResult Handle(ParserEnumerator enumerator)
    {
        enumerator.MoveNext();

        if (enumerator.Current == "list")
        {
            var result = new TreeListArgumentsBuilder();

            while (enumerator.MoveNext())
            {
                if (enumerator.Current == "-d")
                    result.WithDepth(enumerator);
            }

            return result.WithVisitor(_visitor).Build();
        }

        return Next?.Handle(enumerator) ?? new ParsingResult.UnsuccessParsing("command can't be executed");
    }
}