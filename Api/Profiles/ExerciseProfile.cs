using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.ExerciseEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class ExerciseProfile : Profile
{
    public ExerciseProfile()
    {
        CreateMap<CreateExerciseDTO, Exercise>();
        CreateMap<Exercise, ExerciseResponseDTO>();
        CreateMap< (CreateExerciseDTO, int), Exercise>()
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2))
            .ForMember(dest => dest.ExerciseName, expression => expression.MapFrom(src => src.Item1.ExerciseName));
    }
}