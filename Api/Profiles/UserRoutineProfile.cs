using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
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
    }
}
