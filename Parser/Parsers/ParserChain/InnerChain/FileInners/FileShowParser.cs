using Itmo.ObjectOrientedProgramming.Lab4.FilePrinters;
using Itmo.ObjectOrientedProgramming.Lab4.ParserExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParsersEnumerator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.InnerChain.FileInners;

public class FileShowParser : InnerChainLink
{
    private readonly IFilePrinter _printer;

    public FileShowParser(IFilePrinter printer)
    {
        _printer = printer;
    }

    public override ParsingResult Handle(ParserEnumerator enumerator)
    {
        enumerator.MoveNext();

        if (enumerator.Current == "show")
        {
            var builder = new FileShowArgumentsBuilder();

            builder.WithPrinter(_printer).WithPathInCommand(enumerator);

            while (enumerator.MoveNext())
            {
                if (enumerator.Current == "-m")
                    builder.WithMode(enumerator);
            }

            return builder.Build();
        }

        return Next?.Handle(enumerator) ?? new ParsingResult.UnsuccessParsing("command can't be executed");
    }
}