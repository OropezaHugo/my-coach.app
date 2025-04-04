using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.DietEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class FoodGroupProfile : Profile
{
    public FoodGroupProfile()
    {
        CreateMap<FoodGroup, FoodGroupResponseDTO>();
        CreateMap<CreateFoodGroupDTO, FoodGroup>();
        CreateMap<(CreateFoodGroupDTO, int), FoodGroup>()
            .ForMember(dest => dest.FoodGroupName, expression => expression.MapFrom(src => src.Item1.FoodGroupName))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
    }
}