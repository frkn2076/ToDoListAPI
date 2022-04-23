using Data;
using Data.Contracts;
using Data.Entities;
using Service.Contracts;
using Service.Models;

namespace Service.Implementations;

public class ItemService : IItemService
{
    private readonly IRepository _repository;

    public ItemService(IRepository repository)
    {
        _repository = repository;
    }

    //public async Task<ServiceResponse<IEnumerable<Activity>>> GetListsOfUserAsync(int profileId, int skip, int count)
    //{
    //    var activities = await _socialRepository.GetActivityAsync(count, skip);

    //    if (activities == null || !activities.Any())
    //    {
    //        return new()
    //        {
    //            Error = ErrorMessages.NoRecordHasFound
    //        };
    //    }

    //    return new()
    //    {
    //        IsSuccessful = true,
    //        Response = activities
    //    };
    //}
}
