using Core.Entities;
using Core.Entities.DietEntities;

namespace Core.Interfaces;

public interface IDietRepository
{
    Task<List<(Diet, UserDiet)>> GetDietsByUserId(int id);
}