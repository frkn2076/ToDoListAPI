using Data.Entities;
using Mapster;
using Service.Models.Requests;
using Service.Models.Responses;

namespace Service.Mapper;

public class ServiceModuleMapper
{
    public static void Init()
    {
        #region DTO To Entity

        TypeAdapterConfig<ListRequestDTO, ListEntity>.NewConfig();

        //TypeAdapterConfig<RegisterRequestModel, AuthenticationRequestDTO>.NewConfig();

        //TypeAdapterConfig<TokenDTOResponse, BaseResponse>.NewConfig();
        //.Map(dest => dest.AccessToken, src => src.AccessToken)
        //.Map(dest => dest.AccessTokenExpiresIn, src => src.AccessTokenExpiresIn)
        //.Map(dest => dest.RefreshToken, src => src.RefreshToken)
        //.Map(dest => dest.RefreshTokenExpiresIn, src => src.RefreshTokenExpiresIn);

        #endregion

        #region Entity To DTO

        TypeAdapterConfig<ListEntity, ListResponseDTO>.NewConfig();

        #endregion
    }
}