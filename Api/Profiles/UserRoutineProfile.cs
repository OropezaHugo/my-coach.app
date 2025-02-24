using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities;

namespace Api.Profiles;


public class UserRoutineProfile : Profile
{
    public UserRoutineProfile()
    {
        CreateMap<UserRoutine, UserRoutineResponseDTO>();
        CreateMap<CreateUserRoutineDTO, UserRoutine>();
    }
}
