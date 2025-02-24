using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities;

namespace Api.Profiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<User, UserResponseDTO>();
        CreateMap<CreateUserDTO, User>();
        CreateMap<(CreateUserDTO, int), User>()
            .ForMember(dest => dest.Birthday, expression => expression.MapFrom(src => src.Item1.Birthday))
            .ForMember(dest => dest.Email, expression => expression.MapFrom(src => src.Item1.Email))
            .ForMember(dest => dest.Name, expression => expression.MapFrom(src => src.Item1.Name))
            .ForMember(dest => dest.AvatarUrl, expression => expression.MapFrom(src => src.Item1.AvatarUrl))
            .ForMember(dest => dest.Password, expression => expression.MapFrom(src => src.Item1.Password))
            .ForMember(dest => dest.RoleId, expression => expression.MapFrom(src => src.Item1.RoleId))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
    }
}