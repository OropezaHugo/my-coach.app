using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.Entities.GamificationEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class AchievementProfile : Profile
{
    public AchievementProfile()
    {
        CreateMap<Achievement, AchievementResponseDTO>();
        CreateMap<CreateAchievementDTO, Achievement>();
        CreateMap<(CreateAchievementDTO dto, int id), Achievement>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.AchievementName, opt => opt.MapFrom(src => src.dto.AchievementName))
            .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.dto.ExerciseId))
            .ForMember(dest => dest.AchievementImage, opt => opt.MapFrom(src => src.dto.AchievementImage))
            .ForMember(dest => dest.ObtainingDescription, opt => opt.MapFrom(src => src.dto.ObtainingDescription))
            .ForMember(dest => dest.AchievementStepsPerLevel, opt => opt.MapFrom(src => src.dto.AchievementStepsPerLevel));
        CreateMap<(UserAchievements ua, Achievement ac), UserAchievementContentDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ua.Id))
            .ForMember(dest => dest.AchievementName, opt => opt.MapFrom(src => src.ac.AchievementName))
            .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.ac.ExerciseId))
            .ForMember(dest => dest.AchievementImage, opt => opt.MapFrom(src => src.ac.AchievementImage))
            .ForMember(dest => dest.AchievementType, opt => opt.MapFrom(src => src.ac.AchievementType))
            .ForMember(dest => dest.ObtainingDescription, opt => opt.MapFrom(src => src.ac.ObtainingDescription))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.ua.UserId))
            .ForMember(dest => dest.AchievementId, opt => opt.MapFrom(src => src.ua.AchievementId))
            .ForMember(dest => dest.AchievementStepsProgress, opt => opt.MapFrom(src => src.ua.AchievementStepsProgress))
            .ForMember(dest => dest.AchievementActualLevel, opt => opt.MapFrom(src => src.ua.AchievementActualLevel))
            .ForMember(dest => dest.IsBadge, opt => opt.MapFrom(src => src.ua.IsBadge))
            .ForMember(dest => dest.AchievementStepsPerLevel, opt => opt.MapFrom(src => src.ac.AchievementStepsPerLevel));
    }
}