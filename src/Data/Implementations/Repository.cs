using Dapper;
using Data.Contracts;
using Data.Entities;
using Data.Utils;
using System.Data;
using System.Reflection;

namespace Data.Implementations;

public class Repository : IRepository
{
    private readonly IConnectionService _connectionService;

    public IDbConnection PostgresConnection => _connectionService.GetPostgresConnection();

    public Repository(IConnectionService connectionService)
    {
        _connectionService = connectionService;
    }

    public async Task<ProfileEntity> GetProfileByUserNameAsync(string userName, IDbTransaction transaction = null)
    {
        return await PostgresConnection.QueryFirstOrDefaultAsync<ProfileEntity>(GetQuery(Queries.GetProfileByUserNameQuery), new { userName }, transaction: transaction);
    }

    public async Task<ProfileEntity> CreateProfileAsync(ProfileEntity profile, IDbTransaction transaction = null)
    {
        return await PostgresConnection.QueryFirstOrDefaultAsync<ProfileEntity>(GetQuery(Queries.CreateProfileQuery), profile, transaction: transaction);
    }

    #region Helper

    private string GetQuery(string queryFileName)
    {
        string sqlFolderPath = Path.Combine(Queries.SqlFolder, Queries.AdhocFolder);
        string path = Path.Combine(AppContext.BaseDirectory, sqlFolderPath);
        string file = string.Concat(queryFileName, Queries.SqlFileExtension);
        return FileResourceUtility.LoadResource(path, file);
    }

    #endregion Helper
}
