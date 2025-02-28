using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.DietEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class FoodGroupFoodProfile : Profile
{
    public FoodGroupFoodProfile()
    {
        CreateMap<FoodGroupFood, FoodGroupFoodResponseDTO>();
        CreateMap<CreateFoodGroupFoodDTO, FoodGroupFood>();
        CreateMap< (CreateFoodGroupFoodDTO, int), FoodGroupFood>()
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2))
            .ForMember(dest => dest.FoodId, expression => expression.MapFrom(src => src.Item1.FoodId))
            .ForMember(dest => dest.FoodAmount, expression => expression.MapFrom(src => src.Item1.FoodAmount))
            .ForMember(dest => dest.FoodGroupId, expression => expression.MapFrom(src => src.Item1.FoodGroupId));
    }
}