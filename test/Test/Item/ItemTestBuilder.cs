using Data.Contracts;
using Data.Entities;
using Data.Models;
using Moq;
using Service.Contracts;
using Service.Implementations;
using System.Collections.Generic;
using System.Data;

namespace Test.Item;

public class ItemTestBuilder
{
    public static ItemTestBuilder Create() => new();

    public IItemService ItemService;
    private Mock<IRepository> _repository { get; set; } = new Mock<IRepository>();

    public void SetupItemService()
    {
        ItemService = new ItemService(_repository.Object);
    }

    public void SetupGetProfileByUserNameAsync(string username, string password)
    {
        var profile = new ProfileEntity()
        {
            UserName = username,
            Password = password
        };

        _repository.Setup(x => x.GetProfileByUserNameAsync(It.IsAny<string>(), It.IsAny<IDbTransaction>())).ReturnsAsync(profile);
    }

    public void SetupCreateListAsync()
    {
        _repository.Setup(x => x.CreateListAsync(It.IsAny<ListEntity>(), It.IsAny<IDbTransaction>())).ReturnsAsync(new ListEntity());
    }

    public void SetupUpdateListAsync()
    {
        _repository.Setup(x => x.UpdateListAsync(It.IsAny<ListEntity>(), It.IsAny<IDbTransaction>())).ReturnsAsync(true);
    }

    public void SetupDeleteListAsync()
    {
        _repository.Setup(x => x.DeleteListAsync(It.IsAny<int>(), It.IsAny<IDbTransaction>())).ReturnsAsync(true);
    }

    public void SetupCreateTaskAsync()
    {
        _repository.Setup(x => x.CreateTaskAsync(It.IsAny<TaskEntity>(), It.IsAny<IDbTransaction>())).ReturnsAsync(new TaskEntity());
    }

    public void SetupUpdateTaskAsync()
    {
        _repository.Setup(x => x.UpdateTaskAsync(It.IsAny<TaskEntity>(), It.IsAny<IDbTransaction>())).ReturnsAsync(true);
    }

    public void SetupDeleteTaskAsync()
    {
        _repository.Setup(x => x.DeleteTaskAsync(It.IsAny<int>(), It.IsAny<IDbTransaction>())).ReturnsAsync(true);
    }

    public void SetupUpdateTaskStatusAsync()
    {
        _repository.Setup(x => x.UpdateTaskStatusAsync(It.IsAny<bool>(), It.IsAny<int>(), It.IsAny<IDbTransaction>())).ReturnsAsync(true);
    }

    public void SetupUpdateUserTimeZoneAsync()
    {
        _repository.Setup(x => x.UpdateUserTimeZoneAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IDbTransaction>())).ReturnsAsync(true);
    }

    public void SetupGetListsOfUserAsync()
    {
        _repository.Setup(x => x.GetListsOfUserAsync(It.IsAny<ListPaginationFilter>(), It.IsAny<IDbTransaction>()))
            .ReturnsAsync(new List<ListEntity>() { new ListEntity() } );
    }

    public void SetupGetTasksOfListAsync()
    {
        _repository.Setup(x => x.GetTasksOfListAsync(It.IsAny<TaskFilter>(), It.IsAny<IDbTransaction>()))
            .ReturnsAsync(new List<TaskEntity>() { new TaskEntity() } );
    }

    public void SetupGetTimeZoneByIdAsync()
    {
        _repository.Setup(x => x.GetTimeZoneByIdAsync(It.IsAny<int>(), It.IsAny<IDbTransaction>())).ReturnsAsync(1);
    }
}
