using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.Entities.ExerciseEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;


public class UserRoutineProfile : Profile
{
    public UserRoutineProfile()
    {
        CreateMap<UserRoutine, UserRoutineResponseDTO>();
        CreateMap<CreateUserRoutineDTO, UserRoutine>();
        CreateMap< (CreateUserRoutineDTO, int), UserRoutine>()
            .ForMember(dest => dest.UserId, expression => expression.MapFrom(src => src.Item1.UserId))
            .ForMember(dest => dest.RoutineId, expression => expression.MapFrom(src => src.Item1.RoutineId))
            .ForMember(dest => dest.TargetDate, expression => expression.MapFrom(src => src.Item1.TargetDate))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
        CreateMap<(Routine, UserRoutine), UserRoutineInfoDTO>()
            .ForMember(dest => dest.UserId, expression => expression.MapFrom(src => src.Item2.UserId))
            .ForMember(dest => dest.RoutineId, expression => expression.MapFrom(src => src.Item1.Id))
            .ForMember(dest => dest.TargetDate, expression => expression.MapFrom(src => src.Item2.TargetDate))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2.Id))
            .ForMember(dest => dest.RoutineName, expression => expression.MapFrom(src => src.Item1.RoutineName));
            
    }
}
