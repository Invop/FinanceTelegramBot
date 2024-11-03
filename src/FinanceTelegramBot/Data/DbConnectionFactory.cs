using System.Data;
using Microsoft.Data.Sqlite;

namespace FinanceTelegramBot.Data;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default);
}
public class SqliteConnectionFactory(string connectionString) : IDbConnectionFactory
{
    public async Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default)
    {
        var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync(token);
        return connection;
    }
}
