using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.DietEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class FoodProfile : Profile
{
    public FoodProfile()
    {
        CreateMap<Food, FoodResponseDTO>();
        CreateMap<CreateFoodDTO, Food>();
        CreateMap<(CreateFoodDTO, int), Food>()
            .ForMember(dest => dest.FoodName, expression => expression.MapFrom(src => src.Item1.FoodName))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
    }
}