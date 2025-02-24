using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities.DietEntities;

namespace Api.Profiles;

public class DietFoodGroupProfile : Profile
{
    public DietFoodGroupProfile()
    {
        CreateMap<DietFoodGroup, DietFoodGroupResponseDTO>();
        CreateMap<CreateDietFoodGroupDTO, DietFoodGroup>();
    }
}