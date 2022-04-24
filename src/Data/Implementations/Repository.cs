using Dapper;
using Data.Contracts;
using Data.Entities;
using Data.Models;
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

    public async Task<ProfileEntity> GetProfileByUserNameAsync(string userName, IDbTransaction transaction = null)
    {
        return await PostgresConnection.QueryFirstOrDefaultAsync<ProfileEntity>(GetQuery(Queries.GetProfileByUserNameQuery), new { userName }, transaction: transaction);
    }

    public async Task<ProfileEntity> CreateProfileAsync(ProfileEntity profile, IDbTransaction transaction = null)
    {
        return await PostgresConnection.QueryFirstOrDefaultAsync<ProfileEntity>(GetQuery(Queries.CreateProfileQuery), profile, transaction: transaction);
    }

    public async Task<ListEntity> CreateListAsync(ListEntity list, IDbTransaction transaction = null)
    {
        return await PostgresConnection.QueryFirstOrDefaultAsync<ListEntity>(GetQuery(Queries.CreateListQuery), list, transaction: transaction);
    }

    public async Task<bool> UpdateListAsync(ListEntity list, IDbTransaction transaction = null)
    {
        var affectedRows = await PostgresConnection.ExecuteAsync(GetQuery(Queries.UpdateListQuery), list, transaction: transaction);
        return affectedRows > 0;
    }

    public async Task<bool> DeleteListAsync(int id, IDbTransaction transaction = null)
    {
        var affectedRows = await PostgresConnection.ExecuteAsync(GetQuery(Queries.DeleteListQuery), new { id }, transaction: transaction);
        return affectedRows > 0;
    }

    public async Task<TaskEntity> CreateTaskAsync(TaskEntity task, IDbTransaction transaction = null)
    {
        return await PostgresConnection.QueryFirstOrDefaultAsync<TaskEntity>(GetQuery(Queries.CreateTaskQuery), task, transaction: transaction);
    }

    public async Task<bool> UpdateTaskAsync(TaskEntity task, IDbTransaction transaction = null)
    {
        var affectedRows = await PostgresConnection.ExecuteAsync(GetQuery(Queries.UpdateTaskQuery), task, transaction: transaction);
        return affectedRows > 0;
    }

    public async Task<bool> DeleteTaskAsync(int id, IDbTransaction transaction = null)
    {
        var affectedRows = await PostgresConnection.ExecuteAsync(GetQuery(Queries.DeleteTaskQuery), new { id }, transaction: transaction);
        return affectedRows > 0;
    }

    public async Task<bool> UpdateTaskStatusAsync(bool isDone, int id, IDbTransaction transaction = null)
    {
        var affectedRows = await PostgresConnection.ExecuteAsync(GetQuery(Queries.UpdateTaskStatusQuery), new { isDone, id }, transaction: transaction);
        return affectedRows > 0;
    }

    public async Task<bool> UpdateUserTimeZoneAsync(int timeZone, int profileId, IDbTransaction transaction = null)
    {
        var affectedRows = await PostgresConnection.ExecuteAsync(GetQuery(Queries.UpdateUserTimeZoneQuery), new { timeZone, profileId }, transaction: transaction);
        return affectedRows > 0;
    }

    public async Task<IEnumerable<ListEntity>> GetListsOfUserAsync(ListPaginationFilter filter, IDbTransaction transaction = null)
    {
        return await PostgresConnection.QueryAsync<ListEntity>(GetQuery(Queries.GetListsByFilterQuery), filter, transaction: transaction);
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
