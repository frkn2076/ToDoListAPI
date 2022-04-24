using Data.Entities;
using Data.Models;
using System.Data;

namespace Data.Contracts;

public interface IRepository
{
    public IDbConnection PostgresConnection { get; }

    Task<ProfileEntity> GetProfileByUserNameAsync(string userName, IDbTransaction transaction = null);

    Task<ProfileEntity> CreateProfileAsync(ProfileEntity profile, IDbTransaction transaction = null);

    Task<ListEntity> CreateListAsync(ListEntity list, IDbTransaction transaction = null);

    Task<bool> UpdateListAsync(ListEntity list, IDbTransaction transaction = null);

    Task<bool> DeleteListAsync(int id, IDbTransaction transaction = null);

    Task<TaskEntity> CreateTaskAsync(TaskEntity task, IDbTransaction transaction = null);

    Task<bool> UpdateTaskAsync(TaskEntity task, IDbTransaction transaction = null);

    Task<bool> DeleteTaskAsync(int id, IDbTransaction transaction = null);

    Task<bool> UpdateTaskStatusAsync(bool isDone, int id, IDbTransaction transaction = null);

    Task<bool> UpdateUserTimeZoneAsync(int timeZone, int profileId, IDbTransaction transaction = null);

    Task<IEnumerable<ListEntity>> GetListsOfUserAsync(ListPaginationFilter filter, IDbTransaction transaction = null);

    Task<IEnumerable<TaskEntity>> GetTasksOfListAsync(TaskFilter filter, IDbTransaction transaction = null);

    Task<int?> GetTimeZoneByIdAsync(int profileId, IDbTransaction transaction = null);

    Task<bool> GetAnyListExistsAsync(IDbTransaction transaction = null);

    Task<bool> GetAnyProfileExistsAsync(IDbTransaction transaction = null);

    Task<bool> GetAnyTaskExistsAsync(IDbTransaction transaction = null);
}
