using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.Entities.DietEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class UserDietProfile : Profile
{
    public UserDietProfile()
    {
        CreateMap<UserDiet, UserDietResponseDTO>();
        CreateMap<CreateUserDietDTO, UserDiet>();
        CreateMap< (CreateUserDietDTO, int), UserDiet>()
            .ForMember(dest => dest.DietId, expression => expression.MapFrom(src => src.Item1.DietId))
            .ForMember(dest => dest.UserId, expression => expression.MapFrom(src => src.Item1.UserId))
            .ForMember(dest => dest.AssignedDate, expression => expression.MapFrom(src => src.Item1.AssignedDate))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
        CreateMap< (Diet, UserDiet), UserDietInfoDTO>()
            .ForMember(dest => dest.DietId, expression => expression.MapFrom(src => src.Item1.Id))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2.Id))
            .ForMember(dest => dest.UserId, expression => expression.MapFrom(src => src.Item2.UserId))
            .ForMember(dest => dest.AssignedDate, expression => expression.MapFrom(src => src.Item2.AssignedDate))
            .ForMember(dest => dest.DietName, expression => expression.MapFrom(src => src.Item1.DietName))
            .ForMember(dest => dest.WaterAmount, expression => expression.MapFrom(src => src.Item1.WaterAmount));
    }
}