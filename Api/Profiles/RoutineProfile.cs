using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities.ExerciseEntities;

namespace Api.Profiles;

public class RoutineProfile : Profile
{
    public RoutineProfile()
    {
        CreateMap<Routine, RoutineResponseDTO>();
        CreateMap<CreateRoutineDTO, Routine>();
        CreateMap<(CreateRoutineDTO, int), Routine>()
            .ForMember(dest => dest.RoutineName, expression => expression.MapFrom(src => src.Item1.RoutineName))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
    }
}