using Itmo.ObjectOrientedProgramming.Lab4.ParserExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.InnerChain;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParsersEnumerator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.OuterChain;

public abstract class OuterChainLink
{
    protected OuterChainLink? NextOuterChainLink { get; private set; }

    protected InnerChainLink? NextInnerChainLink { get; private set; }

    public void AddNextOuterChain(OuterChainLink link)
    {
        if (NextOuterChainLink is null)
        {
            NextOuterChainLink = link;
            return;
        }

        NextOuterChainLink.AddNextOuterChain(link);
    }

    public void AddNextInnerChainLink(InnerChainLink link)
    {
        if (NextInnerChainLink is null)
        {
            NextInnerChainLink = link;
            return;
        }

        NextInnerChainLink.AddNextInnerChain(link);
    }

    public abstract ParsingResult Handle(ParserEnumerator enumerator);
}