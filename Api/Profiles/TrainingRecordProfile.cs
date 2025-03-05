using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.ResponseDTOs;

namespace Api.Profiles;

public class TrainingRecordProfile : Profile
{
    public TrainingRecordProfile()
    {
        CreateMap<TrainingRecord, TrainingRecordResponseDTO>();
        CreateMap<CreateTrainingRecordDTO, TrainingRecord>();
        CreateMap<(CreateTrainingRecordDTO, int), TrainingRecord>()
            .ForMember(dest => dest.WeightLifted, expression => expression.MapFrom(src => src.Item1.WeightLifted))
            .ForMember(dest => dest.RepetitionsMade, expression => expression.MapFrom(src => src.Item1.RepetitionsMade))
            .ForMember(dest => dest.RecordDate, expression => expression.MapFrom(src => src.Item1.RecordDate))
            .ForMember(dest => dest.UserId, expression => expression.MapFrom(src => src.Item1.UserId))
            .ForMember(dest => dest.ExerciseId, expression => expression.MapFrom(src => src.Item1.ExerciseId))
            .ForMember(dest => dest.Id, expression => expression.MapFrom(src => src.Item2));
    }
}