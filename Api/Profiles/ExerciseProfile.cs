using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities.ExerciseEntities;

namespace Api.Profiles;

public class ExerciseProfile : Profile
{
    public ExerciseProfile()
    {
        CreateMap<CreateExerciseDTO, Exercise>();
        CreateMap<Exercise, ExerciseResponseDTO>();
    }
}