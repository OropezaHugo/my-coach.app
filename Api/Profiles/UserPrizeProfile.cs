using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities;

namespace Api.Profiles;

public class UserPrizeProfile : Profile
{
    public UserPrizeProfile()
    {
        CreateMap<UserPrize, UserPrizeResponseDTO>();
        CreateMap<CreateUserPrizeDTO, UserPrize>();
    }
}