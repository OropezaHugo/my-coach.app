using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class RoleProfile: Profile
{
    public RoleProfile()
    {
        CreateMap<Role, RoleResponseDTO>();
        CreateMap<CreateRoleDTO, Role>();
        CreateMap<(CreateRoleDTO, int), Role>()
            .ForMember(dest => dest.RoleName, expression => expression.MapFrom(src => src.Item1.RoleName))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
    }
}