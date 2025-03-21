using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.GamificationEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AchievementController(
    IGenericRepository<Achievement> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AchievementResponseDTO>>> GetAchievements()
    {
        var items = await repository.ListAllAsync();
        return Ok(items.Select(item => mapper.Map<AchievementResponseDTO>(item)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AchievementResponseDTO>> GetAchievementById(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(mapper.Map<AchievementResponseDTO>(item));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostAchievement(CreateAchievementDTO dto)
    {
        var entity = mapper.Map<Achievement>(dto);
        repository.AddAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutAchievementById(int id, CreateAchievementDTO dto)
    {
        var entity = mapper.Map<Achievement>((dto, id));
        repository.UpdateAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteAchievementById(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        repository.DeleteAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
}