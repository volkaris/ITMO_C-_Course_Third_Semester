using Core.OutputPorts;
using Core.OutputPorts.UserStates;
using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace OutputAdapters;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User?> LogAsAdmin(string password)
    {
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

        NpgsqlCommand command = connection.CreateCommand();

        command.CommandText = """
                              select  id, password
                              from admins
                              where password = :password
                              """;

        command.Parameters.AddWithValue("password", password);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (reader.ReadAsync().IsCompletedSuccessfully is false)
            return null;

        return new User(
            reader.GetString(0),
            reader.GetString(1),
            new LoggedAsAdmin());
    }
}