using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.DietEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class DietFoodGroupProfile : Profile
{
    public DietFoodGroupProfile()
    {
        CreateMap<DietFoodGroup, DietFoodGroupResponseDTO>();
        CreateMap<CreateDietFoodGroupDTO, DietFoodGroup>();
        CreateMap< (CreateDietFoodGroupDTO, int), DietFoodGroup>()
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2))
            .ForMember(dest => dest.DietId, expression => expression.MapFrom(src => src.Item1.DietId))
            .ForMember(dest => dest.FoodGroupId, expression => expression.MapFrom(src => src.Item1.FoodGroupId))
            .ForMember(dest => dest.FoodGroupTime, expression => expression.MapFrom(src => src.Item1.FoodGroupTime));
    }
}