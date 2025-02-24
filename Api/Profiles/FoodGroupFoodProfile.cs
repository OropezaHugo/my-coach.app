using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities.DietEntities;

namespace Api.Profiles;

public class FoodGroupFoodProfile : Profile
{
    public FoodGroupFoodProfile()
    {
        CreateMap<FoodGroupFood, FoodGroupFoodResponseDTO>();
        CreateMap<CreateFoodGroupFoodDTO, FoodGroupFood>();
    }
}