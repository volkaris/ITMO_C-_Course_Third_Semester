using Core.OutputPorts;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Microsoft.Extensions.DependencyInjection;

namespace OutputAdapters.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        collection.AddScoped<IAdminRepository, AdminRepository>();

        collection.AddScoped<IUserRepository, UserRepository>();

        return collection;
    }
}