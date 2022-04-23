using Data.Entities;
using System.Data;

namespace Data.Contracts;

public interface IRepository
{
    Task<ProfileEntity> GetProfileByUserNameAsync(string userName, IDbTransaction transaction = null);

    Task<ProfileEntity> CreateProfileAsync(ProfileEntity profile, IDbTransaction transaction = null);
}
