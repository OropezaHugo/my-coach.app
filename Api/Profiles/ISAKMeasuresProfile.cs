using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class ISAKMeasuresProfile : Profile
{
    public ISAKMeasuresProfile()
    {
        // Mapeo de ISAKMeasures a ISAKMeasuresResponseDTO
        CreateMap<ISAKMeasures, ISAKMeasuresResponseDTO>();

        // Mapeo de CreateISAKMeasuresDTO a ISAKMeasures
        CreateMap<CreateISAKMeasuresDTO, ISAKMeasures>();

        // Mapeo para actualización: (CreateISAKMeasuresDTO, int) -> ISAKMeasures
        CreateMap<(CreateISAKMeasuresDTO dto, int id), ISAKMeasures>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.TricepsMm, opt => opt.MapFrom(src => src.dto.TricepsMm))
            .ForMember(dest => dest.SubscapularMm, opt => opt.MapFrom(src => src.dto.SubscapularMm))
            .ForMember(dest => dest.BicepsMm, opt => opt.MapFrom(src => src.dto.BicepsMm))
            .ForMember(dest => dest.IliacCrestMm, opt => opt.MapFrom(src => src.dto.IliacCrestMm))
            .ForMember(dest => dest.SupraespinalMm, opt => opt.MapFrom(src => src.dto.SupraespinalMm))
            .ForMember(dest => dest.AbdominalMm, opt => opt.MapFrom(src => src.dto.AbdominalMm))
            .ForMember(dest => dest.FrontThighMm, opt => opt.MapFrom(src => src.dto.FrontThighMm))
            .ForMember(dest => dest.MedialCalfMm, opt => opt.MapFrom(src => src.dto.MedialCalfMm))
            .ForMember(dest => dest.RelaxedArmCm, opt => opt.MapFrom(src => src.dto.RelaxedArmCm))
            .ForMember(dest => dest.FlexedArmCm, opt => opt.MapFrom(src => src.dto.FlexedArmCm))
            .ForMember(dest => dest.WaistCm, opt => opt.MapFrom(src => src.dto.WaistCm))
            .ForMember(dest => dest.HipCm, opt => opt.MapFrom(src => src.dto.HipCm))
            .ForMember(dest => dest.MidThighCm, opt => opt.MapFrom(src => src.dto.MidThighCm))
            .ForMember(dest => dest.CalfCm, opt => opt.MapFrom(src => src.dto.CalfCm))
            .ForMember(dest => dest.WristDiameterCm, opt => opt.MapFrom(src => src.dto.WristDiameterCm))
            .ForMember(dest => dest.ElbowDiameterCm, opt => opt.MapFrom(src => src.dto.ElbowDiameterCm))
            .ForMember(dest => dest.KneeDiameterCm, opt => opt.MapFrom(src => src.dto.KneeDiameterCm))
            .ForMember(dest => dest.WeightKg, opt => opt.MapFrom(src => src.dto.WeightKg))
            .ForMember(dest => dest.TotalHeightMts, opt => opt.MapFrom(src => src.dto.TotalHeightMts))
            .ForMember(dest => dest.WingspanCm, opt => opt.MapFrom(src => src.dto.WingspanCm))
            .ForMember(dest => dest.FootLengthCm, opt => opt.MapFrom(src => src.dto.FootLengthCm))
            .ForMember(dest => dest.MeasureDate, opt => opt.MapFrom(src => src.dto.MeasureDate))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.dto.UserId));
    }
}