using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserAchievementController(
    IGenericRepository<UserAchievements> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserAchievementsResponseDTO>>> GetUserAchievements()
    {
        var items = await repository.ListAllAsync();
        return Ok(items.Select(item => mapper.Map<UserAchievementsResponseDTO>(item)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserAchievementsResponseDTO>> GetUserAchievementById(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(mapper.Map<UserAchievementsResponseDTO>(item));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostUserAchievement(CreateUserAchievementsDTO dto)
    {
        var entity = mapper.Map<UserAchievements>(dto);
        repository.AddAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutUserAchievementById(int id, CreateUserAchievementsDTO dto)
    {
        var entity = mapper.Map<UserAchievements>((dto, id));
        repository.UpdateAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteUserAchievementById(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        repository.DeleteAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
}