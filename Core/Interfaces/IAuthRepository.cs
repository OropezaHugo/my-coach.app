using Core.Entities;

namespace Core.Interfaces;

public interface IAuthRepository
{
    Task<User?> GetUserByEmailWithRole(string email);
}