using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.Entities.TrainingPlanEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;


public class TrainingPlanRoutineProfile : Profile
{
    public TrainingPlanRoutineProfile()
    {
        CreateMap<TrainingPlanRoutines, TrainingPlanRoutineResponseDTO>();
                CreateMap<CreateTrainingPlanRoutineDTO, TrainingPlanRoutines>();
                CreateMap<(CreateTrainingPlanRoutineDTO, int), TrainingPlanRoutines>()
                    .ForMember(dest => dest.TrainingPlanId, expression => expression.MapFrom(src => src.Item1.TrainingPlanId))
                    .ForMember(dest => dest.RoutineId, expression => expression.MapFrom(src => src.Item1.RoutineId))
                    .ForMember(dest => dest.RoutineWeekDay, expression => expression.MapFrom(src => src.Item1.RoutineWeekDay))
                    .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
    }
}
