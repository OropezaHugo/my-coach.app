using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.ExerciseEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;


public class RoutineExerciseProfile : Profile
{
    public RoutineExerciseProfile()
    {
        CreateMap<RoutineExercise, RoutineExerciseResponseDTO>();
        CreateMap<CreateRoutineExerciseDTO, RoutineExercise>();
        CreateMap< (CreateRoutineExerciseDTO, int), RoutineExercise>()
            .ForMember(dest => dest.Effort, expression => expression.MapFrom(src => src.Item1.Effort))
            .ForMember(dest => dest.ExerciseId, expression => expression.MapFrom(src => src.Item1.ExerciseId))
            .ForMember(dest => dest.RoutineId, expression => expression.MapFrom(src => src.Item1.RoutineId))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
    }
}