using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class UserAchievementsProfile : Profile
{
    public UserAchievementsProfile()
    {
        CreateMap<UserAchievements, UserAchievementsResponseDTO>();
        CreateMap<CreateUserAchievementsDTO, UserAchievements>();
        CreateMap<(CreateUserAchievementsDTO dto, int id), UserAchievements>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.dto.UserId))
            .ForMember(dest => dest.AchievementId, opt => opt.MapFrom(src => src.dto.AchievementId))
            .ForMember(dest => dest.AchievementStepsProgress, opt => opt.MapFrom(src => src.dto.AchievementStepsProgress))
            .ForMember(dest => dest.AchievementActualLevel, opt => opt.MapFrom(src => src.dto.AchievementActualLevel));
    }
}