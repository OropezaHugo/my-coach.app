using Core.Entities;
using Core.Entities.DietEntities;
using Core.ResponseDTOs;

namespace Core.Interfaces;

public interface IDietRepository
{
    Task<IEnumerable<(Diet, UserDiet)>> GetDietsByUserId(int id);
    Task<DietContentResponseDTO?> GetDietContentByDietId(int dietId);
}