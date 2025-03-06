using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.DietEntities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class FoodProfile : Profile
{
    public FoodProfile()
    {
        CreateMap<Food, FoodResponseDTO>();
        CreateMap<CreateFoodDTO, Food>();
        CreateMap<(CreateFoodDTO, int), Food>()
            .ForMember(dest => dest.FoodGroup, expression => expression.MapFrom(src => src.Item1.FoodGroup))
            .ForMember(dest => dest.FoodSubGroup, expression => expression.MapFrom(src => src.Item1.FoodSubGroup))
            .ForMember(dest => dest.FoodVitaminB3Mg, expression => expression.MapFrom(src => src.Item1.FoodVitaminB3Mg))
            .ForMember(dest => dest.FoodAshGr, expression => expression.MapFrom(src => src.Item1.FoodAshGr))
            .ForMember(dest => dest.FoodCalciumGr, expression => expression.MapFrom(src => src.Item1.FoodCalciumGr))
            .ForMember(dest => dest.FoodCarbsGr, expression => expression.MapFrom(src => src.Item1.FoodCarbsGr))
            .ForMember(dest => dest.FoodEnergyKcal, expression => expression.MapFrom(src => src.Item1.FoodEnergyKcal))
            .ForMember(dest => dest.FoodFatGr, expression => expression.MapFrom(src => src.Item1.FoodFatGr))
            .ForMember(dest => dest.FoodFibberGr, expression => expression.MapFrom(src => src.Item1.FoodFibberGr))
            .ForMember(dest => dest.FoodVitaminAMig, expression => expression.MapFrom(src => src.Item1.FoodVitaminAMig))
            .ForMember(dest => dest.FoodVitaminB1Mg, expression => expression.MapFrom(src => src.Item1.FoodVitaminB1Mg))
            .ForMember(dest => dest.FoodVitaminB2Mg, expression => expression.MapFrom(src => src.Item1.FoodVitaminB2Mg))
            .ForMember(dest => dest.FoodVitaminCMg, expression => expression.MapFrom(src => src.Item1.FoodVitaminCMg))
            .ForMember(dest => dest.FoodIronMg, expression => expression.MapFrom(src => src.Item1.FoodIronMg))
            .ForMember(dest => dest.FoodPhosphorusMg, expression => expression.MapFrom(src => src.Item1.FoodPhosphorusMg))
            .ForMember(dest => dest.FoodProteinGr, expression => expression.MapFrom(src => src.Item1.FoodProteinGr))
            .ForMember(dest => dest.FoodName, expression => expression.MapFrom(src => src.Item1.FoodName))
            .ForMember(dest => dest.FoodHumidityGr, expression => expression.MapFrom(src => src.Item1.FoodHumidityGr))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
    }
}