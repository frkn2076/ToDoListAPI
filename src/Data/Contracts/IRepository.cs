using Data.Entities;
using System.Data;

namespace Data.Contracts;

public interface IRepository
{
    Task<Profile> GetProfileByUserNameAsync(string userName, IDbTransaction transaction = null);

    Task<Profile> CreateProfileAsync(Profile profile, IDbTransaction transaction = null);
}
