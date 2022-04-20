using Dapper;
using Data.Contracts;
using Data.Entities;
using Data.Utils;
using System.Data;

namespace Data.Implementations;

public class Repository : IRepository
{
    private readonly IConnectionService _connectionService;

    public IDbConnection PostgresConnection => _connectionService.GetPostgresConnection();

    public Repository(IConnectionService connectionService)
    {
        _connectionService = connectionService;
    }

    public async Task<Profile> GetProfileByUserNameAsync(string userName, IDbTransaction transaction = null)
    {
        return await PostgresConnection.QueryFirstOrDefaultAsync<Profile>(GetQuery(Queries.GetProfileByUserNameQuery), new { userName }, transaction: transaction);
    }

    public async Task<Profile> CreateProfileAsync(Profile profile, IDbTransaction transaction = null)
    {
        return await PostgresConnection.QueryFirstOrDefaultAsync<Profile>(GetQuery(Queries.CreateProfileQuery), profile, transaction: transaction);
    }

    #region Helper

    private string GetQuery(string queryFileName)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string path = Path.Combine(currentDirectory, Queries.AdhocFolderPath);
        string file = string.Concat(queryFileName, Queries.SqlFileExtension);
        return FileResourceUtility.LoadResource(path, file);
    }

    #endregion Helper
}
