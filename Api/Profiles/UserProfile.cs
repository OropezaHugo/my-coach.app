using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.ResponseDTOs;

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
            .ForMember(dest => dest.Endpoint, expression => expression.MapFrom(src => src.Item1.Endpoint))
            .ForMember(dest => dest.P256dh, expression => expression.MapFrom(src => src.Item1.P256dh))
            .ForMember(dest => dest.Auth, expression => expression.MapFrom(src => src.Item1.Auth))
            .ForMember(dest => dest.RoleId, expression => expression.MapFrom(src => src.Item1.RoleId))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
    }
}