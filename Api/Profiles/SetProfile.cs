using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.TrainingPlanEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;


public class SetProfile : Profile
{
    public SetProfile()
    {
        CreateMap<CreateSetDTO, Set>();
        CreateMap<Set, SetResponseDTO>();
        CreateMap< (CreateSetDTO, int), Set>()
            .ForMember(dest => dest.Repetitions, expression => expression.MapFrom(src => src.Item1.Repetitions))
            .ForMember(dest => dest.Weight, expression => expression.MapFrom(src => src.Item1.Weight))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
    }
}