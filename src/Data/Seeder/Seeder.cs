using Dapper;
using Data.Contracts;
using Data.Entities;

namespace Data.Seeder;

public class Seeder
{
    private readonly IRepository _repository;

    public Seeder(IRepository repository)
    {
        _repository = repository;
    }

    public async Task Init()
    {
        try
        {
            using var transaction = _repository.PostgresConnection.BeginTransaction();

            var anyProfile = await _repository.GetAnyProfileExistsAsync(transaction);
            var anyList = await _repository.GetAnyListExistsAsync(transaction);
            var anyTask = await _repository.GetAnyTaskExistsAsync(transaction);

            if (anyProfile || anyList || anyTask)
            {
                return;
            }

            var profiles = GetProfileSeeder();

            var lists = GetListSeeder();

            var tasks = GetTaskSeeder();

            foreach (var profile in profiles)
            {
                await _repository.CreateProfileAsync(profile, transaction);
            }

            foreach (var list in lists)
            {
                await _repository.CreateListAsync(list, transaction);
            }

            foreach (var task in tasks)
            {
                await _repository.CreateTaskAsync(task, transaction);
            }

            transaction.Commit();
        }
        catch (Exception ex)
        {
            throw new Exception($"Seeder has failed, error: {ex.Message}");
        }
    }

    #region Helper

    private ProfileEntity BuildCryptedProfileEntity(string userName, string password)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

        var profile = new ProfileEntity()
        {
            UserName = userName,
            Password = passwordHash
        };

        return profile;
    }

    private List<ProfileEntity> GetProfileSeeder()
    {
        var user1 = BuildCryptedProfileEntity("ozturkfurkan1994@gmail.com", "12345");
        var user2 = BuildCryptedProfileEntity("testuser@hotmail.com", "password");

        return new() { user1, user2 };
    }

    private List<ListEntity> GetListSeeder()
    {
        var list1 = new ListEntity()
        {
            Title = "title1",
            Description = "desc1",
            Date = DateTime.Now,
            ProfileId = 1,
        };

        var list2 = new ListEntity()
        {
            Title = "title1",
            Description = "desc1",
            Date = DateTime.Now.AddMonths(1),
            ProfileId = 1,
        };

        var list3 = new ListEntity()
        {
            Title = "title1",
            Description = "desc1",
            Date = DateTime.Now,
            ProfileId = 2,
        };

        return new() { list1, list2, list3 };
    }

    private List<TaskEntity> GetTaskSeeder()
    {
        var task1 = new TaskEntity()
        {
            Title = "title1",
            Description = "desc1",
            Deadline = DateTime.Now,
            IsDone = true,
            ListId = 1
        };

        var task2 = new TaskEntity()
        {
            Title = "title1",
            Description = "desc1",
            Deadline = DateTime.Now.AddDays(1),
            IsDone = false,
            ListId = 1
        };

        var task3 = new TaskEntity()
        {
            Title = "title1",
            Description = "desc1",
            Deadline = DateTime.Now.AddMonths(1),
            IsDone = true,
            ListId = 1
        };

        var task4 = new TaskEntity()
        {
            Title = "title1",
            Description = "desc1",
            Deadline = DateTime.Now,
            IsDone = false,
            ListId = 2
        };

        var task5 = new TaskEntity()
        {
            Title = "title1",
            Description = "desc1",
            Deadline = DateTime.Now.AddMonths(1),
            IsDone = true,
            ListId = 2
        };

        var task6 = new TaskEntity()
        {
            Title = "title1",
            Description = "desc1",
            Deadline = DateTime.Now,
            IsDone = true,
            ListId = 3
        };

        return Enumerable.Repeat(new List<TaskEntity>() { task1, task2, task3, task4, task5, task6 }, 20).SelectMany(x => x).ToList();
    }

    #endregion
}
