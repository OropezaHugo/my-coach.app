using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.TrainingPlanEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class ExerciseSetProfile : Profile
{
    public ExerciseSetProfile()
    {
        CreateMap<ExerciseSet, ExerciseSetResponseDTO>();
        CreateMap<CreateExerciseSetDTO, ExerciseSet>();
        CreateMap< (CreateExerciseSetDTO, int), ExerciseSet>()
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2))
            .ForMember(dest => dest.Fatigue, expression => expression.MapFrom(src => src.Item1.Fatigue))
            .ForMember(dest => dest.ExerciseId, expression => expression.MapFrom(src => src.Item1.ExerciseId))
            .ForMember(dest => dest.SetId, expression => expression.MapFrom(src => src.Item1.SetId));
    }
}
