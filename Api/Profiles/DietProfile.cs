using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities.DietEntities;

namespace Api.Profiles;

public class DietProfile: Profile
{
    public DietProfile()
    {
        CreateMap<Diet, DietResponseDTO>();
        CreateMap<CreateDietDTO, Diet>();
        CreateMap<(CreateDietDTO, int), Diet>()
            .ForMember(dest => dest.DietName, expression => expression.MapFrom(src => src.Item1.DietName))
            .ForMember(dest => dest.WaterAmount, expression => expression.MapFrom(src => src.Item1.WaterAmount))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
    }
}