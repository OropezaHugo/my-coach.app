using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities.ExerciseEntities;

namespace Api.Profiles;


public class RoutineExerciseProfile : Profile
{
    public RoutineExerciseProfile()
    {
        CreateMap<RoutineExercise, RoutineExerciseResponseDTO>();
        CreateMap<CreateRoutineExerciseDTO, RoutineExercise>();
    }
}