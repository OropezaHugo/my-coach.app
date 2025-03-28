using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.GamificationEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class AvatarProfile : Profile
{
    public AvatarProfile()
    {
        CreateMap<Avatar, AvatarResponseDTO>();
        CreateMap<CreateAvatarDTO, Avatar>();
        
        CreateMap<(CreateAvatarDTO dto, int id), Avatar>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.dto.AvatarUrl));
    }
}