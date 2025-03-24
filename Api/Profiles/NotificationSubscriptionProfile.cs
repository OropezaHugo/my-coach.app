using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.GamificationEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class NotificationSubscriptionProfile : Profile
{
    public NotificationSubscriptionProfile()
    {
        CreateMap<NotificationSubscription, NotificationSubscriptionResponseDTO>();
        CreateMap<CreateNotificationSubscriptionDTO, NotificationSubscription>();
        
        CreateMap<(CreateNotificationSubscriptionDTO dto, int id), NotificationSubscription>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Endpoint, opt => opt.MapFrom(src => src.dto.Endpoint))
            .ForMember(dest => dest.P256dh, opt => opt.MapFrom(src => src.dto.P256dh))
            .ForMember(dest => dest.Auth, opt => opt.MapFrom(src => src.dto.Auth))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.dto.UserId));
    }
}