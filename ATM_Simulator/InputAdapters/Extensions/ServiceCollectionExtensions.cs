using Core.InputPorts;
using Core.InputPorts.IScenarios;
using InputAdapters.Admin.AddUser;
using InputAdapters.Admin.Login;
using InputAdapters.Exi;
using InputAdapters.User.AddMoney;
using InputAdapters.User.CheckBalance;
using InputAdapters.User.CheckOperationHistory;
using InputAdapters.User.Login;
using InputAdapters.User.WithdrawMoney;
using Microsoft.Extensions.DependencyInjection;

namespace InputAdapters.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();

        collection.AddScoped<IScenarioProvider, AddUserScenarioProvder>();

        collection.AddScoped<IScenarioProvider, UserLoginScenarioProvider>();

        collection.AddScoped<IScenarioProvider, CheckBalanceScenarioProvider>();

        collection.AddScoped<IScenarioProvider, WithdrawMoneyScenarioProvider>();

        collection.AddScoped<IScenarioProvider, AddMoneyScenarioProvider>();

        collection.AddScoped<IScenarioProvider, CheckOperationHistoryScenarioProvider>();

        collection.AddScoped<IScenarioProvider, ExitScenarioProvider>();

        return collection;
    }
}