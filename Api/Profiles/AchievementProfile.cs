using Api.RequestDTOs;
using AutoMapper;
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
            .ForMember(dest => dest.AchievementImage, opt => opt.MapFrom(src => src.dto.AchievementImage))
            .ForMember(dest => dest.ObtainingDescription, opt => opt.MapFrom(src => src.dto.ObtainingDescription))
            .ForMember(dest => dest.AchievementStepsPerLevel, opt => opt.MapFrom(src => src.dto.AchievementStepsPerLevel));
    }
}