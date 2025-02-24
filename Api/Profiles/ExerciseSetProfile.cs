using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities.ExerciseEntities;

namespace Api.Profiles;

public class ExerciseSetProfile : Profile
{
    public ExerciseSetProfile()
    {
        CreateMap<ExerciseSet, ExerciseSetResponseDTO>();
        CreateMap<CreateExerciseSetDTO, ExerciseSet>();
    }
}
