using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.Entities.TrainingPlanEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class TrainingPlanProfile : Profile
{
    public TrainingPlanProfile()
    {
        CreateMap<TrainingPlan, TrainingPlanResponseDTO>();
        CreateMap<CreateTrainingPlanDTO, TrainingPlan>();
        CreateMap<(CreateTrainingPlanDTO, int), TrainingPlan>()
            .ForMember(dest => dest.Objective, expression => expression.MapFrom(src => src.Item1.Objective))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
        CreateMap<(TrainingPlan, UserTrainingPlans), UserTrainingPlanInfoDTO>()
            .ForMember(dest => dest.Objective, expression => expression.MapFrom(src => src.Item1.Objective))
            .ForMember(dest => dest.TrainingPlanId, expression => expression.MapFrom(src => src.Item1.Id))
            .ForMember(dest => dest.UserId, expression => expression.MapFrom(src => src.Item2.UserId))
            .ForMember(dest => dest.AssignedDate, expression => expression.MapFrom(src => src.Item2.AssignedDate))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2.Id));
    }
}