using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.DietEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DietController
(
    IGenericRepository<Diet> repository,
    IDietRepository dietRepository,
    IMapper mapper
): ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DietResponseDTO>>> GetDiets()
    {
        var diets = await repository.ListAllAsync();
        return Ok(diets.Select(diet => mapper.Map<DietResponseDTO>(diet)));
    }

    [HttpGet("names")]
    public async Task<ActionResult<IEnumerable<string>>> GetDietNames()
    {
        var spec = new DietNameListSpecification();
        var diets = await repository.ListAllAsync(spec);
        return Ok(diets);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<DietResponseDTO>> GetDietById(int id)
    {
        var diet = await repository.GetByIdAsync(id);
        if (diet == null) return NotFound();
        return Ok(mapper.Map<DietResponseDTO>(diet));
    }
    
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<UserDietInfoDTO>> GetDietsByUserId(int userId)
    {
        var diets = await dietRepository.GetDietsByUserId(userId);
        return Ok(diets.Select(diet => mapper.Map<UserDietInfoDTO>(diet)));
    }

    [HttpPost]
    public async Task<ActionResult<DietResponseDTO>> PostDiet(CreateDietDTO dietDto)
    {
        var diet = mapper.Map<Diet>(dietDto);
        var newDiet = repository.AddAsync(diet);
        await repository.SaveChangesAsync();
        return Ok(mapper.Map<DietResponseDTO>(newDiet));
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
