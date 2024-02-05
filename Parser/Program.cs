using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeComands.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.FilePrinters;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.ParserExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.InnerChain;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.InnerChain.FileInners;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.InnerChain.TreeInners;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserChain.OuterChain;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParsersEnumerator;

namespace Itmo.ObjectOrientedProgramming.Lab4;

// I didn't forget about Do/Don't about Main. It used to maintain console application.
public static class Program
{
    public static void Main()
    {
        string? currentPath = null;

        var currentContext = new Context(currentPath, new LocalFileSystem());

        OuterChainLink connectRequest = new ConnectParser();

        OuterChainLink disConnectRequest = new DisconnectParser();

        OuterChainLink fileRequest = new FileParser();

        InnerChainLink fileShow = new FileShowParser(new ConsoleFilePrinter());
        InnerChainLink fileCopy = new FileCopyParser();
        InnerChainLink fileDelete = new FileDeleteParser();
        InnerChainLink fileMove = new FileMoveParser();
        InnerChainLink fileRename = new FileRenameParser();

        fileRequest.AddNextInnerChainLink(fileShow);
        fileRequest.AddNextInnerChainLink(fileCopy);
        fileRequest.AddNextInnerChainLink(fileDelete);
        fileRequest.AddNextInnerChainLink(fileMove);
        fileRequest.AddNextInnerChainLink(fileRename);

        OuterChainLink treeRequest = new TreeParser();

        InnerChainLink treeList =
            new TreeListParser(
                new FileSystemVisitor(@"C:\Users\Ilya\Documents\GitHub\volkaris\src\Lab4\IndentConfig.txt"));
        InnerChainLink treeGoTo = new TreeGoToParser();

        treeRequest.AddNextInnerChainLink(treeList);
        treeRequest.AddNextInnerChainLink(treeGoTo);

        connectRequest.AddNextOuterChain(disConnectRequest);
        connectRequest.AddNextOuterChain(treeRequest);
        connectRequest.AddNextOuterChain(fileRequest);

        while (true)
        {
            var enumerator = new ParserEnumerator((Console.ReadLine() ?? string.Empty).Split(" "));

            ParsingResult parsingResult = connectRequest.Handle(enumerator);

            if (parsingResult is ParsingResult.SuccessParsing success)
            {
                CommandsExecutionResult commandExecutionResult =
                    success.Command.ExecuteCommand(currentContext);
                if (commandExecutionResult is CommandsExecutionResult.UnsuccessCommandExecution failedExecution)
                    Console.WriteLine(failedExecution.FailReason);
            }
            else if (parsingResult is ParsingResult.UnsuccessParsing fail)
            {
                Console.WriteLine(fail.FailReason);
            }
        }
    }
}