using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class UserPrizeProfile : Profile
{
    public UserPrizeProfile()
    {
        CreateMap<UserPrize, UserPrizeResponseDTO>();
        CreateMap<CreateUserPrizeDTO, UserPrize>();
        CreateMap< (CreateUserPrizeDTO, int), UserPrize>()
            .ForMember(dest => dest.UserId, expression => expression.MapFrom(src => src.Item1.UserId))
            .ForMember(dest => dest.PrizeId, expression => expression.MapFrom(src => src.Item1.PrizeId))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
        CreateMap< (UserPrize, Prize), UserPrizeInfoDTO>()
            .ForMember(dest => dest.UserId, expression => expression.MapFrom(src => src.Item1.UserId))
            .ForMember(dest => dest.PrizeId, expression => expression.MapFrom(src => src.Item1.PrizeId))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item1.Id))
            .ForMember(dest => dest.Points, expression => expression.MapFrom(src => src.Item2.Points))
            .ForMember(dest => dest.PrizeName, expression => expression.MapFrom(src => src.Item2.PrizeName));
    }
}