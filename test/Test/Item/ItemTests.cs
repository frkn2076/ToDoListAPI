using Data;
using Moq;
using NUnit.Framework;
using Service.Models.Requests;
using System;
using System.Threading.Tasks;

namespace Test.Item;

public class ItemTests
{
    [Test]
    public async Task CreateListAsync_Throws_Exception_If_Input_Is_Null()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupItemService();

        Assert.ThrowsAsync<ArgumentNullException>(() => builder.ItemService.CreateListAsync(null, 1));
    }

    [Test]
    public async Task CreateListAsync_Returns_OperationHasFailed_If_Creation_Fails()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupItemService();

        var response = await builder.ItemService.CreateListAsync(new ListRequestDTO(), 0);

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.OperationHasFailed, response.Error);
    }

    [Test]
    public async Task CreateListAsync_Returns_OperationHasFailed_If_List_Created_Successfully()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupCreateListAsync();
        builder.SetupItemService();

        var response = await builder.ItemService.CreateListAsync(new ListRequestDTO(), 0);

        Assert.IsTrue(response.IsSuccessful);
    }

    [Test]
    public async Task UpdateListAsync_Throws_Exception_If_Input_Is_Null()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupItemService();

        Assert.ThrowsAsync<ArgumentNullException>(() => builder.ItemService.UpdateListAsync(null));
    }

    [Test]
    public async Task UpdateListAsync_Returns_OperationHasFailed_If_Update_Fails()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupItemService();

        var response = await builder.ItemService.UpdateListAsync(new ListRequestDTO());

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.OperationHasFailed, response.Error);
    }

    [Test]
    public async Task UpdateListAsync_Returns_Success_If_Update_Successfully()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupUpdateListAsync();
        builder.SetupItemService();

        var response = await builder.ItemService.UpdateListAsync(new ListRequestDTO());

        Assert.IsTrue(response.IsSuccessful);
    }

    [Test]
    public async Task DeleteListAsync_Returns_OperationHasFailed_If_Delete_Fails()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupItemService();

        var response = await builder.ItemService.DeleteListAsync(1);

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.OperationHasFailed, response.Error);
    }

    [Test]
    public async Task DeleteListAsync_Returns_Success_If_Delete_Successfully()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupDeleteListAsync();
        builder.SetupItemService();

        var response = await builder.ItemService.DeleteListAsync(1);

        Assert.IsTrue(response.IsSuccessful);
    }

    [Test]
    public async Task CreateTaskAsync_Throws_Exception_If_Input_Is_Null()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupItemService();

        Assert.ThrowsAsync<ArgumentNullException>(() => builder.ItemService.CreateTaskAsync(null));
    }

    [Test]
    public async Task CreateTaskAsync_Returns_OperationHasFailed_If_Creation_Fails()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupItemService();

        var response = await builder.ItemService.CreateTaskAsync(new TaskRequestDTO());

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.OperationHasFailed, response.Error);
    }

    [Test]
    public async Task CreateTaskAsync_Returns_OperationHasFailed_If_Task_Created_Successfully()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupCreateTaskAsync();
        builder.SetupItemService();

        var response = await builder.ItemService.CreateTaskAsync(new TaskRequestDTO());

        Assert.IsTrue(response.IsSuccessful);
    }

    [Test]
    public async Task UpdateTaskAsync_Throws_Exception_If_Input_Is_Null()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupItemService();

        Assert.ThrowsAsync<ArgumentNullException>(() => builder.ItemService.UpdateTaskAsync(null));
    }

    [Test]
    public async Task UpdateTaskAsync_Returns_OperationHasFailed_If_Update_Fails()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupItemService();

        var response = await builder.ItemService.UpdateTaskAsync(new TaskRequestDTO());

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.OperationHasFailed, response.Error);
    }

    [Test]
    public async Task UpdateTaskAsync_Returns_Success_If_Update_Successfully()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupUpdateTaskAsync();
        builder.SetupItemService();

        var response = await builder.ItemService.UpdateTaskAsync(new TaskRequestDTO());

        Assert.IsTrue(response.IsSuccessful);
    }

    [Test]
    public async Task DeleteTaskAsync_Returns_OperationHasFailed_If_Delete_Fails()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupItemService();

        var response = await builder.ItemService.DeleteTaskAsync(1);

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.OperationHasFailed, response.Error);
    }

    [Test]
    public async Task DeleteTaskAsync_Returns_Success_If_Delete_Successfully()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupDeleteTaskAsync();
        builder.SetupItemService();

        var response = await builder.ItemService.DeleteTaskAsync(1);

        Assert.IsTrue(response.IsSuccessful);
    }

    [Test]
    public async Task UpdateTaskStatusAsync_Returns_OperationHasFailed_If_Update_Fails()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupItemService();

        var response = await builder.ItemService.UpdateTaskStatusAsync(true, 1);

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.OperationHasFailed, response.Error);
    }

    [Test]
    public async Task UpdateTaskStatusAsync_Returns_Success_If_Update_Successfully()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupUpdateTaskStatusAsync();
        builder.SetupItemService();

        var response = await builder.ItemService.UpdateTaskStatusAsync(true, 1);

        Assert.IsTrue(response.IsSuccessful);
    }
    

    [Test]
    public async Task UpdateUserTimeZoneAsync_Returns_OperationHasFailed_If_Update_Fails()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupItemService();

        var response = await builder.ItemService.UpdateUserTimeZoneAsync(1, 1);

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.OperationHasFailed, response.Error);
    }

    [Test]
    public async Task UpdateUserTimeZoneAsync_Returns_Success_If_Update_Successfully()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupUpdateUserTimeZoneAsync();
        builder.SetupItemService();

        var response = await builder.ItemService.UpdateUserTimeZoneAsync(1, 1);

        Assert.IsTrue(response.IsSuccessful);
    }

    [Test]
    public async Task GetListsOfUserAsync_Throws_Exception_If_Input_Is_Null()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupItemService();

        Assert.ThrowsAsync<ArgumentNullException>(() => builder.ItemService.GetListsOfUserAsync(null, 1));
    }

    [Test]
    public async Task GetListsOfUserAsync_Returns_OperationHasFailed_If_No_Record_Returns()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupItemService();

        var response = await builder.ItemService.GetListsOfUserAsync(new ListPaginationFilterRequestDTO(), 1);

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.NoRecordHasFound, response.Error);
    }

    [Test]
    public async Task GetListsOfUserAsync_Returns_Success_If_Records_Found()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupGetListsOfUserAsync();
        builder.SetupGetTimeZoneByIdAsync();
        builder.SetupItemService();

        var response = await builder.ItemService.GetListsOfUserAsync(new ListPaginationFilterRequestDTO(), 1);

        Assert.IsTrue(response.IsSuccessful);
    }

    [Test]
    public async Task GetTasksOfListAsync_Throws_Exception_If_Input_Is_Null()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupItemService();

        Assert.ThrowsAsync<ArgumentNullException>(() => builder.ItemService.GetTasksOfListAsync(null, 1));
    }

    [Test]
    public async Task GetTasksOfListAsync_Returns_NoRecordHasFound_If_No_Tasks_Found()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupItemService();

        var response = await builder.ItemService.GetTasksOfListAsync(new TaskFilterRequestDTO(), 1);

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.NoRecordHasFound, response.Error);
    }

    [Test]
    public async Task GetTasksOfListAsync_Returns_Success_If_Records_Found()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupGetTasksOfListAsync();
        builder.SetupGetTimeZoneByIdAsync();
        builder.SetupItemService();

        var response = await builder.ItemService.GetTasksOfListAsync(new TaskFilterRequestDTO(), 1);

        Assert.IsTrue(response.IsSuccessful);
    }
}
