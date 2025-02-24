using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities;

namespace Api.Profiles;


public class PrizeProfile : Profile
{
    public PrizeProfile()
    {
        CreateMap<CreatePrizeDTO, Prize>();
        CreateMap<Prize, PrizeResponseDTO>();
    }
}
