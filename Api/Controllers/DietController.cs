using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities.DietEntities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DietController
(
    IGenericRepository<Diet> repository,
    IMapper mapper
): ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DietResponseDTO>>> GetDiets()
    {
        var diets = await repository.ListAllAsync();
        return Ok(diets.Select(diet => mapper.Map<DietResponseDTO>(diet)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DietResponseDTO>> GetDietById(int id)
    {
        var diet = await repository.GetByIdAsync(id);
        if (diet == null) return NotFound();
        return Ok(mapper.Map<DietResponseDTO>(diet));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostDiet(CreateDietDTO dietDto)
    {
        var diet = mapper.Map<Diet>(dietDto);
        repository.AddAsync(diet);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutDietById(int id, CreateDietDTO dietDto)
    {
        var diet = mapper.Map<Diet>((dietDto, id));
        repository.AddAsync(diet);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteDietById(int id)
    {
        var diet = await repository.GetByIdAsync(id);
        if (diet == null) return NotFound();
        repository.DeleteAsync(diet);
        return Ok(await repository.SaveChangesAsync());
    }
}
