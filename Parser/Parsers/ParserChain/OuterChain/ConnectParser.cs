using Itmo.ObjectOrientedProgramming.Lab4.ParserExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParsersEnumerator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.OuterChain;

public class ConnectParser : OuterChainLink
{
    public override ParsingResult Handle(ParserEnumerator enumerator)
    {
        enumerator.MoveNext();
        if (enumerator.Current == "connect")
        {
            var builder = new ConnectBuilder();

            builder.WithPathInCommand(enumerator);

            while (enumerator.MoveNext())
            {
                if (enumerator.Current == "-m")
                    builder.WithMode(enumerator);
            }

            return builder.Build();
        }

        return NextOuterChainLink?.Handle(enumerator) ??
               new ParsingResult.UnsuccessParsing("command can't be executed");
    }
}