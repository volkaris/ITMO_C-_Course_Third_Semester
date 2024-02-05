using Itmo.ObjectOrientedProgramming.Lab4.ParserExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParsersEnumerator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.InnerChain;

public abstract class InnerChainLink
{
    protected InnerChainLink? Next { get; private set; }

    public void AddNextInnerChain(InnerChainLink link)
    {
        if (Next is null)
        {
            Next = link;
            return;
        }

        Next.AddNextInnerChain(link);
    }

    public abstract ParsingResult Handle(ParserEnumerator enumerator);
}