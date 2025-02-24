using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities;

namespace Api.Profiles;

public class UserDietProfile : Profile
{
    public UserDietProfile()
    {
        CreateMap<UserDiet, UserDietResponseDTO>();
        CreateMap<CreateUserDietDTO, UserDiet>();
    }
}