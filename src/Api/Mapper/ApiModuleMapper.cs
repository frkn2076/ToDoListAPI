using Api.Models.Requests;
using Data.Entities;
using Data.Models;
using Mapster;
using Service.Models.Requests;
using Service.Models.Responses;

namespace Api.Mapper;

public class ApiModuleMapper
{
    public static void Init()
    {
        #region Request To DTO

        TypeAdapterConfig<RegisterRequestModel, AuthenticationRequestDTO>.NewConfig();

        TypeAdapterConfig<ListRequestModel, ListRequestDTO>.NewConfig();

        TypeAdapterConfig<TaskRequestModel, TaskRequestDTO>.NewConfig();

        TypeAdapterConfig<ListPaginationFilterRequestModel, ListPaginationFilterRequestDTO>.NewConfig();

        #endregion

        #region DTO To Entity

        TypeAdapterConfig<ListRequestDTO, ListEntity>.NewConfig();

        TypeAdapterConfig<TaskRequestDTO, TaskEntity>.NewConfig();

        TypeAdapterConfig<ListPaginationFilterRequestDTO, ListPaginationFilter>.NewConfig();

        #endregion

        #region Entity To DTO

        TypeAdapterConfig<ListEntity, ListResponseDTO>.NewConfig();

        TypeAdapterConfig<TaskEntity, TaskResponseDTO>.NewConfig();

        #endregion
    }
}