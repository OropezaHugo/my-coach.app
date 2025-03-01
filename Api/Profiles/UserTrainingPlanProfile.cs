using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.ResponseDTOs;

namespace Api.Profiles;


public class UserTrainingPlanProfile : Profile
{
    public UserTrainingPlanProfile()
    {
        CreateMap<UserTrainingPlans, UserTrainingPlanResponseDTO>();
        CreateMap<CreateUserTrainingPlanDTO, UserTrainingPlans>();
        CreateMap<(CreateUserTrainingPlanDTO, int), UserTrainingPlans>()
            .ForMember(dest => dest.UserId, expression => expression.MapFrom(src => src.Item1.UserId))
            .ForMember(dest => dest.TrainingPlanId, expression => expression.MapFrom(src => src.Item1.TrainingPlanId))
            .ForMember(dest => dest.AssignedDate, expression => expression.MapFrom(src => src.Item1.AssignedDate))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
    }
}