using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.ResponseDTOs;

namespace Api.Profiles;


public class PrizeProfile : Profile
{
    public PrizeProfile()
    {
        CreateMap<CreatePrizeDTO, Prize>();
        CreateMap<Prize, PrizeResponseDTO>();
        CreateMap< (CreatePrizeDTO, int), Prize>()
            .ForMember(dest => dest.Points, expression => expression.MapFrom(src => src.Item1.Points))
            .ForMember(dest => dest.PrizeName, expression => expression.MapFrom(src => src.Item1.PrizeName))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
    }
}
