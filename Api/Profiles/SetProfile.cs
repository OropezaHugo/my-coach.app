using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities.ExerciseEntities;

namespace Api.Profiles;


public class SetProfile : Profile
{
    public SetProfile()
    {
        CreateMap<CreateSetDTO, Set>();
        CreateMap<Set, SetResponseDTO>();
    }
}