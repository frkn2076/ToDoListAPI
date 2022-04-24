using Api.Models.Requests;
using Data.Entities;
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

        //TypeAdapterConfig<TokenDTOResponse, BaseResponse>.NewConfig();
        //.Map(dest => dest.AccessToken, src => src.AccessToken)
        //.Map(dest => dest.AccessTokenExpiresIn, src => src.AccessTokenExpiresIn)
        //.Map(dest => dest.RefreshToken, src => src.RefreshToken)
        //.Map(dest => dest.RefreshTokenExpiresIn, src => src.RefreshTokenExpiresIn);

        #endregion

        #region DTO To Entity

        TypeAdapterConfig<ListRequestDTO, ListEntity>.NewConfig();

        TypeAdapterConfig<TaskRequestDTO, TaskEntity>.NewConfig();

        #endregion

        #region Entity To DTO

        TypeAdapterConfig<ListEntity, ListResponseDTO>.NewConfig();

        TypeAdapterConfig<TaskEntity, TaskResponseDTO>.NewConfig();

        #endregion
    }
}