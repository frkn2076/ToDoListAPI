using Api.Models.Requests;
using Mapster;
using Service.Models.Requests;

namespace Api.Mapper;

public class Mappers
{
    public static void Init()
    {
        TypeAdapterConfig<RegisterRequestModel, AuthenticationRequestDTO>.NewConfig();

        //TypeAdapterConfig<TokenDTOResponse, BaseResponse>.NewConfig();
        //.Map(dest => dest.AccessToken, src => src.AccessToken)
        //.Map(dest => dest.AccessTokenExpiresIn, src => src.AccessTokenExpiresIn)
        //.Map(dest => dest.RefreshToken, src => src.RefreshToken)
        //.Map(dest => dest.RefreshTokenExpiresIn, src => src.RefreshTokenExpiresIn);
    }
}