using Data.Entities;
using System.Data;

namespace Data.Contracts;

public interface IRepository
{
    Task<ProfileEntity> GetProfileByUserNameAsync(string userName, IDbTransaction transaction = null);

    Task<ProfileEntity> CreateProfileAsync(ProfileEntity profile, IDbTransaction transaction = null);

    Task<ListEntity> CreateListAsync(ListEntity list, IDbTransaction transaction = null);

    Task<bool> UpdateListAsync(ListEntity list, IDbTransaction transaction = null);

    Task<bool> DeleteListAsync(int id, IDbTransaction transaction = null);

    Task<TaskEntity> CreateTaskAsync(TaskEntity task, IDbTransaction transaction = null);

    Task<bool> UpdateTaskAsync(TaskEntity task, IDbTransaction transaction = null);

    Task<bool> DeleteTaskAsync(int id, IDbTransaction transaction = null);
}
