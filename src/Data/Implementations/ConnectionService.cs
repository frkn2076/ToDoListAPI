using Data.Contracts;
using Data.Utils.Models;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace Data.Implementations;

public class ConnectionService : IConnectionService
{
    private readonly ConnectionStrings _connectionStrings;
    private IDbConnection _dbConnection;

    public ConnectionService(IOptions<ConnectionStrings> connectionStrings)
    {
        _connectionStrings = connectionStrings.Value;
    }

    public IDbConnection GetPostgresConnection()
    {
        if (_dbConnection != null && _dbConnection.State == ConnectionState.Open)
        {
            return _dbConnection;
        }

        _dbConnection = new NpgsqlConnection(_connectionStrings.PostgresContext);
        _dbConnection.Open();
        return _dbConnection;
    }

    public void CloseConnection()
    {
        if (_dbConnection != null && _dbConnection.State == ConnectionState.Open)
        {
            _dbConnection.Close();
        }
    }
}
