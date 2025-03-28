using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.Entities.GamificationEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap< User, UserResponseDTO>()
            .ForMember(dest => dest.Birthday, expression => expression.MapFrom(src => src.Birthday))
            .ForMember(dest => dest.Email, expression => expression.MapFrom(src => src.Email))
            .ForMember(dest => dest.Name, expression => expression.MapFrom(src => src.Name))
            .ForMember(dest => dest.RoleId, expression => expression.MapFrom(src => src.RoleId))
            .ForMember(dest => dest.AvatarId, expression => expression.MapFrom(src => src.RoleId))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Id))
            .ForMember(dest => dest.AvatarUrl, expression => expression.MapFrom(src => src.Avatar.AvatarUrl));
        CreateMap<CreateUserDTO, User>();
        CreateMap<(CreateUserDTO, int), User>()
            .ForMember(dest => dest.Birthday, expression => expression.MapFrom(src => src.Item1.Birthday))
            .ForMember(dest => dest.Email, expression => expression.MapFrom(src => src.Item1.Email))
            .ForMember(dest => dest.Name, expression => expression.MapFrom(src => src.Item1.Name))
            .ForMember(dest => dest.RoleId, expression => expression.MapFrom(src => src.Item1.RoleId))
            .ForMember(dest => dest.AvatarId, expression => expression.MapFrom(src => src.Item1.AvatarId))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
    }
}