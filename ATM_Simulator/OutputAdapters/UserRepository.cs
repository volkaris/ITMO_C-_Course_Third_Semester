using System.Globalization;
using System.Text;
using Core.CurrentUserServices;
using Core.OutputPorts;
using Core.OutputPorts.OperationType;
using Core.OutputPorts.UserStates;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace OutputAdapters;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;
    private readonly ICurrentUserService _currentUser;

    public UserRepository(IPostgresConnectionProvider connectionProvider, ICurrentUserService currentUser)
    {
        _currentUser = currentUser;
        _connectionProvider = connectionProvider;
    }

    public async Task<bool> AddBankUser(string id, string password)
    {
        try
        {
            NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = """INSERT INTO users  ("Id", password)  values (:id ,:password)""";

            command.Parameters.AddWithValue("Id", id);

            command.Parameters.AddWithValue("password", password);

            await command.ExecuteReaderAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<User?> LogAsUser(string id, string password)
    {
        try
        {
            NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = """
                                  select  "Id",password
                                  from users
                                  where   "Id"=:id and  password = :password
                                  """;

            command.Parameters.AddWithValue("Id", id);

            command.Parameters.AddWithValue("password", password);

            await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync() is false)
                return null;

            return new User(
                reader.GetString(0),
                reader.GetString(1),
                new LoggedAsUser());
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<long?> CheckBalance()
    {
        try
        {
            NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = """
                                  select  amount_of_money
                                  from users
                                  where   "Id"=:id and  password = :password
                                  """;

            command.Parameters.AddWithValue("id", _currentUser.User?.Id ?? string.Empty);

            command.Parameters.AddWithValue("password", _currentUser.User?.Password ?? string.Empty);

            await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync() is false)
                return null;

            return reader.GetInt32(0);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<bool> ChangeBalance(long value, IOperationType operationType)
    {
        const string updateMoneyQuery = """
                                        update users
                                        set amount_of_money= :Amount_of_money
                                        where "Id" = :id
                                        """;

        const string historyQuery = """
                                             INSERT INTO operation_history  ("user_id",operation_type,date,remaining_amount_of_money )  values (:id ,:operationType,:date,:moneyAmount)
                                    """;
        try
        {
            NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

            NpgsqlCommand updateMoneyCommand = connection.CreateCommand();

            updateMoneyCommand.CommandText = updateMoneyQuery;

            updateMoneyCommand.AddParameter("Id", _currentUser.User?.Id)
                .AddParameter("Amount_of_money", value);

            await using NpgsqlDataReader updateMoneyReader = await updateMoneyCommand.ExecuteReaderAsync();

            await updateMoneyReader.CloseAsync();

            NpgsqlCommand insertIntoHistroyCommand = connection.CreateCommand();

            insertIntoHistroyCommand.CommandText = historyQuery;

            insertIntoHistroyCommand.AddParameter("id", _currentUser.User?.Id)
                .AddParameter("operationType", operationType.ToString())
                .AddParameter("date", DateTime.Now.ToString(CultureInfo.InvariantCulture))
                .AddParameter("moneyAmount", value);

            await insertIntoHistroyCommand.ExecuteReaderAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<string?> CheckOperationHistory()
    {
        const string getHistoryQuery = """
                                       select user_id, operation_type, date, remaining_amount_of_money
                                       from operation_history
                                       where "user_id" = :id
                                       """;
        try
        {
            NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = getHistoryQuery;

            command.Parameters.AddWithValue("Id", _currentUser.User?.Id ?? string.Empty);

            await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                var tableBuilder = new StringBuilder();

                tableBuilder.AppendLine("| User ID | Operation Type |            Date            | Remaining Amount |");
                tableBuilder.AppendLine("|---------|-----------------|---------------------|-------------------|");

                while (await reader.ReadAsync())
                {
                    string userId = reader.GetString(reader.GetOrdinal("user_id"));
                    string operationType = reader.GetString(reader.GetOrdinal("operation_type"));
                    string date = reader.GetString(reader.GetOrdinal("date"));
                    int remainingAmount = reader.GetInt32(reader.GetOrdinal("remaining_amount_of_money"));

                    tableBuilder.AppendLine(
                        CultureInfo.InvariantCulture,
                        $"| {userId,-8} | {operationType,-15} | {date,-20:yyyy-MM-dd HH:mm:ss} | {remainingAmount,-17} |");
                }

                return tableBuilder.ToString();
            }

            return null;
        }
        catch
        {
            return null;
        }
    }
}