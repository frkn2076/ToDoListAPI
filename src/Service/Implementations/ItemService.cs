﻿using Data;
using Data.Contracts;
using Data.Entities;
using Mapster;
using Service.Contracts;
using Service.Models;
using Service.Models.Requests;
using Service.Models.Responses;

namespace Service.Implementations;

public class ItemService : IItemService
{
    private readonly IRepository _repository;

    public ItemService(IRepository repository)
    {
        _repository = repository;
    }

    //public async Task<ServiceResponse<IEnumerable<string>>> GetListsOfUserAsync(int profileId, int skip, int count)
    //{
    //    var activities = await _repository.GetActivityAsync(count, skip);

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

    public async Task<ServiceResponse<ListResponseDTO>> CreateListAsync(ListRequestDTO model, int profileId)
    {
        ArgumentNullException.ThrowIfNull(model);

        var list = model.Adapt<ListEntity>();
        list.ProfileId = profileId;

        var createdList = await _repository.CreateListAsync(list);

        if (createdList == null)
        {
            return ServiceResponse<ListResponseDTO>.Failure(ErrorMessages.OperationHasFailed);
        }

        var response = createdList.Adapt<ListResponseDTO>();

        return ServiceResponse<ListResponseDTO>.Success(response);
    }

    public async Task<ServiceResponse> UpdateListAsync(ListRequestDTO model)
    {
        ArgumentNullException.ThrowIfNull(model);

        var list = model.Adapt<ListEntity>();

        var isSuccessful = await _repository.UpdateListAsync(list);

        if (!isSuccessful)
        {
            return ServiceResponse.Failure(ErrorMessages.OperationHasFailed);
        }

        return ServiceResponse.Success();
    }
}
