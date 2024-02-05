using Itmo.ObjectOrientedProgramming.Lab4.CommandExecutionResult;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
   CommandsExecutionResult ExecuteCommand(Context currentContext);
}