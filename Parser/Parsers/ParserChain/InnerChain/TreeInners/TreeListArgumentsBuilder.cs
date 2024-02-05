using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeComands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeComands.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.ParserExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParsersEnumerator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.InnerChain.TreeInners;

public class TreeListArgumentsBuilder
{
    private int? _depth = 1;
    private IVisitor? _visitor;

    public TreeListArgumentsBuilder WithVisitor(IVisitor visitor)
    {
        _visitor = visitor;
        return this;
    }

    public TreeListArgumentsBuilder WithDepth(ParserEnumerator enumerator)
    {
        enumerator.MoveNext();

        if (int.TryParse(enumerator.Current, out int possibleDepth))
            _depth = possibleDepth;
        else
            _depth = null;

        return this;
    }

    public ParsingResult Build()
    {
        if (_visitor is null) return new ParsingResult.UnsuccessParsing("Why you did this? For what reason?");
        if (_depth is null) return new ParsingResult.UnsuccessParsing("Can't parce number in tree list command");

        return new ParsingResult.SuccessParsing(new TreeList(_visitor, _depth.Value));
    }
}